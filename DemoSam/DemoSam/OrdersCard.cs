using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoSam
{
    public partial class OrdersCard : UserControl
    {
        public event Action<int> OnOrderDeleted;
        public event Action<int> OnOrderUpdated;
        private int _orderId;
        private int _orderDetailsId;

        public OrdersCard()
        {
            InitializeComponent();
        }

        public void LoadOrderCard(DataRow row)
        {
            _orderId = Convert.ToInt32(row["OrdersId"]);
            _orderDetailsId = Convert.ToInt32(row["OrderDetailsId"]);
            labelArticle.Text = "Артикул заказа: " + row["Article"].ToString();
            labelStatus.Text = "Статус заказа: " + row["OrdersStatus"].ToString();
            labelAddressPickUpPoint.Text = "Адрес пункта выдачи:" + row["Address"].ToString();
            labelDataOrder.Text = "Дата заказа: " + row["Date"].ToString();
            labelDateDelivery.Text = "Дата доставки \n" + row["DateDelivery"].ToString();

            bool isAdmin = Session.Role == "Администратор";
            buttonDelete.Visible = isAdmin;
            buttonEdit.Visible = isAdmin;
        }

        private void OrdersCard_Load(object sender, EventArgs e)
        {

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            OnOrderDeleted?.Invoke(_orderId);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            OnOrderUpdated?.Invoke(_orderDetailsId);
        }
    }
}
