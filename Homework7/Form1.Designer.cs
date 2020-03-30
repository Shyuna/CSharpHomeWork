namespace CaylayTree
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
            this.btnDraw = new System.Windows.Forms.Button();
            this.pnlDrawField = new System.Windows.Forms.Panel();
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.lblN = new System.Windows.Forms.Label();
            this.lblLeng = new System.Windows.Forms.Label();
            this.lblPer1 = new System.Windows.Forms.Label();
            this.lblPer2 = new System.Windows.Forms.Label();
            this.lblTh1 = new System.Windows.Forms.Label();
            this.lblTh2 = new System.Windows.Forms.Label();
            this.lblPen = new System.Windows.Forms.Label();
            this.cmbPen = new System.Windows.Forms.ComboBox();
            this.trbPer2 = new System.Windows.Forms.TrackBar();
            this.trbPer1 = new System.Windows.Forms.TrackBar();
            this.trbTh1 = new System.Windows.Forms.TrackBar();
            this.trbTh2 = new System.Windows.Forms.TrackBar();
            this.lblPer1Num = new System.Windows.Forms.Label();
            this.lblPer2Num = new System.Windows.Forms.Label();
            this.lblTh1Num = new System.Windows.Forms.Label();
            this.lblTh2Num = new System.Windows.Forms.Label();
            this.txtN = new System.Windows.Forms.TextBox();
            this.txtLeng = new System.Windows.Forms.TextBox();
            this.pnlDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbPer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbPer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbTh1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbTh2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(181, 458);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(75, 30);
            this.btnDraw.TabIndex = 0;
            this.btnDraw.Text = "绘制";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.BtnDraw_Click);
            // 
            // pnlDrawField
            // 
            this.pnlDrawField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDrawField.Location = new System.Drawing.Point(12, 12);
            this.pnlDrawField.Name = "pnlDrawField";
            this.pnlDrawField.Size = new System.Drawing.Size(411, 440);
            this.pnlDrawField.TabIndex = 1;
            // 
            // pnlDetail
            // 
            this.pnlDetail.Controls.Add(this.txtLeng);
            this.pnlDetail.Controls.Add(this.txtN);
            this.pnlDetail.Controls.Add(this.lblTh2Num);
            this.pnlDetail.Controls.Add(this.lblTh1Num);
            this.pnlDetail.Controls.Add(this.lblPer2Num);
            this.pnlDetail.Controls.Add(this.lblPer1Num);
            this.pnlDetail.Controls.Add(this.trbTh2);
            this.pnlDetail.Controls.Add(this.trbTh1);
            this.pnlDetail.Controls.Add(this.trbPer1);
            this.pnlDetail.Controls.Add(this.trbPer2);
            this.pnlDetail.Controls.Add(this.cmbPen);
            this.pnlDetail.Controls.Add(this.lblPen);
            this.pnlDetail.Controls.Add(this.lblTh2);
            this.pnlDetail.Controls.Add(this.lblTh1);
            this.pnlDetail.Controls.Add(this.lblPer2);
            this.pnlDetail.Controls.Add(this.lblPer1);
            this.pnlDetail.Controls.Add(this.lblLeng);
            this.pnlDetail.Controls.Add(this.lblN);
            this.pnlDetail.Location = new System.Drawing.Point(446, 12);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Size = new System.Drawing.Size(329, 491);
            this.pnlDetail.TabIndex = 2;
            // 
            // lblN
            // 
            this.lblN.AutoSize = true;
            this.lblN.Location = new System.Drawing.Point(15, 23);
            this.lblN.Name = "lblN";
            this.lblN.Size = new System.Drawing.Size(80, 18);
            this.lblN.TabIndex = 0;
            this.lblN.Text = "递归深度";
            // 
            // lblLeng
            // 
            this.lblLeng.AutoSize = true;
            this.lblLeng.Location = new System.Drawing.Point(15, 88);
            this.lblLeng.Name = "lblLeng";
            this.lblLeng.Size = new System.Drawing.Size(80, 18);
            this.lblLeng.TabIndex = 1;
            this.lblLeng.Text = "主干长度";
            // 
            // lblPer1
            // 
            this.lblPer1.AutoSize = true;
            this.lblPer1.Location = new System.Drawing.Point(15, 146);
            this.lblPer1.Name = "lblPer1";
            this.lblPer1.Size = new System.Drawing.Size(116, 18);
            this.lblPer1.TabIndex = 2;
            this.lblPer1.Text = "右分支长度比";
            // 
            // lblPer2
            // 
            this.lblPer2.AutoSize = true;
            this.lblPer2.Location = new System.Drawing.Point(15, 221);
            this.lblPer2.Name = "lblPer2";
            this.lblPer2.Size = new System.Drawing.Size(116, 18);
            this.lblPer2.TabIndex = 3;
            this.lblPer2.Text = "左分支长度比";
            // 
            // lblTh1
            // 
            this.lblTh1.AutoSize = true;
            this.lblTh1.Location = new System.Drawing.Point(15, 296);
            this.lblTh1.Name = "lblTh1";
            this.lblTh1.Size = new System.Drawing.Size(98, 18);
            this.lblTh1.TabIndex = 4;
            this.lblTh1.Text = "右分支角度";
            // 
            // lblTh2
            // 
            this.lblTh2.AutoSize = true;
            this.lblTh2.Location = new System.Drawing.Point(15, 371);
            this.lblTh2.Name = "lblTh2";
            this.lblTh2.Size = new System.Drawing.Size(98, 18);
            this.lblTh2.TabIndex = 5;
            this.lblTh2.Text = "左分支角度";
            // 
            // lblPen
            // 
            this.lblPen.AutoSize = true;
            this.lblPen.Location = new System.Drawing.Point(15, 446);
            this.lblPen.Name = "lblPen";
            this.lblPen.Size = new System.Drawing.Size(80, 18);
            this.lblPen.TabIndex = 6;
            this.lblPen.Text = "画笔颜色";
            // 
            // cmbPen
            // 
            this.cmbPen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPen.FormattingEnabled = true;
            this.cmbPen.Items.AddRange(new object[] {
            "红色",
            "蓝色",
            "黄色",
            "绿色",
            "黑色",
            "粉色"});
            this.cmbPen.Location = new System.Drawing.Point(165, 446);
            this.cmbPen.Name = "cmbPen";
            this.cmbPen.Size = new System.Drawing.Size(121, 26);
            this.cmbPen.TabIndex = 7;
            // 
            // trbPer2
            // 
            this.trbPer2.Location = new System.Drawing.Point(182, 221);
            this.trbPer2.Maximum = 100;
            this.trbPer2.Name = "trbPer2";
            this.trbPer2.Size = new System.Drawing.Size(104, 69);
            this.trbPer2.TabIndex = 8;
            this.trbPer2.Scroll += new System.EventHandler(this.TrbPer2_Scroll);
            // 
            // trbPer1
            // 
            this.trbPer1.Location = new System.Drawing.Point(182, 146);
            this.trbPer1.Maximum = 100;
            this.trbPer1.Name = "trbPer1";
            this.trbPer1.Size = new System.Drawing.Size(104, 69);
            this.trbPer1.TabIndex = 9;
            this.trbPer1.Scroll += new System.EventHandler(this.TrbPer1_Scroll);
            // 
            // trbTh1
            // 
            this.trbTh1.Location = new System.Drawing.Point(182, 296);
            this.trbTh1.Maximum = 90;
            this.trbTh1.Name = "trbTh1";
            this.trbTh1.Size = new System.Drawing.Size(104, 69);
            this.trbTh1.TabIndex = 10;
            this.trbTh1.Scroll += new System.EventHandler(this.TrbTh1_Scroll);
            // 
            // trbTh2
            // 
            this.trbTh2.Location = new System.Drawing.Point(182, 371);
            this.trbTh2.Maximum = 90;
            this.trbTh2.Name = "trbTh2";
            this.trbTh2.Size = new System.Drawing.Size(104, 69);
            this.trbTh2.TabIndex = 11;
            this.trbTh2.Scroll += new System.EventHandler(this.TrbTh2_Scroll);
            // 
            // lblPer1Num
            // 
            this.lblPer1Num.AutoSize = true;
            this.lblPer1Num.Location = new System.Drawing.Point(154, 146);
            this.lblPer1Num.Name = "lblPer1Num";
            this.lblPer1Num.Size = new System.Drawing.Size(17, 18);
            this.lblPer1Num.TabIndex = 14;
            this.lblPer1Num.Text = "0";
            // 
            // lblPer2Num
            // 
            this.lblPer2Num.AutoSize = true;
            this.lblPer2Num.Location = new System.Drawing.Point(154, 221);
            this.lblPer2Num.Name = "lblPer2Num";
            this.lblPer2Num.Size = new System.Drawing.Size(17, 18);
            this.lblPer2Num.TabIndex = 15;
            this.lblPer2Num.Text = "0";
            // 
            // lblTh1Num
            // 
            this.lblTh1Num.AutoSize = true;
            this.lblTh1Num.Location = new System.Drawing.Point(154, 296);
            this.lblTh1Num.Name = "lblTh1Num";
            this.lblTh1Num.Size = new System.Drawing.Size(17, 18);
            this.lblTh1Num.TabIndex = 16;
            this.lblTh1Num.Text = "0";
            // 
            // lblTh2Num
            // 
            this.lblTh2Num.AutoSize = true;
            this.lblTh2Num.Location = new System.Drawing.Point(154, 371);
            this.lblTh2Num.Name = "lblTh2Num";
            this.lblTh2Num.Size = new System.Drawing.Size(17, 18);
            this.lblTh2Num.TabIndex = 17;
            this.lblTh2Num.Text = "0";
            // 
            // txtN
            // 
            this.txtN.Location = new System.Drawing.Point(162, 13);
            this.txtN.Name = "txtN";
            this.txtN.Size = new System.Drawing.Size(124, 28);
            this.txtN.TabIndex = 20;
            // 
            // txtLeng
            // 
            this.txtLeng.Location = new System.Drawing.Point(165, 78);
            this.txtLeng.Name = "txtLeng";
            this.txtLeng.Size = new System.Drawing.Size(121, 28);
            this.txtLeng.TabIndex = 21;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 515);
            this.Controls.Add(this.pnlDetail);
            this.Controls.Add(this.pnlDrawField);
            this.Controls.Add(this.btnDraw);
            this.Name = "Form1";
            this.Text = "CaylayTree";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlDetail.ResumeLayout(false);
            this.pnlDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbPer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbPer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbTh1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbTh2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.Panel pnlDrawField;
        private System.Windows.Forms.Panel pnlDetail;
        private System.Windows.Forms.Label lblPen;
        private System.Windows.Forms.Label lblTh2;
        private System.Windows.Forms.Label lblTh1;
        private System.Windows.Forms.Label lblPer2;
        private System.Windows.Forms.Label lblPer1;
        private System.Windows.Forms.Label lblLeng;
        private System.Windows.Forms.Label lblN;
        private System.Windows.Forms.TrackBar trbTh2;
        private System.Windows.Forms.TrackBar trbTh1;
        private System.Windows.Forms.TrackBar trbPer1;
        private System.Windows.Forms.TrackBar trbPer2;
        private System.Windows.Forms.ComboBox cmbPen;
        private System.Windows.Forms.Label lblTh2Num;
        private System.Windows.Forms.Label lblTh1Num;
        private System.Windows.Forms.Label lblPer2Num;
        private System.Windows.Forms.Label lblPer1Num;
        private System.Windows.Forms.TextBox txtLeng;
        private System.Windows.Forms.TextBox txtN;
    }
}

