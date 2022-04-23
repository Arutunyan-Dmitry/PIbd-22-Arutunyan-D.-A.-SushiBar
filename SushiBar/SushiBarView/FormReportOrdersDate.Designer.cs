namespace SushiBarView
{
    partial class FormReportOrdersDate
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
            this.buttonToPdf = new System.Windows.Forms.Button();
            this.buttonMake = new System.Windows.Forms.Button();
            this.panelFormOrder = new System.Windows.Forms.Panel();
            this.panelFormOrder.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonToPdf
            // 
            this.buttonToPdf.Location = new System.Drawing.Point(906, 3);
            this.buttonToPdf.Name = "buttonToPdf";
            this.buttonToPdf.Size = new System.Drawing.Size(94, 29);
            this.buttonToPdf.TabIndex = 1;
            this.buttonToPdf.Text = "в pdf";
            this.buttonToPdf.UseVisualStyleBackColor = true;
            this.buttonToPdf.Click += new System.EventHandler(this.buttonToPdf_Click);
            // 
            // buttonMake
            // 
            this.buttonMake.Location = new System.Drawing.Point(3, 3);
            this.buttonMake.Name = "buttonMake";
            this.buttonMake.Size = new System.Drawing.Size(142, 29);
            this.buttonMake.TabIndex = 4;
            this.buttonMake.Text = "Сформировать";
            this.buttonMake.UseVisualStyleBackColor = true;
            this.buttonMake.Click += new System.EventHandler(this.buttonMake_Click);
            // 
            // panelFormOrder
            // 
            this.panelFormOrder.Controls.Add(this.buttonMake);
            this.panelFormOrder.Controls.Add(this.buttonToPdf);
            this.panelFormOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFormOrder.Location = new System.Drawing.Point(0, 0);
            this.panelFormOrder.Name = "panelFormOrder";
            this.panelFormOrder.Size = new System.Drawing.Size(1010, 37);
            this.panelFormOrder.TabIndex = 5;
            // 
            // FormReportOrdersDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 450);
            this.Controls.Add(this.panelFormOrder);
            this.Name = "FormReportOrdersDate";
            this.Text = "Заказы по датам";
            this.panelFormOrder.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonToPdf;
        private System.Windows.Forms.Button buttonMake;
        private System.Windows.Forms.Panel panelFormOrder;
    }
}