using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DemoSam
{
    public partial class DetailProduct : Form
    {
        private string connString = @"Server = localhost    ; DataBase = shose_store_sam; Trusted_Connection = True;";
        private readonly bool _isCreateMode;
        private readonly DataRow _row;
        private string _oldPhotoFileName;
        private string _newPhotoFileName;
        private bool _photoChanged;
        private static DetailProduct _openedEditor;

        private static Image LoadImageNoLock(string path)
        {
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var img = Image.FromStream(fs))
            {
                return new Bitmap(img);
            }
        }

        private static void DisposePictureBoxImage(PictureBox pb)
        {
            var old = pb.Image;
            pb.Image = null;
            old?.Dispose();
        }

        public DetailProduct(DataRow row)
        {
            InitializeComponent();
            _row = row;
            _isCreateMode = false;
            _openedEditor = this;
        }

        public DetailProduct()
        {
            InitializeComponent();
            _isCreateMode = true;
            _openedEditor = this;
        }

        public static bool TryActivateOpenedEditor()
        {
            if (_openedEditor != null && !_openedEditor.IsDisposed)
            {
                _openedEditor.Activate();
                _openedEditor.BringToFront();
                return true;
            }

            return false;
        }

        private void DetailProduct_Load(object sender, EventArgs e)
        {
            loadComboBox();

            if (_isCreateMode)
            {
                labelIdProduct.Visible = false;
                buttonDelete.Visible = false;
                pictureBoxPhoto.Image = Properties.Resources.picture;
            }
            else
            {
                labelIdProduct.Visible = true;
                LoadProductById(Convert.ToInt32(_row["ProductId"]));
                buttonDelete.Visible = true;
            }

            pictureBoxPhoto.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void loadComboBox()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string selectProizvoditel = @"select ProivzoditelName from Proivzoditel;";
                string selectPostavchik = @"select PostavchikName from Postavchik;";
                string selectCategory = @"select Name from Categori;";

                comboBoxPostav.Items.Clear();
                comboBoxProizv.Items.Clear();

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
                using (var cmd = new SqlCommand(selectCategory, conn))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (!textBoxCategory.AutoCompleteCustomSource.Contains(reader["Name"].ToString().Trim()))
                        {
                            textBoxCategory.AutoCompleteCustomSource.Add(reader["Name"].ToString().Trim());
                        }
                    }
                    reader.Close();
                }
            }

            textBoxCategory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBoxCategory.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void LoadProductById(int productId)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = @"select p.ProductId, p.ProductName, p.Description, p.Units, p.Price, p.StockQuantity, p.Discount,
                                        p.Photo, c.Name as Category, pro.ProivzoditelName, post.PostavchikName
                                 from Product p
                                 left join Categori c on p.CategoriId = c.CategoriId
                                 left join Proivzoditel pro on p.ProivzoditelId = pro.ProivzoditelId
                                 left join Postavchik post on p.PostavchikId = post.PostavchikId
                                 where p.ProductId = @id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", productId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            labelIdProduct.Text = "Id продукта: " + reader["ProductId"].ToString();
                            textBoxName.Text = reader["ProductName"].ToString();
                            textBoxCategory.Text = reader["Category"].ToString();
                            textBoxDescription.Text = reader["Description"].ToString();
                            txtUnits.Text = reader["Units"].ToString();
                            textBoxPrice.Text = reader["Price"].ToString();
                            comboBoxProizv.Text = reader["ProivzoditelName"] == DBNull.Value ? "" : reader["ProivzoditelName"].ToString().Trim();
                            comboBoxPostav.Text = reader["PostavchikName"] == DBNull.Value ? "" : reader["PostavchikName"].ToString().Trim();
                            numQuantity.Text = reader["StockQuantity"].ToString();
                            numDiscount.Text = reader["Discount"].ToString();
                            _oldPhotoFileName = reader["Photo"] == DBNull.Value ? null : reader["Photo"].ToString();

                            if (!string.IsNullOrWhiteSpace(_oldPhotoFileName))
                            {
                                try
                                {
                                    string path = $"..\\..\\image\\{_oldPhotoFileName}";
                                    pictureBoxPhoto.Image = File.Exists(path) ? LoadImageNoLock(path) : Properties.Resources.picture;
                                }
                                catch
                                {
                                    pictureBoxPhoto.Image = Properties.Resources.picture;
                                }
                            }
                            else
                            {
                                pictureBoxPhoto.Image = Properties.Resources.picture;
                            }
                        }
                    }
                }
            }
        }

        private int GetNextProductId()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("select isnull(max(ProductId), 0) + 1 from Product", conn))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
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
                    DisposePictureBoxImage(pictureBoxPhoto);
                    using (Bitmap original = new Bitmap(openFileDialog.FileName))
                    {
                        Bitmap resized = new Bitmap(300, 200);
                        using (Graphics graphics = Graphics.FromImage(resized))
                        {
                            graphics.Clear(Color.White);
                            graphics.DrawImage(original, 0, 0, 300, 200);
                        }

                        pictureBoxPhoto.Image = resized;
                    }

                    string ext = Path.GetExtension(openFileDialog.FileName);
                    _newPhotoFileName = $"{Guid.NewGuid():N}{ext}";
                    _photoChanged = true;
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
                    int productId = _isCreateMode ? 0 : Convert.ToInt32(_row["ProductId"]);
                    decimal price;
                    if (!decimal.TryParse(textBoxPrice.Text, out price))
                    {
                        MessageBox.Show("Цена указана неверно.");
                        return;
                    }

                    string photoToSave = SavePhotoIfNeeded();

                    string query;
                    if (_isCreateMode)
                    {
                        query = @"insert into Product (Article, ProductName, Units, Price, PostavchikId, ProivzoditelId, CategoriId, Discount, StockQuantity, Description, Photo)
                                  output inserted.ProductId
                                  values (@article, @name, @units, @price,
                                          (Select PostavchikId from Postavchik WHERE PostavchikName = @postav),
                                          (Select ProivzoditelId from Proivzoditel WHERE ProivzoditelName = @proizv),
                                          (Select CategoriId from Categori WHERE Name = @category),
                                          @discount, @stockquan, @desc, @photo)";
                    }
                    else
                    {
                        query = @"Update Product SET
                                  ProductName = @name, Description = @desc, Price = @price, Units = @units, StockQuantity = @stockquan,
                                  Discount = @discount, ProivzoditelId = (Select ProivzoditelId from Proivzoditel WHERE ProivzoditelName = @proizv),
                                  PostavchikId = (Select PostavchikId from Postavchik WHERE PostavchikName = @postav),
                                  CategoriId = (Select CategoriId from Categori WHERE Name = @category),
                                  Photo = @photo
                                  WHERE ProductId = @id";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!_isCreateMode)
                        {
                            cmd.Parameters.AddWithValue("@id", productId);
                        }

                        int article = _isCreateMode ? GetNextProductId() : productId;
                        cmd.Parameters.AddWithValue("@article", article);
                        cmd.Parameters.AddWithValue("@name", textBoxName.Text);
                        cmd.Parameters.AddWithValue("@desc", textBoxDescription.Text);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@units", txtUnits.Text);
                        cmd.Parameters.AddWithValue("@stockquan", Convert.ToInt32(numQuantity.Value));
                        cmd.Parameters.AddWithValue("@discount", Convert.ToInt32(numDiscount.Value));
                        cmd.Parameters.AddWithValue("@proizv", comboBoxProizv.Text);
                        cmd.Parameters.AddWithValue("@postav", comboBoxPostav.Text);
                        cmd.Parameters.AddWithValue("@category", textBoxCategory.Text);
                        cmd.Parameters.AddWithValue("@photo", (object)photoToSave ?? DBNull.Value);

                        if (_isCreateMode)
                        {
                            productId = Convert.ToInt32(cmd.ExecuteScalar());
                            using (SqlCommand fixArticle = new SqlCommand("update Product set Article = @a where ProductId = @id", conn))
                            {
                                fixArticle.Parameters.AddWithValue("@a", productId);
                                fixArticle.Parameters.AddWithValue("@id", productId);
                                fixArticle.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }

                    if (_photoChanged && !string.IsNullOrWhiteSpace(_oldPhotoFileName) && _oldPhotoFileName != _newPhotoFileName)
                    {
                        // гарантируем, что старый Image освобожден
                        DisposePictureBoxImage(pictureBoxPhoto);
                        string oldPath = Path.Combine("..\\..\\image", _oldPhotoFileName);
                        if (File.Exists(oldPath))
                        {
                            File.Delete(oldPath);
                        }
                    }

                    MessageBox.Show("Сохранено!");
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex);
            }
        }

        private string SavePhotoIfNeeded()
        {
            if (!_photoChanged || pictureBoxPhoto.Image == null || string.IsNullOrWhiteSpace(_newPhotoFileName))
            {
                return _isCreateMode ? null : _oldPhotoFileName;
            }

            string imageDir = "..\\..\\image";
            if (!Directory.Exists(imageDir))
            {
                Directory.CreateDirectory(imageDir);
            }

            string path = Path.Combine(imageDir, _newPhotoFileName);
            ImageFormat format = ImageFormat.Png;
            string ext = Path.GetExtension(_newPhotoFileName)?.ToLowerInvariant();
            if (ext == ".jpg" || ext == ".jpeg")
            {
                format = ImageFormat.Jpeg;
            }
            pictureBoxPhoto.Image.Save(path, format);
            return _newPhotoFileName;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (_isCreateMode)
            {
                return;
            }

            int productId = Convert.ToInt32(_row["ProductId"]);
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand checkCmd = new SqlCommand("select count(*) from OrdersDetails where ProductId = @id", conn))
                {
                    checkCmd.Parameters.AddWithValue("@id", productId);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("Нельзя удалить товар, который присутствует в заказе.");
                        return;
                    }
                }

                if (MessageBox.Show("Удалить товар?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                using (SqlCommand deleteCmd = new SqlCommand("delete from Product where ProductId = @id", conn))
                {
                    deleteCmd.Parameters.AddWithValue("@id", productId);
                    deleteCmd.ExecuteNonQuery();
                }
            }

            if (!string.IsNullOrWhiteSpace(_oldPhotoFileName))
            {
                string oldPath = Path.Combine("..\\..\\image", _oldPhotoFileName);
                if (File.Exists(oldPath))
                {
                    File.Delete(oldPath);
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (ReferenceEquals(_openedEditor, this))
            {
                _openedEditor = null;
            }
        }
    }
}