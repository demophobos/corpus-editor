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
        private readonly DocumentProcess _documentProcess;

        private List<ChunkModel> _chunks;

        private ElementModel _element;

        ChunkEditAction _chunkEditAction;

        public event EventHandler<IndexModel> IndexSelected;

        public ChunkListViewer(DocumentProcess documentProcess)
        {
            _documentProcess = documentProcess;

            InitializeComponent();
        }

        public void LoadData(List<ChunkModel> chunks, ElementModel element, ChunkEditAction chunkEditAction)
        {
            loader1.BringToFront();

            loader1.SetStatus("Загрузка фрагментов ...");

            panel.Controls.Clear();

            panel.RowCount = 0;

            _chunks = chunks;

            _element = element;

            _chunkEditAction = chunkEditAction;

            Text = chunkEditAction == ChunkEditAction.MorphDefinitionAccepted ? "Определение применено к следующим случаям:"
                : "Определение отменено для следующих случаев:";

            foreach (var chunk in _chunks)
            {
                var txtChunk = new RichTextBox
                {
                    Text = chunk.Value,

                    Dock = DockStyle.Fill,

                    BorderStyle = BorderStyle.None
                };

                var index = _documentProcess.Indeces.FirstOrDefault(i => i.Id == chunk.IndexId);

                var inxLabel = new LinkLabel
                {
                    Text = index.Name,

                    Tag = index,

                    Dock = DockStyle.Fill,

                    BackColor = SystemColors.Window
                };

                inxLabel.Click += InxLabel_Click;

                txtChunk.HighlightTextRegExp(_element.Value, _chunkEditAction == ChunkEditAction.MorphDefinitionAccepted ? Color.Green : Color.Red, new Font(txtChunk.Font.FontFamily, txtChunk.Font.Size, FontStyle.Underline));

                panel.RowCount += 1;

                panel.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                panel.Controls.Add(inxLabel, 0, panel.RowCount);

                panel.Controls.Add(txtChunk, 1, panel.RowCount);
            }

            loader1.SendToBack();
        }

        private void InxLabel_Click(object sender, EventArgs e)
        {
            if(sender is LinkLabel inxLabel && inxLabel.Tag is IndexModel index)
            {
                IndexSelected?.Invoke(this, index);
            }
        }
    }
}
