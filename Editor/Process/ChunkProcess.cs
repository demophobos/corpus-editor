using API;
using Model;
using Model.Enum;
using Model.Query;
using Model.View;
using Newtonsoft.Json;
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
        public static async Task<ChunkViewModel> GetChunkByQuery(ChunkQuery query)
        {
            return await API.ChunkAPI.GetChunkByQuery(query);
        }

        public static async Task<List<ChunkViewModel>> GetChunksByQuery(ChunkQuery query)
        {
            return await API.ChunkAPI.GetChunksByQuery(query);
        }

        public static async Task<ChunkModel> GetChunk(string chunkId)
        {
            return await ChunkAPI.GetChunk(chunkId);
        }

        public static async Task<ChunkModel> RemoveChunk(ChunkModel chunk)
        {
            await ElementAPI.RemoveByQuery(new ElementQuery { chunkId = chunk.Id }).ConfigureAwait(true);

            return await ChunkAPI.Remove(chunk);
        }

        public static bool ChunkValuesEquals(string valueObj, string newValueObj)
        {
            return valueObj.Equals(newValueObj);
        }

        public static async Task<ChunkModel> PublishChunkValueObj(ChunkModel chunk, string newValueObj)
        {
            if (!ChunkValuesEquals(chunk.ValueObj, newValueObj))
            {
                chunk.ValueObj = newValueObj;

                return await ChunkAPI.Save(chunk).ConfigureAwait(true);
            }
            else
            {
                return null;
            }
        }

        public async static Task<string> CreateChunkValueObjs(List<ElementModel> elements)
        {
            var chunkValueItems = new List<ChunkValueItemModel>();

            foreach (var element in elements)
            {
                var chunkValueItem = new ChunkValueItemModel
                {
                    Id = element.Id,

                    Value = element.Value,

                    Type = element.Type,

                    Order = element.Order
                };

                if (element.MorphId != null)
                {
                    var morphRule = await MorphAPI.GetMorphItem(element.MorphId).ConfigureAwait(true);

                    element.MorphId = morphRule.Id;

                    chunkValueItem.MorphId = morphRule.Id;

                    chunkValueItem.Case = morphRule.Case;

                    chunkValueItem.Degree = morphRule.Degree;

                    chunkValueItem.Dialect = morphRule.Dialect;

                    chunkValueItem.Feature = morphRule.Feature;

                    chunkValueItem.Form = morphRule.Form;

                    chunkValueItem.Gender = morphRule.Gender;

                    chunkValueItem.Lang = morphRule.Lang;

                    chunkValueItem.Lemma = morphRule.Lemma;

                    chunkValueItem.Number = morphRule.Number;

                    chunkValueItem.Mood = morphRule.Mood;

                    chunkValueItem.Person = morphRule.Person;

                    chunkValueItem.Pos = morphRule.Pos;

                    chunkValueItem.Tense = morphRule.Tense;

                    chunkValueItem.Voice = morphRule.Voice;

                }

                chunkValueItems.Add(chunkValueItem);
            }

            return JsonConvert.SerializeObject(chunkValueItems);
        }

        public static async Task<ChunkModel> ChangeChunkStatus(ChunkModel chunk, string status)
        {
            if (chunk.GetType() != typeof(ChunkModel))
            {
                chunk = new ChunkModel { HeaderId = chunk.HeaderId, Id = chunk.Id, IndexId = chunk.IndexId, Value = chunk.Value, ValueObj = chunk.ValueObj };
            }
            chunk.Status = status;

            return await ChunkAPI.Save(chunk).ConfigureAwait(true);
        }

        public static async Task<List<ChunkModel>> ChangeChunkStatus(List<string> chunksToUpdate, string status)
        {
            List<ChunkModel> chunks = new List<ChunkModel>();
            foreach (var chunkId in chunksToUpdate)
            {
                var chunk = await GetChunk(chunkId).ConfigureAwait(true);

                var chunkChanged = await ChangeChunkStatus(chunk, status).ConfigureAwait(true);

                chunks.Add(chunkChanged);
            }

            return chunks;
        }

        public static async Task<ChunkModel> SaveChunkAndElements(ChunkModel chunk, string ruleLang)
        {
            var elements = ParseTextElements(chunk);

            var chunkValueItems = await ApplyMorphRules(elements, ruleLang);

            chunk.ValueObj = JsonConvert.SerializeObject(chunkValueItems);

            var savedChunk = await ChunkAPI.Save(chunk).ConfigureAwait(true);

            await ElementAPI.RemoveByQuery(new ElementQuery { chunkId = savedChunk.Id }).ConfigureAwait(true);

            await SaveElements(savedChunk, elements).ConfigureAwait(true);

            return savedChunk;
        }

        private static async Task<List<ChunkValueItemModel>> ApplyMorphRules(List<ElementModel> elements, string ruleLang)
        {
            var chunkValueItems = new List<ChunkValueItemModel>();

            var morphRules = await MorphAPI.GetMorphItems(new MorphQuery { IsRule = true, Lang = ruleLang }).ConfigureAwait(true);

            foreach (var element in elements)
            {
                var chunkValueItem = new ChunkValueItemModel
                {
                    Value = element.Value,

                    Type = element.Type,

                    Order = element.Order
                };

                var rules = morphRules.Where(i =>
                DiacriticHelper.RemoveDiacritics(i.Form.ToLower()) ==
                DiacriticHelper.RemoveDiacritics(element.Value.ToLower())).ToList();

                if (rules.Count == 1)
                {

                    var morphRule = rules[0];

                    element.MorphId = morphRule.Id;

                    chunkValueItem.MorphId = morphRule.Id;

                    chunkValueItem.Case = morphRule.Case;

                    chunkValueItem.Degree = morphRule.Degree;

                    chunkValueItem.Dialect = morphRule.Dialect;

                    chunkValueItem.Feature = morphRule.Feature;

                    chunkValueItem.Form = morphRule.Form;

                    chunkValueItem.Gender = morphRule.Gender;

                    chunkValueItem.Lang = morphRule.Lang;

                    chunkValueItem.Lemma = morphRule.Lemma;

                    chunkValueItem.Mood = morphRule.Number;

                    chunkValueItem.Person = morphRule.Person;

                    chunkValueItem.Pos = morphRule.Pos;

                    chunkValueItem.Tense = morphRule.Tense;

                    chunkValueItem.Voice = morphRule.Voice;

                }

                chunkValueItems.Add(chunkValueItem);
            }

            return chunkValueItems;
        }

        private static async Task SaveElements(ChunkModel chunk, List<ElementModel> elements)
        {
            foreach (var element in elements)
            {
                element.ChunkId = chunk.Id;

                element.HeaderId = chunk.HeaderId;

                await ElementAPI.Save(element).ConfigureAwait(true);
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

                if (Regex.IsMatch(item, @Properties.Resources.PunctuationPattern) && item.Length > 3)
                {
                    throw new Exception($"некорректное значение: '{item}'");
                }

                if (Regex.IsMatch(item, @Properties.Resources.PunctuationPattern))
                {
                    element.Type = (int)ElementTypeEnum.Punctuation;
                }

                if (item.All(char.IsLetter) || item.Any(char.IsLetter) && item.Contains("-"))
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
