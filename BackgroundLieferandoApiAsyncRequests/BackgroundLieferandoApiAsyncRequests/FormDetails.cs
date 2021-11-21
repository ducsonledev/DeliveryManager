using System;
using System.Windows.Forms;

namespace BackgroundLieferandoApiAsyncRequests
{
    public partial class FormDetails : Form
    {
        public FormDetails(FormRequest formReq)
        {
            InitializeComponent();
            //textBoxName.Text = name;
            // TODO: for all TextBoxes
            //formReq.GlobalDataTable
        }

        private void buttonZurück_Click(object sender, EventArgs e)
        {
            this.Close();
            //Hide();
            // TODO: Show() already existing form again, no need to create more forms than necessary
            //var formReq = new FormRequest();
            //formReq.Show();
        }
    }
}
