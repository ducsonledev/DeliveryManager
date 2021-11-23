using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using static BackgroundLieferandoApiAsyncRequests.ConsumeAPIs;

namespace BackgroundLieferandoApiAsyncRequests
{
    public partial class FormRequest : Form
    {
        public DataTable GlobalDataTable { get; set; }
        public FormRequest()
        {
            InitializeComponent();
            backgroundWorker.WorkerReportsProgress = true; // TODO: false?
            backgroundWorker.WorkerSupportsCancellation = true; // TODO: false?
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //BackgroundWorker worker = sender as BackgroundWorker;
            InitializeGlobalDataTable();
            while (true)
            {
                if (backgroundWorker.CancellationPending == true)
                {
                    e.Cancel = true;
                    return;
                }

                var LieferandoOrders = LieferandoRequest(
                    Properties.Settings.Default.RestaurantId,
                    Properties.Settings.Default.ApiKey,
                    Properties.Settings.Default.Username,
                    Properties.Settings.Default.Password
                    ); // credentials for testing sandboxapi

                if (LieferandoOrders == null)
                {
                    MessageBox.Show(
                        "Leider ist ein Fehler aufgetreten! Bitte überprüfen Sie nochmal Ihre Einstellungen und starten Sie den Vorgang erneut."
                        );
                    e.Cancel = true;
                    return;
                }

                PopulateDataGridViewOrders(LieferandoOrders);
                //UpdateStatusColors();
                // TODO: post only if new
                PostOwnOrders(LieferandoOrders);
                Thread.Sleep(Properties.Settings.Default.OrdersInterval);
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // still for testing, should be changed when it works, but probably never reached?
            // First, handle the case where an exception was thrown.
            if (e.Error != null)
            {
                //MessageBox.Show(e.Error.Message);
                resultLabel.Text = "Error: " + e.Error.Message;
            }
            if (e.Cancelled == true)
            {
                resultLabel.Text = "Requests canceled!";
                resultLabel.ForeColor = Color.Red;
            }
            else
            {
                resultLabel.Text = "Requests completed!";
            }

            resultLabel.TextAlign = ContentAlignment.MiddleCenter;

            //for testing
            // Enable the Start button.
            btnStart.Enabled = true;

            // Disable the Cancel button.
            btnCancel.Enabled = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            backgroundWorker.RunWorkerAsync();
            resultLabel.Text = "Requesting orders from Lieferando again!";
            resultLabel.ForeColor = Color.Green;
            btnCancel.Enabled = true;
            MessageBox.Show("Start Clicked!"); // for testing
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                backgroundWorker.CancelAsync();
                MessageBox.Show("Canceled Clicked! Please wait " + Properties.Settings.Default.OrdersInterval + " until new check for pending status starts."); // message for testing
            }
        }

        private void FormRequest_Load(object sender, EventArgs e)
        {
            backgroundWorker.RunWorkerAsync();
            // for changing enable state of buttons to send status of orders
            DataGridViewFormRequest.SelectionChanged += DataGridViewFormRequest_SelectionChanged;
            resultLabel.Text = "Requesting orders from Lieferando!"; // for testing
        }

        private void button15min_Click(object sender, EventArgs e)
        {
            UpdateStatus(DataGridViewFormRequest.CurrentCell.RowIndex, 1, "");
        }

        private void button20min_Click(object sender, EventArgs e)
        {
            UpdateStatus(DataGridViewFormRequest.CurrentCell.RowIndex, 1, "");
        }

        private void button30min_Click(object sender, EventArgs e)
        {
            UpdateStatus(DataGridViewFormRequest.CurrentCell.RowIndex, 1, "");
        }

        private void button45min_Click(object sender, EventArgs e)
        {
            UpdateStatus(DataGridViewFormRequest.CurrentCell.RowIndex, 1, "");
        }

        private void button60min_Click(object sender, EventArgs e)
        {
            UpdateStatus(DataGridViewFormRequest.CurrentCell.RowIndex, 1, "");
        }

        private void buttonZubereitungStart_Click(object sender, EventArgs e)
        {
            UpdateStatus(DataGridViewFormRequest.CurrentCell.RowIndex, 2, "");
        }

        private void buttonLieferungStart_Click(object sender, EventArgs e)
        {
            UpdateStatus(DataGridViewFormRequest.CurrentCell.RowIndex, 3, "");
        }
        private void buttonLieferungAbschließen_Click(object sender, EventArgs e)
        {
            UpdateStatus(DataGridViewFormRequest.CurrentCell.RowIndex, 4, "");
        }

        private void buttonDetails_Click(object sender, EventArgs e)
        {
            var formDetails = new FormDetails(GlobalDataTable, DataGridViewFormRequest.CurrentCell.RowIndex);
            formDetails.ShowDialog();
        }

        private void DataGridViewFormRequest_SelectionChanged(object sender, EventArgs e)
        {
            // Zero state handling
            if (DataGridViewFormRequest == null)
                return;

            // To manage to ability to only send certain status orders based on current status of the selected row.
            int status = int.Parse(DataGridViewFormRequest.Rows[DataGridViewFormRequest.CurrentCell.RowIndex].Cells["Status"].Value.ToString());
            UpdateButtonsEnableState(status);
        }

        private void InitializeGlobalDataTable()
        {
            // creating DataTable for our DataGridView
            GlobalDataTable = new DataTable("TodaysOrders" + DateTime.Now.Date);
            // identify orders
            GlobalDataTable.Columns.Add("Id", typeof(string));
            // DataGridView headers
            GlobalDataTable.Columns.Add("Start", typeof(string));
            GlobalDataTable.Columns.Add("Ende", typeof(string));
            GlobalDataTable.Columns.Add("Name", typeof(string));
            GlobalDataTable.Columns.Add("Straße", typeof(string));
            GlobalDataTable.Columns.Add("Ort", typeof(string));
            GlobalDataTable.Columns.Add("Telefon", typeof(string));
            GlobalDataTable.Columns.Add("Summe", typeof(string));
            GlobalDataTable.Columns.Add("Status", typeof(int)); // TODO: no status encoding
            GlobalDataTable.Columns.Add("Kasse", typeof(string));
            GlobalDataTable.Columns.Add("Datum", typeof(string));
            // hidden information for FormDetails
            GlobalDataTable.Columns.Add("PLZ", typeof(string));
            GlobalDataTable.Columns.Add("Zusatz", typeof(string));
            GlobalDataTable.Columns.Add("Lieferung", typeof(string));
            GlobalDataTable.Columns.Add("Lieferkosten", typeof(string));
            GlobalDataTable.Columns.Add("Rabatt", typeof(string));
            GlobalDataTable.Columns.Add("Info", typeof(string));
            GlobalDataTable.Columns.Add("Bezahlt", typeof(string));
            GlobalDataTable.Columns.Add("Produkte", typeof(List<Product>));
            GlobalDataTable.Columns.Add("Rabattgutscheine", typeof(List<Discount>));

            // hide columns for clearer UI, only show necessary headers to the user
            GlobalDataTable.Columns[0].ColumnMapping = MappingType.Hidden;
            GlobalDataTable.Columns[11].ColumnMapping = MappingType.Hidden;
            GlobalDataTable.Columns[12].ColumnMapping = MappingType.Hidden;
            GlobalDataTable.Columns[13].ColumnMapping = MappingType.Hidden;
            GlobalDataTable.Columns[14].ColumnMapping = MappingType.Hidden;
            GlobalDataTable.Columns[15].ColumnMapping = MappingType.Hidden;
            GlobalDataTable.Columns[16].ColumnMapping = MappingType.Hidden;
            GlobalDataTable.Columns[17].ColumnMapping = MappingType.Hidden;
            GlobalDataTable.Columns[18].ColumnMapping = MappingType.Hidden;
            GlobalDataTable.Columns[19].ColumnMapping = MappingType.Hidden;
        }

        private bool PopulateDataGridViewOrders(LieferandoOrders lieferandoOrders)
        {
            bool populated = false;
            foreach (var order in lieferandoOrders.orders)
            {
                var selectedRows = GlobalDataTable.Select("Id = '" + order.id + "'");
                if (selectedRows.Length != 0)
                    continue;

                // code reached, only orders that are new to the data table will be added
                var reqDeliverytime = ConvertToOwnDateTime(order.requestedDeliveryTime.ToString(), true);
                GlobalDataTable.Rows.Add(
                    order.id,
                    order.orderDate.ToString("HH:mm:ss"),
                    reqDeliverytime, // TODO: adding delivery time to start time when clicking time buttons 
                                     // TODO: automatic delivery time
                    order.customer.name,
                    order.customer.street + " " + order.customer.streetNumber,
                    order.customer.city,
                    order.customer.phoneNumber,
                    order.totalPrice.ToString("0.00"),
                    InitializeStatus(reqDeliverytime),
                    Properties.Settings.Default.Kasse,
                    order.orderDate.ToString("dd/MM/yyyy"),
                    order.customer.postalCode,
                    order.customer.extraAddressInfo,
                    (order.orderType == "delivery") ? "ja" : "nein",
                    order.deliveryCosts.ToString("0.00"),
                    order.totalDiscount.ToString("0.00"),
                    order.remark,
                    order.isPaid ? "ja" : "nein",
                    order.products,
                    order.discounts
                );
                // TODO: but not filtering specific orders that should be posted to our server
                populated = true;
            }
            UpdateDataGridViewSource(GlobalDataTable);
            UpdateStatusColors();
            return populated;
        }

        // create a method to handle updating the datasource
        // Layout: https://stackoverflow.com/questions/52992223/c-sharp-update-datagridview-from-backgroundworker
        public void UpdateDataGridViewSource(object data)
        {
            // check if we need to swap thread context
            if (DataGridViewFormRequest.InvokeRequired)
            {
                // we aren't on the UI thread. Ask the UI thread to do stuff.
                DataGridViewFormRequest.Invoke(new Action(() => UpdateDataGridViewSource(data)));
            }
            else
            {
                // we are on the UI thread. We are free to touch things.
                DataGridViewFormRequest.DataSource = data;
                // Resize the DataGridView columns to fit the newly loaded data.
                DataGridViewFormRequest.AutoResizeColumns();
            }
        }

        //
        // TODO: UpdateStatus in general -> post status update and update row color call
        // use with currently selected row
        //
        private bool UpdateStatus(int currRowIdx, int status, string deliveryTime)
        {
            bool success = true; // post successfully send
            // TODO: switch status
            GlobalDataTable.Rows[currRowIdx].SetField("Status", status);
            // TODO: call PostUpdateStatus from ConsumeAPIs.cs, pass whats needed for json id key status ...
            // overload methods? or dict?
            UpdateStatusColors();
            if(success) UpdateButtonsEnableState(status);
            return success;
        }

        // Highlights the rows in specific color according to the changes in status send to Lieferando.
        // Documentation: https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.datagridview.selectionchanged?redirectedfrom=MSDN&view=windowsdesktop-6.0
        private void UpdateStatusColors()
        {
            int status;
            // Iterate through the rows.
            for (int i = 0; i < DataGridViewFormRequest.Rows.Count; i++)
            {
                status = int.Parse(DataGridViewFormRequest.Rows[i].Cells["Status"].Value.ToString());
                switch (status)
                {
                    // Status 0: The order was printed by a restaurant. (printed)
                    case 0:
                        DataGridViewFormRequest.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        DataGridViewFormRequest.Rows[i].DefaultCellStyle.SelectionBackColor = Color.White;
                        break;
                    // Status 1: The order was confirmed with a change in delivery time. (confirmed_change_delivery_time)
                    case 1:
                        DataGridViewFormRequest.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 192);
                        DataGridViewFormRequest.Rows[i].DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 255, 192);
                        break;
                    // Status 2: The restaurant started preparing the order. (kitchen)
                    case 2:
                        DataGridViewFormRequest.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 192);
                        DataGridViewFormRequest.Rows[i].DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 192, 192);
                        break;
                    // Status 3: The order is in delivery by a courier. (in_delivery)
                    case 3:
                        DataGridViewFormRequest.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 192);
                        DataGridViewFormRequest.Rows[i].DefaultCellStyle.SelectionBackColor = Color.FromArgb(192, 255, 192);
                        break;
                    // Status 4: The order has been delivered by a courier. (delivered)
                    case 4:
                        DataGridViewFormRequest.Rows[i].DefaultCellStyle.BackColor = Color.DarkGray;
                        DataGridViewFormRequest.Rows[i].DefaultCellStyle.SelectionBackColor = Color.DarkGray;
                        break;

                    default:
                        break;
                }
                // To make sure color on selection is black.
                DataGridViewFormRequest.Rows[i].DefaultCellStyle.SelectionForeColor = Color.Black;
            }
        }

        private void UpdateButtonsEnableState(int status)
        {
            switch (status)
            {
                // Status 0: The order was printed by a restaurant. (printed)
                case 0:
                    panelLieferzeitSenden.Enabled = true;
                    buttonZubereitungStart.Enabled = false;
                    buttonLieferungStart.Enabled = false;
                    buttonLieferungAbschließen.Enabled = false;
                    break;
                // Status 1: The order was confirmed with a change in delivery time. (confirmed_change_delivery_time)
                case 1:
                    panelLieferzeitSenden.Enabled = false;
                    buttonZubereitungStart.Enabled = true;
                    buttonLieferungStart.Enabled = false;
                    buttonLieferungAbschließen.Enabled = false;
                    break;
                // Status 2: The restaurant started preparing the order. (kitchen)
                case 2:
                    panelLieferzeitSenden.Enabled = false;
                    buttonZubereitungStart.Enabled = false;
                    buttonLieferungStart.Enabled = true;
                    buttonLieferungAbschließen.Enabled = false;
                    break;
                // Status 3: The order is in delivery by a courier. (in_delivery)
                case 3:
                    panelLieferzeitSenden.Enabled = false;
                    buttonZubereitungStart.Enabled = false;
                    buttonLieferungStart.Enabled = false;
                    buttonLieferungAbschließen.Enabled = true;
                    break;
                // Status 4: The order has been delivered by a courier. (delivered)
                case 4:
                    panelLieferzeitSenden.Enabled = false;
                    buttonZubereitungStart.Enabled = false;
                    buttonLieferungStart.Enabled = false;
                    buttonLieferungAbschließen.Enabled = false;
                    break;

                default:
                    panelLieferzeitSenden.Enabled = false;
                    buttonZubereitungStart.Enabled = false;
                    buttonLieferungStart.Enabled = false;
                    buttonLieferungAbschließen.Enabled = false;
                    break;
            }
        }

        // Function to convert various string representations of dates and times to DateTime values
        // and returns it in format "HH:mm:ss" if time set to true(default false). 
        private string ConvertToOwnDateTime(string value, bool time = false)
        {
            try
            {
                return time ? Convert.ToDateTime(value).ToString("HH:mm:ss") :
                    Convert.ToDateTime(value).ToString("dd/MM/yyyy HH:mm:ss");
            }
            catch (FormatException)
            {
                Console.WriteLine("'{0}' is not in the proper format.", value);
                return string.Empty;
            }
        }

        // TODO maybe: no status encoding
        private int InitializeStatus(string reqDeliveryTime)
        {
            // Post Update Status when 1
            return reqDeliveryTime == string.Empty ? 0 : 1; // 0 "Neu eingegangen" : 1 "Lieferzeit mitgeteilt";
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            labelTimeNow.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
        }

        //
        // TODO: Automatische Statusänderung nach Schema
        // -> TODO: Schema überlegen. (f.e. Lieferzeit 30, nach 10 min Lieferung starten)
        //
    }
}

