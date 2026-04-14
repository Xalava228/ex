using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoSam
{
    public partial class MainForm : Form
    {

        private string connStrin = @"Server = localhost; DataBase = shose_store_sam; Trusted_Connection = True;";

        public string search;
        

        public MainForm()
        {
            InitializeComponent();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Session.Role = Session.Role.Trim();

            labelLogin.Text = Session.FullName;

            labelRole.Text = Session.Role;

            SetupByRole();

            LoadProduct(search);


            buttonLogout.BackColor = ColorTranslator.FromHtml("#00FA9A");
            btnAddOrder.BackColor = ColorTranslator.FromHtml("#00FA9A");
            flowLayoutPanel1.BackColor = ColorTranslator.FromHtml("#7FFF00");
            
            pictureBoxLogo.Image = Image.FromFile(@"..\..\image\Icon.png");
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;

            comboBoxFilter.Items.Clear();
            comboBoxFilter.Items.Add("Все поставщики");
            comboBoxFilter.Items.Add("Kari");
            comboBoxFilter.Items.Add("Обувь для вас");
            comboBoxFilter.SelectedIndex = 0;

            comboBoxSortir.Items.Clear();
            comboBoxSortir.Items.Add("Сортировка по убыванию");
            comboBoxSortir.Items.Add("Сортировка по возрастанию");
        }

        private void SetupByRole()
        {
            comboBoxSortir.Visible = false;
            comboBoxFilter.Visible = false;
            textBoxSearch.Visible = false;
            btnAddOrder.Visible = false;
            buttonaddprod.Visible = false;

            if (labelRole.Text == "Администратор")
            {
                comboBoxSortir.Visible = true;
                comboBoxFilter.Visible = true;
                textBoxSearch.Visible = true;
                btnAddOrder.Visible = true;
                buttonaddprod.Visible = true;
            }
            else if (labelRole.Text == "Менеджер") {
                comboBoxSortir.Visible = true;
                comboBoxFilter.Visible = true;
                textBoxSearch.Visible = true;
                btnAddOrder.Visible = true;
                buttonaddprod.Visible = false;
            }
            else if (labelRole.Text == "Авторизованный клиент") {
                comboBoxSortir.Visible = false;
                comboBoxFilter.Visible = false;
                textBoxSearch.Visible = false;
                btnAddOrder.Visible = false;
                buttonaddprod.Visible = false;
            }

        }

        private DataTable GetProductTable(string search)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connStrin))
            {
               string query = @"select p.ProductId, p.Discount, p.Photo, c.Name AS Category, 
                                            p.ProductName, 
                                            p.Description, 
                                            pro.ProivzoditelName, 
                                            post.PostavchikName, 
                                            p.Price, 
                                            p.Units, 
                                            p.StockQuantity, 
                                            p.DiscountPrice

                                            From Product p 
                                            JOIN Categori c On p.CategoriId = c.CategoriId
                                            JOIN Proivzoditel pro On p.ProivzoditelId = pro.ProivzoditelId
                                                JOIN Postavchik post On p.PostavchikId = post.PostavchikId

                                            Where p.ProductName like @search or 
                                            c.Name like @search or 
                                            p.Description like @search or 
                                            p.Units like @search or
                                            pro.ProivzoditelName like @search or
                                            post.PostavchikName like @search or
                                            p.Price like @search or
                                            p.StockQuantity like @search or
                                            p.DiscountPrice like @search";

               
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@search", "%" + search + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }


        private void LoadProduct(string search)
        {
            flowLayoutPanel1.Controls.Clear();
            DataTable dt = GetProductTable(search ?? "");

            if (comboBoxFilter.SelectedItem?.ToString() != "Все поставщики")
            {
                string supplier = comboBoxFilter.SelectedItem?.ToString();
                dt = new DataView(dt) { RowFilter = $"PostavchikName = '{supplier}'" }.ToTable();
            }

            if (comboBoxSortir.SelectedIndex == 0)
                dt = new DataView(dt) { Sort = "StockQuantity ASC" }.ToTable();
            else if (comboBoxSortir.SelectedIndex == 1)
                    dt = new DataView(dt) { Sort = "StockQuantity DESC" }.ToTable();
            
            foreach (DataRow row in dt.Rows)
            {
                ProductCard card = new ProductCard();
                card.LoadProduct(row);
                card.OnProductUpdated += () => LoadProduct(textBoxSearch.Text);
                flowLayoutPanel1.Controls.Add(card);
            }
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            Session.Role = "Гость";
            Session.FullName = "";
            FormAutorization form = new FormAutorization();
            form.Show();
            Hide();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBoxLogo_Click(object sender, EventArgs e)
        {

        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProduct(textBoxSearch.Text);
        }

        private void comboBoxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProduct(textBoxSearch.Text);
        }

        private void comboBoxSortir_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProduct(textBoxSearch.Text);
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            Orders orders = new Orders();
            orders.Show();
        }
    }
}
