using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DemoSam
{

    public partial class DetailProduct : Form
    {

        private string connString = @"Server = localhost    ; DataBase = shose_store_sam; Trusted_Connection = True;";

        private DataRow _row;
        public DetailProduct(DataRow row)
        {
            InitializeComponent();
            _row = row;
        }

        private void DetailProduct_Load(object sender, EventArgs e)
        {
            labelIdProduct.Text = "Id продукта: " + _row["ProductId"].ToString();
            textBoxName.Text = _row["ProductName"].ToString();
            textBoxCategory.Text = _row["Category"].ToString();
            textBoxDescription.Text = _row["Description"].ToString();
            txtUnits.Text = _row["Units"].ToString();
            textBoxPrice.Text = _row["Price"].ToString();
            loadComboBox();
            comboBoxProizv.Text = _row["ProivzoditelName"].ToString().Trim();
            comboBoxPostav.Text = _row["PostavchikName"].ToString().Trim();
            numQuantity.Text = _row["StockQuantity"].ToString();
            numDiscount.Text = _row["Discount"].ToString();

            if (_row["Photo"] != DBNull.Value)
            {
                pictureBoxPhoto.Image = Image.FromFile($"..\\..\\image\\{_row["Photo"].ToString()}");
                pictureBoxPhoto.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
                pictureBoxPhoto.Image = Properties.Resources.picture;
            pictureBoxPhoto.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void loadComboBox()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string selectProizvoditel = @"select ProivzoditelName from Proivzoditel;";
                string selectPostavchik = @"select PostavchikName from Postavchik;";
                using (var cmd = new SqlCommand(selectPostavchik, conn))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBoxPostav.Items.Add(reader["PostavchikName"].ToString().Trim());
                    }
                    reader.Close();
                }
                using (var cmd = new SqlCommand(selectProizvoditel, conn))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBoxProizv.Items.Add(reader["ProivzoditelName"].ToString().Trim());
                    }
                    reader.Close();
                }
            }
        }

        private void labelIdProduct_Click(object sender, EventArgs e)
        {

        }

        private void buttonEditPhoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "(*.png; *.jpg) | *.png; *.jpg";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxPhoto.Image = new Bitmap(openFileDialog.FileName);
                    pictureBoxPhoto.Tag = System.IO.Path.GetFileName(openFileDialog.FileName);

                    string dest = $"..\\..\\image\\{pictureBoxPhoto.Tag}";
                    System.IO.File.Copy(openFileDialog.FileName, dest, true);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string query = @"Update Product SET
                                        ProductName = @name, Description = @desc, Price = @price, Units = @units, StockQuantity = @stockquan,
                                        Discount = @discount, ProivzoditelId = (Select ProivzoditelId from Proivzoditel WHERE ProivzoditelName = @proizv),
                                        PostavchikId = (Select PostavchikId from Postavchik WHERE PostavchikName = @postav), Photo = @photo 
                                    WHERE ProductId = @id"; 
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", textBoxName.Text);
                        cmd.Parameters.AddWithValue("@desc", textBoxDescription.Text);
                        cmd.Parameters.AddWithValue("@price", textBoxPrice.Text);
                        cmd.Parameters.AddWithValue("@units", txtUnits.Text);
                        cmd.Parameters.AddWithValue("@stockquan", numQuantity.Text);
                        cmd.Parameters.AddWithValue("@discount", numDiscount.Text);
                        cmd.Parameters.AddWithValue("@proizv", comboBoxProizv.Text);
                        cmd.Parameters.AddWithValue("@postav", comboBoxPostav.Text);
                        cmd.Parameters.AddWithValue("@id", _row["ProductId"]);
                        cmd.Parameters.AddWithValue("@photo", pictureBoxPhoto.Tag ?? _row["Photo"]);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Сохранено!");
                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex);
            }
        }
    }
}