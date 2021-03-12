using Common.Process;
using Microsoft.Reporting.WinForms;
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

namespace Report
{
    public partial class ReportBrowser : DockContent
    {
        DocumentReportProcess _documentReportProcess;

        ReportViewer _reportViewer;

        ReportTypeEnum _currentReportType;

        public ReportBrowser(DocumentProcess documentProcess)
        {
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

        public async Task GetReport(ReportTypeEnum reportTypeEnum) {

            _reportViewer.ReportRefresh -= ReportRefresh;

            _currentReportType = reportTypeEnum;

            switch (reportTypeEnum)
            {
                case ReportTypeEnum.ChunkWithoutVersion:
                    await GetChunkStatusReport().ConfigureAwait(true);
                    break;
                default:
                    break;
            }

            _reportViewer.ReportRefresh += ReportRefresh;
        }

        private async Task GetChunkStatusReport() {
            
            Text = "Отчет: Статус фрагментов";

            _reportViewer.LocalReport.DataSources.Clear();

            _reportViewer.LocalReport.ReportPath = @"Reports\ChunkStatus.rdlc";
            
            var ds = new ReportDataSource
            {
                Name = "DataSet1",
            };

            ds.Value = await _documentReportProcess.GetChunkStatusReport().ConfigureAwait(true);

            _reportViewer.LocalReport.DataSources.Add(ds);

            _reportViewer.RefreshReport();
        }
    }
}
