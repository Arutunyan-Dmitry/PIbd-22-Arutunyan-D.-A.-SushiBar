
namespace SushiBarView
{
    partial class FormDish
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
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.labelPrice = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.groupBoxIngredient = new System.Windows.Forms.GroupBox();
            this.buttonRef = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            this.buttonUpd = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ingredient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupBoxIngredient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(104, 68);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(95, 27);
            this.textBoxPrice.TabIndex = 7;
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(18, 71);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(48, 20);
            this.labelPrice.TabIndex = 5;
            this.labelPrice.Text = "Цена:";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(18, 26);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(80, 20);
            this.labelName.TabIndex = 4;
            this.labelName.Text = "Название:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(104, 26);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(292, 27);
            this.textBoxName.TabIndex = 8;
            // 
            // groupBoxIngredient
            // 
            this.groupBoxIngredient.Controls.Add(this.buttonRef);
            this.groupBoxIngredient.Controls.Add(this.buttonDel);
            this.groupBoxIngredient.Controls.Add(this.buttonUpd);
            this.groupBoxIngredient.Controls.Add(this.buttonAdd);
            this.groupBoxIngredient.Controls.Add(this.dataGridView);
            this.groupBoxIngredient.Location = new System.Drawing.Point(18, 113);
            this.groupBoxIngredient.Name = "groupBoxIngredient";
            this.groupBoxIngredient.Size = new System.Drawing.Size(828, 370);
            this.groupBoxIngredient.TabIndex = 9;
            this.groupBoxIngredient.TabStop = false;
            this.groupBoxIngredient.Text = "Ингредиенты";
            // 
            // buttonRef
            // 
            this.buttonRef.Location = new System.Drawing.Point(687, 192);
            this.buttonRef.Name = "buttonRef";
            this.buttonRef.Size = new System.Drawing.Size(94, 29);
            this.buttonRef.TabIndex = 8;
            this.buttonRef.Text = "Обновить";
            this.buttonRef.UseVisualStyleBackColor = true;
            this.buttonRef.Click += new System.EventHandler(this.buttonRef_Click);
            // 
            // buttonDel
            // 
            this.buttonDel.Location = new System.Drawing.Point(687, 135);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(94, 29);
            this.buttonDel.TabIndex = 7;
            this.buttonDel.Text = "Удалить";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // buttonUpd
            // 
            this.buttonUpd.Location = new System.Drawing.Point(687, 79);
            this.buttonUpd.Name = "buttonUpd";
            this.buttonUpd.Size = new System.Drawing.Size(94, 29);
            this.buttonUpd.TabIndex = 6;
            this.buttonUpd.Text = "Изменить";
            this.buttonUpd.UseVisualStyleBackColor = true;
            this.buttonUpd.Click += new System.EventHandler(this.buttonUpd_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(687, 26);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(94, 29);
            this.buttonAdd.TabIndex = 5;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Ingredient,
            this.Number});
            this.dataGridView.Location = new System.Drawing.Point(6, 26);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 29;
            this.dataGridView.Size = new System.Drawing.Size(628, 338);
            this.dataGridView.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.Visible = false;
            this.ID.Width = 125;
            // 
            // Ingredient
            // 
            this.Ingredient.HeaderText = "Ингредиент";
            this.Ingredient.MinimumWidth = 6;
            this.Ingredient.Name = "Ingredient";
            this.Ingredient.Width = 450;
            // 
            // Number
            // 
            this.Number.HeaderText = "Количество";
            this.Number.MinimumWidth = 6;
            this.Number.Name = "Number";
            this.Number.Width = 125;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(752, 489);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(94, 29);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(640, 489);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(106, 29);
            this.buttonSave.TabIndex = 11;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // FormDish
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 527);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBoxIngredient);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.labelName);
            this.Name = "FormDish";
            this.Text = "Блюдо";
            this.Load += new System.EventHandler(this.FormDish_Load);
            this.groupBoxIngredient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.GroupBox groupBoxIngredient;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ingredient;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.Button buttonRef;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonUpd;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
    }
}