using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace DemoSam
{
    public partial class ProductCard : UserControl
    {
        public event Action OnProductUpdated;
        public string ProductId;
        public ProductCard()
        {
            InitializeComponent();
           


        }

        private DataRow _row;

        public void LoadProduct(DataRow row)
        {
            _row = row;
            if (int.Parse(row["Discount"].ToString()) >= 15)
            {
                this.BackColor = ColorTranslator.FromHtml("#2E8B57");
            }

            if (int.Parse(row["Price"].ToString()) > 0)
            {
                lblPrice.Font = new Font(lblPrice.Font, FontStyle.Strikeout);
                lblPrice.ForeColor = Color.Red;
            }
            
            if (int.Parse(row["StockQuantity"].ToString()) == 0)
            {
                this.BackColor = Color.PaleTurquoise;
            }

            ProductId = row["ProductId"].ToString();

            lblCategory.Text = row["Category"].ToString().Trim() + " | " + row["ProductName"].ToString();
            lblDescription.Text = "Описание: " + row["Description"].ToString();
            lblManufacturer.Text = "Производитель: " + row["ProivzoditelName"].ToString();
            lblSupplier.Text = "Поставщик: " + row["PostavchikName"].ToString();
            lblPrice.Text = "Цена: " + row["Price"].ToString();
            lblNewPrice.Text = "Цена по скидке: " + row["DiscountPrice"].ToString();
            lblUnit.Text = "Единица измерения: " + row["Units"].ToString();
            lblStock.Text = "Количество на складе: " + row["StockQuantity"].ToString();
            lblDiscount.Text = "Действующая скидака \n" + row["Discount"].ToString() + "%";


            if (row["Photo"] != DBNull.Value && row["Photo"] != null)
            {
                pictureBoxPhoto.Image = Image.FromFile($"..\\..\\image\\{row["Photo"].ToString()}");
                pictureBoxPhoto.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
                pictureBoxPhoto.Image = Properties.Resources.picture;
                pictureBoxPhoto.SizeMode = PictureBoxSizeMode.Zoom;

        }


        private void ProductCard_Load(object sender, EventArgs e)
        {

        }

        private void lblPrice_Click(object sender, EventArgs e)
        {

        }

        private void lblStock_Click(object sender, EventArgs e)
        {

        }

        private void lblCategory_Click(object sender, EventArgs e)
        {

        }

        private void ProductCard_Click(object sender, EventArgs e)
        {

            if (Session.Role == "Администратор")
            {
                DetailProduct detailProduct = new DetailProduct(_row);
                if (detailProduct.ShowDialog() == DialogResult.OK)
                {
                    OnProductUpdated?.Invoke();
                }
            }
        }
    }
}
