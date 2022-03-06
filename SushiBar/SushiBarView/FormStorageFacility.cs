using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SushiBarContracts.BuisnessLogicContracts;
using SushiBarContracts.BindingModels;

namespace SushiBarView
{
    public partial class FormStorageFacility : Form
    {
        private int? id;
        public int Id { set { id = value; } }
        private readonly IStorageFacilityLogic _logic;
        private Dictionary<int, (string, int)> storageFacilityIngredients;

        public FormStorageFacility(IStorageFacilityLogic logic)
        {
            InitializeComponent();

            textBoxFirstName.Leave += textBox_Leave;
            textBoxLastName.Leave += textBox_Leave;
            textBoxMiddleName.Leave += textBox_Leave;
            textBoxFirstName.Enter += textBox_Enter;
            textBoxLastName.Enter += textBox_Enter;
            textBoxMiddleName.Enter += textBox_Enter;

            _logic = logic;
        }

        private void FormStorageFacility_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                        var view = _logic.Read( new StorageFacilityBindingModel
                        {
                            Id = id.Value
                        })?[0];

                    if (view != null)
                    {
                        string[] FLM = view.OwnerFLM.Split(';');
                        textBoxName.Text = view.Name;
                        textBoxFirstName.Text = FLM[0];
                        textBoxLastName.Text = FLM[1];
                        textBoxMiddleName.Text = FLM?[2];
                        storageFacilityIngredients = view.StorageFacilityIngredients;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                storageFacilityIngredients = new Dictionary<int, (string, int)>();
            }
        }

        private void LoadData()
        {
            try
            {
                if (storageFacilityIngredients != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (KeyValuePair<int, (string, int)> storagefacilityingredient in storageFacilityIngredients)
                    {
                        dataGridView.Rows.Add(new object[] { storagefacilityingredient.Key, storagefacilityingredient.Value.Item1,
                        storagefacilityingredient.Value.Item2 });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((textBoxFirstName.Text == "Фамилия") || (textBoxLastName.Text == "Имя"))
            {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string tpMid = textBoxMiddleName.Text;
                if (tpMid.Equals("Отчество"))
                    tpMid = null;
                _logic.CreateOrUpdate(new StorageFacilityBindingModel
                {
                    Id = id,
                    Name = textBoxName.Text,    
                    OwnerFLM = textBoxFirstName.Text + ";" + textBoxLastName.Text + ";" + tpMid,
                    StorageFacilityIngredients = storageFacilityIngredients
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        //----------Два метода для Watermark текстбоксов ФИО-------------
        private void textBox_Leave(object sender, EventArgs e)
        {
            if ((sender as Control).Text == "")
            {
                switch ((sender as Control).Name)
                {
                    case "textBoxFirstName":
                        (sender as Control).Text = "Фамилия";
                        break;
                    case "textBoxLastName":
                        (sender as Control).Text = "Имя";
                        break;
                    case "textBoxMiddleName":
                        (sender as Control).Text = "Отчество";
                        break;
                }
                (sender as Control).ForeColor = Color.Gray;
            }
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            if (((sender as Control).Name == "textBoxFirstName") && ((sender as Control).Text == "Фамилия") ||
                ((sender as Control).Name == "textBoxLastName") && ((sender as Control).Text == "Имя") ||
                ((sender as Control).Name == "textBoxMiddleName") && ((sender as Control).Text == "Отчество"))
            {
                (sender as Control).Text = "";
                (sender as Control).ForeColor = Color.Black;
            }
        }
        //---------------------------------------------------------------
    }
}
