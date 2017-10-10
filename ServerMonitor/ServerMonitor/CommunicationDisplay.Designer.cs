namespace ServerMonitor
{
    partial class CommunicationDisplay
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
            this.dgv_data = new System.Windows.Forms.DataGridView();
            this.server_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.server_ip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.last_comm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bw_socket = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_data
            // 
            this.dgv_data.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.server_name,
            this.server_ip,
            this.last_comm});
            this.dgv_data.Location = new System.Drawing.Point(12, 12);
            this.dgv_data.Name = "dgv_data";
            this.dgv_data.Size = new System.Drawing.Size(966, 338);
            this.dgv_data.TabIndex = 0;
            // 
            // server_name
            // 
            this.server_name.HeaderText = "Server Name";
            this.server_name.Name = "server_name";
            this.server_name.ReadOnly = true;
            // 
            // server_ip
            // 
            this.server_ip.HeaderText = "Server IP";
            this.server_ip.Name = "server_ip";
            this.server_ip.ReadOnly = true;
            // 
            // last_comm
            // 
            this.last_comm.HeaderText = "Last Communicated";
            this.last_comm.Name = "last_comm";
            this.last_comm.ReadOnly = true;
            // 
            // CommunicationDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 362);
            this.Controls.Add(this.dgv_data);
            this.Name = "CommunicationDisplay";
            this.Text = "Server Monitor";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_data)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_data;
        private System.Windows.Forms.DataGridViewTextBoxColumn server_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn server_ip;
        private System.Windows.Forms.DataGridViewTextBoxColumn last_comm;
        private System.ComponentModel.BackgroundWorker bw_socket;
    }
}

