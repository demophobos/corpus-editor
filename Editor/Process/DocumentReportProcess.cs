using Model;
using Model.Enum;
using Model.Query;
using Model.Report;
using Model.View;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Process
{
    public class DocumentReportProcess
    {
        private DocumentProcess _documentProcess;

        private List<IndexModel> _indeces;

        private List<ChunkViewModel> _chunks;

        private List<ChunkViewModel> _interpChunks;

        private List<InterpModel> _interps;

        private List<ChunkIndexedReportModel> _fullTextReportResult;

        public DocumentReportProcess(DocumentProcess documentProcess)
        {
            _documentProcess = documentProcess;
        }
        public async Task<List<ChunkReportModel>> GetChunkWithoutTranslationReport()
        {
            var statusItems = await GetStatusItems().ConfigureAwait(true);

            return statusItems.Where(i => i.HasVersion == false).Select(i => new ChunkReportModel { IndexName = i.IndexName, Value = i.Value }).ToList();
        }

        public async Task<List<ChunkStatusReportModel>> GetChunkWithUndefinedWordReport()
        {
            var statusItems = await GetStatusItems().ConfigureAwait(true);

            return statusItems.Where(i => i.UnresolvedItems > 0).OrderByDescending(i => i.UnresolvedItems).ToList();
        }

        private async Task<List<ChunkStatusReportModel>> GetStatusItems()
        {
            _chunks = await _documentProcess.GetChunksByHeader().ConfigureAwait(true);

            var interpQuery = new InterpTableQuery();

            if (_documentProcess.Header.EditionType == EditionTypeStringEnum.Original)
            {
                interpQuery.SourceHeaderId = _documentProcess.Header.Id;
            }
            else
            {
                interpQuery.InterpHeaderId = _documentProcess.Header.Id;
            }

            _interps = await _documentProcess.GetInterpsByQueryTable(interpQuery).ConfigureAwait(true);

            return _chunks.Select(i => CreateStatusModel(i)).ToList();
        }

        private ChunkStatusReportModel CreateStatusModel(ChunkViewModel chunk)
        {
            var publishedElements = JsonConvert.DeserializeObject<ChunkValueItemModel[]>(chunk.ValueObj).Where(i => i.Type == (int)ElementTypeEnum.Word);

            var resolvedItems = publishedElements.Count(j => j.MorphId != null);

            var unresolvedItems = publishedElements.Count(j => j.MorphId == null);

            var languages = publishedElements.Where(i => !string.IsNullOrEmpty(i.Lang)).Select(i => i.Lang).Distinct();

            var lang = languages.Count() > 0 ? string.Join(", ", languages) : string.Empty;

            var hasVersion = false;

            if (_documentProcess.Header.EditionType == EditionTypeStringEnum.Original)
            {
                hasVersion = _interps.Any(i => i.SourceId == chunk.Id);
            }
            else
            {
                hasVersion = _interps.Any(i => i.InterpId == chunk.Id);
            }

            return new ChunkStatusReportModel
            {
                IndexName = chunk.IndexName,
                Value = chunk.Value,
                ResolvedItems = resolvedItems,
                UnresolvedItems = unresolvedItems,
                Languages = lang,
                HasVersion = hasVersion
            };
        }

        public async Task<List<PosReportModel>> GetPosStatisticsReport()
        {
            var result = new List<PosReportModel>();

            var chunks = await _documentProcess.GetChunksByHeader().ConfigureAwait(true);

            var values = new List<ChunkValueItemModel>();

            foreach (var chunk in chunks)
            {
                var items = JsonConvert.DeserializeObject<List<ChunkValueItemModel>>(chunk.ValueObj).Where(i => i.Type == (int)ElementTypeEnum.Word && i.MorphId != null);

                if (items.Count() > 0)
                {
                    values.AddRange(items);
                }
            }

            result = values.GroupBy(i => i.Pos).Select(i => new PosReportModel { Name = i.Key, Count = i.Count() }).ToList().OrderByDescending(i => i.Count).ToList();

            return result;
        }

        public async Task<List<ChunkStatusReportModel>> GetReadinessStatisticsReport()
        {
            return await GetStatusItems().ConfigureAwait(true);
        }

        public async Task<List<ChunkIndexedReportModel>> GetParallelTextReport(List<HeaderModel> headers)
        {
            _fullTextReportResult = new List<ChunkIndexedReportModel>();

            _interpChunks = new List<ChunkViewModel>();

            var origHeader = headers.FirstOrDefault(i => i.EditionType == EditionTypeStringEnum.Original);

            _indeces = await _documentProcess.GetIndecesByHeader(origHeader.Id).ConfigureAwait(true);

            _chunks = await _documentProcess.GetChunksByHeader(origHeader).ConfigureAwait(true);

            foreach (var interpHeader in headers.Where(i => i.EditionType == EditionTypeStringEnum.Interpretation))
            {
                var interps = await _documentProcess.GetChunksByHeader(interpHeader).ConfigureAwait(true);
                _interpChunks.AddRange(interps);
            }

            foreach (var topIndex in _indeces.Where(i => i.ParentId == null).OrderBy(j => j.Order))
            {
                CreateTextItem(topIndex);

                CreateTextItems(topIndex.Id);
            }


            return _fullTextReportResult;
        }

        public async Task<List<ChunkIndexedReportModel>> GetTextReport()
        {
            _fullTextReportResult = new List<ChunkIndexedReportModel>();

            _chunks = await _documentProcess.GetChunksByHeader().ConfigureAwait(true);

            _indeces = _documentProcess.Indeces;

            foreach (var topIndex in _indeces.Where(i => i.ParentId == null).OrderBy(j => j.Order))
            {
                CreateTextItem(topIndex);

                CreateTextItems(topIndex.Id);
            }
            return _fullTextReportResult;
        }

        private void CreateTextItems(string parentId)
        {
            var childerenTexts = _indeces.Where(i => i.ParentId == parentId).OrderBy(j => j.Order);

            foreach (var child in childerenTexts)
            {
                CreateTextItem(child);

                CreateTextItems(child.Id);
            }
        }

        private void CreateTextItem(IndexModel index)
        {
            var chunk = _chunks.FirstOrDefault(i => i.IndexId == index.Id);

            var fullTextItem = new ChunkIndexedReportModel
            {
                IndexId = index.Id,
                IndexName = index.Name,
                ChunkId = chunk?.Id,
                ChunkValue = chunk?.Value
            };

            _fullTextReportResult.Add(fullTextItem);

            if (_interpChunks != null)
            {
                foreach (var interp in _interpChunks.Where(i => i.IndexName == index.Name))
                {
                    var interpItem = new ChunkIndexedReportModel
                    {
                        ChunkId = interp.Id,
                        ChunkValue = interp.Value
                    };
                    _fullTextReportResult.Add(interpItem);
                }
            }
        }
    }
}
