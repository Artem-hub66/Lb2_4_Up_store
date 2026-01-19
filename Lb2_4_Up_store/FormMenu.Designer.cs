namespace Lb2_4_Up_store
{
    partial class FormMenu
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
            panelTopMenu = new Panel();
            lblUserNameMenu = new Label();
            btnLogutMenu = new Button();
            panelTopMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelTopMenu
            // 
            panelTopMenu.Controls.Add(lblUserNameMenu);
            panelTopMenu.Controls.Add(btnLogutMenu);
            panelTopMenu.Location = new Point(10, 10);
            panelTopMenu.Name = "panelTopMenu";
            panelTopMenu.Padding = new Padding(0, 0, 0, 10);
            panelTopMenu.Size = new Size(964, 40);
            panelTopMenu.TabIndex = 0;
            // 
            // lblUserNameMenu
            // 
            lblUserNameMenu.AutoSize = true;
            lblUserNameMenu.Dock = DockStyle.Right;
            lblUserNameMenu.Location = new Point(769, 0);
            lblUserNameMenu.Name = "lblUserNameMenu";
            lblUserNameMenu.Size = new Size(45, 19);
            lblUserNameMenu.TabIndex = 1;
            lblUserNameMenu.Text = "label1";
            lblUserNameMenu.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnLogutMenu
            // 
            btnLogutMenu.BackColor = Color.MediumSpringGreen;
            btnLogutMenu.Dock = DockStyle.Right;
            btnLogutMenu.FlatStyle = FlatStyle.Flat;
            btnLogutMenu.Location = new Point(814, 0);
            btnLogutMenu.Name = "btnLogutMenu";
            btnLogutMenu.Size = new Size(150, 30);
            btnLogutMenu.TabIndex = 0;
            btnLogutMenu.Text = "Выход";
            btnLogutMenu.UseVisualStyleBackColor = false;
            btnLogutMenu.Click += BtnLogutMenu_Click;
            // 
            // FormMenu
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(984, 661);
            Controls.Add(panelTopMenu);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4);
            Name = "FormMenu";
            Padding = new Padding(10);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Меню";
            panelTopMenu.ResumeLayout(false);
            panelTopMenu.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTopMenu;
        private Button btnLogutMenu;
        private Label lblUserNameMenu;
    }
}