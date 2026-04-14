using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

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
            Close();
        }

        private void Orders_Load(object sender, EventArgs e)
        {
            LoadOrderCard();
            labelNazvanieFormOrder.Text = "Список заказов";
            btnAddOrder.Visible = Session.Role == "Администратор";

            flowLayoutPanelOrder.BackColor = ColorTranslator.FromHtml("#7FFF00");

        }

        private DataTable GetOrdersTable()
        {
            DataTable ordersTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = @"Select o.OrdersId, od.OrderDetailsId, od.ProductId, od.Quantity, o.UserId, o.PickUpPointId, 
                                        p.Article, o.OrdersStatus, pick.Address, o.Date, o.DateDelivery 
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
                card.OnOrderDeleted += DeleteOrder;
                card.OnOrderUpdated += EditOrder;
                flowLayoutPanelOrder.Controls.Add(card);
            }
        }

        private void flowLayoutPanelOrder_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            if (Session.Role != "Администратор")
            {
                return;
            }

            using (OrderEditForm form = new OrderEditForm(connString))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadOrderCard();
                }
            }
        }

        private void DeleteOrder(int orderId)
        {
            if (Session.Role != "Администратор")
            {
                return;
            }

            if (MessageBox.Show("Удалить заказ?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand details = new SqlCommand("delete from OrdersDetails where OrdersId = @id", conn))
                {
                    details.Parameters.AddWithValue("@id", orderId);
                    details.ExecuteNonQuery();
                }

                using (SqlCommand order = new SqlCommand("delete from Orders where OrdersId = @id", conn))
                {
                    order.Parameters.AddWithValue("@id", orderId);
                    order.ExecuteNonQuery();
                }
            }

            LoadOrderCard();
        }

        private void EditOrder(int orderDetailsId)
        {
            if (Session.Role != "Администратор")
            {
                return;
            }

            using (OrderEditForm form = new OrderEditForm(connString, orderDetailsId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadOrderCard();
                }
            }
        }
    }
}
