namespace Lb2_4_Up_store
{
    partial class FormOrders
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
            panelTopOrder = new Panel();
            lblUserNameOrder = new Label();
            btnLogutOrder = new Button();
            dgvOrders = new DataGridView();
            panelTopOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            SuspendLayout();
            // 
            // panelTopOrder
            // 
            panelTopOrder.Controls.Add(lblUserNameOrder);
            panelTopOrder.Controls.Add(btnLogutOrder);
            panelTopOrder.Dock = DockStyle.Top;
            panelTopOrder.Location = new Point(10, 10);
            panelTopOrder.Name = "panelTopOrder";
            panelTopOrder.Padding = new Padding(0, 0, 0, 10);
            panelTopOrder.Size = new Size(964, 40);
            panelTopOrder.TabIndex = 0;
            // 
            // lblUserNameOrder
            // 
            lblUserNameOrder.AutoSize = true;
            lblUserNameOrder.Dock = DockStyle.Right;
            lblUserNameOrder.Location = new Point(769, 0);
            lblUserNameOrder.Name = "lblUserNameOrder";
            lblUserNameOrder.Size = new Size(45, 19);
            lblUserNameOrder.TabIndex = 1;
            lblUserNameOrder.Text = "label1";
            lblUserNameOrder.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnLogutOrder
            // 
            btnLogutOrder.BackColor = Color.MediumSpringGreen;
            btnLogutOrder.Dock = DockStyle.Right;
            btnLogutOrder.FlatStyle = FlatStyle.Flat;
            btnLogutOrder.Location = new Point(814, 0);
            btnLogutOrder.Name = "btnLogutOrder";
            btnLogutOrder.Size = new Size(150, 30);
            btnLogutOrder.TabIndex = 0;
            btnLogutOrder.Text = "Выход";
            btnLogutOrder.UseVisualStyleBackColor = false;
            btnLogutOrder.Click += BtnLogutOrder_Click;
            // 
            // dgvOrders
            // 
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AllowUserToDeleteRows = false;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvOrders.BackgroundColor = Color.White;
            dgvOrders.BorderStyle = BorderStyle.None;
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrders.ColumnHeadersVisible = false;
            dgvOrders.Dock = DockStyle.Fill;
            dgvOrders.Location = new Point(10, 50);
            dgvOrders.MultiSelect = false;
            dgvOrders.Name = "dgvOrders";
            dgvOrders.ReadOnly = true;
            dgvOrders.RowHeadersVisible = false;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.Size = new Size(964, 601);
            dgvOrders.TabIndex = 1;
            // 
            // FormOrders
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(984, 661);
            Controls.Add(dgvOrders);
            Controls.Add(panelTopOrder);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4);
            Name = "FormOrders";
            Padding = new Padding(10);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Заказы";
            panelTopOrder.ResumeLayout(false);
            panelTopOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTopOrder;
        private Button btnLogutOrder;
        private Label lblUserNameOrder;
        private DataGridView dgvOrders;
    }
}