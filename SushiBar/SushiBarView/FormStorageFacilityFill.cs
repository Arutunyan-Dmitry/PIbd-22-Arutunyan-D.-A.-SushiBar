using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SushiBarContracts.BuisnessLogicContracts;
using SushiBarContracts.ViewModels;
using SushiBarContracts.BindingModels;

namespace SushiBarView
{
    public partial class FormStorageFacilityFill : Form
    {
        public int IngredientId
        {
            get { return Convert.ToInt32(comboBoxIngredient.SelectedValue); }
            set { comboBoxIngredient.SelectedValue = value; }
        }

        public int StorageFacilityId
        {
            get { return Convert.ToInt32(comboBoxStorageFacility.SelectedValue); }
            set { comboBoxStorageFacility.SelectedValue = value; }
        }

        public int Count
        {
            get { return Convert.ToInt32(textBoxCount.Text); }
            set
            {
                textBoxCount.Text = value.ToString();
            }
        }
        private readonly IStorageFacilityLogic _storageFacilityLogic;
        public FormStorageFacilityFill(IStorageFacilityLogic storageFacilityLogic, IIngredientLogic ingredientLogic)
        {
            InitializeComponent();
            _storageFacilityLogic = storageFacilityLogic;
            List<IngredientViewModel> ingredientView = ingredientLogic.Read(null);
            if (ingredientView != null)
            {
                comboBoxIngredient.DisplayMember = "IngredientName";
                comboBoxIngredient.ValueMember = "Id";
                comboBoxIngredient.DataSource = ingredientView;
                comboBoxIngredient.SelectedItem = null;
            }

            List<StorageFacilityViewModel> storageFacilityView = storageFacilityLogic.Read(null);
            if (storageFacilityView != null)
            {
                comboBoxStorageFacility.DisplayMember = "Name";
                comboBoxStorageFacility.ValueMember = "Id";
                comboBoxStorageFacility.DataSource = storageFacilityView;
                comboBoxStorageFacility.SelectedItem = null;
            }
        }

        private void buttonFill_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Введите количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxIngredient.SelectedValue == null)
            {
                MessageBox.Show("Выберите ингредиент", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxStorageFacility.SelectedValue == null)
            {
                MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _storageFacilityLogic.AddIngrediend(new AddIngredientBindingModel
            {
                IngredientId = Convert.ToInt32(comboBoxIngredient.SelectedValue),
                StorageFacilityId = Convert.ToInt32(comboBoxStorageFacility.SelectedValue),
                Count = Convert.ToInt32(textBoxCount.Text)
            });
            MessageBox.Show("Пополнение совершено", "Пополнение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
