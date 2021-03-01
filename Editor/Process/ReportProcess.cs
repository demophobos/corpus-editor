using API;
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
    public class ReportProcess
    {
        DocumentProcess _documentProcess;
        public ReportProcess(DocumentProcess documentProcess)
        {
            _documentProcess = documentProcess;
        }
        #region RLNC
        private int pairCount;
        public async Task<string> CreateRusCorporaChunkReport(IndexModel index, ChunkModel chunk, List<InterpViewModel> interpretations, List<InterpViewModel> originals)
        {
            pairCount = 0;

            var sb = new StringBuilder();

            sb.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");

            sb.Append("<html>");

            sb.Append($"<head></head>");

            sb.Append("<body>");

            CreateRLNCRow(sb, chunk, index, interpretations, originals);

            await CreateRLNCRows(index.Id, sb, index, interpretations, originals);

            sb.Append("</body>");

            sb.Append("</html>");

            return sb.ToString();
        }

        private async Task CreateRLNCRows(string indexId, StringBuilder sb, IndexModel index, List<InterpViewModel> interpretations, List<InterpViewModel> originals)
        {
            var childerenTexts = _documentProcess.Indeces.Where(i => i.ParentId == indexId);

            foreach (var child in childerenTexts)
            {
                var childChunk = await ChunkProcess.GetChunkByQuery(new ChunkQuery { IndexId = indexId }).ConfigureAwait(true);

                CreateRLNCRow(sb, childChunk, index, interpretations, originals);

                await CreateRLNCRows(child.Id, sb, index, interpretations, originals).ConfigureAwait(true);
            }
        }

        private void CreateRLNCRow(StringBuilder sb, ChunkModel chunk, IndexModel index, List<InterpViewModel> interpretations, List<InterpViewModel> originals)
        {
            var query = new InterpQuery();

            if (_documentProcess.Header.EditionType == EditionTypeStringEnum.Original)
            {
                query.SourceId = chunk.Id;
            }
            else
            {
                query.InterpId = chunk.Id;
            }

            var interp = interpretations.Count > 0 ? interpretations.FirstOrDefault() : originals.FirstOrDefault();

            if (chunk != null && interp != null)
            {
                sb.Append($"<para id=\"{pairCount}\">");

                sb.Append(FormatTextToRLNC(chunk, interp, index));

                sb.Append($"</para>");
            }

            pairCount += 1;
        }

        private string FormatTextToRLNC(ChunkModel chunk, InterpViewModel intepretation, IndexModel index)
        {
            var sb = new StringBuilder();

            var elements = JsonConvert.DeserializeObject<List<ChunkValueItemModel>>(chunk.ValueObj);

            sb.Append($"<se lang=\"{RusCorporaMapper.ConvertLang(_documentProcess.Header.Lang)}\" variant_id=\"0\">");

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

            sb.AppendLine($" [{_documentProcess.Header.Code}, {index.Name}]</se>");

            //sb.AppendLine($"<se lang=\"{RusCorporaMapper.ConvertLang(intepretation.HeaderLang)}\" variant_id=\"1\">{transText.Value} [{transText.EditionCode}, {transText.PathName}]</se>");

            return sb.ToString();
        }

        private static string GetGrammarInfoToRLNC(ChunkValueItemModel chunkValueItem)
        {
            var gsb = new StringBuilder();

            gsb.Append($"<ana lex=\"{chunkValueItem.Lemma}\" gr=\"{RusCorporaMapper.ConvertPos(chunkValueItem)}\"/>");

            return gsb.ToString();
        }
        #endregion
    }
}
