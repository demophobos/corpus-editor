using API;
using CliWrap;
using CliWrap.Buffered;
using Model;
using Model.Enum;
using Model.Query;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
            try
            {
                return await MorphAPI.Save(morph);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MorphModel> DeleteMorph(MorphModel morph)
        {
            return await MorphAPI.Remove(morph);
        }

        public MorphModel CreateMorphModel(MorpheusAnalysisModel result, string lang)
        {
            return new MorphModel
            {
                Case = !string.IsNullOrEmpty(result.Case) ? result.Case : null,
                Degree = !string.IsNullOrEmpty(result.Degree) ? result.Degree : null,
                Dialect = !string.IsNullOrEmpty(result.Dialect) ? result.Dialect : null,
                Feature = !string.IsNullOrEmpty(result.Feature) ? result.Feature : null,
                Form = result.ExpandedForm,
                Gender = !string.IsNullOrEmpty(result.Gender) ? result.Gender : null,
                Lang = lang,
                Lemma = result.Lemma,
                Mood = !string.IsNullOrEmpty(result.Mood) ? result.Mood : null,
                Number = !string.IsNullOrEmpty(result.Number) ? result.Number : null,
                Person = !string.IsNullOrEmpty(result.Person) ? result.Person : null,
                Pos = result.Pos,
                Tense = !string.IsNullOrEmpty(result.Tense) ? result.Tense : null,
                Voice = !string.IsNullOrEmpty(result.Voice) ? result.Voice : null
            };
        }
        #endregion

        public async Task<List<MorpheusAnalysisModel>> GetMorpheusAnalysis(string value, string lang)
        {
            var result = new List<MorpheusAnalysisModel>();

            string jsonText;

            JObject jObject;

            try
            {
                //Perseus mapping
                if (Regex.IsMatch(value, "^v", RegexOptions.IgnoreCase))
                {
                    jsonText = await GetMorpheusResultAsJson(value, lang).ConfigureAwait(true);

                    jObject = JObject.Parse(jsonText);

                    if (!jObject["analyses"].HasValues)
                    {
                        value = Regex.Replace(value, "^v", "u", RegexOptions.IgnoreCase);

                        jsonText = await GetMorpheusResultAsJson(value, lang).ConfigureAwait(true);
                    }
                }
                else
                {
                    jsonText = await GetMorpheusResultAsJson(value, lang).ConfigureAwait(true);
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

        private async Task<string> GetMorpheusResultAsJson(string token, string lang)
        {
            var xmlString = string.Empty;

            switch (lang)
            {
                case LangStringEnum.Latin:
                    xmlString = await MorpheusAPI.GetLatinWordAnalysis(token).ConfigureAwait(true);
                    break;
                case LangStringEnum.Greek:
                    xmlString = await MorpheusAPI.GetGreekWordAnalysis(token).ConfigureAwait(true);
                    break;

            }

            XmlDocument doc = new XmlDocument();

            doc.LoadXml(xmlString);

            return JsonConvert.SerializeXmlNode(doc);
        }

        public async Task<List<MorphModel>> GetRussianMorphAnalysis(string value)
        {
            var path = Guid.NewGuid().ToString();

            var models = new List<MorphModel>();

            try
            {
                using (FileStream fs = File.Create(path))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(value);
                    fs.Write(info, 0, info.Length);
                }

                var result = await Cli.Wrap("mystem.exe")
                    .WithArguments($"-i --eng-gr --format json {path}")
                    .ExecuteBufferedAsync(Encoding.UTF8);

                var exitCode = result.ExitCode;
                var myStems = JsonConvert.DeserializeObject<List<MyStemModel>>(result.StandardOutput);
                if (myStems.Count > 0)
                {
                    foreach (var st in myStems)
                    {
                        foreach (var an in st.analysis)
                        {
                            var model = new MorphModel
                            {
                                Form = st.text.ToLower(),
                                Lemma = an.lex,
                                Lang = LangStringEnum.Russian
                            };

                            MyStemHelper.ConvertToMorphModel(an.gr, model);

                            models.Add(model);
                        }
                    }
                }

                return models;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                File.Delete(path);
            }
        }
    }
}
