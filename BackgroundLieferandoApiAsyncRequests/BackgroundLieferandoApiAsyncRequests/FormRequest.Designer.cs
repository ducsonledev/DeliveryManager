
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
            this.btnStart = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.progressBarRequest = new System.Windows.Forms.ProgressBar();
            this.labelRequest = new System.Windows.Forms.Label();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Location = new System.Drawing.Point(60, 174);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(113, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start Request";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(296, 174);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(113, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel Request";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // progressBarRequest
            // 
            this.progressBarRequest.Location = new System.Drawing.Point(60, 126);
            this.progressBarRequest.Name = "progressBarRequest";
            this.progressBarRequest.Size = new System.Drawing.Size(349, 23);
            this.progressBarRequest.TabIndex = 2;
            // 
            // labelRequest
            // 
            this.labelRequest.AutoSize = true;
            this.labelRequest.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelRequest.Location = new System.Drawing.Point(57, 91);
            this.labelRequest.Name = "labelRequest";
            this.labelRequest.Size = new System.Drawing.Size(107, 13);
            this.labelRequest.TabIndex = 3;
            this.labelRequest.Text = "Running Requests ...";
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // FormRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(475, 318);
            this.Controls.Add(this.labelRequest);
            this.Controls.Add(this.progressBarRequest);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnStart);
            this.Name = "FormRequest";
            this.Text = "FormRequest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ProgressBar progressBarRequest;
        private System.Windows.Forms.Label labelRequest;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
    }
}

