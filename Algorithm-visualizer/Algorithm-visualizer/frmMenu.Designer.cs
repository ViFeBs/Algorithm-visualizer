namespace Algorithm_visualizer
{
    partial class frmMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSort = new Button();
            SuspendLayout();
            // 
            // btnSort
            // 
            btnSort.Location = new Point(40, 65);
            btnSort.Name = "btnSort";
            btnSort.Size = new Size(105, 45);
            btnSort.TabIndex = 0;
            btnSort.Text = "Sort Algorithm";
            btnSort.UseVisualStyleBackColor = true;
            btnSort.Click += btnSort_Click;
            // 
            // frmMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSort);
            Name = "frmMenu";
            Text = "Menu";
            FormClosing += frmMenu_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        private Button btnSort;
    }
}
