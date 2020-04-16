namespace crawler
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnCrawl = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.lblurl = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.detailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detailBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCrawl
            // 
            this.btnCrawl.Location = new System.Drawing.Point(572, 25);
            this.btnCrawl.Margin = new System.Windows.Forms.Padding(20, 15, 20, 20);
            this.btnCrawl.Name = "btnCrawl";
            this.btnCrawl.Size = new System.Drawing.Size(103, 33);
            this.btnCrawl.TabIndex = 0;
            this.btnCrawl.Text = "开始爬行";
            this.btnCrawl.UseVisualStyleBackColor = true;
            this.btnCrawl.Click += new System.EventHandler(this.BtnCrawl_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lblurl);
            this.flowLayoutPanel1.Controls.Add(this.txtUrl);
            this.flowLayoutPanel1.Controls.Add(this.btnCrawl);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(800, 80);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // txtUrl
            // 
            this.txtUrl.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.detailBindingSource, "URL", true));
            this.txtUrl.Location = new System.Drawing.Point(140, 30);
            this.txtUrl.Margin = new System.Windows.Forms.Padding(0, 20, 30, 20);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(382, 28);
            this.txtUrl.TabIndex = 2;
            this.txtUrl.Text = "https://www.cnblogs.com/dstang2000/";
            // 
            // lblurl
            // 
            this.lblurl.AutoSize = true;
            this.lblurl.Location = new System.Drawing.Point(40, 35);
            this.lblurl.Margin = new System.Windows.Forms.Padding(30, 25, 20, 20);
            this.lblurl.Name = "lblurl";
            this.lblurl.Size = new System.Drawing.Size(80, 18);
            this.lblurl.TabIndex = 3;
            this.lblurl.Text = "起始地址";
            // 
            // richTextBox1
            // 
            this.richTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.detailBindingSource, "Details", true));
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 80);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(800, 370);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // detailBindingSource
            // 
            this.detailBindingSource.DataSource = typeof(crawler.SimpleCrawler);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detailBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCrawl;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblurl;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.BindingSource detailBindingSource;
    }
}

