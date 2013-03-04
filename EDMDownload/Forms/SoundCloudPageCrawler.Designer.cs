namespace EDMDownload.Forms
{
    partial class SoundCloudPageCrawler
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
            this.web_SoundCloud = new System.Windows.Forms.WebBrowser();
            this.timer_Update = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // web_SoundCloud
            // 
            this.web_SoundCloud.Dock = System.Windows.Forms.DockStyle.Fill;
            this.web_SoundCloud.Location = new System.Drawing.Point(0, 0);
            this.web_SoundCloud.MinimumSize = new System.Drawing.Size(20, 20);
            this.web_SoundCloud.Name = "web_SoundCloud";
            this.web_SoundCloud.Size = new System.Drawing.Size(480, 382);
            this.web_SoundCloud.TabIndex = 0;
            this.web_SoundCloud.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.web_SoundCloud_DocumentCompleted);
            // 
            // timer_Update
            // 
            this.timer_Update.Enabled = true;
            this.timer_Update.Interval = 1000;
            this.timer_Update.Tick += new System.EventHandler(this.timer_Update_Tick);
            // 
            // SoundCloudPageCrawler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 382);
            this.Controls.Add(this.web_SoundCloud);
            this.Name = "SoundCloudPageCrawler";
            this.Text = "SoundCloudPageCrawler";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser web_SoundCloud;
        private System.Windows.Forms.Timer timer_Update;
    }
}