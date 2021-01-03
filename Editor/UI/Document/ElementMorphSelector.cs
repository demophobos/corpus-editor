using Model;
using Model.Query;
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
    public partial class ElementMorphSelector : DockContent
    {
        MorphProcess _morphProcess;

        ElementModel _element;

        public event EventHandler<ElementModel> ElementMorphAccepted;

        public event EventHandler<ElementModel> ElementMorphRejected;

        public ElementMorphSelector()
        {
            _morphProcess = new MorphProcess();

            InitializeComponent();
        }

        public async Task LoadDataAsync(ElementModel element)
        {
            _element = element;

            if (string.IsNullOrEmpty(element.MorphId))
            {
                var query = new MorphQuery { Form = element.Value.ToLower() };

                morphSource.DataSource = await _morphProcess.GetMorphItems(query).ConfigureAwait(true);
            }
            else
            {
                morphSource.DataSource = await _morphProcess.GetMorphItem(element.MorphId).ConfigureAwait(true);
            }
        }

        private async void btnAcceptDefinition_ClickAsync(object sender, EventArgs e)
        {
            if (morphSource.Current != null && morphSource.Current is MorphModel morph)
            {
                _element.MorphId = morph.Id;

                _element = await ElementProcess.SaveModel(_element).ConfigureAwait(true);

                await LoadDataAsync(_element);

                ElementMorphAccepted.Invoke(this, _element);
            }
        }

        private async void btnUndoAccept_Click(object sender, EventArgs e)
        {
            _element.MorphId = null;

            _element = await ElementProcess.SaveModel(_element).ConfigureAwait(true);

            await LoadDataAsync(_element);

            ElementMorphRejected.Invoke(this, _element);
        }
    }
}
