using SushiBarContracts.BuisnessLogicContracts;
using System;
using System.Windows.Forms;

namespace SushiBarView
{
    public partial class FormMails : Form
    {
        private readonly IMessageInfoLogic _logic;
        public FormMails(IMessageInfoLogic logic)
        {
            _logic = logic;
            InitializeComponent();
        }

        private void FormMails_Load(object sender, EventArgs e)
        {
            try
            {
                var list = _logic.Read(null);
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
