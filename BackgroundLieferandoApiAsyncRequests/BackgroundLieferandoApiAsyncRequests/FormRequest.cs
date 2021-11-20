using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using static BackgroundLieferandoApiAsyncRequests.ConsumeAPIs;

namespace BackgroundLieferandoApiAsyncRequests
{
    public partial class FormRequest : Form
    {
        public FormRequest()
        {
            InitializeComponent();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
        }
        
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //BackgroundWorker worker = sender as BackgroundWorker;
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
                    ); // for testing credentials for sanboxapi
                if (LieferandoOrders == null)
                {
                    MessageBox.Show(
                        "Leider ist ein Fehler aufgetreten! Bitte überprüfen Sie nochmal Ihre Einstellungen und starten Sie den Vorgang erneut."
                        );
                    e.Cancel = true;
                    return;
                }
                
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
            resultLabel.Text = "Requesting orders from Lieferando!";
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
            resultLabel.Text = "Requesting orders from Lieferando!";
        }
    }
}
