using Common.Process;
using Model;
using Model.Enum;
using Model.Query;
using Process;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Document
{
    public partial class ChunkExplorer : DockContent
    {
        private MorphProcess _morphProcess = new MorphProcess();

        public event EventHandler<ElementModel> ElementSelected;

        private List<ElementModel> _elements = new List<ElementModel>();

        private List<ElementModel> _definedWords = new List<ElementModel>();

        private List<ElementModel> _multyDefWords = new List<ElementModel>();

        private List<ElementModel> _noDefWords = new List<ElementModel>();

        public ChunkModel Chunk { get; private set; }

        public ChunkExplorer(ChunkModel chunk)
        {
            Chunk = chunk;

            InitializeComponent();
        }

        private async void ChunkExplorer_Load(object sender, EventArgs e)
        {
            await LoadElements().ConfigureAwait(true);
        }

        private async Task LoadElements()
        {
            loader1.BringToFront();

            loader1.SetStatus("Загрузка элементов");

            flowLayoutPanel1.Controls.Clear();

            var query = new ElementQuery { chunkId = Chunk.Id };

            _elements = await ElementProcess.GetElements(query).ConfigureAwait(true);

            foreach (var element in _elements)

            {
                if (element.Type == (int)ElementTypeEnum.NewLine)
                {
                    var lastLabel = flowLayoutPanel1.Controls.OfType<Label>().LastOrDefault();

                    flowLayoutPanel1.SetFlowBreak(lastLabel, true);
                }
                else if (element.Type == (int)ElementTypeEnum.Space)
                {
                    var next = _elements.FirstOrDefault(i => i.Order == element.Order + 1);

                    if (next != null && next.Type == (int)ElementTypeEnum.Punctuation)
                    {
                        continue;
                    }
                }
                else
                {
                    var label = new Label
                    {
                        AutoSize = true,
                        Text = element.Value,
                        Tag = element,
                        Padding = new Padding(1, 1, 1, 1),
                        FlatStyle = FlatStyle.Flat
                    };

                    label.MouseMove += Label_MouseMove;

                    label.MouseLeave += Label_MouseLeave;

                    if (!string.IsNullOrWhiteSpace(element.Value) && element.Type != (int)ElementTypeEnum.Punctuation)
                    {
                        if (!string.IsNullOrEmpty(element.MorphId))
                        {
                            label.ForeColor = Color.Black;
                        }
                        else
                        {
                            label.ForeColor = Color.Blue;
                        }
                    }

                    label.Click += Label_Click;

                    flowLayoutPanel1.Controls.Add(label);

                    loader1.SetStatus($"Загрузка элементов: {flowLayoutPanel1.Controls.Count}");
                }
            }

            await CheckMorphStatus().ConfigureAwait(true);
        }

        private void Label_Click(object sender, EventArgs e)
        {
            MarkSelectedLabel(sender);
        }

        private void MarkSelectedLabel(object sender)
        {
            if (sender is Label selectedLabel &&
                selectedLabel.Tag is ElementModel selectedElement &&
                selectedElement.Type == (int)ElementTypeEnum.Word)
            {

                var labels = flowLayoutPanel1.Controls.OfType<Label>();

                foreach (var label in labels)
                {
                    if (label.Tag is ElementModel element && element.Id == selectedElement.Id)
                    {
                        label.BackColor = SystemColors.GradientActiveCaption;
                    }
                    else
                    {
                        label.BackColor = SystemColors.Window;
                    }
                }

                ElementSelected.Invoke(this, selectedElement);
            }
        }

        private void Label_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void Label_MouseMove(object sender, MouseEventArgs e)
        {
            var el = ((Label)sender).Tag as ElementModel;

            if (el.Type == (int)ElementTypeEnum.Word)
            {
                Cursor = Cursors.Hand;
            }
            else
            {
                Cursor = Cursors.Default;
            }

            base.OnMouseMove(e);
        }

        internal void MarkSelectedElement(ElementModel e)
        {
            var labels = flowLayoutPanel1.Controls.OfType<Label>();

            foreach (Label label in labels)
            {
                if (label.Tag is ElementModel element && element.Id == e.Id)
                {
                    if (!string.IsNullOrEmpty(e.MorphId))
                    {
                        label.ForeColor = Color.Black;
                    }
                    else
                    {
                        label.ForeColor = Color.Blue;
                    }
                }
            }

        }

        internal void MarkElementMorphStatus(ElementModel e, Color color)
        {
            var labels = flowLayoutPanel1.Controls.OfType<Label>();

            foreach (Label label in labels)
            {
                if (label.Tag is ElementModel element && element.Id == e.Id)
                {
                    label.ForeColor = color;
                }
            }

        }

        internal async void RunMorphService()
        {
            loader1.BringToFront();

            loader1.SetStatus("Получение данных из морфологического сервиса");

            var resultsCount = 0;

            foreach (var word in _noDefWords)
            {
                if (word.MorphId == null)
                {
                    var results = await _morphProcess.GetMorpheusAnalysis(word.Value, LangStringEnum.Latin).ConfigureAwait(true);

                    foreach (var result in results)
                    {
                        var model = _morphProcess.CreateMorphModel(result, LangStringEnum.Latin);

                        model = await _morphProcess.SaveMorph(model).ConfigureAwait(true);

                        if (model != null)
                        {
                            resultsCount += 1;

                            loader1.SetStatus($"Получение данных из морфологического сервиса: {resultsCount}");
                        }
                    }
                }
            }

            await LoadElements();

            loader1.SendToBack();

            DialogProcess.InfoMessage("Морфологический сервис Morpheus", $"Найдено новых определений {resultsCount}");
        }

        internal async Task CheckMorphStatus()
        {
            loader1.SetStatus("Проверка морфологии");

            var words = _elements.Where(i => i.Type == (int)ElementTypeEnum.Word).ToList();

            _definedWords = words.Where(i => i.MorphId != null).ToList();

            foreach (var word in _definedWords)
            {
                MarkElementMorphStatus(word, Color.Black);
            }

            _multyDefWords = words.Where(i => i.MorphId == null).ToList();

            foreach (var word in _multyDefWords)
            {
                var results = await _morphProcess.GetMorphItems(new MorphQuery { Form = word.Value.ToLower() }).ConfigureAwait(true);

                if (results.Count == 1)
                {
                    MarkElementMorphStatus(word, Color.Green);
                }

                if (results.Count == 0)
                {
                    _noDefWords.Add(word);

                    MarkElementMorphStatus(word, Color.Red);
                }
            }

            loader1.SendToBack();
        }
    }
}
