using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using static BackgroundLieferandoApiAsyncRequests.ConsumeAPIs;
using static BackgroundLieferandoApiAsyncRequests.OrdersExtension;

namespace BackgroundLieferandoApiAsyncRequests
{
    public partial class FormRequest : Form
    {
        public DataTable GlobalDataTable { get; set; }
        public FormRequest()
        {
            InitializeComponent();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
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

                PopulateDataGridView(LieferandoOrders);
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
            resultLabel.Text = "Requesting orders from Lieferando!"; // for testing
        }

        private void button15min_Click(object sender, EventArgs e)
        {
            UpdateRowStatusColor();
        }

        private void button20min_Click(object sender, EventArgs e)
        {
            UpdateRowStatusColor();
        }

        private void button30min_Click(object sender, EventArgs e)
        {
            UpdateRowStatusColor();
        }

        private void button45min_Click(object sender, EventArgs e)
        {
            UpdateRowStatusColor();
        }

        private void button60min_Click(object sender, EventArgs e)
        {
            UpdateRowStatusColor();
        }

        private void buttonZubereitungStart_Click(object sender, EventArgs e)
        {
            UpdateRowStatusColor();
        }

        private void buttonLieferungStart_Click(object sender, EventArgs e)
        {
            UpdateRowStatusColor();
        }
        private void buttonLieferungAbschließen_Click(object sender, EventArgs e)
        {
            UpdateRowStatusColor();
        }

        private void buttonDetails_Click(object sender, EventArgs e)
        {
            var formDetails = new FormDetails(this);
            formDetails.ShowDialog();
        }

        private void InitializeGlobalDataTable()
        {
            // creating DataTable for our DataGridView
            GlobalDataTable = new DataTable("TodaysOrders" + DateTime.Now);
            GlobalDataTable.Columns.Add("Id", typeof(string));
            GlobalDataTable.Columns.Add("Start", typeof(string));
            GlobalDataTable.Columns.Add("Ende", typeof(string));
            GlobalDataTable.Columns.Add("Name", typeof(string));
            GlobalDataTable.Columns.Add("Straße", typeof(string));
            GlobalDataTable.Columns.Add("Ort", typeof(string));
            GlobalDataTable.Columns.Add("Telefon", typeof(string));
            GlobalDataTable.Columns.Add("Summe", typeof(double));
            GlobalDataTable.Columns.Add("Status", typeof(int)); // TODO: Documentation Status 0,1,2,3, ...
            GlobalDataTable.Columns.Add("Kasse", typeof(string));
            GlobalDataTable.Columns.Add("Datum", typeof(string));
            // hide columns for clearer UI
            GlobalDataTable.Columns[0].ColumnMapping = MappingType.Hidden;

            // TODO: more information for FormDetails
        }

        private bool PopulateDataGridView(LieferandoOrders lieferandoOrders)
        {
            bool populated = false;
            foreach (var order in lieferandoOrders.orders)
            {
                var selectedRows = GlobalDataTable.Select("Id = '" + order.id + "'");
                if (selectedRows.Length != 0)
                    continue;
                // example, GlobalDataTable.Rows.Add(
                // "12:32", "13:02",
                // "Pieter Post",
                // "Brouwerstraat",
                // "Enschede",
                // "01600102",
                // 4.00, 1, 1, "21/12/21");
                var datetime = ConvertToOwnDateTime(order.requestedDeliveryTime.ToString());
                var split_datetime = datetime.Split(' ');
                GlobalDataTable.Rows.Add(
                    order.id,
                    split_datetime[1],
                    "13:02",
                    order.customer.name,
                    order.customer.street,
                    order.customer.city,
                    order.customer.phoneNumber,
                    order.totalPrice,
                    0,
                    Properties.Settings.Default.Kasse,
                    split_datetime[0]
                    );
                // code reached 
                // TODO: but not filtering specific orders that should be posted to our server
                populated = true;
            }
            UpdateDataGridViewSource(GlobalDataTable);
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
            }
        }

        // Highlights the rows in specific color according to the changes in status send to Lieferando.
        // Documentation: https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.datagridview.selectionchanged?redirectedfrom=MSDN&view=windowsdesktop-6.0
        private void UpdateRowStatusColor()
        {
            int status;
            // Iterate through the rows.
            for (int i = 0; i < DataGridViewFormRequest.Rows.Count; i++)
            {
                status = int.Parse(DataGridViewFormRequest.Rows[i].Cells["Status"].Value.ToString());

                // Status 0: The order was printed by a restaurant. (printed)
                if (status == 0)
                {
                    DataGridViewFormRequest.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
                // Status 1: The order was confirmed with a change in delivery time. (confirmed_change_delivery_time)
                else if (status == 1) 
                {
                    DataGridViewFormRequest.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 192);
                }
                // Status 2: The restaurant started preparing the order. (kitchen)
                else if (status == 2)
                {
                    DataGridViewFormRequest.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 192, 192);
                }
                // Status 3: The order is in delivery by a courier. (in_delivery)
                else if (status == 3)
                {
                    DataGridViewFormRequest.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(192, 255, 192);
                }
                // Status 4: The order has been delivered by a courier. (delivered)
                else if (status == 4)
                {
                    DataGridViewFormRequest.Rows[i].DefaultCellStyle.BackColor = Color.DarkGray;
                }
            }
        }

    }
}

