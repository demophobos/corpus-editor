using Model;
using Model.Enum;
using Model.Query;
using Process.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Process
{
    public class ChunkProcess
    {
        public static async Task<ChunkModel> GetChunk(string indextId)
        {
            var query = new ChunkQuery { indexId = indextId };

            return await API.ChunkAPI.GetChunk(query);
        }

        public static async Task<ChunkModel> RemoveChunk(ChunkModel chunk)
        {
            return await API.ChunkAPI.Remove(chunk);
        }

        public static async Task<ChunkModel> SaveChunkAndElements(ChunkModel chunk)
        {
            var savedChunk = await API.ChunkAPI.Save(chunk).ConfigureAwait(true);

            await ParseAndSaveElements(savedChunk).ConfigureAwait(true);

            return savedChunk;
        }

        private static async Task ParseAndSaveElements(ChunkModel chunk)
        {
            var elements = ParseTextElements(chunk);

            var morphRules = await API.MorphAPI.GetMorphItems(new MorphQuery { IsRule = true }).ConfigureAwait(true);

            foreach (var element in elements)
            {
                var rules = morphRules.Where(i => i.Form.ToLower() == element.Value.ToLower()).ToList();

                if (rules.Count == 1) {

                    element.MorphId = rules[0].Id;
                }

                await API.ElementAPI.Save(element).ConfigureAwait(true);
            }
        }

        private static List<ElementModel> ParseTextElements(ChunkModel chunk)
        {
            var elements = new List<ElementModel>();

            var list = chunk.Value.SplitByWordsAndOtherSymbols();

            var inx = 0;

            foreach (var item in list)
            {
                var element = new ElementModel
                {
                    ChunkId = chunk.Id,
                    Value = item,
                    Order = inx
                };

                if (Regex.IsMatch(item, @Properties.Resources.PunctuationPattern) && item.Length > 1)
                {
                    throw new Exception($"некорректное значение: '{item}'");
                }

                if (Regex.IsMatch(item, @Properties.Resources.PunctuationPattern))
                {
                    element.Type = (int)ElementTypeEnum.Punctuation;
                }

                if (item.All(char.IsLetter))
                {
                    element.Type = (int)ElementTypeEnum.Word;
                }

                if (item.All(char.IsDigit))
                {
                    element.Type = (int)ElementTypeEnum.Digit;
                }

                if (item.All(char.IsWhiteSpace))
                {
                    if (item.Contains("\n"))
                    {
                        element.Type = (int)ElementTypeEnum.NewLine;
                    }
                    else
                    {
                        element.Type = (int)ElementTypeEnum.Space;
                    }
                }

                elements.Add(element);

                inx += 1;
            }

            return elements;
        }
    }
}
