
namespace BackgroundLieferandoApiAsyncRequests
{
    partial class FormRequest
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.btnStart = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DataGridViewFormRequest = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonDetails = new System.Windows.Forms.Button();
            this.panelLieferzeitSenden = new System.Windows.Forms.Panel();
            this.button15min = new System.Windows.Forms.Button();
            this.button60min = new System.Windows.Forms.Button();
            this.button45min = new System.Windows.Forms.Button();
            this.button20min = new System.Windows.Forms.Button();
            this.button30min = new System.Windows.Forms.Button();
            this.labelLieferzeitSenden = new System.Windows.Forms.Label();
            this.checkBoxLieferzeit = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonZubereitungStart = new System.Windows.Forms.Button();
            this.buttonLieferungStart = new System.Windows.Forms.Button();
            this.buttonLieferungAbschließen = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewFormRequest)).BeginInit();
            this.panelLieferzeitSenden.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Location = new System.Drawing.Point(19, 74);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(107, 23);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.Location = new System.Drawing.Point(43, 41);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(284, 13);
            this.resultLabel.TabIndex = 6;
            this.resultLabel.Text = "Klicke auf \"Start\" um Anfragen an Lieferando zu beginnen!";
            this.resultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(265, 74);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(107, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "for testing";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.resultLabel);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Location = new System.Drawing.Point(21, 313);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(383, 107);
            this.panel1.TabIndex = 10;
            // 
            // DataGridViewFormRequest
            // 
            this.DataGridViewFormRequest.AllowUserToAddRows = false;
            this.DataGridViewFormRequest.AllowUserToDeleteRows = false;
            this.DataGridViewFormRequest.AllowUserToResizeColumns = false;
            this.DataGridViewFormRequest.AllowUserToResizeRows = false;
            this.DataGridViewFormRequest.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridViewFormRequest.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.DataGridViewFormRequest.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGridViewFormRequest.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.DataGridViewFormRequest.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.DataGridViewFormRequest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewFormRequest.GridColor = System.Drawing.Color.Black;
            this.DataGridViewFormRequest.Location = new System.Drawing.Point(0, 112);
            this.DataGridViewFormRequest.Name = "DataGridViewFormRequest";
            this.DataGridViewFormRequest.ReadOnly = true;
            this.DataGridViewFormRequest.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewFormRequest.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridViewFormRequest.Size = new System.Drawing.Size(848, 171);
            this.DataGridViewFormRequest.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "20.11.2021 12:32:12";
            // 
            // buttonDetails
            // 
            this.buttonDetails.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonDetails.Location = new System.Drawing.Point(12, 12);
            this.buttonDetails.Name = "buttonDetails";
            this.buttonDetails.Size = new System.Drawing.Size(110, 49);
            this.buttonDetails.TabIndex = 13;
            this.buttonDetails.Text = "Details anzeigen";
            this.buttonDetails.UseVisualStyleBackColor = true;
            this.buttonDetails.Click += new System.EventHandler(this.buttonDetails_Click);
            // 
            // panelLieferzeitSenden
            // 
            this.panelLieferzeitSenden.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLieferzeitSenden.Controls.Add(this.button15min);
            this.panelLieferzeitSenden.Controls.Add(this.button60min);
            this.panelLieferzeitSenden.Controls.Add(this.button45min);
            this.panelLieferzeitSenden.Controls.Add(this.button20min);
            this.panelLieferzeitSenden.Controls.Add(this.button30min);
            this.panelLieferzeitSenden.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelLieferzeitSenden.Location = new System.Drawing.Point(133, 17);
            this.panelLieferzeitSenden.Name = "panelLieferzeitSenden";
            this.panelLieferzeitSenden.Size = new System.Drawing.Size(282, 60);
            this.panelLieferzeitSenden.TabIndex = 14;
            this.panelLieferzeitSenden.Tag = "";
            // 
            // button15min
            // 
            this.button15min.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button15min.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button15min.FlatAppearance.BorderSize = 0;
            this.button15min.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button15min.Location = new System.Drawing.Point(3, 5);
            this.button15min.Margin = new System.Windows.Forms.Padding(0);
            this.button15min.Name = "button15min";
            this.button15min.Size = new System.Drawing.Size(50, 50);
            this.button15min.TabIndex = 15;
            this.button15min.Text = "15 min";
            this.button15min.UseVisualStyleBackColor = false;
            this.button15min.Click += new System.EventHandler(this.button15min_Click);
            // 
            // button60min
            // 
            this.button60min.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button60min.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button60min.Location = new System.Drawing.Point(227, 5);
            this.button60min.Name = "button60min";
            this.button60min.Size = new System.Drawing.Size(50, 50);
            this.button60min.TabIndex = 19;
            this.button60min.Text = "60 min";
            this.button60min.UseVisualStyleBackColor = false;
            this.button60min.Click += new System.EventHandler(this.button60min_Click);
            // 
            // button45min
            // 
            this.button45min.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button45min.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button45min.Location = new System.Drawing.Point(171, 5);
            this.button45min.Name = "button45min";
            this.button45min.Size = new System.Drawing.Size(50, 50);
            this.button45min.TabIndex = 21;
            this.button45min.Text = "45 min";
            this.button45min.UseVisualStyleBackColor = false;
            this.button45min.Click += new System.EventHandler(this.button45min_Click);
            // 
            // button20min
            // 
            this.button20min.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button20min.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button20min.Location = new System.Drawing.Point(59, 5);
            this.button20min.Name = "button20min";
            this.button20min.Size = new System.Drawing.Size(50, 50);
            this.button20min.TabIndex = 18;
            this.button20min.Text = "20 min";
            this.button20min.UseVisualStyleBackColor = false;
            this.button20min.Click += new System.EventHandler(this.button20min_Click);
            // 
            // button30min
            // 
            this.button30min.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button30min.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button30min.Location = new System.Drawing.Point(115, 5);
            this.button30min.Name = "button30min";
            this.button30min.Size = new System.Drawing.Size(50, 50);
            this.button30min.TabIndex = 20;
            this.button30min.Text = "30 min";
            this.button30min.UseVisualStyleBackColor = false;
            this.button30min.Click += new System.EventHandler(this.button30min_Click);
            // 
            // labelLieferzeitSenden
            // 
            this.labelLieferzeitSenden.AutoSize = true;
            this.labelLieferzeitSenden.Location = new System.Drawing.Point(137, 7);
            this.labelLieferzeitSenden.Name = "labelLieferzeitSenden";
            this.labelLieferzeitSenden.Size = new System.Drawing.Size(87, 13);
            this.labelLieferzeitSenden.TabIndex = 22;
            this.labelLieferzeitSenden.Text = "Lieferzeit senden";
            // 
            // checkBoxLieferzeit
            // 
            this.checkBoxLieferzeit.AutoSize = true;
            this.checkBoxLieferzeit.Location = new System.Drawing.Point(133, 89);
            this.checkBoxLieferzeit.Name = "checkBoxLieferzeit";
            this.checkBoxLieferzeit.Size = new System.Drawing.Size(156, 17);
            this.checkBoxLieferzeit.TabIndex = 23;
            this.checkBoxLieferzeit.Text = "Automatische Lieferzeit von";
            this.checkBoxLieferzeit.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Info;
            this.textBox1.Location = new System.Drawing.Point(286, 87);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(35, 20);
            this.textBox1.TabIndex = 24;
            this.textBox1.Text = "30";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(324, 90);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "min";
            // 
            // buttonZubereitungStart
            // 
            this.buttonZubereitungStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonZubereitungStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonZubereitungStart.Location = new System.Drawing.Point(434, 17);
            this.buttonZubereitungStart.Name = "buttonZubereitungStart";
            this.buttonZubereitungStart.Size = new System.Drawing.Size(135, 68);
            this.buttonZubereitungStart.TabIndex = 26;
            this.buttonZubereitungStart.Text = "Zubereitung starten";
            this.buttonZubereitungStart.UseVisualStyleBackColor = false;
            this.buttonZubereitungStart.Click += new System.EventHandler(this.buttonZubereitungStart_Click);
            // 
            // buttonLieferungStart
            // 
            this.buttonLieferungStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonLieferungStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonLieferungStart.Location = new System.Drawing.Point(575, 17);
            this.buttonLieferungStart.Name = "buttonLieferungStart";
            this.buttonLieferungStart.Size = new System.Drawing.Size(128, 68);
            this.buttonLieferungStart.TabIndex = 27;
            this.buttonLieferungStart.Text = "Lieferung starten";
            this.buttonLieferungStart.UseVisualStyleBackColor = false;
            this.buttonLieferungStart.Click += new System.EventHandler(this.buttonLieferungStart_Click);
            // 
            // buttonLieferungAbschließen
            // 
            this.buttonLieferungAbschließen.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.buttonLieferungAbschließen.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonLieferungAbschließen.Location = new System.Drawing.Point(709, 17);
            this.buttonLieferungAbschließen.Name = "buttonLieferungAbschließen";
            this.buttonLieferungAbschließen.Size = new System.Drawing.Size(128, 68);
            this.buttonLieferungAbschließen.TabIndex = 28;
            this.buttonLieferungAbschließen.Text = "Lieferung abschließen";
            this.buttonLieferungAbschließen.UseVisualStyleBackColor = false;
            this.buttonLieferungAbschließen.Click += new System.EventHandler(this.buttonLieferungAbschließen_Click);
            // 
            // FormRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(848, 432);
            this.Controls.Add(this.buttonLieferungAbschließen);
            this.Controls.Add(this.buttonLieferungStart);
            this.Controls.Add(this.buttonZubereitungStart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.checkBoxLieferzeit);
            this.Controls.Add(this.labelLieferzeitSenden);
            this.Controls.Add(this.panelLieferzeitSenden);
            this.Controls.Add(this.buttonDetails);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DataGridViewFormRequest);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormRequest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormRequest";
            this.Load += new System.EventHandler(this.FormRequest_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewFormRequest)).EndInit();
            this.panelLieferzeitSenden.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView DataGridViewFormRequest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonDetails;
        private System.Windows.Forms.Panel panelLieferzeitSenden;
        private System.Windows.Forms.Button button15min;
        private System.Windows.Forms.Button button60min;
        private System.Windows.Forms.Button button45min;
        private System.Windows.Forms.Button button20min;
        private System.Windows.Forms.Button button30min;
        private System.Windows.Forms.Label labelLieferzeitSenden;
        private System.Windows.Forms.CheckBox checkBoxLieferzeit;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonZubereitungStart;
        private System.Windows.Forms.Button buttonLieferungStart;
        private System.Windows.Forms.Button buttonLieferungAbschließen;
    }
}

