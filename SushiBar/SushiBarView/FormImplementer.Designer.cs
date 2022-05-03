namespace SushiBarView
{
    partial class FormImplementer
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
            this.LabelFLM = new System.Windows.Forms.Label();
            this.textBoxFLM = new System.Windows.Forms.TextBox();
            this.labelWorkingTime = new System.Windows.Forms.Label();
            this.textBoxWorkingTime = new System.Windows.Forms.TextBox();
            this.labelPauseTime = new System.Windows.Forms.Label();
            this.textBoxPauseTime = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LabelFLM
            // 
            this.LabelFLM.AutoSize = true;
            this.LabelFLM.Location = new System.Drawing.Point(12, 15);
            this.LabelFLM.Name = "LabelFLM";
            this.LabelFLM.Size = new System.Drawing.Size(45, 20);
            this.LabelFLM.TabIndex = 0;
            this.LabelFLM.Text = "ФИО:";
            // 
            // textBoxFLM
            // 
            this.textBoxFLM.Location = new System.Drawing.Point(60, 12);
            this.textBoxFLM.Name = "textBoxFLM";
            this.textBoxFLM.Size = new System.Drawing.Size(198, 27);
            this.textBoxFLM.TabIndex = 1;
            this.textBoxFLM.Text = "ИвановИИ1";
            // 
            // labelWorkingTime
            // 
            this.labelWorkingTime.AutoSize = true;
            this.labelWorkingTime.Location = new System.Drawing.Point(12, 54);
            this.labelWorkingTime.Name = "labelWorkingTime";
            this.labelWorkingTime.Size = new System.Drawing.Size(149, 20);
            this.labelWorkingTime.TabIndex = 2;
            this.labelWorkingTime.Text = "Время выполнения:";
            // 
            // textBoxWorkingTime
            // 
            this.textBoxWorkingTime.Location = new System.Drawing.Point(167, 51);
            this.textBoxWorkingTime.Name = "textBoxWorkingTime";
            this.textBoxWorkingTime.Size = new System.Drawing.Size(91, 27);
            this.textBoxWorkingTime.TabIndex = 3;
            this.textBoxWorkingTime.Text = "100";
            // 
            // labelPauseTime
            // 
            this.labelPauseTime.AutoSize = true;
            this.labelPauseTime.Location = new System.Drawing.Point(12, 92);
            this.labelPauseTime.Name = "labelPauseTime";
            this.labelPauseTime.Size = new System.Drawing.Size(131, 20);
            this.labelPauseTime.TabIndex = 4;
            this.labelPauseTime.Text = "Время перерыва:";
            // 
            // textBoxPauseTime
            // 
            this.textBoxPauseTime.Location = new System.Drawing.Point(167, 92);
            this.textBoxPauseTime.Name = "textBoxPauseTime";
            this.textBoxPauseTime.Size = new System.Drawing.Size(91, 27);
            this.textBoxPauseTime.TabIndex = 5;
            this.textBoxPauseTime.Text = "10";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(137, 139);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(124, 29);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(12, 139);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(119, 29);
            this.buttonSave.TabIndex = 7;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // FormImplementer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 180);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.textBoxPauseTime);
            this.Controls.Add(this.labelPauseTime);
            this.Controls.Add(this.textBoxWorkingTime);
            this.Controls.Add(this.labelWorkingTime);
            this.Controls.Add(this.textBoxFLM);
            this.Controls.Add(this.LabelFLM);
            this.Name = "FormImplementer";
            this.Text = "Исполнитель";
            this.Load += new System.EventHandler(this.FormImplementer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelFLM;
        private System.Windows.Forms.TextBox textBoxFLM;
        private System.Windows.Forms.Label labelWorkingTime;
        private System.Windows.Forms.TextBox textBoxWorkingTime;
        private System.Windows.Forms.Label labelPauseTime;
        private System.Windows.Forms.TextBox textBoxPauseTime;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
    }
}