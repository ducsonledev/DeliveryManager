using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using static BackgroundLieferandoApiAsyncRequests.ConsumeAPIs;
using System.Diagnostics; // for testing performance

namespace BackgroundLieferandoApiAsyncRequests
{
    public partial class FormRequest : Form
    {
        public DataTable GlobalDataTable { get; set; }
        public DataTable GlobalFinishedOrdersDataTable { get; set; }
        public FormRequest()
        {
            InitializeComponent();
            backgroundWorker.WorkerReportsProgress = true; // TODO: false? delete line?
            backgroundWorker.WorkerSupportsCancellation = true; // TODO: false? delete line?
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Initialize DataTable.
            InitializeGlobalDataTable();
            // TODO optimization: Initialize datagridview with columns?

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
                );

                if (LieferandoOrders == null)
                {
                    MessageBox.Show(
                        "Leider ist ein Fehler aufgetreten! Bitte überprüfen Sie nochmal Ihre Einstellungen (Settings) und starten Sie den Vorgang erneut."
                        );
                    e.Cancel = true;
                    return;
                }

                // only for new incoming orders we populate data and post to our server 
                if (LieferandoOrders.orders.Count != 0)
                {
                    PopulateDataGridViewOrders(LieferandoOrders);
                    PostOwnOrders(LieferandoOrders);
                }

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

        // TODO later: clean up.
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
            // event handling for closing this form
            Closing += FormRequest_Closing;
            resultLabel.Text = "Requesting orders from Lieferando!"; // for testing
        }

        private void FormRequest_Closing(object sender, CancelEventArgs e)
        {
            MessageBox.Show("Closing form!");

            GlobalDataTable.WriteXml(GlobalDataTable.TableName + ".xml");
            GlobalFinishedOrdersDataTable.WriteXml(GlobalFinishedOrdersDataTable.TableName + ".xml");
        }

        private void button15min_Click(object sender, EventArgs e)
        {
            // Handling Zero state.
            if (DataGridViewFormRequest.Rows.Count == 0)
                return;

            UpdateStatus_OnClick(DataGridViewFormRequest.CurrentCell.RowIndex, 1, new TimeSpan(0, 15, 0));
        }

        private void button20min_Click(object sender, EventArgs e)
        {
            // Handling Zero state.
            if (DataGridViewFormRequest.Rows.Count == 0)
                return;

            UpdateStatus_OnClick(DataGridViewFormRequest.CurrentCell.RowIndex, 1, new TimeSpan(0, 20, 0));
        }

        private void button30min_Click(object sender, EventArgs e)
        {
            // Handling Zero state.
            if (DataGridViewFormRequest.Rows.Count == 0)
                return;

            UpdateStatus_OnClick(DataGridViewFormRequest.CurrentCell.RowIndex, 1, new TimeSpan(0, 30, 0));
        }

        private void button45min_Click(object sender, EventArgs e)
        {
            // Handling Zero state.
            if (DataGridViewFormRequest.Rows.Count == 0)
                return;

            UpdateStatus_OnClick(DataGridViewFormRequest.CurrentCell.RowIndex, 1, new TimeSpan(0, 45, 0));
        }

        private void button60min_Click(object sender, EventArgs e)
        {
            // Handling Zero state.
            if (DataGridViewFormRequest.Rows.Count == 0)
                return;

            UpdateStatus_OnClick(DataGridViewFormRequest.CurrentCell.RowIndex, 1, new TimeSpan(1, 0, 0));
        }

        private void buttonZubereitungStart_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();

            // Handling Zero state.
            if (DataGridViewFormRequest.Rows.Count == 0)
                return;

            UpdateStatus_OnClick(DataGridViewFormRequest.CurrentCell.RowIndex, 2, TimeSpan.Zero);

            sw.Stop();

            Console.WriteLine("Zubereitung starten - Elapsed={0}", sw.Elapsed);
        }

        private void buttonLieferungStart_Click(object sender, EventArgs e)
        {
            // Handling Zero state.
            if (DataGridViewFormRequest.Rows.Count == 0)
                return;

            UpdateStatus_OnClick(DataGridViewFormRequest.CurrentCell.RowIndex, 3, TimeSpan.Zero);
        }
        private void buttonLieferungAbschließen_Click(object sender, EventArgs e)
        {
            // Handling Zero state.
            if (DataGridViewFormRequest.Rows.Count == 0)
                return;

            UpdateStatus_OnClick(DataGridViewFormRequest.CurrentCell.RowIndex, 4, TimeSpan.Zero);
        }

        private void buttonDetails_Click(object sender, EventArgs e)
        {
            // Handling Zero state.
            if (DataGridViewFormRequest.Rows.Count == 0)
                return;

            var formDetails = new FormDetails(GlobalDataTable, DataGridViewFormRequest.CurrentCell.RowIndex);
            formDetails.ShowDialog();
        }

        private void DataGridViewFormRequest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handling Zero state.
            if (DataGridViewFormRequest.Rows.Count == 0)
                return;

            // Handle click on comlumn headers.
            if (DataGridViewFormRequest.CurrentCell == null)
                return;

            //DataGridViewFormRequest_SelectionChanged(sender, e);
            // To manage to ability to only send certain status orders based on current status of the selected row. issue with: .SelectedRows[0].Index
            int status = int.Parse(DataGridViewFormRequest.Rows[DataGridViewFormRequest.CurrentCell.RowIndex].Cells["Status"].Value.ToString());
            UpdateButtonsEnableState(status);
        }

        // Initialize both DataTables for open orders and finished orders.
        private void InitializeGlobalDataTable()
        {
            // Creating and initializing DataTables.
            GlobalDataTable = new DataTable() {
                Columns = { 
                    { "Start", typeof(string) }, 
                    { "Ende", typeof(string) },
                    { "Name", typeof(string) },
                    { "Straße", typeof(string) },
                    { "Ort", typeof(string) },
                    { "Telefon", typeof(string) },
                    { "Summe", typeof(string) },
                    { "Status", typeof(int) },
                    { "Kasse", typeof(string) },
                    { "Datum", typeof(string) },
                    { "PLZ", typeof(string) },
                    { "Zusatz", typeof(string) },
                    { "Lieferung", typeof(string) },
                    { "Lieferkosten", typeof(string) },
                    { "Rabatt", typeof(string) },
                    { "Info", typeof(string) },
                    { "Bezahlt", typeof(string) },
                    { "Produkte", typeof(string) },  // TODO: Generic List content not shown. (Solution: ToString() before printing/saving)
                    { "Rabattgutscheine", typeof(string) },  // TODO: Generic List content not shown. (Solution: ToString() before printing/saving)
                    { "Key", typeof(string) },
                    { "EndDateTime", typeof(string) },
                    { "Id", typeof(string) }
                }
            };
            GlobalFinishedOrdersDataTable = GlobalDataTable.Clone();
            // Setting DataTable names.
            GlobalDataTable.TableName = "TodaysOpenOrders" + DateTime.Now.ToString("s").Replace(":", "-");
            GlobalFinishedOrdersDataTable.TableName = "TodaysFinishedOrders" + DateTime.Now.ToString("s").Replace(":", "-");
        }

        private void PopulateDataGridViewOrders(LieferandoOrders lieferandoOrders)
        {
            foreach (var order in lieferandoOrders.orders)
            {
                var selectedRows = GlobalDataTable.Select("Id = '" + order.id + "'");
                if (selectedRows.Length != 0)
                    continue;
                // code reached, only orders that are new to the data table will be added
                var reqDeliverytime = ConvertToOwnDateTime(order.requestedDeliveryTime.ToString(), "timeonly");
                var reqDeliveryLieferandoTime = ConvertToOwnDateTime(order.requestedDeliveryTime.ToString(), "lieferando");
                int statusEncode = InitializeEncodedStatus(reqDeliverytime);
                GlobalDataTable.Rows.Add(
                    order.orderDate.ToString("HH:mm:ss"),
                    reqDeliverytime, // TODO later: adding automatic delivery time
                    order.customer.name,
                    order.customer.street + " " + order.customer.streetNumber,
                    order.customer.city,
                    order.customer.phoneNumber,
                    order.totalPrice.ToString("0.00"),
                    statusEncode,
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
                    order.discounts,
                    order.orderKey,
                    reqDeliveryLieferandoTime,
                    order.id
                );
                // Post update status for initial incoming orders
                var success = PostStatusUpdate(buildStatusUpdateObj(GlobalDataTable.Rows.Count - 1, statusEncode));
                // for incoming orders that already has requested delivery time, the status 0 and 1 will be send
                if (statusEncode == 1)
                    success = PostStatusUpdate(buildStatusUpdateObj(GlobalDataTable.Rows.Count - 1, statusEncode - 1));
                // TODO: success == false error handling??
                // recall automatically until it works?
                // message: check your internet connection in the meantime?
            }
            UpdateDataGridViewSource(GlobalDataTable);
            UpdateStatusColors();
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
                Stopwatch sw = new Stopwatch();

                sw.Start();

                // Adjust orders by seperating finished orders from open orders.
                AdjustDataTable();

                // We are on the UI thread. We are free to touch things in DataGridView.
                DataGridViewFormRequest.DataSource = data;

                // Data table is empty, then no need for more settings.
                if (DataGridViewFormRequest.Rows.Count == 0)
                    return;

                Stopwatch sw2 = new Stopwatch();
                sw2.Start();

                // Makes UI easier to read.
                AdjustDataGridView();

                sw2.Stop();
                Console.WriteLine("AdjustDataGridView Elapsed={0}", sw2.Elapsed);

                sw.Stop();

                Console.WriteLine("Update DataGridView data Elapsed={0}", sw.Elapsed);
            }

            
        }

        // Adjust orders by seperating finished orders from open orders.
        public void AdjustDataTable()
        {
            for (int i = 0; i < GlobalDataTable.Rows.Count; i++)
            {
                var dr = GlobalDataTable.Rows[i];
                if (dr.Field<int>("Status") == 4)
                {
                    GlobalFinishedOrdersDataTable.ImportRow(dr);
                    GlobalDataTable.Rows.Remove(dr);
                }
            }
        }

        // Adjust visibility, sorting or widths of columns and rows in DataGridView.
        private void AdjustDataGridView()
        {
            // Hide columns for clear UI.
            DataGridViewFormRequest.Columns["PLZ"].Visible = false;
            DataGridViewFormRequest.Columns["Zusatz"].Visible = false;
            DataGridViewFormRequest.Columns["Lieferung"].Visible = false;
            DataGridViewFormRequest.Columns["Lieferkosten"].Visible = false;
            DataGridViewFormRequest.Columns["Rabatt"].Visible = false;
            DataGridViewFormRequest.Columns["Info"].Visible = false;
            DataGridViewFormRequest.Columns["Bezahlt"].Visible = false;
            DataGridViewFormRequest.Columns["Produkte"].Visible = false;
            DataGridViewFormRequest.Columns["Rabattgutscheine"].Visible = false; 
            DataGridViewFormRequest.Columns["Key"].Visible = false;
            DataGridViewFormRequest.Columns["EndDateTime"].Visible = false;
            DataGridViewFormRequest.Columns["Id"].Visible = false;

            // Sets enable state of button senders.
            UpdateButtonsEnableState(GlobalDataTable.Rows[DataGridViewFormRequest.CurrentCell.RowIndex].Field<int>("Status"));

            // Disable sorting, to keep right status colors every time.
            foreach (DataGridViewColumn dgvc in DataGridViewFormRequest.Columns)
            {
                dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            // Resize the DataGridView columns to fit the newly loaded data.
            DataGridViewFormRequest.AutoResizeColumns();
        }

        // Updates the status when the user makes an action that triggers it.
        private bool UpdateStatus_OnClick(int currRowIdx, int status, TimeSpan deliveryTime)
        {
            // updates status in data table
            GlobalDataTable.Rows[currRowIdx].SetField("Status", status);
            // Sets new requestedDeliveryTime in DataTable if status is 1.
            if (status == 1)
            {
                var startTime = Convert.ToDateTime(GlobalDataTable.Rows[currRowIdx].Field<string>("Start"));
                var endTime = startTime.Add(deliveryTime);
                GlobalDataTable.Rows[currRowIdx].SetField("Ende", endTime.ToString("HH:mm:ss"));
                GlobalDataTable.Rows[currRowIdx].SetField("EndDateTime", endTime.ToString("s") + endTime.ToString("zzz"));
            }
            UpdateDataGridViewSource(GlobalDataTable);
            UpdateStatusColors();

            Stopwatch sw = new Stopwatch();

            sw.Start();

            var success = PostStatusUpdate(buildStatusUpdateObj(currRowIdx, status)); // testing

            sw.Stop();

            Console.WriteLine("PostStatusUpdate Elapsed={0}", sw.Elapsed);


            // for testing, since takeaway sandbox is currently not avaiable,
            // so post update status won't work
            success = true;
            if (success)
                // what if status updates at the moment are not possible,
                // UI should still be working as usual for user?
                // then it must be internet that has to be checked
                // or server down, which means no orders possible
                UpdateButtonsEnableState(status);
            //else
            //TODO: messagebox, error handling??


            return success;

            // TODO: or error handling after call in new method with context to current action?
        }

        //f.e.
        // {
        //      "id": "cae66b7e-791b-11e7-b4d8-3464a91febf3",
        //      "key": "D41D8CD98F00B204E9800998ECF8427E",
        //      "status": "confirmed_change_delivery_time",
        //      "changedDeliveryTime": "2020-02-04T19:45:00+02:00"
        // }
        private LieferandoStatusUpdates buildStatusUpdateObj(int currRowIdx, int status)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();

            LieferandoStatusUpdates newStatusUpdate = new LieferandoStatusUpdates(); // empty json
            var currRowData = GlobalDataTable.Rows[currRowIdx]; // need unknown data in grid
            switch (status)
            {
                // Status 0: The order was printed by a restaurant. (printed)
                case 0:
                    newStatusUpdate.id = currRowData.Field<string>("Id");
                    newStatusUpdate.key = currRowData.Field<string>("Key");
                    newStatusUpdate.status = "printed";

                    break;
                // Status 1: The order was confirmed with a change in delivery time. (confirmed_change_delivery_time)
                case 1:
                    newStatusUpdate.id = currRowData.Field<string>("Id");
                    newStatusUpdate.key = currRowData.Field<string>("Key");
                    newStatusUpdate.status = "confirmed_change_delivery_time";
                    newStatusUpdate.changedDeliveryTime = currRowData.Field<string>("EndDateTime");
                    break;
                // Status 2: The restaurant started preparing the order. (kitchen)
                case 2:
                    newStatusUpdate.id = currRowData.Field<string>("Id");
                    newStatusUpdate.key = currRowData.Field<string>("Key");
                    newStatusUpdate.status = "kitchen";
                    break;
                // Status 3: The order is in delivery by a courier. (in_delivery)
                case 3:
                    newStatusUpdate.id = currRowData.Field<string>("Id");
                    newStatusUpdate.key = currRowData.Field<string>("Key");
                    newStatusUpdate.status = "in_delivery";
                    break;
                // Status 4: The order has been delivered by a courier. (delivered)
                case 4:
                    newStatusUpdate.id = currRowData.Field<string>("Id");
                    newStatusUpdate.key = currRowData.Field<string>("Key");
                    newStatusUpdate.status = "delivered";
                    break;

                default:
                    break;
            }

            sw.Stop();

            Console.WriteLine("buildStatusUpdateObj Elapsed={0}", sw.Elapsed);
            return newStatusUpdate;
        }

        // Highlights the rows in specific color according to the changes in status send to Lieferando.
        // Documentation: https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.datagridview.selectionchanged?redirectedfrom=MSDN&view=windowsdesktop-6.0
        private void UpdateStatusColors()
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();


            //int status;
            // Iterate through the rows.
            for (int i = 0; i < DataGridViewFormRequest.Rows.Count; i++)
            {
                int status = int.Parse(DataGridViewFormRequest.Rows[i].Cells["Status"].Value.ToString());
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

            sw.Stop();

            Console.WriteLine("UpdateColorStatus Elapsed={0}", sw.Elapsed);
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


        // TODO optimization: handle "ASAP" as other input value, (already handled in general with this approach)
        //
        // Function to convert various string representations of dates and times to DateTime values.
        // Returns it in format "HH:mm:ss" if timeflag set to "timeonly"
        // or in format something like yyyy-MM-ddTHH:mm:sszzz if timeflag set to "lieferando"(default ""). 
        private string ConvertToOwnDateTime(string value, string timeflag = "")
        {
            try
            {
                if (timeflag == "timeonly")
                    return Convert.ToDateTime(value).ToString("HH:mm:ss");
                else if (timeflag == "lieferando")
                    // "yyyy'-'MM'-'dd'T'HH':'mm':'ss'zzz" - not working
                    return Convert.ToDateTime(value).ToString("s") + Convert.ToDateTime(value).ToString("zzz");
                else
                    return Convert.ToDateTime(value).ToString("dd/MM/yyyy HH:mm:ss");
            }
            catch (FormatException)
            {
                Console.WriteLine("'{0}' is not in the proper format.", value);
                return string.Empty;
            }
        }

        // Initializes the encoded status of the order.
        private int InitializeEncodedStatus(string reqDeliveryTime)
        {
            return reqDeliveryTime == string.Empty ? 0 : 1; // 0 "Neu eingegangen" : 1 "Lieferzeit mitgeteilt";
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            labelTimeNow.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
        }

        //
        // Discussion idea:
        // Checkbox Automatische Statusänderung aktivieren
        // TODO: Automatische Statusänderung nach Schema
        // -> TODO: Schema überlegen.
        // (f.e. Lieferzeit 30, nach 3min Zubereitung starten, nach 10 min Lieferung starten)
        //
    }
}

