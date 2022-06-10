using SushiBarContracts.BindingModels;
using SushiBarContracts.BuisnessLogicContracts;
using Microsoft.Reporting.WinForms;
using System;
using System.Reflection;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using SushiBarContracts.ViewModels;

namespace SushiBarView
{
    public partial class FormReportOrdersDate : Form
    {
        private readonly ReportViewer reportViewer;
        private readonly IReportLogic _logic;
        public FormReportOrdersDate(IReportLogic logic)
        {
            InitializeComponent();
            _logic = logic;
            reportViewer = new ReportViewer
            {
                Dock = DockStyle.Fill
            };
            reportViewer.LocalReport.LoadReportDefinition(new FileStream("ReportOrdersDate.rdlc", FileMode.Open));
            Controls.Clear();
            Controls.Add(reportViewer);
            Controls.Add(panelFormOrder);
        }

        private void buttonMake_Click(object sender, EventArgs e)
        {
            try
            {
                MethodInfo method = _logic.GetType().GetMethod("GetOrdersDate");
                var dataSource = (List<ReportOrdersDateViewModel>)method.Invoke(_logic, null);
                var source = new ReportDataSource("DataSetOrdersDate", dataSource);
                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.DataSources.Add(source);
                reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonToPdf_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _logic.SaveOrdersDateToPdfFile(new ReportBindingModel
                    {
                        FileName = dialog.FileName
                    });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
