namespace Algorithm_visualizer
{
    partial class frmSearch
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
            pnlAnimation = new Panel();
            btnBFS = new Button();
            btnGraph = new Button();
            btnBack = new Button();
            lblGraph = new Label();
            lblResult = new Label();
            SuspendLayout();
            // 
            // pnlAnimation
            // 
            pnlAnimation.Location = new Point(12, 95);
            pnlAnimation.Name = "pnlAnimation";
            pnlAnimation.Size = new Size(776, 343);
            pnlAnimation.TabIndex = 0;
            // 
            // btnBFS
            // 
            btnBFS.Location = new Point(495, 38);
            btnBFS.Name = "btnBFS";
            btnBFS.Size = new Size(141, 41);
            btnBFS.TabIndex = 1;
            btnBFS.Text = "BFS";
            btnBFS.UseVisualStyleBackColor = true;
            btnBFS.Click += btnBFS_Click;
            // 
            // btnGraph
            // 
            btnGraph.Location = new Point(108, 38);
            btnGraph.Name = "btnGraph";
            btnGraph.Size = new Size(141, 41);
            btnGraph.TabIndex = 2;
            btnGraph.Text = "Generate Graph";
            btnGraph.UseVisualStyleBackColor = true;
            btnGraph.Click += btnGraph_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(12, 38);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(46, 26);
            btnBack.TabIndex = 3;
            btnBack.Text = "<--";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // lblGraph
            // 
            lblGraph.AutoSize = true;
            lblGraph.Location = new Point(268, 9);
            lblGraph.Name = "lblGraph";
            lblGraph.Size = new Size(39, 15);
            lblGraph.TabIndex = 4;
            lblGraph.Text = "Graph";
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(331, 9);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(39, 15);
            lblResult.TabIndex = 5;
            lblResult.Text = "Result";
            // 
            // frmSearch
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(lblResult);
            Controls.Add(lblGraph);
            Controls.Add(btnBack);
            Controls.Add(btnGraph);
            Controls.Add(btnBFS);
            Controls.Add(pnlAnimation);
            Name = "frmSearch";
            Text = "Search Algorithm";
            FormClosing += frmSearch_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlAnimation;
        private Button btnBFS;
        private Button btnGraph;
        private Button btnBack;
        private Label lblGraph;
        private Label lblResult;
    }
}