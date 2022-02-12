
namespace SushiBarView
{
    partial class FormCreateOrder
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
            this.textBoxSum = new System.Windows.Forms.TextBox();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.labelPrice = new System.Windows.Forms.Label();
            this.labelNumber = new System.Windows.Forms.Label();
            this.labelDish = new System.Windows.Forms.Label();
            this.comboBoxDish = new System.Windows.Forms.ComboBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxSum
            // 
            this.textBoxSum.Location = new System.Drawing.Point(111, 83);
            this.textBoxSum.Name = "textBoxSum";
            this.textBoxSum.ReadOnly = true;
            this.textBoxSum.Size = new System.Drawing.Size(291, 27);
            this.textBoxSum.TabIndex = 12;
            this.textBoxSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(111, 51);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(291, 27);
            this.textBoxCount.TabIndex = 11;
            this.textBoxCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxCount.TextChanged += new System.EventHandler(this.textBoxCount_TextChanged);
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(12, 86);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(58, 20);
            this.labelPrice.TabIndex = 10;
            this.labelPrice.Text = "Сумма:";
            // 
            // labelNumber
            // 
            this.labelNumber.AutoSize = true;
            this.labelNumber.Location = new System.Drawing.Point(12, 54);
            this.labelNumber.Name = "labelNumber";
            this.labelNumber.Size = new System.Drawing.Size(93, 20);
            this.labelNumber.TabIndex = 9;
            this.labelNumber.Text = "Количество:";
            // 
            // labelDish
            // 
            this.labelDish.AutoSize = true;
            this.labelDish.Location = new System.Drawing.Point(12, 20);
            this.labelDish.Name = "labelDish";
            this.labelDish.Size = new System.Drawing.Size(58, 20);
            this.labelDish.TabIndex = 13;
            this.labelDish.Text = "Блюдо:";
            // 
            // comboBoxDish
            // 
            this.comboBoxDish.FormattingEnabled = true;
            this.comboBoxDish.Location = new System.Drawing.Point(111, 17);
            this.comboBoxDish.Name = "comboBoxDish";
            this.comboBoxDish.Size = new System.Drawing.Size(291, 28);
            this.comboBoxDish.TabIndex = 14;
            this.comboBoxDish.SelectedIndexChanged += new System.EventHandler(this.comboBoxDish_SelectedIndexChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(279, 130);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(94, 29);
            this.buttonCancel.TabIndex = 15;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(169, 130);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(104, 29);
            this.buttonSave.TabIndex = 16;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // FormCreateOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 173);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.comboBoxDish);
            this.Controls.Add(this.labelDish);
            this.Controls.Add(this.textBoxSum);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.labelNumber);
            this.Name = "FormCreateOrder";
            this.Text = "Заказ";
            this.Load += new System.EventHandler(this.FormCreateOrder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSum;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label labelNumber;
        private System.Windows.Forms.Label labelDish;
        private System.Windows.Forms.ComboBox comboBoxDish;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
    }
}