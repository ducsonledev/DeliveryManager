
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.btnStart = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DataGridViewFormRequest = new System.Windows.Forms.DataGridView();
            this.labelTimeNow = new System.Windows.Forms.Label();
            this.buttonDetails = new System.Windows.Forms.Button();
            this.panelLieferzeitSenden = new System.Windows.Forms.Panel();
            this.button15min = new System.Windows.Forms.Button();
            this.button60min = new System.Windows.Forms.Button();
            this.button45min = new System.Windows.Forms.Button();
            this.button20min = new System.Windows.Forms.Button();
            this.button30min = new System.Windows.Forms.Button();
            this.labelLieferzeitSenden = new System.Windows.Forms.Label();
            this.buttonZubereitungStart = new System.Windows.Forms.Button();
            this.buttonLieferungStart = new System.Windows.Forms.Button();
            this.buttonLieferungAbschließen = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.panelSenderButtons = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewFormRequest)).BeginInit();
            this.panelLieferzeitSenden.SuspendLayout();
            this.panelSenderButtons.SuspendLayout();
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
            this.btnStart.Location = new System.Drawing.Point(23, 55);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(107, 23);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.Location = new System.Drawing.Point(38, 39);
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
            this.btnCancel.Location = new System.Drawing.Point(261, 55);
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
            this.panel1.Location = new System.Drawing.Point(8, 453);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(383, 86);
            this.panel1.TabIndex = 10;
            // 
            // DataGridViewFormRequest
            // 
            this.DataGridViewFormRequest.AllowUserToAddRows = false;
            this.DataGridViewFormRequest.AllowUserToDeleteRows = false;
            this.DataGridViewFormRequest.AllowUserToResizeColumns = false;
            this.DataGridViewFormRequest.AllowUserToResizeRows = false;
            this.DataGridViewFormRequest.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridViewFormRequest.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.DataGridViewFormRequest.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.DataGridViewFormRequest.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGridViewFormRequest.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.DataGridViewFormRequest.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewFormRequest.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.DataGridViewFormRequest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewFormRequest.GridColor = System.Drawing.Color.Black;
            this.DataGridViewFormRequest.Location = new System.Drawing.Point(0, 100);
            this.DataGridViewFormRequest.MultiSelect = false;
            this.DataGridViewFormRequest.Name = "DataGridViewFormRequest";
            this.DataGridViewFormRequest.ReadOnly = true;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewFormRequest.RowHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.DataGridViewFormRequest.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DataGridViewFormRequest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DataGridViewFormRequest.ShowEditingIcon = false;
            this.DataGridViewFormRequest.ShowRowErrors = false;
            this.DataGridViewFormRequest.Size = new System.Drawing.Size(857, 318);
            this.DataGridViewFormRequest.TabIndex = 11;
            this.DataGridViewFormRequest.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewFormRequest_CellClick);
            // 
            // labelTimeNow
            // 
            this.labelTimeNow.AutoSize = true;
            this.labelTimeNow.Location = new System.Drawing.Point(12, 83);
            this.labelTimeNow.Name = "labelTimeNow";
            this.labelTimeNow.Size = new System.Drawing.Size(106, 13);
            this.labelTimeNow.TabIndex = 12;
            this.labelTimeNow.Text = "20.11.2021 12:32:12";
            // 
            // buttonDetails
            // 
            this.buttonDetails.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonDetails.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.buttonDetails.FlatAppearance.BorderSize = 0;
            this.buttonDetails.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.buttonDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDetails.Location = new System.Drawing.Point(8, 17);
            this.buttonDetails.Name = "buttonDetails";
            this.buttonDetails.Size = new System.Drawing.Size(111, 50);
            this.buttonDetails.TabIndex = 13;
            this.buttonDetails.Text = "Details anzeigen";
            this.buttonDetails.UseVisualStyleBackColor = false;
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
            this.panelLieferzeitSenden.Location = new System.Drawing.Point(128, 17);
            this.panelLieferzeitSenden.Name = "panelLieferzeitSenden";
            this.panelLieferzeitSenden.Size = new System.Drawing.Size(323, 68);
            this.panelLieferzeitSenden.TabIndex = 14;
            this.panelLieferzeitSenden.Tag = "";
            // 
            // button15min
            // 
            this.button15min.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button15min.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button15min.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.button15min.FlatAppearance.BorderSize = 0;
            this.button15min.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.button15min.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button15min.Location = new System.Drawing.Point(5, 5);
            this.button15min.Margin = new System.Windows.Forms.Padding(0);
            this.button15min.Name = "button15min";
            this.button15min.Size = new System.Drawing.Size(58, 58);
            this.button15min.TabIndex = 15;
            this.button15min.Text = "15 min";
            this.button15min.UseVisualStyleBackColor = false;
            this.button15min.Click += new System.EventHandler(this.button15min_Click);
            // 
            // button60min
            // 
            this.button60min.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button60min.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.button60min.FlatAppearance.BorderSize = 0;
            this.button60min.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.button60min.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button60min.Location = new System.Drawing.Point(257, 5);
            this.button60min.Name = "button60min";
            this.button60min.Size = new System.Drawing.Size(58, 58);
            this.button60min.TabIndex = 19;
            this.button60min.Text = "60 min";
            this.button60min.UseVisualStyleBackColor = false;
            this.button60min.Click += new System.EventHandler(this.button60min_Click);
            // 
            // button45min
            // 
            this.button45min.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button45min.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.button45min.FlatAppearance.BorderSize = 0;
            this.button45min.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.button45min.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button45min.Location = new System.Drawing.Point(194, 5);
            this.button45min.Name = "button45min";
            this.button45min.Size = new System.Drawing.Size(58, 58);
            this.button45min.TabIndex = 21;
            this.button45min.Text = "45 min";
            this.button45min.UseVisualStyleBackColor = false;
            this.button45min.Click += new System.EventHandler(this.button45min_Click);
            // 
            // button20min
            // 
            this.button20min.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button20min.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.button20min.FlatAppearance.BorderSize = 0;
            this.button20min.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.button20min.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button20min.Location = new System.Drawing.Point(68, 5);
            this.button20min.Name = "button20min";
            this.button20min.Size = new System.Drawing.Size(58, 58);
            this.button20min.TabIndex = 18;
            this.button20min.Text = "20 min";
            this.button20min.UseVisualStyleBackColor = false;
            this.button20min.Click += new System.EventHandler(this.button20min_Click);
            // 
            // button30min
            // 
            this.button30min.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button30min.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.button30min.FlatAppearance.BorderSize = 0;
            this.button30min.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.button30min.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button30min.Location = new System.Drawing.Point(131, 5);
            this.button30min.Name = "button30min";
            this.button30min.Size = new System.Drawing.Size(58, 58);
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
            // buttonZubereitungStart
            // 
            this.buttonZubereitungStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.buttonZubereitungStart.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.buttonZubereitungStart.FlatAppearance.BorderSize = 0;
            this.buttonZubereitungStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.buttonZubereitungStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonZubereitungStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonZubereitungStart.Location = new System.Drawing.Point(457, 18);
            this.buttonZubereitungStart.Name = "buttonZubereitungStart";
            this.buttonZubereitungStart.Size = new System.Drawing.Size(126, 68);
            this.buttonZubereitungStart.TabIndex = 26;
            this.buttonZubereitungStart.Text = "Zubereitung starten";
            this.buttonZubereitungStart.UseVisualStyleBackColor = false;
            this.buttonZubereitungStart.EnabledChanged += new System.EventHandler(this.buttonZubereitungStart_EnabledChanged);
            this.buttonZubereitungStart.Click += new System.EventHandler(this.buttonZubereitungStart_Click);
            this.buttonZubereitungStart.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonZubereitungStart_Paint);
            // 
            // buttonLieferungStart
            // 
            this.buttonLieferungStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonLieferungStart.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.buttonLieferungStart.FlatAppearance.BorderSize = 0;
            this.buttonLieferungStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.buttonLieferungStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLieferungStart.Location = new System.Drawing.Point(589, 18);
            this.buttonLieferungStart.Name = "buttonLieferungStart";
            this.buttonLieferungStart.Size = new System.Drawing.Size(126, 68);
            this.buttonLieferungStart.TabIndex = 27;
            this.buttonLieferungStart.Text = "Lieferung starten";
            this.buttonLieferungStart.UseVisualStyleBackColor = false;
            this.buttonLieferungStart.EnabledChanged += new System.EventHandler(this.buttonLieferungStart_EnabledChanged);
            this.buttonLieferungStart.Click += new System.EventHandler(this.buttonLieferungStart_Click);
            this.buttonLieferungStart.Paint += new System.Windows.Forms.PaintEventHandler(this.buttonLieferungStart_Paint);
            // 
            // buttonLieferungAbschließen
            // 
            this.buttonLieferungAbschließen.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonLieferungAbschließen.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.buttonLieferungAbschließen.FlatAppearance.BorderSize = 0;
            this.buttonLieferungAbschließen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCyan;
            this.buttonLieferungAbschließen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLieferungAbschließen.Location = new System.Drawing.Point(721, 18);
            this.buttonLieferungAbschließen.Name = "buttonLieferungAbschließen";
            this.buttonLieferungAbschließen.Size = new System.Drawing.Size(126, 68);
            this.buttonLieferungAbschließen.TabIndex = 28;
            this.buttonLieferungAbschließen.Text = "Lieferung abschließen";
            this.buttonLieferungAbschließen.UseVisualStyleBackColor = false;
            this.buttonLieferungAbschließen.Click += new System.EventHandler(this.buttonLieferungAbschließen_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // panelSenderButtons
            // 
            this.panelSenderButtons.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panelSenderButtons.Controls.Add(this.buttonLieferungAbschließen);
            this.panelSenderButtons.Controls.Add(this.buttonLieferungStart);
            this.panelSenderButtons.Controls.Add(this.buttonZubereitungStart);
            this.panelSenderButtons.Controls.Add(this.labelLieferzeitSenden);
            this.panelSenderButtons.Controls.Add(this.panelLieferzeitSenden);
            this.panelSenderButtons.Controls.Add(this.buttonDetails);
            this.panelSenderButtons.Controls.Add(this.labelTimeNow);
            this.panelSenderButtons.Location = new System.Drawing.Point(0, 0);
            this.panelSenderButtons.Name = "panelSenderButtons";
            this.panelSenderButtons.Size = new System.Drawing.Size(856, 100);
            this.panelSenderButtons.TabIndex = 29;
            // 
            // FormRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(856, 548);
            this.Controls.Add(this.panelSenderButtons);
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
            this.panelSenderButtons.ResumeLayout(false);
            this.panelSenderButtons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView DataGridViewFormRequest;
        private System.Windows.Forms.Label labelTimeNow;
        private System.Windows.Forms.Button buttonDetails;
        private System.Windows.Forms.Panel panelLieferzeitSenden;
        private System.Windows.Forms.Button button15min;
        private System.Windows.Forms.Button button60min;
        private System.Windows.Forms.Button button45min;
        private System.Windows.Forms.Button button20min;
        private System.Windows.Forms.Button button30min;
        private System.Windows.Forms.Label labelLieferzeitSenden;
        private System.Windows.Forms.Button buttonZubereitungStart;
        private System.Windows.Forms.Button buttonLieferungStart;
        private System.Windows.Forms.Button buttonLieferungAbschließen;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Panel panelSenderButtons;
    }
}

