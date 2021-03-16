using Microsoft.Reporting.WinForms;
using Model;
using Model.Enum;
using Process;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Report
{
    public partial class ReportBrowser : DockContent
    {
        DocumentReportProcess _documentReportProcess;

        DocumentProcess _documentProcess;

        ReportViewer _reportViewer;

        ReportTypeEnum _currentReportType;

        public ReportBrowser(DocumentProcess documentProcess)
        {
            _documentProcess = documentProcess;

            _documentReportProcess = new DocumentReportProcess(documentProcess);

            InitializeComponent();

            _reportViewer = new ReportViewer();

            _reportViewer.Dock = DockStyle.Fill;

            _reportViewer.ProcessingMode = ProcessingMode.Local;

            Controls.Add(_reportViewer);
        }

        private async void ReportRefresh(object sender, CancelEventArgs e)
        {
            await GetReport(_currentReportType).ConfigureAwait(true);

        }

        public async Task GetReport(ReportTypeEnum reportTypeEnum)
        {
            loader1.BringToFront();

            loader1.SetStatus("Формирование отчета...");

            _reportViewer.ReportRefresh -= ReportRefresh;

            _currentReportType = reportTypeEnum;

            switch (reportTypeEnum)
            {
                case ReportTypeEnum.ChunkWithoutParallelText:
                    await GetChunkWithoutParallelTextReport().ConfigureAwait(true);
                    break;
                case ReportTypeEnum.ChunkWithUndefinedWord:
                    await GetChunkWithUndefinedWordReport().ConfigureAwait(true);
                    break;
                case ReportTypeEnum.Text:
                    await GetTextReport().ConfigureAwait(true);
                    break;
                case ReportTypeEnum.ParallelText:
                    await GetParallelTextReport().ConfigureAwait(true);
                    break;
                case ReportTypeEnum.ReadinessStatistics:
                    await GetReadinessStatisticsReport().ConfigureAwait(true);
                    break;
                case ReportTypeEnum.PosStatistics:
                    await GetPosStatisticsReport().ConfigureAwait(true);
                    break;
                case ReportTypeEnum.ChunkUnpublished:
                    await GetChunkUnpublishedReport().ConfigureAwait(true);
                    break;
                default:
                    break;
            }

            _reportViewer.ReportRefresh += ReportRefresh;

            loader1.SendToBack();
        }

        private async Task GetChunkUnpublishedReport()
        {
            Text = "Неопубликованные фрагменты";

            _reportViewer.LocalReport.DataSources.Clear();

            _reportViewer.LocalReport.ReportPath = @"Reports\ChunkUnpublished.rdlc";

            var ds = new ReportDataSource
            {
                Name = "DS_Chunks",
            };

            ds.Value = await _documentReportProcess.GetChunkUnpublishedReport().ConfigureAwait(true);

            _reportViewer.LocalReport.DataSources.Add(ds);

            _reportViewer.RefreshReport();
        }

        private async Task GetPosStatisticsReport()
        {
            Text = "Части речи";

            _reportViewer.LocalReport.DataSources.Clear();

            _reportViewer.LocalReport.ReportPath = @"Reports\PosStatistics.rdlc";

            var ds = new ReportDataSource
            {
                Name = "DS_Pos",
            };

            ds.Value = await _documentReportProcess.GetPosStatisticsReport().ConfigureAwait(true);

            _reportViewer.LocalReport.DataSources.Add(ds);

            _reportViewer.RefreshReport();
        }

        private async Task GetReadinessStatisticsReport()
        {
            Text = "Статистика выполнения";

            _reportViewer.LocalReport.DataSources.Clear();

            _reportViewer.LocalReport.ReportPath = @"Reports\ReadinessStatistics.rdlc";

            var ds = new ReportDataSource
            {
                Name = "DS_Chunks",
            };

            ds.Value = await _documentReportProcess.GetReadinessStatisticsReport().ConfigureAwait(true);

            _reportViewer.LocalReport.DataSources.Add(ds);

            _reportViewer.RefreshReport();
        }

        private async Task GetChunkWithUndefinedWordReport()
        {
            Text = "Фрагменты с неопределенными словами";

            _reportViewer.LocalReport.DataSources.Clear();

            _reportViewer.LocalReport.ReportPath = @"Reports\ChunkWithUndefinedWord.rdlc";

            var ds = new ReportDataSource
            {
                Name = "DS_Chunks",
            };

            ds.Value = await _documentReportProcess.GetChunkWithUndefinedWordReport().ConfigureAwait(true);

            _reportViewer.LocalReport.DataSources.Add(ds);

            _reportViewer.RefreshReport();
        }

        private async Task GetParallelTextReport()
        {
            var headers = await HeaderProcess.GetHeaders(_documentProcess.Header.ProjectId).ConfigureAwait(true);

            Text = $"Параллельный текст";

            _reportViewer.LocalReport.DataSources.Clear();

            _reportViewer.LocalReport.ReportPath = @"Reports\ParallelText.rdlc";

            var dsHeader = new ReportDataSource
            {
                Name = "DS_Headers",
            };

            dsHeader.Value = headers;

            _reportViewer.LocalReport.DataSources.Add(dsHeader);

            var dsChunks = new ReportDataSource
            {
                Name = "DS_Chunks",
            };

            dsChunks.Value = await _documentReportProcess.GetParallelTextReport(headers).ConfigureAwait(true);

            _reportViewer.LocalReport.DataSources.Add(dsChunks);

            _reportViewer.RefreshReport();
        }

        private async Task GetTextReport()
        {
            Text = $"Текст";

            _reportViewer.LocalReport.DataSources.Clear();

            _reportViewer.LocalReport.ReportPath = @"Reports\Text.rdlc";

            var dsHeader = new ReportDataSource
            {
                Name = "DS_Headers",
            };

            dsHeader.Value = new List<HeaderModel>
            {
                _documentProcess.Header
            };

            _reportViewer.LocalReport.DataSources.Add(dsHeader);

            var dsChunks = new ReportDataSource
            {
                Name = "DS_Chunks",
            };

            dsChunks.Value = await _documentReportProcess.GetTextReport().ConfigureAwait(true);

            _reportViewer.LocalReport.DataSources.Add(dsChunks);

            _reportViewer.RefreshReport();
        }

        private async Task GetChunkWithoutParallelTextReport()
        {
            Text = "Фрагменты без перевода";

            _reportViewer.LocalReport.DataSources.Clear();

            _reportViewer.LocalReport.ReportPath = @"Reports\ChunkWithoutParallelText.rdlc";

            var ds = new ReportDataSource
            {
                Name = "DS_Chunks",
            };

            ds.Value = await _documentReportProcess.GetChunkWithoutTranslationReport().ConfigureAwait(true);

            _reportViewer.LocalReport.DataSources.Add(ds);

            _reportViewer.RefreshReport();
        }
    }
}
