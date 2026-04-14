namespace DemoSam
{
    partial class OrdersCard
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelArticle = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelAddressPickUpPoint = new System.Windows.Forms.Label();
            this.labelDataOrder = new System.Windows.Forms.Label();
            this.labelDateDelivery = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelArticle
            // 
            this.labelArticle.AutoSize = true;
            this.labelArticle.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelArticle.Location = new System.Drawing.Point(31, 23);
            this.labelArticle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelArticle.Name = "labelArticle";
            this.labelArticle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelArticle.Size = new System.Drawing.Size(95, 15);
            this.labelArticle.TabIndex = 0;
            this.labelArticle.Text = "Артикул Заказа";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(35, 61);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(76, 15);
            this.labelStatus.TabIndex = 1;
            this.labelStatus.Text = "Сатус заказа";
            // 
            // labelAddressPickUpPoint
            // 
            this.labelAddressPickUpPoint.AutoSize = true;
            this.labelAddressPickUpPoint.Location = new System.Drawing.Point(35, 96);
            this.labelAddressPickUpPoint.Name = "labelAddressPickUpPoint";
            this.labelAddressPickUpPoint.Size = new System.Drawing.Size(165, 15);
            this.labelAddressPickUpPoint.TabIndex = 2;
            this.labelAddressPickUpPoint.Text = "Адрес пункта выдачи (текст)";
            // 
            // labelDataOrder
            // 
            this.labelDataOrder.AutoSize = true;
            this.labelDataOrder.Location = new System.Drawing.Point(34, 132);
            this.labelDataOrder.Name = "labelDataOrder";
            this.labelDataOrder.Size = new System.Drawing.Size(70, 15);
            this.labelDataOrder.TabIndex = 3;
            this.labelDataOrder.Text = "Дата заказа";
            // 
            // labelDateDelivery
            // 
            this.labelDateDelivery.AutoSize = true;
            this.labelDateDelivery.Location = new System.Drawing.Point(706, 76);
            this.labelDateDelivery.Name = "labelDateDelivery";
            this.labelDateDelivery.Size = new System.Drawing.Size(85, 15);
            this.labelDateDelivery.TabIndex = 4;
            this.labelDateDelivery.Text = "Дата доставки";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(726, 123);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(111, 34);
            this.buttonDelete.TabIndex = 5;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(609, 123);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(111, 34);
            this.buttonEdit.TabIndex = 6;
            this.buttonEdit.Text = "Редактировать";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // OrdersCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.labelDateDelivery);
            this.Controls.Add(this.labelDataOrder);
            this.Controls.Add(this.labelAddressPickUpPoint);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.labelArticle);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "OrdersCard";
            this.Size = new System.Drawing.Size(855, 174);
            this.Load += new System.EventHandler(this.OrdersCard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelArticle;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelAddressPickUpPoint;
        private System.Windows.Forms.Label labelDataOrder;
        private System.Windows.Forms.Label labelDateDelivery;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonEdit;
    }
}
