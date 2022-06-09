namespace SushiBarView
{
    partial class FormMails
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonGetCurrentPage = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.textBoxPage = new System.Windows.Forms.TextBox();
            this.labelTxt = new System.Windows.Forms.Label();
            this.labelPageAmount = new System.Windows.Forms.Label();
            this.ButtonOpen = new System.Windows.Forms.Button();
            this.groupBoxPagin = new System.Windows.Forms.GroupBox();
            this.buttonPrev = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBoxPagin.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(1, 1);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 29;
            this.dataGridView.Size = new System.Drawing.Size(798, 414);
            this.dataGridView.TabIndex = 0;
            // 
            // buttonGetCurrentPage
            // 
            this.buttonGetCurrentPage.Location = new System.Drawing.Point(11, 63);
            this.buttonGetCurrentPage.Name = "buttonGetCurrentPage";
            this.buttonGetCurrentPage.Size = new System.Drawing.Size(164, 29);
            this.buttonGetCurrentPage.TabIndex = 2;
            this.buttonGetCurrentPage.Text = "Перейти";
            this.buttonGetCurrentPage.UseVisualStyleBackColor = true;
            this.buttonGetCurrentPage.Click += new System.EventHandler(this.buttonGetCurrentPage_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(95, 98);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(80, 30);
            this.buttonNext.TabIndex = 3;
            this.buttonNext.Text = ">>";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // textBoxPage
            // 
            this.textBoxPage.Location = new System.Drawing.Point(81, 30);
            this.textBoxPage.Name = "textBoxPage";
            this.textBoxPage.Size = new System.Drawing.Size(59, 27);
            this.textBoxPage.TabIndex = 4;
            // 
            // labelTxt
            // 
            this.labelTxt.AutoSize = true;
            this.labelTxt.Location = new System.Drawing.Point(6, 33);
            this.labelTxt.Name = "labelTxt";
            this.labelTxt.Size = new System.Drawing.Size(80, 20);
            this.labelTxt.TabIndex = 5;
            this.labelTxt.Text = "Страница ";
            // 
            // labelPageAmount
            // 
            this.labelPageAmount.AutoSize = true;
            this.labelPageAmount.Location = new System.Drawing.Point(146, 33);
            this.labelPageAmount.Name = "labelPageAmount";
            this.labelPageAmount.Size = new System.Drawing.Size(0, 20);
            this.labelPageAmount.TabIndex = 6;
            // 
            // ButtonOpen
            // 
            this.ButtonOpen.Location = new System.Drawing.Point(816, 12);
            this.ButtonOpen.Name = "ButtonOpen";
            this.ButtonOpen.Size = new System.Drawing.Size(164, 29);
            this.ButtonOpen.TabIndex = 7;
            this.ButtonOpen.Text = "Открыть";
            this.ButtonOpen.UseVisualStyleBackColor = true;
            this.ButtonOpen.Click += new System.EventHandler(this.ButtonOpen_Click);
            // 
            // groupBoxPagin
            // 
            this.groupBoxPagin.Controls.Add(this.buttonPrev);
            this.groupBoxPagin.Controls.Add(this.labelTxt);
            this.groupBoxPagin.Controls.Add(this.labelPageAmount);
            this.groupBoxPagin.Controls.Add(this.buttonGetCurrentPage);
            this.groupBoxPagin.Controls.Add(this.buttonNext);
            this.groupBoxPagin.Controls.Add(this.textBoxPage);
            this.groupBoxPagin.Location = new System.Drawing.Point(805, 56);
            this.groupBoxPagin.Name = "groupBoxPagin";
            this.groupBoxPagin.Size = new System.Drawing.Size(187, 141);
            this.groupBoxPagin.TabIndex = 8;
            this.groupBoxPagin.TabStop = false;
            this.groupBoxPagin.Text = "Переход по страницам";
            // 
            // buttonPrev
            // 
            this.buttonPrev.Location = new System.Drawing.Point(11, 98);
            this.buttonPrev.Name = "buttonPrev";
            this.buttonPrev.Size = new System.Drawing.Size(80, 30);
            this.buttonPrev.TabIndex = 7;
            this.buttonPrev.Text = "<<";
            this.buttonPrev.UseVisualStyleBackColor = true;
            this.buttonPrev.Click += new System.EventHandler(this.buttonPrev_Click_1);
            // 
            // FormMails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 421);
            this.Controls.Add(this.groupBoxPagin);
            this.Controls.Add(this.ButtonOpen);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormMails";
            this.Text = "Письмена";
            this.Load += new System.EventHandler(this.FormMails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBoxPagin.ResumeLayout(false);
            this.groupBoxPagin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonGetCurrentPage;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.TextBox textBoxPage;
        private System.Windows.Forms.Label labelTxt;
        private System.Windows.Forms.Label labelPageAmount;
        private System.Windows.Forms.Button ButtonOpen;
        private System.Windows.Forms.GroupBox groupBoxPagin;
        private System.Windows.Forms.Button buttonPrev;
    }
}