using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DemoSam
{
    public class OrderEditForm : Form
    {
        private readonly string _connString;
        private readonly int? _orderDetailsId;

        private DateTimePicker _dateOrder;
        private DateTimePicker _dateDelivery;
        private TextBox _status;
        private ComboBox _pickUp;
        private ComboBox _product;
        private NumericUpDown _quantity;
        private NumericUpDown _userId;

        public OrderEditForm(string connString, int? orderDetailsId = null)
        {
            _connString = connString;
            _orderDetailsId = orderDetailsId;
            BuildUi();
            LoadData();
        }

        private void BuildUi()
        {
            Text = _orderDetailsId.HasValue ? "Редактирование заказа" : "Добавление заказа";
            Width = 460;
            Height = 420;
            StartPosition = FormStartPosition.CenterParent;

            Label lblDateOrder = new Label { Left = 20, Top = 20, Width = 180, Text = "Дата заказа" };
            _dateOrder = new DateTimePicker { Left = 20, Top = 42, Width = 190 };

            Label lblDateDelivery = new Label { Left = 230, Top = 20, Width = 180, Text = "Дата доставки" };
            _dateDelivery = new DateTimePicker { Left = 230, Top = 42, Width = 190 };

            Label lblStatus = new Label { Left = 20, Top = 85, Width = 180, Text = "Статус" };
            _status = new TextBox { Left = 20, Top = 107, Width = 400 };

            Label lblPick = new Label { Left = 20, Top = 145, Width = 180, Text = "Пункт выдачи" };
            _pickUp = new ComboBox { Left = 20, Top = 167, Width = 400, DropDownStyle = ComboBoxStyle.DropDownList };

            Label lblProduct = new Label { Left = 20, Top = 205, Width = 180, Text = "Товар" };
            _product = new ComboBox { Left = 20, Top = 227, Width = 400, DropDownStyle = ComboBoxStyle.DropDownList };

            Label lblQuantity = new Label { Left = 20, Top = 265, Width = 180, Text = "Количество" };
            _quantity = new NumericUpDown { Left = 20, Top = 287, Width = 190, Minimum = 1, Maximum = 100000 };

            Label lblUser = new Label { Left = 230, Top = 265, Width = 180, Text = "ID пользователя" };
            _userId = new NumericUpDown { Left = 230, Top = 287, Width = 190, Minimum = 1, Maximum = 100000 };

            Button save = new Button { Left = 240, Top = 330, Width = 180, Text = "Сохранить" };
            save.Click += Save_Click;
            Button cancel = new Button { Left = 20, Top = 330, Width = 180, Text = "Отмена" };
            cancel.Click += (s, e) => Close();

            Controls.Add(lblDateOrder);
            Controls.Add(_dateOrder);
            Controls.Add(lblDateDelivery);
            Controls.Add(_dateDelivery);
            Controls.Add(lblStatus);
            Controls.Add(_status);
            Controls.Add(lblPick);
            Controls.Add(_pickUp);
            Controls.Add(lblProduct);
            Controls.Add(_product);
            Controls.Add(lblQuantity);
            Controls.Add(_quantity);
            Controls.Add(lblUser);
            Controls.Add(_userId);
            Controls.Add(save);
            Controls.Add(cancel);
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                conn.Open();

                DataTable pickUpData = new DataTable();
                using (SqlDataAdapter ad = new SqlDataAdapter("select PickUpPointId, Address from PickUpPoint", conn))
                {
                    ad.Fill(pickUpData);
                }
                _pickUp.DataSource = pickUpData;
                _pickUp.DisplayMember = "Address";
                _pickUp.ValueMember = "PickUpPointId";

                DataTable productData = new DataTable();
                using (SqlDataAdapter ad = new SqlDataAdapter("select ProductId, ProductName from Product", conn))
                {
                    ad.Fill(productData);
                }
                _product.DataSource = productData;
                _product.DisplayMember = "ProductName";
                _product.ValueMember = "ProductId";

                if (_orderDetailsId.HasValue)
                {
                    string query = @"select o.OrdersId, o.Date, o.DateDelivery, o.OrdersStatus, o.PickUpPointId, o.UserId,
                                            od.ProductId, od.Quantity
                                     from OrdersDetails od
                                     join Orders o on o.OrdersId = od.OrdersId
                                     where od.OrderDetailsId = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", _orderDetailsId.Value);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                _dateOrder.Value = Convert.ToDateTime(reader["Date"]);
                                _dateDelivery.Value = Convert.ToDateTime(reader["DateDelivery"]);
                                _status.Text = reader["OrdersStatus"].ToString();
                                _pickUp.SelectedValue = Convert.ToInt32(reader["PickUpPointId"]);
                                _product.SelectedValue = Convert.ToInt32(reader["ProductId"]);
                                _quantity.Value = Convert.ToDecimal(reader["Quantity"]);
                                _userId.Value = Convert.ToDecimal(reader["UserId"]);
                            }
                        }
                    }
                }
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                conn.Open();
                if (_orderDetailsId.HasValue)
                {
                    int orderId;
                    using (SqlCommand getCmd = new SqlCommand("select OrdersId from OrdersDetails where OrderDetailsId = @id", conn))
                    {
                        getCmd.Parameters.AddWithValue("@id", _orderDetailsId.Value);
                        orderId = Convert.ToInt32(getCmd.ExecuteScalar());
                    }

                    using (SqlCommand orderCmd = new SqlCommand(@"update Orders set Date = @dateOrder, DateDelivery = @dateDelivery,
                                                                  OrdersStatus = @status, PickUpPointId = @pick, UserId = @userId
                                                                  where OrdersId = @orderId", conn))
                    {
                        orderCmd.Parameters.AddWithValue("@dateOrder", _dateOrder.Value);
                        orderCmd.Parameters.AddWithValue("@dateDelivery", _dateDelivery.Value);
                        orderCmd.Parameters.AddWithValue("@status", _status.Text);
                        orderCmd.Parameters.AddWithValue("@pick", _pickUp.SelectedValue);
                        orderCmd.Parameters.AddWithValue("@userId", Convert.ToInt32(_userId.Value));
                        orderCmd.Parameters.AddWithValue("@orderId", orderId);
                        orderCmd.ExecuteNonQuery();
                    }

                    using (SqlCommand detailsCmd = new SqlCommand(@"update OrdersDetails set ProductId = @product, Quantity = @quantity
                                                                    where OrderDetailsId = @detailsId", conn))
                    {
                        detailsCmd.Parameters.AddWithValue("@product", _product.SelectedValue);
                        detailsCmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(_quantity.Value));
                        detailsCmd.Parameters.AddWithValue("@detailsId", _orderDetailsId.Value);
                        detailsCmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    using (SqlTransaction tx = conn.BeginTransaction())
                    {
                        int newOrderId;

                        using (SqlCommand orderCmd = new SqlCommand(
                            @"insert into Orders(Date, DateDelivery, PickUpPointId, UserId, CodePolychenie, OrdersStatus)
                              output inserted.OrdersId
                              values (@dateOrder, @dateDelivery, @pick, @userId, @code, @status)", conn, tx))
                        {
                            orderCmd.Parameters.AddWithValue("@dateOrder", _dateOrder.Value);
                            orderCmd.Parameters.AddWithValue("@dateDelivery", _dateDelivery.Value);
                            orderCmd.Parameters.AddWithValue("@pick", _pickUp.SelectedValue);
                            orderCmd.Parameters.AddWithValue("@userId", Convert.ToInt32(_userId.Value));
                            orderCmd.Parameters.AddWithValue("@code", "0");
                            orderCmd.Parameters.AddWithValue("@status", _status.Text);
                            newOrderId = Convert.ToInt32(orderCmd.ExecuteScalar());
                        }

                        using (SqlCommand updateCode = new SqlCommand(
                            @"update Orders set CodePolychenie = @code where OrdersId = @id", conn, tx))
                        {
                            updateCode.Parameters.AddWithValue("@code", newOrderId.ToString());
                            updateCode.Parameters.AddWithValue("@id", newOrderId);
                            updateCode.ExecuteNonQuery();
                        }

                        using (SqlCommand detailsCmd = new SqlCommand(
                            @"insert into OrdersDetails(OrdersId, ProductId, Quantity)
                              values (@orderId, @product, @quantity)", conn, tx))
                        {
                            detailsCmd.Parameters.AddWithValue("@orderId", newOrderId);
                            detailsCmd.Parameters.AddWithValue("@product", _product.SelectedValue);
                            detailsCmd.Parameters.AddWithValue("@quantity", Convert.ToInt32(_quantity.Value));
                            detailsCmd.ExecuteNonQuery();
                        }

                        tx.Commit();
                    }
                }
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // OrderEditForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "OrderEditForm";
            this.Load += new System.EventHandler(this.OrderEditForm_Load);
            this.ResumeLayout(false);

        }

        private void OrderEditForm_Load(object sender, EventArgs e)
        {

        }
    }
}
