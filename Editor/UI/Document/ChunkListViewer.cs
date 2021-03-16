using Common.Helper;
using Model;
using Model.Enum;
using Process;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Document
{
    public partial class ChunkListViewer : DockContent
    {
        private DocumentProcess _documentProcess;

        private List<ChunkModel> _chunks;

        private ElementModel _element;

        ChunkEditAction _chunkEditAction;

        public ChunkListViewer(DocumentProcess documentProcess)
        {
            _documentProcess = documentProcess;

            InitializeComponent();
        }

        public void LoadData(List<ChunkModel> chunks, ElementModel element, ChunkEditAction chunkEditAction)
        {
            txtChunk.Clear();

            _chunks = chunks;

            _element = element;

            _chunkEditAction = chunkEditAction;

            Text = chunkEditAction == ChunkEditAction.MorphDefinitionAccepted ? "Определение применено к следующим случаям:"
                : "Определение отменено для следующих случаев:";

            foreach (var chunk in _chunks)
            {
                txtChunk.AppendText(_documentProcess.Indeces.FirstOrDefault(i => i.Id == chunk.IndexId).Name, Color.Blue);

                txtChunk.AppendText(". ");

                txtChunk.AppendText(chunk.Value);

                txtChunk.AppendText(Environment.NewLine);
            }

            txtChunk.HighlightText(_element.Value, _chunkEditAction == ChunkEditAction.MorphDefinitionAccepted ? Color.Green : Color.Red, new Font(txtChunk.Font.FontFamily, txtChunk.Font.Size, FontStyle.Underline));
        }
    }
}
