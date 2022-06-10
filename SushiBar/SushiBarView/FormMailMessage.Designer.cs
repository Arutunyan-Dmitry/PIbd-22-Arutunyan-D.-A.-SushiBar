namespace SushiBarView
{
    partial class FormMailMessage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelSenderName = new System.Windows.Forms.Label();
            this.textBoxSender = new System.Windows.Forms.TextBox();
            this.labelMessage = new System.Windows.Forms.Label();
            this.listBoxBody = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxHeader = new System.Windows.Forms.TextBox();
            this.textBoxRequest = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelSenderName
            // 
            this.labelSenderName.AutoSize = true;
            this.labelSenderName.Location = new System.Drawing.Point(12, 9);
            this.labelSenderName.Name = "labelSenderName";
            this.labelSenderName.Size = new System.Drawing.Size(99, 20);
            this.labelSenderName.TabIndex = 0;
            this.labelSenderName.Text = "Отправитель";
            // 
            // textBoxSender
            // 
            this.textBoxSender.Location = new System.Drawing.Point(12, 32);
            this.textBoxSender.Name = "textBoxSender";
            this.textBoxSender.ReadOnly = true;
            this.textBoxSender.Size = new System.Drawing.Size(776, 27);
            this.textBoxSender.TabIndex = 1;
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Location = new System.Drawing.Point(12, 73);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(91, 20);
            this.labelMessage.TabIndex = 2;
            this.labelMessage.Text = "Сообщение";
            // 
            // listBoxBody
            // 
            this.listBoxBody.FormattingEnabled = true;
            this.listBoxBody.ItemHeight = 20;
            this.listBoxBody.Location = new System.Drawing.Point(12, 123);
            this.listBoxBody.Name = "listBoxBody";
            this.listBoxBody.Size = new System.Drawing.Size(776, 144);
            this.listBoxBody.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 290);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ответ";
            // 
            // textBoxHeader
            // 
            this.textBoxHeader.Location = new System.Drawing.Point(12, 96);
            this.textBoxHeader.Name = "textBoxHeader";
            this.textBoxHeader.ReadOnly = true;
            this.textBoxHeader.Size = new System.Drawing.Size(776, 27);
            this.textBoxHeader.TabIndex = 6;
            // 
            // textBoxRequest
            // 
            this.textBoxRequest.Location = new System.Drawing.Point(12, 313);
            this.textBoxRequest.Multiline = true;
            this.textBoxRequest.Name = "textBoxRequest";
            this.textBoxRequest.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxRequest.Size = new System.Drawing.Size(776, 147);
            this.textBoxRequest.TabIndex = 7;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(594, 478);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(94, 29);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Отправить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(694, 478);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(94, 29);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Назад";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormMailMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 518);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxRequest);
            this.Controls.Add(this.textBoxHeader);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxBody);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.textBoxSender);
            this.Controls.Add(this.labelSenderName);
            this.Name = "FormMailMessage";
            this.Text = "Письмо";
            this.Load += new System.EventHandler(this.FormMailMessage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSenderName;
        private System.Windows.Forms.TextBox textBoxSender;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.ListBox listBoxBody;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxHeader;
        private System.Windows.Forms.TextBox textBoxRequest;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}