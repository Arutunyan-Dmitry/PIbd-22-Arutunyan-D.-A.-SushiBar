using SushiBarContracts.BindingModels;
using SushiBarContracts.BuisnessLogicContracts;
using System;
using Unity;
using System.Windows.Forms;

namespace SushiBarView
{
    public partial class FormMails : Form
    {
        private bool hasNext = false;
        private readonly int mailsOnPage = 2;
        private int NumOfPages;
        private int currentPage = 0;
        private readonly IMessageInfoLogic _logic;
        public FormMails(IMessageInfoLogic logic)
        {
            if (mailsOnPage < 1) { mailsOnPage = 5; }
            _logic = logic;
            InitializeComponent();
        }

        private void FormMails_Load(object sender, EventArgs e)
        {
            try
            {
                textBoxPage.Text = (currentPage + 1).ToString();

                var list = _logic.Read(null);
                NumOfPages = list.Count / mailsOnPage;
                if (list.Count % mailsOnPage != 0) { NumOfPages++; }
                labelPageAmount.Text = "из " + NumOfPages.ToString();
            } 
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                var list = _logic.Read(new MessageInfoBindingModel { ToSkip = currentPage * mailsOnPage, ToTake = mailsOnPage});

                hasNext = !(currentPage >= NumOfPages - 1);

                if (hasNext)
                {
                    buttonNext.Enabled = true;
                }
                else
                {
                    buttonNext.Enabled = false;
                }

                if (list != null)
                {                 
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[5].ReadOnly = true;
                    dataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                if (currentPage != 0)
                {
                    buttonPrev.Enabled = true;
                } 
                else
                {
                    buttonPrev.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (hasNext)
            {
                currentPage++;
                textBoxPage.Text = (currentPage + 1).ToString();
                buttonPrev.Enabled = true;
                LoadData();
            }
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            if ((currentPage - 1) >= 0)
            {
                currentPage--;
                textBoxPage.Text = (currentPage + 1).ToString();
                buttonNext.Enabled = true;
                if (currentPage == 0)
                {
                    buttonPrev.Enabled = false;
                }
                LoadData();
            }
        }

        private void buttonGetCurrentPage_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxPage.Text))
            {
                MessageBox.Show("Введите номер страницы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Convert.ToInt32(textBoxPage.Text) < 0 || Convert.ToInt32(textBoxPage.Text) > NumOfPages)
            {
                MessageBox.Show("Недопустимый номер страницы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            currentPage = Convert.ToInt32(textBoxPage.Text) - 1;
            textBoxPage.Text = (currentPage + 1).ToString();
            LoadData();
        }

        private void ButtonOpen_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Program.Container.Resolve<FormMailMessage>();
                form.Id = dataGridView.SelectedRows[0].Cells[0].Value.ToString();
                form.ShowDialog();
                LoadData();
            }
        }
    }
}
