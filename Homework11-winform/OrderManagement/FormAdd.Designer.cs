namespace OrderManagement
{
    partial class FormAdd
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
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtCuName = new System.Windows.Forms.TextBox();
            this.txtAddr = new System.Windows.Forms.TextBox();
            this.lblNum = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblAddr = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblItemDetail = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnModifyItem = new System.Windows.Forms.Button();
            this.btnDeleteItem = new System.Windows.Forms.Button();
            this.btnSaveOrder = new System.Windows.Forms.Button();
            this.orderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ItembindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItembindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtID
            // 
            this.txtID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderBindingSource, "OrderNum", true));
            this.txtID.Location = new System.Drawing.Point(94, 26);
            this.txtID.Margin = new System.Windows.Forms.Padding(3, 13, 23, 23);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 28);
            this.txtID.TabIndex = 0;
            // 
            // txtCuName
            // 
            this.txtCuName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderBindingSource, "Customer", true));
            this.txtCuName.Location = new System.Drawing.Point(298, 26);
            this.txtCuName.Margin = new System.Windows.Forms.Padding(3, 13, 23, 23);
            this.txtCuName.Name = "txtCuName";
            this.txtCuName.Size = new System.Drawing.Size(100, 28);
            this.txtCuName.TabIndex = 1;
            // 
            // txtAddr
            // 
            this.txtAddr.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderBindingSource, "Address", true));
            this.txtAddr.Location = new System.Drawing.Point(502, 26);
            this.txtAddr.Margin = new System.Windows.Forms.Padding(3, 13, 23, 23);
            this.txtAddr.Name = "txtAddr";
            this.txtAddr.Size = new System.Drawing.Size(100, 28);
            this.txtAddr.TabIndex = 2;
            // 
            // lblNum
            // 
            this.lblNum.Location = new System.Drawing.Point(26, 26);
            this.lblNum.Margin = new System.Windows.Forms.Padding(13, 13, 3, 23);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(62, 28);
            this.lblNum.TabIndex = 3;
            this.lblNum.Text = "订单号";
            this.lblNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCustomer
            // 
            this.lblCustomer.Location = new System.Drawing.Point(230, 26);
            this.lblCustomer.Margin = new System.Windows.Forms.Padding(13, 13, 3, 23);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(62, 28);
            this.lblCustomer.TabIndex = 4;
            this.lblCustomer.Text = "顾客名";
            this.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAddr
            // 
            this.lblAddr.Location = new System.Drawing.Point(434, 26);
            this.lblAddr.Margin = new System.Windows.Forms.Padding(13, 13, 3, 23);
            this.lblAddr.Name = "lblAddr";
            this.lblAddr.Size = new System.Drawing.Size(62, 28);
            this.lblAddr.TabIndex = 5;
            this.lblAddr.Text = "地址";
            this.lblAddr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lblNum);
            this.flowLayoutPanel1.Controls.Add(this.txtID);
            this.flowLayoutPanel1.Controls.Add(this.lblCustomer);
            this.flowLayoutPanel1.Controls.Add(this.txtCuName);
            this.flowLayoutPanel1.Controls.Add(this.lblAddr);
            this.flowLayoutPanel1.Controls.Add(this.txtAddr);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(13);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(800, 82);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.ItembindingSource1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 82);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(800, 368);
            this.dataGridView1.TabIndex = 7;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.lblItemDetail);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 82);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(800, 48);
            this.flowLayoutPanel2.TabIndex = 8;
            // 
            // lblItemDetail
            // 
            this.lblItemDetail.AutoSize = true;
            this.lblItemDetail.Location = new System.Drawing.Point(23, 13);
            this.lblItemDetail.Margin = new System.Windows.Forms.Padding(23, 13, 23, 0);
            this.lblItemDetail.Name = "lblItemDetail";
            this.lblItemDetail.Size = new System.Drawing.Size(98, 18);
            this.lblItemDetail.TabIndex = 0;
            this.lblItemDetail.Text = "订单明细：";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.btnAddItem);
            this.flowLayoutPanel3.Controls.Add(this.btnModifyItem);
            this.flowLayoutPanel3.Controls.Add(this.btnDeleteItem);
            this.flowLayoutPanel3.Controls.Add(this.btnSaveOrder);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 389);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(800, 61);
            this.flowLayoutPanel3.TabIndex = 9;
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(20, 20);
            this.btnAddItem.Margin = new System.Windows.Forms.Padding(20);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(110, 30);
            this.btnAddItem.TabIndex = 0;
            this.btnAddItem.Text = "添加明细";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.BtnAddItem_Click);
            // 
            // btnModifyItem
            // 
            this.btnModifyItem.Location = new System.Drawing.Point(170, 20);
            this.btnModifyItem.Margin = new System.Windows.Forms.Padding(20);
            this.btnModifyItem.Name = "btnModifyItem";
            this.btnModifyItem.Size = new System.Drawing.Size(110, 30);
            this.btnModifyItem.TabIndex = 1;
            this.btnModifyItem.Text = "修改明细";
            this.btnModifyItem.UseVisualStyleBackColor = true;
            this.btnModifyItem.Click += new System.EventHandler(this.BtnModifyItem_Click);
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.Location = new System.Drawing.Point(320, 20);
            this.btnDeleteItem.Margin = new System.Windows.Forms.Padding(20);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(110, 30);
            this.btnDeleteItem.TabIndex = 2;
            this.btnDeleteItem.Text = "删除明细";
            this.btnDeleteItem.UseVisualStyleBackColor = true;
            this.btnDeleteItem.Click += new System.EventHandler(this.BtnDeleteItem_Click);
            // 
            // btnSaveOrder
            // 
            this.btnSaveOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveOrder.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSaveOrder.Location = new System.Drawing.Point(610, 20);
            this.btnSaveOrder.Margin = new System.Windows.Forms.Padding(160, 20, 20, 20);
            this.btnSaveOrder.Name = "btnSaveOrder";
            this.btnSaveOrder.Size = new System.Drawing.Size(110, 30);
            this.btnSaveOrder.TabIndex = 3;
            this.btnSaveOrder.Text = "保存订单";
            this.btnSaveOrder.UseVisualStyleBackColor = true;
            // 
            // orderBindingSource
            // 
            this.orderBindingSource.DataSource = typeof(ConsoleApp3.Order);
            // 
            // ItembindingSource1
            // 
            this.ItembindingSource1.DataMember = "ItemList";
            this.ItembindingSource1.DataSource = this.orderBindingSource;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "Price";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "Amount";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            // 
            // FormAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "FormAdd";
            this.Text = "FormAdd";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItembindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtCuName;
        private System.Windows.Forms.TextBox txtAddr;
        private System.Windows.Forms.Label lblNum;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblAddr;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label lblItemDetail;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnModifyItem;
        private System.Windows.Forms.Button btnDeleteItem;
        private System.Windows.Forms.Button btnSaveOrder;
        private System.Windows.Forms.BindingSource orderBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource ItembindingSource1;
    }
}