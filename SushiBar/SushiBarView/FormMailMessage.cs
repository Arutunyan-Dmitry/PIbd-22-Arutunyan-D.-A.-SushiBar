using SushiBarContracts.BuisnessLogicContracts;
using System;
using Unity;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SushiBarContracts.BindingModels;
using SushiBarBusinessLogic.MailWorker;

namespace SushiBarView
{
    public partial class FormMailMessage : Form
    {
        private string id;
        public string Id { set { id = value; } }
        private readonly IMessageInfoLogic _logic;
        private readonly AbstractMailWorker _mailWorker;
        public FormMailMessage(IMessageInfoLogic logic, AbstractMailWorker mailWorker)
        {
            _logic = logic;
            _mailWorker = mailWorker;
            InitializeComponent();
            textBoxHeader.BackColor = Color.White;
            textBoxSender.BackColor = Color.White;
        }

        private void FormMailMessage_Load(object sender, EventArgs e)
        {
            if (id != null)
            {
                try
                {
                    var view = _logic.Read(new MessageInfoBindingModel
                    {
                        MessageId = id,
                    })?[0];

                    if (view != null)
                    {
                        textBoxSender.Text = view.SenderName;
                        textBoxHeader.Text = view.Subject;
                        foreach (string line in view.Body.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None))
                        {
                            listBoxBody.Items.Add(line);
                        }
                        textBoxRequest.Text = view.Request;
                    }
                    if (view.Request != null)
                    {
                        textBoxRequest.ReadOnly = true;
                        textBoxRequest.BackColor = Color.White;
                        buttonSave.Enabled = false;
                        buttonSave.Visible = false;
                    }
                    if (!view.IsRead)
                    {
                        _logic.Update(new MessageInfoBindingModel
                        {
                            MessageId = id,
                            IsRead = true,
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxRequest.Text))
            {
                MessageBox.Show("Введите ответ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {               
                _logic.Update(new MessageInfoBindingModel
                {
                    MessageId = id,
                    IsRead = true,
                    Request = textBoxRequest.Text,
                });

                var message = _logic.Read(new MessageInfoBindingModel
                {
                    MessageId = id,
                })?[0];

                _mailWorker.MailSendAsync(new MailSendInfoBindingModel
                {
                    MailAddress = message.SenderName,
                    Subject = $"Re: {message.Subject}",
                    Text = $"{textBoxRequest.Text} \n\n | Ответ на: \n | {message.SenderName} {message.DateDelivery.ToShortTimeString()} \n | {message.Body}"
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
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
