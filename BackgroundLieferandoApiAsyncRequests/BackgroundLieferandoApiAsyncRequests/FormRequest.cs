using System;
using System.ComponentModel;
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
            BackgroundWorker worker = sender as BackgroundWorker;

            TimeSpan interval = new TimeSpan(0, 1, 0); // 1 min
            while (true)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                var LieferandoOrders = LieferandoRequest(txtBoxUsername.Text, txtBoxPassword.Text, txtBoxApiCode.Text, txtBoxRestaurantId.Text); // credentials for sanboxapi //"test-username-123", "test-password-123"
                if(LieferandoOrders == null)
                {
                    MessageBox.Show(
                        "Leider ist ein Fehler aufgetreten! Bitte überprüfen Sie nochmal Ihre Einstellungen und starten Sie den Vorgang erneut."
                        );
                    e.Cancel = true;
                    break;
                }
                PostOwnOrders(LieferandoOrders);
                Thread.Sleep(interval);
                // backgroundWorker.ReportProgress(i); //TODO maybe: if we want to show some feedback of the progress working, usually with iterator
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //progressBarRequest.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //if(e.Cancelled == true)
            //{
            //    MessageBox.Show("Cancelled Request");
            //    //progressBarRequest.Value = 1000;
            //}
            //else
            //{
            //    MessageBox.Show("Completed Request");
            //}
            if (e.Cancelled == true)
            {
                resultLabel.Text = "Canceled!";
            }
            else if (e.Error != null)
            {
                resultLabel.Text = "Error: " + e.Error.Message;
            }
            else
            {
                resultLabel.Text = "Running!";
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //progressBarRequest.Maximum = 1000;
            //progressBarRequest.Minimum = 0;
            //progressBarRequest.Value = 0;
            backgroundWorker.RunWorkerAsync();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                backgroundWorker.CancelAsync();
            }
        }
    }
}
