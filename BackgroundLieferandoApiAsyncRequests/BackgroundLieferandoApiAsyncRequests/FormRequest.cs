using Newtonsoft.Json;
using RestSharp;
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace BackgroundLieferandoApiAsyncRequests
{
    public partial class FormRequest : Form
    {
        public FormRequest()
        {
            InitializeComponent();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
            // TODO: passed credentials from login form
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //var clientPost = new RestClient("<server-base-adresse>:13000"); 
            var clientPost = new RestClient("https://sandbox-pull-posapi.takeaway.com/1.0/orders/1234567"); // temp test adress // TODO later: Please add server adresse with Port 13000.
            var requestPostOrd = new RestRequest(Method.POST);
            TimeSpan interval = new TimeSpan(0, 1, 0); // 1 min
            while (true)
            {
                if (backgroundWorker.CancellationPending == true)
                {
                    e.Cancel = true;
                    return;
                }
                var LieferandoOrders = LieferandoApiRequester.LieferandoRequest(txtBoxUsername.Text, txtBoxPassword.Text, txtBoxApiCode.Text, txtBoxRestaurantId.Text); // credentials for sanboxapi //"test-username-123", "test-password-123"
                // TODO: better way to catch wrong credentials
                if(LieferandoOrders == null)
                {
                    MessageBox.Show(
                        "Leider ist ein Fehler aufgetreten! Bitte überprüfen Sie nochmal Ihre Einstellungen und starten den Vorgang erneut."
                        );
                    break;
                }
                var ownOrders = LieferandoOrders.ToOwnOrder();
                foreach (var ownOrder in ownOrders)
                {
                    var newOwnOrder = JsonConvert.SerializeObject(ownOrder, Formatting.Indented);
                    IRestResponse responsePost = clientPost.Execute(requestPostOrd.AddJsonBody(newOwnOrder));
                    Console.WriteLine(responsePost.Content);
                }
                Thread.Sleep(interval);
                // backgroundWorker.ReportProgress(i); //TODO maybe: if we want to show some feedback of the progress working, usually with i in for loop
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //progressBarRequest.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Cancelled == true)
            {
                MessageBox.Show("Cancelled Request");
                //progressBarRequest.Value = 1000;
            }
            else
            {
                MessageBox.Show("Completed Request");
            }
        }
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    //progressBarRequest.Maximum = 1000;
        //    //progressBarRequest.Minimum = 0;
        //    //progressBarRequest.Value = 0;
        //    backgroundWorker.RunWorkerAsync();
        //}

        private void btnCancel_Click(object sender, EventArgs e)
        {
            backgroundWorker.CancelAsync();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            backgroundWorker.RunWorkerAsync();
        }
    }
}
