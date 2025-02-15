﻿namespace ChatServer
{
    partial class ServidorChat
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
            this.txtIP = new System.Windows.Forms.TextBox();
            this.numPorta = new System.Windows.Forms.NumericUpDown();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.listaLog = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.numPorta)).BeginInit();
            this.SuspendLayout();
            // 
            // txtIP
            // 
            this.txtIP.BackColor = System.Drawing.Color.LightGray;
            this.txtIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIP.ForeColor = System.Drawing.SystemColors.InfoText;
            this.txtIP.Location = new System.Drawing.Point(12, 12);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(314, 35);
            this.txtIP.TabIndex = 0;
            this.txtIP.Text = "127.0.0.1";
            // 
            // numPorta
            // 
            this.numPorta.BackColor = System.Drawing.Color.LightGray;
            this.numPorta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numPorta.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPorta.ForeColor = System.Drawing.SystemColors.InfoText;
            this.numPorta.Location = new System.Drawing.Point(332, 13);
            this.numPorta.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numPorta.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numPorta.Name = "numPorta";
            this.numPorta.Size = new System.Drawing.Size(222, 35);
            this.numPorta.TabIndex = 1;
            this.numPorta.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // btnStartServer
            // 
            this.btnStartServer.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnStartServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartServer.Location = new System.Drawing.Point(560, 13);
            this.btnStartServer.Margin = new System.Windows.Forms.Padding(0);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(228, 35);
            this.btnStartServer.TabIndex = 2;
            this.btnStartServer.Text = "Start Server";
            this.btnStartServer.UseVisualStyleBackColor = false;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartServer_Click);
            // 
            // listaLog
            // 
            this.listaLog.BackColor = System.Drawing.Color.LightGray;
            this.listaLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listaLog.FormattingEnabled = true;
            this.listaLog.ItemHeight = 24;
            this.listaLog.Location = new System.Drawing.Point(12, 53);
            this.listaLog.Name = "listaLog";
            this.listaLog.Size = new System.Drawing.Size(776, 388);
            this.listaLog.TabIndex = 3;
            // 
            // ServidorChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 472);
            this.Controls.Add(this.listaLog);
            this.Controls.Add(this.btnStartServer);
            this.Controls.Add(this.numPorta);
            this.Controls.Add(this.txtIP);
            this.Name = "ServidorChat";
            this.Text = "Servidor de Chat";
            ((System.ComponentModel.ISupportInitialize)(this.numPorta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.NumericUpDown numPorta;
        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.ListBox listaLog;
    }
}

