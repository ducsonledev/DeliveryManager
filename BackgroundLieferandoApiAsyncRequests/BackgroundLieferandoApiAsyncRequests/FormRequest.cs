using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using static BackgroundLieferandoApiAsyncRequests.ConsumeAPIs;
using System.Diagnostics; // for testing performance
using System.Collections.Generic;

namespace BackgroundLieferandoApiAsyncRequests
{
    public partial class FormRequest : Form
    {
        public DataTable GlobalOpenOrdersDataTable { get; set; }
        public DataTable GlobalFinishedOrdersDataTable { get; set; }
        public FormRequest()
        {
            InitializeComponent();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Initialize DataTable.
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
                );

                if (LieferandoOrders == null)
                {
                    MessageBox.Show(
                        "Leider ist ein Fehler aufgetreten! Bitte überprüfen Sie nochmal Ihre Einstellungen (Settings) und starten Sie den Vorgang erneut."
                        );
                    e.Cancel = true;
                    return;
                }

                // only for at least one new incoming orders we populate data and post to our server 
                if (LieferandoOrders.orders.Count != 0)
                {
                    var success = PostOwnOrders(LieferandoOrders);

                    success = true; // for testing, since we still don't send to our server adresse, but the set up is there

                    // only populate in DataTable and DataGridView if we can create a receipt by posting to our server
                    if (success)
                        PopulateDataGridViewOrders(LieferandoOrders); // handles the new orders only itself by comparing with DataTable
                }

                Thread.Sleep(Properties.Settings.Default.OrdersInterval);
            }
        }


        // TODO: saving DataTables when canceling and open last orders in open orders xml when not older than 1 Day/12hours
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // still for testing, should be changed when it works, but probably never reached?
            // First, handle the case where an exception was thrown.
            if (e.Error != null)
            {
                //MessageBox.Show(e.Error.Message);
                resultLabel.Text = "Error: " + e.Error.Message;
                // save orders on error occasion
                GlobalOpenOrdersDataTable.WriteXml(GlobalOpenOrdersDataTable.TableName + ".xml");
                GlobalFinishedOrdersDataTable.WriteXml(GlobalFinishedOrdersDataTable.TableName + ".xml");
            }
            if (e.Cancelled == true)
            {
                resultLabel.Text = "Requests canceled!";
                resultLabel.ForeColor = Color.Red;
                //MessageBox.Show("Requests canceled!");
                // save orders on cancel occasion
                GlobalOpenOrdersDataTable.WriteXml(GlobalOpenOrdersDataTable.TableName + ".xml");
                GlobalFinishedOrdersDataTable.WriteXml(GlobalFinishedOrdersDataTable.TableName + ".xml");
            }
            else
            {
                resultLabel.Text = "Requests completed!";
                //MessageBox.Show("Requests completed!");
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
            // moving all finished orders to the according datatable even when selected (f.e. last order left is finished)
            AdjustDataTable(closing:true);
            GlobalOpenOrdersDataTable.WriteXml(GlobalOpenOrdersDataTable.TableName + ".xml");
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

            var formDetails = new FormDetails(GlobalOpenOrdersDataTable, DataGridViewFormRequest.CurrentCell.RowIndex);
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
            GlobalOpenOrdersDataTable = new DataTable()
            {
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
                    { "Produkte", typeof(List<Product>) },
                    { "Rabattgutscheine", typeof(List<Discount>) },
                    { "Key", typeof(string) },
                    { "EndDateTime", typeof(string) },
                    { "Id", typeof(string) }
                }
            };
            GlobalFinishedOrdersDataTable = GlobalOpenOrdersDataTable.Clone();
            // Setting DataTable names.
            GlobalOpenOrdersDataTable.TableName = "TodaysOpenOrders" + DateTime.Now.ToString("s").Replace(":", "-");
            GlobalFinishedOrdersDataTable.TableName = "TodaysFinishedOrders" + DateTime.Now.ToString("s").Replace(":", "-");
        }

        private void PopulateDataGridViewOrders(LieferandoOrders lieferandoOrders)
        {
            foreach (var order in lieferandoOrders.orders)
            {
                var selectedRows = GlobalOpenOrdersDataTable.Select("Id = '" + order.id + "'");
                if (selectedRows.Length != 0)
                    continue;

                // in the following, code reached, only orders that are new to the data table will be added and posted to our server

                // collecting and sending orders
                var reqDeliverytime = ConvertToOwnDateTime(order.requestedDeliveryTime.ToString(), "timeonly");
                var reqDeliveryLieferandoTime = ConvertToOwnDateTime(order.requestedDeliveryTime.ToString(), "lieferando");
                int statusEncode = InitializeEncodedStatus(reqDeliverytime);

                // in the following, code reached, only when we posted the new orders to our server for the receipt (printed)

                // adding new orders to open orders data table
                GlobalOpenOrdersDataTable.Rows.Add(
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
                bool success;
                // for incoming orders that already has requested delivery time, the status 0 and 1 will be send
                if (statusEncode == 1)
                    success = PostStatusUpdate(BuildStatusUpdateObj(GlobalOpenOrdersDataTable.Rows.Count - 1, statusEncode - 1));
                // Post update status for initial incoming orders
                success = PostStatusUpdate(BuildStatusUpdateObj(GlobalOpenOrdersDataTable.Rows.Count - 1, statusEncode));
                // if not successful, doesn't matter, then we don't send status and keep order in DataTable.
                // this is just for convenience for real time customer feedback and doesn't actually hinder the full delivery till the door
            }
            UpdateDataGridViewSource(GlobalOpenOrdersDataTable);
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
        public void AdjustDataTable(bool closing = false)
        {
            for (int i = 0; i < GlobalOpenOrdersDataTable.Rows.Count; i++)
            {
                var dr = GlobalOpenOrdersDataTable.Rows[i];
                if (dr.Field<int>("Status") == 4 && (DataGridViewFormRequest.CurrentCell.RowIndex != i || closing))
                {
                    GlobalFinishedOrdersDataTable.ImportRow(dr);
                    GlobalOpenOrdersDataTable.Rows.Remove(dr);
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
            //DataGridViewFormRequest.Columns["Produkte"].Visible = false; // obj. instance not initialized in DataGridView anyway
            //DataGridViewFormRequest.Columns["Rabattgutscheine"].Visible = false; // obj. instance not initialized in DataGridView anyway
            DataGridViewFormRequest.Columns["Key"].Visible = false;
            DataGridViewFormRequest.Columns["EndDateTime"].Visible = false;
            DataGridViewFormRequest.Columns["Id"].Visible = false;

            // Sets enable state of button senders.
            UpdateButtonsEnableState(GlobalOpenOrdersDataTable.Rows[DataGridViewFormRequest.CurrentCell.RowIndex].Field<int>("Status"));

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
            Stopwatch sw = new Stopwatch();

            sw.Start();

            // called with the new current row because the Data Table could have been adjusted in the mean time TODO but status is wrong for current cell
            bool success = PostStatusUpdate(BuildStatusUpdateObj(DataGridViewFormRequest.CurrentCell.RowIndex, status));

            sw.Stop();

            Console.WriteLine("PostStatusUpdate Elapsed={0}", sw.Elapsed);

            // for testing purposes, since takeaway sandbox is currently not avaiable,
            // so post update status won't work
            success = true; // for testing

            // If no status is send, the GlobalOpenOrdersDataTable should keep the order, otherwise, the same order will be requested from Lieferando Server
            // and we would have the same order multiple times. Since Lieferando only removes orders that have a successfully changed status or if that order
            // is older than 12 hours.
            if (!success)
                return false;

            // in the following, code reached, successfully send status update to Lieferando API

            // updates status in data table
            GlobalOpenOrdersDataTable.Rows[currRowIdx].SetField("Status", status);
            // Sets new requestedDeliveryTime in DataTable if status is 1.
            if (status == 1)
            {
                var startTime = Convert.ToDateTime(GlobalOpenOrdersDataTable.Rows[currRowIdx].Field<string>("Start"));
                var endTime = startTime.Add(deliveryTime);
                GlobalOpenOrdersDataTable.Rows[currRowIdx].SetField("Ende", endTime.ToString("HH:mm:ss"));
                GlobalOpenOrdersDataTable.Rows[currRowIdx].SetField("EndDateTime", endTime.ToString("s") + endTime.ToString("zzz"));
            }
            UpdateDataGridViewSource(GlobalOpenOrdersDataTable);
            UpdateStatusColors();
            UpdateButtonsEnableState(status);

            return success;
        }

        //f.e.
        // {
        //      "id": "cae66b7e-791b-11e7-b4d8-3464a91febf3",
        //      "key": "D41D8CD98F00B204E9800998ECF8427E",
        //      "status": "confirmed_change_delivery_time",
        //      "changedDeliveryTime": "2020-02-04T19:45:00+02:00"
        // }
        private LieferandoStatusUpdates BuildStatusUpdateObj(int currRowIdx, int status)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();

            LieferandoStatusUpdates newStatusUpdate = new LieferandoStatusUpdates(); // looks like empty json serialization
            var currRowData = GlobalOpenOrdersDataTable.Rows[currRowIdx]; // need data in open orders data table of selected row
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

        //
        // TODO optimization maybe: handle "ASAP" as other input value,
        // (SOLVED, already handled in general with this approach, but maybe not the cleanest way.)
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

        // Customize disabling color of buttons.
        // Layout: https://stackoverflow.com/questions/18717090/how-to-avoid-color-changes-when-button-is-disabled
        private void buttonZubereitungStart_EnabledChanged(object sender, EventArgs e)
        {
            buttonZubereitungStart.ForeColor = buttonZubereitungStart.Enabled == false ? Color.Gray : Color.Black;
        }

        private void buttonLieferungStart_EnabledChanged(object sender, EventArgs e)
        {
            buttonLieferungStart.ForeColor = buttonLieferungStart.Enabled == false ? Color.Gray : Color.Black;
        }

        private void buttonZubereitungStart_Paint(object sender, PaintEventArgs e)
        {
            dynamic btn = (Button)sender;
            dynamic drawBrush = new SolidBrush(btn.ForeColor);
            dynamic sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            buttonZubereitungStart.Text = string.Empty;
            e.Graphics.DrawString("Zubereitung starten", btn.Font, drawBrush, e.ClipRectangle, sf);
            drawBrush.Dispose();
            sf.Dispose();
        }

        private void buttonLieferungStart_Paint(object sender, PaintEventArgs e)
        {
            dynamic btn = (Button)sender;
            dynamic drawBrush = new SolidBrush(btn.ForeColor);
            dynamic sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            buttonLieferungStart.Text = string.Empty;
            e.Graphics.DrawString("Lieferung starten", btn.Font, drawBrush, e.ClipRectangle, sf);
            drawBrush.Dispose();
            sf.Dispose();
        }
    }
}

