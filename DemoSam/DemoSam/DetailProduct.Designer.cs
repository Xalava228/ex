namespace DemoSam
{
    partial class DetailProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailProduct));
            this.labelTovar = new System.Windows.Forms.Label();
            this.pictureBoxPhoto = new System.Windows.Forms.PictureBox();
            this.buttonEditPhoto = new System.Windows.Forms.Button();
            this.labelIdProduct = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxCategory = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.comboBoxProizv = new System.Windows.Forms.ComboBox();
            this.comboBoxPostav = new System.Windows.Forms.ComboBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblManufacturer = new System.Windows.Forms.Label();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.txtUnits = new System.Windows.Forms.TextBox();
            this.lblUnits = new System.Windows.Forms.Label();
            this.numDiscount = new System.Windows.Forms.NumericUpDown();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTovar
            // 
            this.labelTovar.AutoSize = true;
            this.labelTovar.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTovar.Location = new System.Drawing.Point(430, 21);
            this.labelTovar.Name = "labelTovar";
            this.labelTovar.Size = new System.Drawing.Size(58, 21);
            this.labelTovar.TabIndex = 0;
            this.labelTovar.Text = "Товар";
            // 
            // pictureBoxPhoto
            // 
            this.pictureBoxPhoto.Location = new System.Drawing.Point(41, 84);
            this.pictureBoxPhoto.Name = "pictureBoxPhoto";
            this.pictureBoxPhoto.Size = new System.Drawing.Size(290, 228);
            this.pictureBoxPhoto.TabIndex = 1;
            this.pictureBoxPhoto.TabStop = false;
            // 
            // buttonEditPhoto
            // 
            this.buttonEditPhoto.Location = new System.Drawing.Point(42, 323);
            this.buttonEditPhoto.Name = "buttonEditPhoto";
            this.buttonEditPhoto.Size = new System.Drawing.Size(288, 28);
            this.buttonEditPhoto.TabIndex = 2;
            this.buttonEditPhoto.Text = "Выбор изображения";
            this.buttonEditPhoto.UseVisualStyleBackColor = true;
            this.buttonEditPhoto.Click += new System.EventHandler(this.buttonEditPhoto_Click);
            // 
            // labelIdProduct
            // 
            this.labelIdProduct.AutoSize = true;
            this.labelIdProduct.Location = new System.Drawing.Point(365, 84);
            this.labelIdProduct.Name = "labelIdProduct";
            this.labelIdProduct.Size = new System.Drawing.Size(68, 15);
            this.labelIdProduct.TabIndex = 3;
            this.labelIdProduct.Text = "ID Товара: ";
            this.labelIdProduct.Click += new System.EventHandler(this.labelIdProduct_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(368, 139);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(513, 22);
            this.textBoxName.TabIndex = 4;
            // 
            // textBoxCategory
            // 
            this.textBoxCategory.Location = new System.Drawing.Point(368, 192);
            this.textBoxCategory.Name = "textBoxCategory";
            this.textBoxCategory.Size = new System.Drawing.Size(513, 22);
            this.textBoxCategory.TabIndex = 5;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(368, 258);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(513, 22);
            this.textBoxDescription.TabIndex = 6;
            // 
            // comboBoxProizv
            // 
            this.comboBoxProizv.FormattingEnabled = true;
            this.comboBoxProizv.Location = new System.Drawing.Point(31, 386);
            this.comboBoxProizv.Name = "comboBoxProizv";
            this.comboBoxProizv.Size = new System.Drawing.Size(328, 23);
            this.comboBoxProizv.TabIndex = 9;
            // 
            // comboBoxPostav
            // 
            this.comboBoxPostav.FormattingEnabled = true;
            this.comboBoxPostav.Location = new System.Drawing.Point(381, 386);
            this.comboBoxPostav.Name = "comboBoxPostav";
            this.comboBoxPostav.Size = new System.Drawing.Size(328, 23);
            this.comboBoxPostav.TabIndex = 10;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(365, 121);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(130, 15);
            this.lblName.TabIndex = 11;
            this.lblName.Text = "Наименование товара";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(365, 174);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(64, 15);
            this.lblCategory.TabIndex = 12;
            this.lblCategory.Text = "Категория";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(367, 240);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(62, 15);
            this.lblDescription.TabIndex = 13;
            this.lblDescription.Text = "Описание";
            // 
            // lblManufacturer
            // 
            this.lblManufacturer.AutoSize = true;
            this.lblManufacturer.Location = new System.Drawing.Point(28, 368);
            this.lblManufacturer.Name = "lblManufacturer";
            this.lblManufacturer.Size = new System.Drawing.Size(91, 15);
            this.lblManufacturer.TabIndex = 14;
            this.lblManufacturer.Text = "Производитель";
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Location = new System.Drawing.Point(382, 368);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(69, 15);
            this.lblSupplier.TabIndex = 15;
            this.lblSupplier.Text = "Поставщик";
            // 
            // txtUnits
            // 
            this.txtUnits.Location = new System.Drawing.Point(376, 327);
            this.txtUnits.Name = "txtUnits";
            this.txtUnits.Size = new System.Drawing.Size(100, 22);
            this.txtUnits.TabIndex = 19;
            // 
            // lblUnits
            // 
            this.lblUnits.AutoSize = true;
            this.lblUnits.Location = new System.Drawing.Point(371, 297);
            this.lblUnits.Name = "lblUnits";
            this.lblUnits.Size = new System.Drawing.Size(117, 15);
            this.lblUnits.TabIndex = 18;
            this.lblUnits.Text = "Единица измерения";
            // 
            // numDiscount
            // 
            this.numDiscount.Location = new System.Drawing.Point(730, 386);
            this.numDiscount.Name = "numDiscount";
            this.numDiscount.Size = new System.Drawing.Size(80, 22);
            this.numDiscount.TabIndex = 27;
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(727, 368);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(105, 15);
            this.lblDiscount.TabIndex = 26;
            this.lblDiscount.Text = "Скидка, % (0–100)";
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(690, 323);
            this.numQuantity.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(120, 22);
            this.numQuantity.TabIndex = 25;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(687, 297);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(126, 15);
            this.lblQuantity.TabIndex = 24;
            this.lblQuantity.Text = "Количество на складе";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(523, 297);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(35, 15);
            this.lblPrice.TabIndex = 22;
            this.lblPrice.Text = "Цена";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(318, 450);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 32);
            this.btnSave.TabIndex = 28;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(474, 450);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 32);
            this.btnCancel.TabIndex = 29;
            this.btnCancel.Text = "Назад";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(523, 325);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(107, 22);
            this.textBoxPrice.TabIndex = 30;
            // 
            // DetailProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 520);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.numDiscount);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtUnits);
            this.Controls.Add(this.lblUnits);
            this.Controls.Add(this.lblSupplier);
            this.Controls.Add(this.lblManufacturer);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.comboBoxPostav);
            this.Controls.Add(this.comboBoxProizv);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.textBoxCategory);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelIdProduct);
            this.Controls.Add(this.buttonEditPhoto);
            this.Controls.Add(this.pictureBoxPhoto);
            this.Controls.Add(this.labelTovar);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "DetailProduct";
            this.Load += new System.EventHandler(this.DetailProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTovar;
        private System.Windows.Forms.PictureBox pictureBoxPhoto;
        private System.Windows.Forms.Button buttonEditPhoto;
        private System.Windows.Forms.Label labelIdProduct;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxCategory;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.ComboBox comboBoxProizv;
        private System.Windows.Forms.ComboBox comboBoxPostav;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblManufacturer;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.TextBox txtUnits;
        private System.Windows.Forms.Label lblUnits;
        private System.Windows.Forms.NumericUpDown numDiscount;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox textBoxPrice;
    }
}