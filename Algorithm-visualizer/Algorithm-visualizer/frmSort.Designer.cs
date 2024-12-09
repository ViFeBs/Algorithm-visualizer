namespace Algorithm_visualizer
{
    partial class frmSort
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
            fileSystemWatcher1 = new FileSystemWatcher();
            btnBack = new Button();
            btnArray = new Button();
            btnBubbleSort = new Button();
            lblArray = new Label();
            lblResult = new Label();
            pnlAnimation = new Panel();
            btnQuickSort = new Button();
            btnMergeSort = new Button();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(12, 12);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(43, 23);
            btnBack.TabIndex = 0;
            btnBack.Text = "<-";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnArray
            // 
            btnArray.Location = new Point(127, 14);
            btnArray.Name = "btnArray";
            btnArray.Size = new Size(75, 23);
            btnArray.TabIndex = 1;
            btnArray.Text = "New Array";
            btnArray.UseVisualStyleBackColor = true;
            btnArray.Click += btnArray_Click;
            // 
            // btnBubbleSort
            // 
            btnBubbleSort.Location = new Point(518, 12);
            btnBubbleSort.Name = "btnBubbleSort";
            btnBubbleSort.Size = new Size(75, 23);
            btnBubbleSort.TabIndex = 2;
            btnBubbleSort.Text = "BubbleSort";
            btnBubbleSort.UseVisualStyleBackColor = true;
            btnBubbleSort.Click += btnBubbleSort_Click;
            // 
            // lblArray
            // 
            lblArray.AutoSize = true;
            lblArray.Location = new Point(291, 12);
            lblArray.Name = "lblArray";
            lblArray.Size = new Size(66, 15);
            lblArray.TabIndex = 3;
            lblArray.Text = "Array Atual";
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(291, 37);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(59, 15);
            lblResult.TabIndex = 4;
            lblResult.Text = "Resultado";
            // 
            // pnlAnimation
            // 
            pnlAnimation.Location = new Point(0, 68);
            pnlAnimation.Name = "pnlAnimation";
            pnlAnimation.Size = new Size(798, 383);
            pnlAnimation.TabIndex = 5;
            // 
            // btnQuickSort
            // 
            btnQuickSort.Location = new Point(599, 12);
            btnQuickSort.Name = "btnQuickSort";
            btnQuickSort.Size = new Size(75, 23);
            btnQuickSort.TabIndex = 6;
            btnQuickSort.Text = "Quick Sort";
            btnQuickSort.UseVisualStyleBackColor = true;
            btnQuickSort.Click += btnQuickSort_Click;
            // 
            // btnMergeSort
            // 
            btnMergeSort.Location = new Point(680, 12);
            btnMergeSort.Name = "btnMergeSort";
            btnMergeSort.Size = new Size(75, 23);
            btnMergeSort.TabIndex = 7;
            btnMergeSort.Text = "Merge Sort";
            btnMergeSort.UseVisualStyleBackColor = true;
            btnMergeSort.Click += btnMergeSort_Click;
            // 
            // frmSort
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(btnMergeSort);
            Controls.Add(btnQuickSort);
            Controls.Add(pnlAnimation);
            Controls.Add(lblResult);
            Controls.Add(lblArray);
            Controls.Add(btnBubbleSort);
            Controls.Add(btnArray);
            Controls.Add(btnBack);
            Name = "frmSort";
            Text = "Sort Algorithm";
            FormClosing += frmSort_FormClosing;
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FileSystemWatcher fileSystemWatcher1;
        private Button btnBack;
        private Button btnBubbleSort;
        private Button btnArray;
        private Label lblArray;
        private Label lblResult;
        private Panel pnlAnimation;
        private Button btnQuickSort;
        private Button btnMergeSort;
    }
}
