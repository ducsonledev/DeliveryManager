using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using static BackgroundLieferandoApiAsyncRequests.ConsumeAPIs;

namespace BackgroundLieferandoApiAsyncRequests
{
    public partial class FormDetails : Form
    {
        public FormDetails(DataTable dt, int currRowIdx)
        {
            InitializeComponent();

            textBoxName.Text = dt.Rows[currRowIdx].Field<string>("Name");
            textBoxStraße.Text = dt.Rows[currRowIdx].Field<string>("Straße");
            textBoxPLZOrt.Text = dt.Rows[currRowIdx].Field<string>("PLZ") + " " + dt.Rows[currRowIdx].Field<string>("Ort");
            textBoxTelefon.Text = dt.Rows[currRowIdx].Field<string>("Telefon");
            textBoxZusatz.Text = dt.Rows[currRowIdx].Field<string>("Zusatz");
            textBoxLieferung.Text = dt.Rows[currRowIdx].Field<string>("Lieferung");
            textBoxSumme.Text = dt.Rows[currRowIdx].Field<string>("Summe").ToString();
            textBoxLieferkosten.Text = dt.Rows[currRowIdx].Field<string>("Lieferkosten");
            textBoxRabatt.Text = dt.Rows[currRowIdx].Field<string>("Rabatt");
            textBoxInfo.Text = dt.Rows[currRowIdx].Field<string>("Info");
            textBoxBezahlt.Text = dt.Rows[currRowIdx].Field<string>("Bezahlt");

            PopulateDataGridViewProducts(dt, currRowIdx);
            // Resize the DataGridView columns to fit the newly loaded data.
            DataGridViewFormDetails.AutoResizeColumns();
            // No highlighting seen with selection.
            DataGridViewFormDetails.DefaultCellStyle.SelectionBackColor = DataGridViewFormDetails.DefaultCellStyle.BackColor;
            DataGridViewFormDetails.DefaultCellStyle.SelectionForeColor = DataGridViewFormDetails.DefaultCellStyle.ForeColor;
            // prevent columnheaders from highlighting on mouse over
            foreach (DataGridViewColumn col in DataGridViewFormDetails.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void PopulateDataGridViewProducts(DataTable dt, int currRowIdx)
        {
            foreach (var discount in dt.Rows[currRowIdx].Field<List<Discount>>("Rabattgutscheine"))
            {
                DataGridViewFormDetails.Rows.Add(new string[] {
                        "Rabatt",
                        discount.name,
                        discount.count.ToString(),
                        discount.price.ToString("0.00")
                    }
                );
            }

            foreach (var product in dt.Rows[currRowIdx].Field<List<Product>>("Produkte"))
            {
                DataGridViewFormDetails.Rows.Add(new string[] {
                        product.id,
                        product.name,
                        product.count.ToString(),
                        product.price.ToString("0.00"),
                        product.remark
                    }
                );
                foreach(var sideDish in product.sideDishes)
                {
                    DataGridViewFormDetails.Rows.Add(new string[] {
                            "Beilage",
                            sideDish.name,
                            sideDish.count.ToString(),
                            sideDish.price.ToString("0.00")
                        }
                    );
                }
            }
        }

        private void buttonZurück_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
