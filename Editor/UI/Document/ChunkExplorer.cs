using Model;
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
    public partial class ChunkExplorer : DockContent
    {
        private ChunkModel _chunk;
        public ChunkExplorer(ChunkModel chunk)
        {
            _chunk = chunk;
            InitializeComponent();
        }

        private void ChunkExplorer_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();

            var label = new Label
            {
                AutoSize = true,
                Text = _chunk.Value,
                Tag = _chunk,
                Padding = new Padding(1, 1, 1, 1),
                FlatStyle = FlatStyle.Flat
            };

            flowLayoutPanel1.Controls.Add(label);
        }
    }
}
