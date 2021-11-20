
namespace BackgroundLieferandoApiAsyncRequests
{
    partial class FormDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ArtikelNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bezeichnung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Menge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Preis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Zusatz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxStraße = new System.Windows.Forms.TextBox();
            this.labelStraße = new System.Windows.Forms.Label();
            this.textBoxPLZOrt = new System.Windows.Forms.TextBox();
            this.labelPLZOrt = new System.Windows.Forms.Label();
            this.textBoxTelefon = new System.Windows.Forms.TextBox();
            this.labelTelefon = new System.Windows.Forms.Label();
            this.textBoxZusatz = new System.Windows.Forms.TextBox();
            this.labelZusatz = new System.Windows.Forms.Label();
            this.textBoxLieferung = new System.Windows.Forms.TextBox();
            this.labelLieferung = new System.Windows.Forms.Label();
            this.textBoxLieferkosten = new System.Windows.Forms.TextBox();
            this.labelLieferkosten = new System.Windows.Forms.Label();
            this.textBoxSumme = new System.Windows.Forms.TextBox();
            this.labelSumme = new System.Windows.Forms.Label();
            this.textBoxRabatt = new System.Windows.Forms.TextBox();
            this.labelRabatt = new System.Windows.Forms.Label();
            this.textBoxInfo = new System.Windows.Forms.TextBox();
            this.labelInfo = new System.Windows.Forms.Label();
            this.textBoxBezahlt = new System.Windows.Forms.TextBox();
            this.labelBezahlt = new System.Windows.Forms.Label();
            this.buttonZurück = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ArtikelNr,
            this.Bezeichnung,
            this.Menge,
            this.Preis,
            this.Zusatz});
            this.dataGridView1.GridColor = System.Drawing.Color.Black;
            this.dataGridView1.Location = new System.Drawing.Point(-43, 88);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Size = new System.Drawing.Size(777, 185);
            this.dataGridView1.TabIndex = 0;
            // 
            // ArtikelNr
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            this.ArtikelNr.DefaultCellStyle = dataGridViewCellStyle3;
            this.ArtikelNr.HeaderText = "ArtikelNr";
            this.ArtikelNr.Name = "ArtikelNr";
            this.ArtikelNr.ReadOnly = true;
            this.ArtikelNr.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ArtikelNr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ArtikelNr.Width = 80;
            // 
            // Bezeichnung
            // 
            this.Bezeichnung.HeaderText = "Bezeichnung";
            this.Bezeichnung.MinimumWidth = 10;
            this.Bezeichnung.Name = "Bezeichnung";
            this.Bezeichnung.ReadOnly = true;
            this.Bezeichnung.Width = 250;
            // 
            // Menge
            // 
            this.Menge.HeaderText = "Menge";
            this.Menge.Name = "Menge";
            this.Menge.ReadOnly = true;
            this.Menge.Width = 80;
            // 
            // Preis
            // 
            this.Preis.HeaderText = "Preis";
            this.Preis.Name = "Preis";
            this.Preis.ReadOnly = true;
            this.Preis.Width = 80;
            // 
            // Zusatz
            // 
            this.Zusatz.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Zusatz.HeaderText = "Zusatz";
            this.Zusatz.Name = "Zusatz";
            this.Zusatz.ReadOnly = true;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(19, 13);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Name";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(57, 10);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.ReadOnly = true;
            this.textBoxName.Size = new System.Drawing.Size(127, 20);
            this.textBoxName.TabIndex = 2;
            // 
            // textBoxStraße
            // 
            this.textBoxStraße.Location = new System.Drawing.Point(57, 36);
            this.textBoxStraße.Name = "textBoxStraße";
            this.textBoxStraße.ReadOnly = true;
            this.textBoxStraße.Size = new System.Drawing.Size(127, 20);
            this.textBoxStraße.TabIndex = 4;
            // 
            // labelStraße
            // 
            this.labelStraße.AutoSize = true;
            this.labelStraße.Location = new System.Drawing.Point(16, 39);
            this.labelStraße.Name = "labelStraße";
            this.labelStraße.Size = new System.Drawing.Size(38, 13);
            this.labelStraße.TabIndex = 3;
            this.labelStraße.Text = "Straße";
            // 
            // textBoxPLZOrt
            // 
            this.textBoxPLZOrt.Location = new System.Drawing.Point(57, 62);
            this.textBoxPLZOrt.Name = "textBoxPLZOrt";
            this.textBoxPLZOrt.ReadOnly = true;
            this.textBoxPLZOrt.Size = new System.Drawing.Size(127, 20);
            this.textBoxPLZOrt.TabIndex = 6;
            // 
            // labelPLZOrt
            // 
            this.labelPLZOrt.AutoSize = true;
            this.labelPLZOrt.Location = new System.Drawing.Point(7, 65);
            this.labelPLZOrt.Name = "labelPLZOrt";
            this.labelPLZOrt.Size = new System.Drawing.Size(44, 13);
            this.labelPLZOrt.TabIndex = 5;
            this.labelPLZOrt.Text = "PLZ Ort";
            // 
            // textBoxTelefon
            // 
            this.textBoxTelefon.Location = new System.Drawing.Point(246, 10);
            this.textBoxTelefon.Name = "textBoxTelefon";
            this.textBoxTelefon.ReadOnly = true;
            this.textBoxTelefon.Size = new System.Drawing.Size(100, 20);
            this.textBoxTelefon.TabIndex = 8;
            // 
            // labelTelefon
            // 
            this.labelTelefon.AutoSize = true;
            this.labelTelefon.Location = new System.Drawing.Point(201, 13);
            this.labelTelefon.Name = "labelTelefon";
            this.labelTelefon.Size = new System.Drawing.Size(43, 13);
            this.labelTelefon.TabIndex = 7;
            this.labelTelefon.Text = "Telefon";
            // 
            // textBoxZusatz
            // 
            this.textBoxZusatz.Location = new System.Drawing.Point(246, 36);
            this.textBoxZusatz.Name = "textBoxZusatz";
            this.textBoxZusatz.ReadOnly = true;
            this.textBoxZusatz.Size = new System.Drawing.Size(100, 20);
            this.textBoxZusatz.TabIndex = 10;
            // 
            // labelZusatz
            // 
            this.labelZusatz.AutoSize = true;
            this.labelZusatz.Location = new System.Drawing.Point(205, 39);
            this.labelZusatz.Name = "labelZusatz";
            this.labelZusatz.Size = new System.Drawing.Size(39, 13);
            this.labelZusatz.TabIndex = 9;
            this.labelZusatz.Text = "Zusatz";
            // 
            // textBoxLieferung
            // 
            this.textBoxLieferung.Location = new System.Drawing.Point(246, 62);
            this.textBoxLieferung.Name = "textBoxLieferung";
            this.textBoxLieferung.ReadOnly = true;
            this.textBoxLieferung.Size = new System.Drawing.Size(100, 20);
            this.textBoxLieferung.TabIndex = 12;
            // 
            // labelLieferung
            // 
            this.labelLieferung.AutoSize = true;
            this.labelLieferung.Location = new System.Drawing.Point(193, 65);
            this.labelLieferung.Name = "labelLieferung";
            this.labelLieferung.Size = new System.Drawing.Size(51, 13);
            this.labelLieferung.TabIndex = 11;
            this.labelLieferung.Text = "Lieferung";
            // 
            // textBoxLieferkosten
            // 
            this.textBoxLieferkosten.Location = new System.Drawing.Point(423, 36);
            this.textBoxLieferkosten.Name = "textBoxLieferkosten";
            this.textBoxLieferkosten.ReadOnly = true;
            this.textBoxLieferkosten.Size = new System.Drawing.Size(73, 20);
            this.textBoxLieferkosten.TabIndex = 14;
            // 
            // labelLieferkosten
            // 
            this.labelLieferkosten.AutoSize = true;
            this.labelLieferkosten.Location = new System.Drawing.Point(352, 39);
            this.labelLieferkosten.Name = "labelLieferkosten";
            this.labelLieferkosten.Size = new System.Drawing.Size(65, 13);
            this.labelLieferkosten.TabIndex = 13;
            this.labelLieferkosten.Text = "Lieferkosten";
            // 
            // textBoxSumme
            // 
            this.textBoxSumme.Location = new System.Drawing.Point(423, 10);
            this.textBoxSumme.Name = "textBoxSumme";
            this.textBoxSumme.ReadOnly = true;
            this.textBoxSumme.Size = new System.Drawing.Size(73, 20);
            this.textBoxSumme.TabIndex = 16;
            // 
            // labelSumme
            // 
            this.labelSumme.AutoSize = true;
            this.labelSumme.Location = new System.Drawing.Point(375, 13);
            this.labelSumme.Name = "labelSumme";
            this.labelSumme.Size = new System.Drawing.Size(42, 13);
            this.labelSumme.TabIndex = 15;
            this.labelSumme.Text = "Summe";
            // 
            // textBoxRabatt
            // 
            this.textBoxRabatt.Location = new System.Drawing.Point(423, 62);
            this.textBoxRabatt.Name = "textBoxRabatt";
            this.textBoxRabatt.ReadOnly = true;
            this.textBoxRabatt.Size = new System.Drawing.Size(73, 20);
            this.textBoxRabatt.TabIndex = 18;
            // 
            // labelRabatt
            // 
            this.labelRabatt.AutoSize = true;
            this.labelRabatt.Location = new System.Drawing.Point(378, 65);
            this.labelRabatt.Name = "labelRabatt";
            this.labelRabatt.Size = new System.Drawing.Size(39, 13);
            this.labelRabatt.TabIndex = 17;
            this.labelRabatt.Text = "Rabatt";
            // 
            // textBoxInfo
            // 
            this.textBoxInfo.Location = new System.Drawing.Point(550, 10);
            this.textBoxInfo.Name = "textBoxInfo";
            this.textBoxInfo.ReadOnly = true;
            this.textBoxInfo.Size = new System.Drawing.Size(163, 20);
            this.textBoxInfo.TabIndex = 20;
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(519, 13);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(25, 13);
            this.labelInfo.TabIndex = 19;
            this.labelInfo.Text = "Info";
            // 
            // textBoxBezahlt
            // 
            this.textBoxBezahlt.Location = new System.Drawing.Point(550, 36);
            this.textBoxBezahlt.Name = "textBoxBezahlt";
            this.textBoxBezahlt.ReadOnly = true;
            this.textBoxBezahlt.Size = new System.Drawing.Size(67, 20);
            this.textBoxBezahlt.TabIndex = 22;
            // 
            // labelBezahlt
            // 
            this.labelBezahlt.AutoSize = true;
            this.labelBezahlt.Location = new System.Drawing.Point(502, 39);
            this.labelBezahlt.Name = "labelBezahlt";
            this.labelBezahlt.Size = new System.Drawing.Size(42, 13);
            this.labelBezahlt.TabIndex = 21;
            this.labelBezahlt.Text = "Bezahlt";
            // 
            // buttonZurück
            // 
            this.buttonZurück.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.buttonZurück.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonZurück.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonZurück.Location = new System.Drawing.Point(623, 40);
            this.buttonZurück.Name = "buttonZurück";
            this.buttonZurück.Size = new System.Drawing.Size(90, 42);
            this.buttonZurück.TabIndex = 23;
            this.buttonZurück.Text = "zurück";
            this.buttonZurück.UseVisualStyleBackColor = false;
            this.buttonZurück.Click += new System.EventHandler(this.buttonZurück_Click);
            // 
            // FormDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(734, 274);
            this.Controls.Add(this.buttonZurück);
            this.Controls.Add(this.textBoxBezahlt);
            this.Controls.Add(this.labelBezahlt);
            this.Controls.Add(this.textBoxInfo);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.textBoxRabatt);
            this.Controls.Add(this.labelRabatt);
            this.Controls.Add(this.textBoxSumme);
            this.Controls.Add(this.labelSumme);
            this.Controls.Add(this.textBoxLieferkosten);
            this.Controls.Add(this.labelLieferkosten);
            this.Controls.Add(this.textBoxLieferung);
            this.Controls.Add(this.labelLieferung);
            this.Controls.Add(this.textBoxZusatz);
            this.Controls.Add(this.labelZusatz);
            this.Controls.Add(this.textBoxTelefon);
            this.Controls.Add(this.labelTelefon);
            this.Controls.Add(this.textBoxPLZOrt);
            this.Controls.Add(this.labelPLZOrt);
            this.Controls.Add(this.textBoxStraße);
            this.Controls.Add(this.labelStraße);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormDetails";
            this.Text = "FormDetails";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxStraße;
        private System.Windows.Forms.Label labelStraße;
        private System.Windows.Forms.TextBox textBoxPLZOrt;
        private System.Windows.Forms.Label labelPLZOrt;
        private System.Windows.Forms.TextBox textBoxTelefon;
        private System.Windows.Forms.Label labelTelefon;
        private System.Windows.Forms.TextBox textBoxZusatz;
        private System.Windows.Forms.Label labelZusatz;
        private System.Windows.Forms.TextBox textBoxLieferung;
        private System.Windows.Forms.Label labelLieferung;
        private System.Windows.Forms.TextBox textBoxLieferkosten;
        private System.Windows.Forms.Label labelLieferkosten;
        private System.Windows.Forms.TextBox textBoxSumme;
        private System.Windows.Forms.Label labelSumme;
        private System.Windows.Forms.TextBox textBoxRabatt;
        private System.Windows.Forms.Label labelRabatt;
        private System.Windows.Forms.TextBox textBoxInfo;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.TextBox textBoxBezahlt;
        private System.Windows.Forms.Label labelBezahlt;
        private System.Windows.Forms.Button buttonZurück;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArtikelNr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bezeichnung;
        private System.Windows.Forms.DataGridViewTextBoxColumn Menge;
        private System.Windows.Forms.DataGridViewTextBoxColumn Preis;
        private System.Windows.Forms.DataGridViewTextBoxColumn Zusatz;
    }
}