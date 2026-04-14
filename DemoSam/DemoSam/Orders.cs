using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DemoSam
{
    public partial class Orders : Form
    {

        private string connString = @"Server = localhost; DataBase = shose_store_sam; Trusted_Connection = True;";

        public Orders()
        {
            InitializeComponent();

        }

        private void buttonLogoutOrders_Click(object sender, EventArgs e)
        {
        }

        private void Orders_Load(object sender, EventArgs e)
        {
            LoadOrderCard();

            flowLayoutPanelOrder.BackColor = ColorTranslator.FromHtml("#7FFF00");

        }

        private DataTable GetOrdersTable()
        {
            DataTable ordersTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = @"Select p.Article, o.OrdersStatus, pick.Address, o.Date, o.DateDelivery 
From Orders o 
Join PickUpPoint pick on o.PickUpPointId = pick.PickupPointID
Join OrdersDetails od on o.OrdersId = od.OrdersId
join Product p on od.ProductId = p.ProductId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ordersTable);
                }
            }
            return ordersTable;
        }

        private void LoadOrderCard()
        {
            flowLayoutPanelOrder.Controls.Clear();
            DataTable ordersTable = GetOrdersTable();

            foreach (DataRow row in ordersTable.Rows)
            {
                OrdersCard card = new OrdersCard();
                card.LoadOrderCard(row);
                flowLayoutPanelOrder.Controls.Add(card);
            }
        }

        private void flowLayoutPanelOrder_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {

        }
    }
}
