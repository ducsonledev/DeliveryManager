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
            // hide columns for clear UI
            GlobalDataTable.Columns[0].ColumnMapping = MappingType.Hidden;
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

                foreach (var order in LieferandoOrders.orders)
                {
                    var rows = GlobalDataTable.Select("Id = '" + order.id + "'");
                    if (rows.Length != 0) // error, no column with id
                        continue;
                    // TODO: DataTable with hidden columns, so init all data in dataTable?
                    //GlobalDataTable.Rows.Add(new TimeSpan(0, 12, 32), "13:02", "Pieter Post", "Brouwerstraat", "Enschede", "01600102", 4.00, 1, 1, new DateTime(2018, 5, 1));
                    var datetime = ConvertToOwnDateTime(order.requestedDeliveryTime.ToString());
                    var split_datetime = datetime.Split(' ');
                    GlobalDataTable.Rows.Add(
                        order.id,
                        split_datetime[1], 
                        "", 
                        order.customer.name, 
                        order.customer.street, 
                        order.customer.city, 
                        order.customer.phoneNumber, 
                        order.totalPrice, 
                        0, 
                        1,
                        split_datetime[0]
                        );
                }
                this.UpdateDataGridViewSource(GlobalDataTable);
                PostOwnOrders(LieferandoOrders);
                Thread.Sleep(Properties.Settings.Default.OrdersInterval);
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
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
            //dataGridViewFormRequest.DataSource = GlobalDataTable;
            backgroundWorker.RunWorkerAsync();
            resultLabel.Text = "Requesting orders from Lieferando!";
        }

        private void buttonLieferungAbschließen_Click(object sender, EventArgs e)
        {

        }

        private void buttonDetails_Click(object sender, EventArgs e)
        {
            var formDetails = new FormDetails(this);
            formDetails.ShowDialog();
        }

        // create a method to handle updating the datasource
        // https://stackoverflow.com/questions/52992223/c-sharp-update-datagridview-from-backgroundworker
        public void UpdateDataGridViewSource(object data)
        {
            // check if we need to swap thread context
            if (this.dataGridViewFormRequest.InvokeRequired)
            {
                // we aren't on the UI thread. Ask the UI thread to do stuff.
                this.dataGridViewFormRequest.Invoke(new Action(() => UpdateDataGridViewSource(data)));
            }
            else
            {
                // we are on the UI thread. We are free to touch things.
                this.dataGridViewFormRequest.DataSource = data;
                //this.dataGridView.DataBind();
            }
        }
    }
}
