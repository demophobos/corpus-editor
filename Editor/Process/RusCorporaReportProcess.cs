using Model;
using Model.Enum;
using Model.Query;
using Model.View;
using Newtonsoft.Json;
using Process.Helper;
using Process.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Process
{
    public class RusCorporaReportProcess
    {
        DocumentProcess _documentProcess;
        public RusCorporaReportProcess(DocumentProcess documentProcess)
        {
            _documentProcess = documentProcess;
        }

        private int pairCount;
        private async Task<string> CreateSingleChunkReport(ChunkViewModel chunk)
        {
            var interpViews = await GetInterps(chunk);

            if (interpViews.Count == 0)
            {
                throw new Exception("Переводы отсутствуют");
            }

            return CreateRLNCRow(interpViews, pairCount = 0);
        }

        private async Task<List<InterpViewModel>> GetInterps(ChunkViewModel chunk)
        {
            var query = new InterpViewQuery();

            if (chunk.HeaderEditionType == EditionTypeStringEnum.Original)
            {
                query.SourceId = chunk.Id;

            }
            else
            {
                query.InterpId = chunk.Id;
            }

            var interpViews = await _documentProcess.GetInterpsByQueryView(query).ConfigureAwait(true);

            return interpViews;
        }

        private async Task CreateRLNCRows(IndexModel parentIndex, StringBuilder sb)
        {
            var childIndeces = _documentProcess.Indeces.Where(i => i.ParentId == parentIndex.Id).OrderBy(i => i.Order);

            foreach (var childIndex in childIndeces)
            {
                var childChunk = await ChunkProcess.GetChunkByQuery(new ChunkQuery { IndexId = childIndex.Id }).ConfigureAwait(true);

                if (childChunk != null)
                {
                    var interpViews = await GetInterps(childChunk).ConfigureAwait(true);

                    sb.Append(CreateRLNCRow(interpViews, pairCount += 1));
                }

                await CreateRLNCRows(childIndex, sb).ConfigureAwait(true);
            }
        }

        private string CreateRLNCRow(List<InterpViewModel> interpretations, int pairCount)
        {
            var sb = new StringBuilder();

            sb.Append($"<para id=\"{pairCount}\">");

            sb.Append(FormatTextToRLNC(interpretations));

            sb.Append($"</para>");

            return sb.ToString();
        }

        public async Task<string> CreateTextExport()
        {
            var sb = new StringBuilder();

            var topIndeces = _documentProcess.Indeces.Where(i => i.ParentId == null).OrderBy(i => i.Order).ToList();

            sb.Append(CreateHeader());

            foreach (var index in topIndeces)
            {
                var singleChunkReport = string.Empty;

                var parentChunk = await ChunkProcess.GetChunkByQuery(new ChunkQuery { IndexId = index.Id });

                if (parentChunk != null)
                {
                    singleChunkReport = await CreateSingleChunkReport(parentChunk).ConfigureAwait(true);
                }

                sb.Append(singleChunkReport);

                await CreateRLNCRows(index, sb).ConfigureAwait(true);
            }

            sb.Append(CreateFooter());

            return sb.ToString();
        }

        public async Task<string> CreateIndexExport(IndexModel index, bool includeChildren)
        {
            var sb = new StringBuilder();

            var singleChunkReport = string.Empty;

            var parentChunk = await ChunkProcess.GetChunkByQuery(new ChunkQuery { IndexId = index.Id });

            if (parentChunk != null)
            {
                singleChunkReport = await CreateSingleChunkReport(parentChunk).ConfigureAwait(true);
            }

            if (!includeChildren)
            {
                sb.Append($"{CreateHeader()}{singleChunkReport}{CreateFooter()}");
            }
            else
            {

                sb.Append(CreateHeader());

                sb.Append(singleChunkReport);

                await CreateRLNCRows(index, sb).ConfigureAwait(true);

                sb.Append(CreateFooter());
            }

            return sb.ToString();
        }

        #region Helper Methods
        private string FormatTextToRLNC(List<InterpViewModel> interpretations)
        {
            var sb = new StringBuilder();

            var elements = JsonConvert.DeserializeObject<List<ChunkValueItemModel>>(interpretations[0].SourceValueObj);

            sb.Append($"<se lang=\"{RusCorporaMapper.ConvertLang(interpretations[0].SourceHeaderLang)}\" variant_id=\"0\">");

            foreach (var element in elements)
            {
                if (!string.IsNullOrWhiteSpace(element.Value) && !Regex.IsMatch(element.Value, Resources.PunctuationPattern))
                {
                    string grammar = GetGrammarInfoToRLNC(element);

                    sb.Append($"<w>{grammar}{element.Value}</w>");
                }
                else
                {
                    sb.Append(element.Value);
                }
            }

            sb.AppendLine($" [{interpretations[0].SourceHeaderCode}, {interpretations[0].SourceIndexName}]</se>");

            sb.AppendLine($"<se lang=\"{RusCorporaMapper.ConvertLang(interpretations[0].InterpHeaderLang)}\" variant_id=\"1\">{interpretations[0].InterpValue} [{interpretations[0].InterpHeaderCode}, {interpretations[0].InterpIndexName}]</se>");

            return sb.ToString();
        }

        private static string GetGrammarInfoToRLNC(ChunkValueItemModel chunkValueItem)
        {
            var gsb = new StringBuilder();

            gsb.Append($"<ana lex=\"{chunkValueItem.Lemma}\" gr=\"{RusCorporaMapper.ConvertPos(chunkValueItem)}\"/>");

            return gsb.ToString();
        }

        private static string CreateFooter()
        {
            var sb = new StringBuilder();

            sb.Append("</body>");

            sb.Append("</html>");

            return sb.ToString();
        }

        private static string CreateHeader()
        {
            var sb = new StringBuilder();

            sb.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");

            sb.Append("<html>");

            sb.Append($"<head></head>");

            sb.Append("<body>");

            return sb.ToString();
        }
        #endregion
    }
}
