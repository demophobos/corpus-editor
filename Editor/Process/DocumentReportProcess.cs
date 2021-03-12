using Model;
using Model.Enum;
using Model.Query;
using Model.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process
{
    public class DocumentReportProcess
    {
        private DocumentProcess _documentProcess;

        private List<ChunkViewModel> _chunks;

        private List<InterpModel> _interps;
        public DocumentReportProcess(DocumentProcess documentProcess) {
            _documentProcess = documentProcess;
        }
        public async Task<List<ChunkStatusModel>> GetChunkStatusReport()
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

            var statusItems = _chunks.OrderBy(i => i.IndexOrder)
                .Select(i => CreateStatusModel(i))
                .OrderByDescending(i => i.ResolvedItems)
                .OrderByDescending(i => i.UnresolvedItems);

            return statusItems.ToList();
        }

        private ChunkStatusModel CreateStatusModel(ChunkViewModel chunk)
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

            return new ChunkStatusModel
            {
                Id = chunk.Id,
                IndexId = chunk.IndexId,
                IndexName = chunk.IndexName,
                ChunkText = chunk.Value,
                ResolvedItems = resolvedItems,
                UnresolvedItems = unresolvedItems,
                Languages = lang,
                HasVersion = hasVersion
            };
        }
    }
}
