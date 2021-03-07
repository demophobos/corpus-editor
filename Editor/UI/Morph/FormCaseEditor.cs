using Common.Helper;
using Model;
using Model.Enum;
using Model.Query;
using Process;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using WeifenLuo.WinFormsUI.Docking;

namespace Morph
{
    public partial class FormCaseEditor : DockContent
    {
        private MorphModel _morph;
        private IndexModel _index;

        public FormCaseEditor()
        {
            InitializeComponent();
        }

        public async Task LoadData(MorphModel morph, IndexModel index)
        {
            _morph = morph;

            _index = index;

            loader1.BringToFront();

            loader1.SetStatus("Загрузка...");

            var elements = await ElementProcess.GetElements(new ElementQuery
            {
                type = (int)ElementTypeEnum.Word,
                value = _morph.Form,
                headerId = _index.HeaderId
            }
            ).ConfigureAwait(true);

            var applicableElements = elements.Where(i => i.MorphId == null).ToList();

            var chunkIds = applicableElements.GroupBy(i => i.ChunkId);

            bindingSource1.DataSource = chunkIds.ToList();

            Text = $"{_morph.Form}: {chunkIds.Count()}";

            loader1.SendToBack();
        }

        private async void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            if (bindingSource1.Current != null && bindingSource1.Current is IGrouping<string, ElementModel> group)
            {
                loader1.BringToFront();

                loader1.SetStatus("Загрузка...");

                var chunk = await ChunkProcess.GetChunk(group.Key).ConfigureAwait(true);

                richTextBox1.Text = chunk.Value;

                richTextBox1.HighlightTextRegExp(_morph.Form, Color.Green, Color.Gold);

                loader1.SendToBack();
            }
        }

        private async void btnApply_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Current != null && bindingSource1.Current is IGrouping<string, ElementModel> group)
            {
                foreach (var element in group)
                {

                    element.MorphId = _morph.Id;

                    await ElementProcess.SaveModel(element).ConfigureAwait(true);
                }

            }
        }

        private async void btnCancel_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Current != null && bindingSource1.Current is IGrouping<string, ElementModel> group)
            {
                foreach (var element in group)
                {

                    element.MorphId = null;

                    await ElementProcess.SaveModel(element).ConfigureAwait(true);
                }

            }
        }
    }
}
