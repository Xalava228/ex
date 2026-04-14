namespace DemoSam
{
    partial class Orders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Orders));
            this.labelNazvanieFormOrder = new System.Windows.Forms.Label();
            this.buttonLogoutOrders = new System.Windows.Forms.Button();
            this.flowLayoutPanelOrder = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddOrder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelNazvanieFormOrder
            // 
            this.labelNazvanieFormOrder.AutoSize = true;
            this.labelNazvanieFormOrder.Location = new System.Drawing.Point(22, 22);
            this.labelNazvanieFormOrder.Name = "labelNazvanieFormOrder";
            this.labelNazvanieFormOrder.Size = new System.Drawing.Size(35, 13);
            this.labelNazvanieFormOrder.TabIndex = 0;
            this.labelNazvanieFormOrder.Text = "label1";
            // 
            // buttonLogoutOrders
            // 
            this.buttonLogoutOrders.Location = new System.Drawing.Point(25, 63);
            this.buttonLogoutOrders.Name = "buttonLogoutOrders";
            this.buttonLogoutOrders.Size = new System.Drawing.Size(86, 26);
            this.buttonLogoutOrders.TabIndex = 1;
            this.buttonLogoutOrders.Text = "Назад";
            this.buttonLogoutOrders.UseVisualStyleBackColor = true;
            this.buttonLogoutOrders.Click += new System.EventHandler(this.buttonLogoutOrders_Click);
            // 
            // flowLayoutPanelOrder
            // 
            this.flowLayoutPanelOrder.AutoScroll = true;
            this.flowLayoutPanelOrder.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelOrder.Location = new System.Drawing.Point(25, 115);
            this.flowLayoutPanelOrder.Name = "flowLayoutPanelOrder";
            this.flowLayoutPanelOrder.Size = new System.Drawing.Size(934, 473);
            this.flowLayoutPanelOrder.TabIndex = 2;
            this.flowLayoutPanelOrder.WrapContents = false;
            this.flowLayoutPanelOrder.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanelOrder_Paint);
            // 
            // btnAddOrder
            // 
            this.btnAddOrder.Location = new System.Drawing.Point(857, 42);
            this.btnAddOrder.Name = "btnAddOrder";
            this.btnAddOrder.Size = new System.Drawing.Size(102, 30);
            this.btnAddOrder.TabIndex = 3;
            this.btnAddOrder.Text = "Добавить";
            this.btnAddOrder.UseVisualStyleBackColor = true;
            this.btnAddOrder.Click += new System.EventHandler(this.btnAddOrder_Click);
            // 
            // Orders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 606);
            this.Controls.Add(this.btnAddOrder);
            this.Controls.Add(this.flowLayoutPanelOrder);
            this.Controls.Add(this.buttonLogoutOrders);
            this.Controls.Add(this.labelNazvanieFormOrder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Orders";
            this.Text = "Заказы";
            this.Load += new System.EventHandler(this.Orders_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNazvanieFormOrder;
        private System.Windows.Forms.Button buttonLogoutOrders;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelOrder;
        private System.Windows.Forms.Button btnAddOrder;
    }
}