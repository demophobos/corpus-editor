using Model;
using Model.Enum;
using Model.Query;
using Model.View;
using Newtonsoft.Json;
using Process.Helper;
using Process.Properties;
using System;
using System.Collections.Generic;
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
        #region RLNC
        private int pairCount;
        public async Task<string> CreateRusCorporaChunkReport(ChunkViewModel chunk)
        {
            var query = new InterpQuery();

            if (chunk.HeaderEditionType == EditionTypeStringEnum.Original)
            {
                query.SourceId = chunk.Id;

            }
            else
            {
                query.InterpId = chunk.Id;
            }

            var interpViews = await _documentProcess.GetInterpsByQuery(query).ConfigureAwait(true);

            if (interpViews.Count == 0)
            {
                throw new Exception("Переводы отсутствуют");
            }

            pairCount = 0;

            var sb = new StringBuilder();

            sb.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");

            sb.Append("<html>");

            sb.Append($"<head></head>");

            sb.Append("<body>");

            CreateRLNCRow(sb, interpViews);

            //await CreateRLNCRows(sb, interpViews);

            sb.Append("</body>");

            sb.Append("</html>");

            return sb.ToString();
        }

        //private async Task CreateRLNCRows(StringBuilder sb, List<InterpViewModel> interpretations)
        //{
        //    var childerenTexts = _documentProcess.Indeces.Where(i => i.ParentId == chunk.IndexId);

        //    foreach (var child in childerenTexts)
        //    {
        //        var childChunk = await ChunkProcess.GetChunkByQuery(new ChunkQuery { IndexId = chunk.IndexId }).ConfigureAwait(true);

        //        CreateRLNCRow(sb, chunk, interpretations);

        //        await CreateRLNCRows(sb, childChunk, interpretations).ConfigureAwait(true);
        //    }
        //}

        private void CreateRLNCRow(StringBuilder sb, List<InterpViewModel> interpretations)
        {

            sb.Append($"<para id=\"{pairCount}\">");

            sb.Append(FormatTextToRLNC(interpretations));

            sb.Append($"</para>");

            pairCount += 1;
        }

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
        #endregion
    }
}
