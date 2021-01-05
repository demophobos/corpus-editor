using API;
using Model;
using Model.Query;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace Process
{
    public class MorphProcess
    {
        #region Morph
        public async Task<List<MorphModel>> GetMorphItems(MorphQuery query)
        {
            return await MorphAPI.GetMorphItems(query);
        }

        public async Task<MorphModel> GetMorphItem(string id)
        {
            return await MorphAPI.GetMorphItem(id);
        }

        public async Task<MorphModel> SaveMorph(MorphModel morph)
        {
            return await MorphAPI.Save(morph);
        }

        public async Task<MorphModel> DeleteMorph(MorphModel morph)
        {
            return await MorphAPI.Remove(morph);
        }
        #endregion

        public async Task<List<MorpheusAnalysisModel>> GetMorpheusAnalysis(string value)
        {
            var result = new List<MorpheusAnalysisModel>();

            string jsonText;

            JObject jObject;

            try
            {
                //Perseus mapping
                if (Regex.IsMatch(value, "^v", RegexOptions.IgnoreCase))
                {
                    jsonText = await GetMorpheusResultAsJson(value).ConfigureAwait(true);

                    jObject = JObject.Parse(jsonText);

                    if (!jObject["analyses"].HasValues)
                    {
                        value = Regex.Replace(value, "^v", "u", RegexOptions.IgnoreCase);

                        jsonText = await GetMorpheusResultAsJson(value).ConfigureAwait(true);
                    }
                }
                else
                {
                    jsonText = await GetMorpheusResultAsJson(value).ConfigureAwait(true);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "InternalServerError")
                {
                    return result;
                }
                else
                {
                    throw ex;
                }
            }


            jObject = JObject.Parse(jsonText);

            if (!jObject["analyses"].HasValues) return result;

            var jTokens = jObject["analyses"]["analysis"];

            if (jTokens is JArray)
            {
                foreach (JToken jToken in jTokens)
                {
                    var morph = JsonConvert.DeserializeObject<MorpheusAnalysisModel>(jToken.ToString());

                    result.Add(morph);
                }
            }
            else
            {
                var morph = JsonConvert.DeserializeObject<MorpheusAnalysisModel>(jTokens.ToString());

                result.Add(morph);
            }
            return result;
        }

        private async Task<string> GetMorpheusResultAsJson(string token)
        {
            var xmlString = await MorpheusAPI.GetLatinWordAnalysis(token).ConfigureAwait(true);

            XmlDocument doc = new XmlDocument();

            doc.LoadXml(xmlString);

            return JsonConvert.SerializeXmlNode(doc);
        }
    }
}
