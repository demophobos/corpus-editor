using Model;
using Process;
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
            else
            {
                lblChunk.Text = string.Empty;
            }
        }
    }
}
