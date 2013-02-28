﻿namespace EDMDownload.Forms
{
    partial class MainWindow
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tab_LivingElectro = new System.Windows.Forms.TabPage();
            this.tab_Log = new System.Windows.Forms.TabPage();
            this.list_Log = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbl_ToolStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.bar_ToolStrip = new System.Windows.Forms.ToolStripProgressBar();
            this.num_LivingElectroPages = new System.Windows.Forms.NumericUpDown();
            this.btn_CrawlLivingElectro = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tab_LivingElectro.SuspendLayout();
            this.tab_Log.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_LivingElectroPages)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tab_LivingElectro);
            this.tabControl.Controls.Add(this.tab_Log);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(667, 530);
            this.tabControl.TabIndex = 0;
            // 
            // tab_LivingElectro
            // 
            this.tab_LivingElectro.Controls.Add(this.btn_CrawlLivingElectro);
            this.tab_LivingElectro.Controls.Add(this.num_LivingElectroPages);
            this.tab_LivingElectro.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab_LivingElectro.Location = new System.Drawing.Point(4, 22);
            this.tab_LivingElectro.Name = "tab_LivingElectro";
            this.tab_LivingElectro.Padding = new System.Windows.Forms.Padding(3);
            this.tab_LivingElectro.Size = new System.Drawing.Size(659, 504);
            this.tab_LivingElectro.TabIndex = 0;
            this.tab_LivingElectro.Text = "Living Electro";
            this.tab_LivingElectro.UseVisualStyleBackColor = true;
            // 
            // tab_Log
            // 
            this.tab_Log.Controls.Add(this.list_Log);
            this.tab_Log.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab_Log.Location = new System.Drawing.Point(4, 22);
            this.tab_Log.Name = "tab_Log";
            this.tab_Log.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Log.Size = new System.Drawing.Size(659, 504);
            this.tab_Log.TabIndex = 2;
            this.tab_Log.Text = "Log";
            this.tab_Log.UseVisualStyleBackColor = true;
            // 
            // list_Log
            // 
            this.list_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list_Log.FormattingEnabled = true;
            this.list_Log.Location = new System.Drawing.Point(3, 3);
            this.list_Log.Name = "list_Log";
            this.list_Log.Size = new System.Drawing.Size(653, 498);
            this.list_Log.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbl_ToolStrip,
            this.bar_ToolStrip});
            this.statusStrip1.Location = new System.Drawing.Point(0, 508);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(667, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbl_ToolStrip
            // 
            this.lbl_ToolStrip.Name = "lbl_ToolStrip";
            this.lbl_ToolStrip.Size = new System.Drawing.Size(87, 17);
            this.lbl_ToolStrip.Text = "Log Statement:";
            // 
            // bar_ToolStrip
            // 
            this.bar_ToolStrip.Name = "bar_ToolStrip";
            this.bar_ToolStrip.Size = new System.Drawing.Size(100, 16);
            // 
            // num_LivingElectroPages
            // 
            this.num_LivingElectroPages.Location = new System.Drawing.Point(64, 38);
            this.num_LivingElectroPages.Name = "num_LivingElectroPages";
            this.num_LivingElectroPages.Size = new System.Drawing.Size(58, 20);
            this.num_LivingElectroPages.TabIndex = 0;
            this.num_LivingElectroPages.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_LivingElectroPages.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // btn_CrawlLivingElectro
            // 
            this.btn_CrawlLivingElectro.Location = new System.Drawing.Point(64, 64);
            this.btn_CrawlLivingElectro.Name = "btn_CrawlLivingElectro";
            this.btn_CrawlLivingElectro.Size = new System.Drawing.Size(153, 23);
            this.btn_CrawlLivingElectro.TabIndex = 1;
            this.btn_CrawlLivingElectro.Text = "Crawl Living Electro!";
            this.btn_CrawlLivingElectro.UseVisualStyleBackColor = true;
            this.btn_CrawlLivingElectro.Click += new System.EventHandler(this.btn_CrawlLivingElectro_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 530);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl);
            this.Name = "MainWindow";
            this.Text = "EDM Download";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.tabControl.ResumeLayout(false);
            this.tab_LivingElectro.ResumeLayout(false);
            this.tab_Log.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_LivingElectroPages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tab_LivingElectro;
        private System.Windows.Forms.TabPage tab_Log;
        private System.Windows.Forms.ListBox list_Log;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbl_ToolStrip;
        private System.Windows.Forms.ToolStripProgressBar bar_ToolStrip;
        private System.Windows.Forms.NumericUpDown num_LivingElectroPages;
        private System.Windows.Forms.Button btn_CrawlLivingElectro;
    }
}