using Model;
using Model.Enum;
using Model.Query;
using Process;
using System.Linq;
using System.Text;
using WeifenLuo.WinFormsUI.Docking;

namespace Document
{
    public partial class ChunkViewer : DockContent
    {
        private DocumentProcess _documentProcess;
        public ChunkViewer(DocumentProcess documentProcess)
        {
            _documentProcess = documentProcess;

            InitializeComponent();
        }

        public async void LoadData(IndexModel index)
        {
            loader1.BringToFront();

            loader1.SetStatus("Загрузка данных ...");

            var sb = new StringBuilder();

            Text = index.Name;

            var chunk = await ChunkProcess.GetChunkByQuery(new ChunkQuery { indexId = index.Id }).ConfigureAwait(true);

            if (chunk != null)
            {
                sb.AppendLine(chunk.Value);

                var elements = await ElementProcess.GetElements(new ElementQuery { chunkId = chunk.Id, type = (int)ElementTypeEnum.Word });

                sb.AppendLine($"Слов без определения: {elements.Count(i => i.MorphId == null)}");

                if (_documentProcess.Header.EditionType == EditionTypeStringEnum.Original)
                {
                    var interps = await _documentProcess.GetInterpsByQuery(new InterpQuery { sourceId = chunk.Id });

                    if (interps.Count > 0)
                    {
                        foreach (var interp in interps)
                        {
                            var intChunk = await ChunkProcess.GetChunk(interp.InterpId).ConfigureAwait(true);

                            sb.AppendLine(intChunk.Value);
                        }
                    }
                    else
                    {
                        sb.AppendLine("Ссылка на перевод отсутствует");
                    }
                }
                else
                {
                    var interps = await _documentProcess.GetInterpsByQuery(new InterpQuery { interpId = chunk.Id });

                    var orig = interps.FirstOrDefault();

                    if (orig != null)
                    {
                        var intChunk = await ChunkProcess.GetChunk(orig.SourceId).ConfigureAwait(true);

                        sb.AppendLine(intChunk.Value);
                    }
                    else
                    {
                        sb.AppendLine("Ссылка на оригинал отсутствует");
                    }
                }

                lblChunk.Text = sb.ToString();

            }
            else
            {
                lblChunk.Text = string.Empty;
            }

            loader1.SendToBack();
        }
    }
}
