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
        public OrdersCard()
        {
            InitializeComponent();
        }

        public void LoadOrderCard(DataRow row)
        {
            labelArticle.Text = "Артикул заказа: " + row["Article"].ToString();
            labelStatus.Text = "Статус заказа: " + row["OrdersStatus"].ToString();
            labelAddressPickUpPoint.Text = "Адрес пункта выдачи:" + row["Address"].ToString();
            labelDataOrder.Text = "Дата заказа: " + row["Date"].ToString();
            labelDateDelivery.Text = "Дата доставки \n" + row["DateDelivery"].ToString();

        }

        private void OrdersCard_Load(object sender, EventArgs e)
        {

        }
    }
}
