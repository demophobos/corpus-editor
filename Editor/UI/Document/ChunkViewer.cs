using Model;
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
    public partial class ChunkViewer : DockContent
    {
        public ChunkViewer()
        {
            InitializeComponent();
        }

        public async void LoadData(IndexModel index)
        {
            Text = index.Name;

            var chunk = await ChunkProcess.GetChunk(index.Id).ConfigureAwait(true);

            if (chunk != null)
            {
                lblChunk.Text = chunk.Value;
            }
            else {
                lblChunk.Text = string.Empty;
            }
        }
    }
}
