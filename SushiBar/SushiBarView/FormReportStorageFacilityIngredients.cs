﻿using SushiBarContracts.BindingModels;
using SushiBarContracts.BuisnessLogicContracts;
using SushiBarContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace SushiBarView
{
    public partial class FormReportStorageFacilityIngredients : Form
    {
        private readonly IReportLogic _logic;
        public FormReportStorageFacilityIngredients(IReportLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void FormReportStorageFacilityIngredients_Load(object sender, EventArgs e)
        {
            try
            {
                MethodInfo method = _logic.GetType().GetMethod("GetStorageFacilityIngredient");
                var dict = (List<ReportStorageFacilityIngredientsViewModel>)method.Invoke(_logic, null);
                if (dict != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var elem in dict)
                    {
                        dataGridView.Rows.Add(new object[] { elem.StorageFacilityName, "", "" });
                        foreach (var listElem in elem.Ingredients)
                        {
                            dataGridView.Rows.Add(new object[] { "", listElem.Item1, listElem.Item2 });
                        }
                        dataGridView.Rows.Add(new object[] { "Итого", "", elem.TotalCount });
                        dataGridView.Rows.Add(Array.Empty<object>());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSaveToExcel_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _logic.SaveStorageFacilityIngredientsToExcelFile(new ReportBindingModel
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
