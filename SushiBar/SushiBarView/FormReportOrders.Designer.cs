
namespace SushiBarView
{
    partial class FormReportOrders
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
            this.panelFormOrder = new System.Windows.Forms.Panel();
            this.buttonToPdf = new System.Windows.Forms.Button();
            this.buttonMake = new System.Windows.Forms.Button();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.labelPO = new System.Windows.Forms.Label();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.labelC = new System.Windows.Forms.Label();
            this.panelFormOrder.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFormOrder
            // 
            this.panelFormOrder.Controls.Add(this.buttonToPdf);
            this.panelFormOrder.Controls.Add(this.buttonMake);
            this.panelFormOrder.Controls.Add(this.dateTimePickerTo);
            this.panelFormOrder.Controls.Add(this.labelPO);
            this.panelFormOrder.Controls.Add(this.dateTimePickerFrom);
            this.panelFormOrder.Controls.Add(this.labelC);
            this.panelFormOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFormOrder.Location = new System.Drawing.Point(0, 0);
            this.panelFormOrder.Name = "panelFormOrder";
            this.panelFormOrder.Size = new System.Drawing.Size(1265, 40);
            this.panelFormOrder.TabIndex = 0;
            // 
            // buttonToPdf
            // 
            this.buttonToPdf.Location = new System.Drawing.Point(1156, 5);
            this.buttonToPdf.Name = "buttonToPdf";
            this.buttonToPdf.Size = new System.Drawing.Size(94, 29);
            this.buttonToPdf.TabIndex = 1;
            this.buttonToPdf.Text = "в pdf";
            this.buttonToPdf.UseVisualStyleBackColor = true;
            this.buttonToPdf.Click += new System.EventHandler(this.buttonToPdf_Click);
            // 
            // buttonMake
            // 
            this.buttonMake.Location = new System.Drawing.Point(629, 5);
            this.buttonMake.Name = "buttonMake";
            this.buttonMake.Size = new System.Drawing.Size(142, 29);
            this.buttonMake.TabIndex = 4;
            this.buttonMake.Text = "Сформировать";
            this.buttonMake.UseVisualStyleBackColor = true;
            this.buttonMake.Click += new System.EventHandler(this.buttonMake_Click);
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Location = new System.Drawing.Point(322, 7);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(250, 27);
            this.dateTimePickerTo.TabIndex = 3;
            // 
            // labelPO
            // 
            this.labelPO.AutoSize = true;
            this.labelPO.Location = new System.Drawing.Point(289, 12);
            this.labelPO.Name = "labelPO";
            this.labelPO.Size = new System.Drawing.Size(27, 20);
            this.labelPO.TabIndex = 2;
            this.labelPO.Text = "по";
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(33, 7);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(250, 27);
            this.dateTimePickerFrom.TabIndex = 1;
            // 
            // labelC
            // 
            this.labelC.AutoSize = true;
            this.labelC.Location = new System.Drawing.Point(9, 12);
            this.labelC.Name = "labelC";
            this.labelC.Size = new System.Drawing.Size(18, 20);
            this.labelC.TabIndex = 1;
            this.labelC.Text = "C";
            // 
            // FormReportOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1265, 450);
            this.Controls.Add(this.panelFormOrder);
            this.Name = "FormReportOrders";
            this.Text = "Заказы";
            this.panelFormOrder.ResumeLayout(false);
            this.panelFormOrder.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFormOrder;
        private System.Windows.Forms.Button buttonToPdf;
        private System.Windows.Forms.Button buttonMake;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Label labelPO;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Label labelC;
    }
}