using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackgroundLieferandoApiAsyncRequests
{
    public partial class FormLieferandoLogin : Form
    {
        public FormLieferandoLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            // TODO: pass credentials to lieferando api and text
            // check if successful before going to form request
            FormRequest formReq = new FormRequest();
            formReq.Show();
        }
    }
}
