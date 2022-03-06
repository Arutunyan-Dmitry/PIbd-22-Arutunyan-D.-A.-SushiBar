
namespace SushiBarView
{
    partial class FormStorageFacilityFill
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
            this.buttonFill = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.comboBoxIngredient = new System.Windows.Forms.ComboBox();
            this.labelCount = new System.Windows.Forms.Label();
            this.labelIngredient = new System.Windows.Forms.Label();
            this.comboBoxStorageFacility = new System.Windows.Forms.ComboBox();
            this.labelStore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonFill
            // 
            this.buttonFill.Location = new System.Drawing.Point(193, 136);
            this.buttonFill.Name = "buttonFill";
            this.buttonFill.Size = new System.Drawing.Size(114, 29);
            this.buttonFill.TabIndex = 11;
            this.buttonFill.Text = "Пополнить";
            this.buttonFill.UseVisualStyleBackColor = true;
            this.buttonFill.Click += new System.EventHandler(this.buttonFill_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(313, 136);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(94, 29);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(120, 103);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(292, 27);
            this.textBoxCount.TabIndex = 9;
            this.textBoxCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // comboBoxIngredient
            // 
            this.comboBoxIngredient.FormattingEnabled = true;
            this.comboBoxIngredient.Location = new System.Drawing.Point(120, 58);
            this.comboBoxIngredient.Name = "comboBoxIngredient";
            this.comboBoxIngredient.Size = new System.Drawing.Size(292, 28);
            this.comboBoxIngredient.TabIndex = 8;
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(10, 106);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(93, 20);
            this.labelCount.TabIndex = 7;
            this.labelCount.Text = "Количество:";
            // 
            // labelIngredient
            // 
            this.labelIngredient.AutoSize = true;
            this.labelIngredient.Location = new System.Drawing.Point(10, 61);
            this.labelIngredient.Name = "labelIngredient";
            this.labelIngredient.Size = new System.Drawing.Size(95, 20);
            this.labelIngredient.TabIndex = 6;
            this.labelIngredient.Text = "Ингредиент:";
            // 
            // comboBoxStorageFacility
            // 
            this.comboBoxStorageFacility.FormattingEnabled = true;
            this.comboBoxStorageFacility.Location = new System.Drawing.Point(120, 12);
            this.comboBoxStorageFacility.Name = "comboBoxStorageFacility";
            this.comboBoxStorageFacility.Size = new System.Drawing.Size(292, 28);
            this.comboBoxStorageFacility.TabIndex = 13;
            // 
            // labelStore
            // 
            this.labelStore.AutoSize = true;
            this.labelStore.Location = new System.Drawing.Point(10, 15);
            this.labelStore.Name = "labelStore";
            this.labelStore.Size = new System.Drawing.Size(52, 20);
            this.labelStore.TabIndex = 12;
            this.labelStore.Text = "Склад:";
            // 
            // FormStorageFacilityFill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 178);
            this.Controls.Add(this.comboBoxStorageFacility);
            this.Controls.Add(this.labelStore);
            this.Controls.Add(this.buttonFill);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.comboBoxIngredient);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelIngredient);
            this.Name = "FormStorageFacilityFill";
            this.Text = "Пополнение склада";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonFill;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.ComboBox comboBoxIngredient;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Label labelIngredient;
        private System.Windows.Forms.ComboBox comboBoxStorageFacility;
        private System.Windows.Forms.Label labelStore;
    }
}