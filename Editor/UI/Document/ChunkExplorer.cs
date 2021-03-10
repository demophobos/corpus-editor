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

        private Label _selectedLabel;

        public event EventHandler<ElementModel> ElementSelected;

        public event EventHandler ElementsLoaded;

        public event EventHandler<bool> EnablePublishing;

        private List<ElementModel> _elements = new List<ElementModel>();

        private List<ElementModel> _definedWords = new List<ElementModel>();

        private List<ElementModel> _undefinedWords = new List<ElementModel>();

        private List<ElementModel> _oneDefWords = new List<ElementModel>();

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

            loader1.SetStatus("Загрузка элементов ...");

            flowLayoutPanel1.Controls.Clear();

            var query = new ElementQuery { chunkId = Chunk.Id };

            _elements = await ElementProcess.GetElements(query).ConfigureAwait(true);

            var newValueObjs = await ChunkProcess.CreateChunkValueObjs(_elements).ConfigureAwait(true);

            bool equal = ChunkProcess.ChunkValuesEquals(Chunk, newValueObjs);

            foreach (var element in _elements)
            {
                Label label = new Label();

                if (element.Type == (int)ElementTypeEnum.NewLine)
                {
                    var lastLabel = flowLayoutPanel1.Controls.OfType<Label>().LastOrDefault();

                    flowLayoutPanel1.SetFlowBreak(lastLabel, true);
                }
                else if (element.Type == (int)ElementTypeEnum.Space)
                {
                    label = new Label
                    {
                        AutoSize = true,
                        Text = "•",
                        Tag = element,
                        ForeColor = Color.LightGray,
                        FlatStyle = FlatStyle.Flat
                    };

                    var next = _elements.FirstOrDefault(i => i.Order == element.Order + 1);

                    if (next != null && next.Type == (int)ElementTypeEnum.Punctuation)
                    {
                        continue;
                    }
                }
                else
                {
                    label = new Label
                    {
                        AutoSize = true,
                        Text = element.Value,
                        Tag = element,
                        //Padding = new Padding(1, 1, 1, 1),
                        FlatStyle = FlatStyle.Flat
                    };

                    label.MouseMove += Label_MouseMove;

                    label.MouseLeave += Label_MouseLeave;

                    label.Click += Label_Click;

                    loader1.SetStatus($"Загрузка элементов ... {flowLayoutPanel1.Controls.Count}");
                }

                flowLayoutPanel1.Controls.Add(label);
            }

            await CheckMorphStatus().ConfigureAwait(true);

            ElementsLoaded?.Invoke(this, EventArgs.Empty);

            if (equal == false) {
                EnablePublishing?.Invoke(this, true);
            }
        }

        private void Label_Click(object sender, EventArgs e)
        {
            if (sender is Label selectedLabel &&
                    selectedLabel.Tag is ElementModel selectedElement &&
                    selectedElement.Type == (int)ElementTypeEnum.Word)
            {

                if (_selectedLabel != null)
                {
                    _selectedLabel.Font = new Font(_selectedLabel.Font, FontStyle.Regular);
                    _selectedLabel.BackColor = SystemColors.Window;
                }

                _selectedLabel = selectedLabel;
                _selectedLabel.Font = new Font(_selectedLabel.Font, FontStyle.Underline);
                _selectedLabel.BackColor = Color.Gold;

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

        internal async void RunRussianMorphService()
        {
            loader1.BringToFront();

            loader1.SetStatus("Получение данных морфологического сервиса ... ");

            var resultsCount = 0;

            foreach (var word in _noDefWords)
            {
                if (word.MorphId == null)
                {
                    var results = await _morphProcess.GetRussianMorphAnalysis(word.Value).ConfigureAwait(true);

                    foreach (var model in results)
                    {
                        var savedModel = await _morphProcess.SaveMorph(model).ConfigureAwait(true);

                        if (savedModel != null)
                        {
                            resultsCount += 1;

                            loader1.SetStatus($"Получение данных морфологического сервиса ... {resultsCount}");
                        }
                    }
                }
            }

            await LoadElements();

            loader1.SendToBack();
        }

        internal async void RunLatinMorphService()
        {
            loader1.BringToFront();

            loader1.SetStatus("Получение данных морфологического сервиса ... ");

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

                            loader1.SetStatus($"Получение данных морфологического сервиса ... {resultsCount}");
                        }
                    }
                }
            }

            await LoadElements();

            loader1.SendToBack();
        }

        internal async void RunGreekMorphService()
        {
            loader1.BringToFront();

            loader1.SetStatus("Получение данных морфологического сервиса ... ");

            var resultsCount = 0;

            foreach (var word in _noDefWords)
            {
                if (word.MorphId == null)
                {
                    var results = await _morphProcess.GetMorpheusAnalysis(word.Value, LangStringEnum.Greek).ConfigureAwait(true);

                    foreach (var result in results)
                    {
                        var model = _morphProcess.CreateMorphModel(result, LangStringEnum.Greek);

                        model = await _morphProcess.SaveMorph(model).ConfigureAwait(true);

                        if (model != null)
                        {
                            resultsCount += 1;

                            loader1.SetStatus($"Получение данных морфологического сервиса ... {resultsCount}");
                        }
                    }
                }
            }

            await LoadElements();

            loader1.SendToBack();
        }

        internal void CheckMorphStatus(ElementModel element)
        {
            var word = _elements.FirstOrDefault(i => i.Id == element.Id);

            if (word != null)
            {
                word = element;

                if (word.MorphId != null)
                {
                    MarkElementMorphStatus(word, Color.Black);
                }
                else
                {

                    var noDefWord = _noDefWords.FirstOrDefault(i => i.Id == word.Id);

                    if (noDefWord != null)
                    {
                        MarkElementMorphStatus(noDefWord, Color.Red);
                    }

                    var multyDefWord = _multyDefWords.FirstOrDefault(i => i.Id == word.Id);

                    if (multyDefWord != null)
                    {
                        MarkElementMorphStatus(multyDefWord, SystemColors.Highlight);
                    }

                    var oneDefDord = _oneDefWords.FirstOrDefault(i => i.Id == word.Id);

                    if (oneDefDord != null)
                    {

                        MarkElementMorphStatus(oneDefDord, Color.Green);
                    }
                }
            }
        }

        internal async Task CheckMorphStatus()
        {
            loader1.SetStatus("Проверка морфологии ...");

            var words = _elements.Where(i => i.Type == (int)ElementTypeEnum.Word).ToList();

            _definedWords = words.Where(i => i.MorphId != null).ToList();

            _undefinedWords = words.Where(i => i.MorphId == null).ToList();

            foreach (var word in _definedWords)
            {
                MarkElementMorphStatus(word, Color.Black);

                var results = await _morphProcess.GetMorphItems(new MorphQuery { Form = word.Value.ToLower() }).ConfigureAwait(true);

                if (results.Count > 1)
                {
                    _multyDefWords.Add(word);
                }

                if (results.Count == 1)
                {
                    _oneDefWords.Add(word);
                }
            }

            foreach (var word in _undefinedWords)
            {
                var results = await _morphProcess.GetMorphItems(new MorphQuery { Form = word.Value.ToLower() }).ConfigureAwait(true);

                if (results.Count > 1)
                {
                    MarkElementMorphStatus(word, SystemColors.Highlight);

                    _multyDefWords.Add(word);
                }

                if (results.Count == 1)
                {
                    _oneDefWords.Add(word);

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

        internal async Task PublishChunkAsync()
        {
            loader1.BringToFront();

            loader1.SetStatus("Публикация фрагмента");

            var chunk = new ChunkModel
            {
                HeaderId = Chunk.HeaderId,
                Id = Chunk.Id,
                IndexId = Chunk.IndexId,
                Value = Chunk.Value,
                ValueObj = Chunk.ValueObj
            };

            var newValueObj = await ChunkProcess.CreateChunkValueObjs(_elements).ConfigureAwait(true);

            var result = await ChunkProcess.PublishChunkValueObj(chunk, newValueObj).ConfigureAwait(true);

            if (result != null)
            {

                Chunk.ValueObj = result.ValueObj;

                EnablePublishing.Invoke(this, false);
            }

            loader1.SendToBack();
        }
    }
}
