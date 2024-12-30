namespace Algorithm_visualizer
{
    partial class frmDatastructure
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
            btnBack = new Button();
            btnPush = new Button();
            pnlAnimation = new Panel();
            pnlTree = new Panel();
            groupBox1 = new GroupBox();
            btnPop = new Button();
            lblWarning = new Label();
            groupBox2 = new GroupBox();
            btnDequeue = new Button();
            btnEnqueue = new Button();
            groupBox3 = new GroupBox();
            btnInsert = new Button();
            pnlAnimation.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // btnBack
            // 
            btnBack.Location = new Point(12, 30);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(46, 26);
            btnBack.TabIndex = 4;
            btnBack.Text = "<--";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // btnPush
            // 
            btnPush.Location = new Point(6, 34);
            btnPush.Name = "btnPush";
            btnPush.Size = new Size(73, 41);
            btnPush.TabIndex = 5;
            btnPush.Text = "Push";
            btnPush.UseVisualStyleBackColor = true;
            btnPush.Click += btnPush_Click;
            // 
            // pnlAnimation
            // 
            pnlAnimation.Controls.Add(pnlTree);
            pnlAnimation.Location = new Point(12, 128);
            pnlAnimation.Name = "pnlAnimation";
            pnlAnimation.Size = new Size(776, 310);
            pnlAnimation.TabIndex = 6;
            pnlAnimation.Paint += pnlAnimation_Paint;
            // 
            // pnlTree
            // 
            pnlTree.Location = new Point(133, 3);
            pnlTree.Name = "pnlTree";
            pnlTree.Size = new Size(588, 248);
            pnlTree.TabIndex = 0;
            pnlTree.Paint += pnlTree_Paint;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnPop);
            groupBox1.Controls.Add(btnPush);
            groupBox1.Location = new Point(76, 22);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 100);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Stack";
            // 
            // btnPop
            // 
            btnPop.Location = new Point(121, 34);
            btnPop.Name = "btnPop";
            btnPop.Size = new Size(73, 41);
            btnPop.TabIndex = 6;
            btnPop.Text = "Pop";
            btnPop.UseVisualStyleBackColor = true;
            btnPop.Click += btnPop_Click;
            // 
            // lblWarning
            // 
            lblWarning.AutoSize = true;
            lblWarning.Location = new Point(294, 9);
            lblWarning.Name = "lblWarning";
            lblWarning.Size = new Size(0, 15);
            lblWarning.TabIndex = 8;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnDequeue);
            groupBox2.Controls.Add(btnEnqueue);
            groupBox2.Location = new Point(282, 22);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(200, 100);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Queue";
            // 
            // btnDequeue
            // 
            btnDequeue.Location = new Point(121, 34);
            btnDequeue.Name = "btnDequeue";
            btnDequeue.Size = new Size(73, 41);
            btnDequeue.TabIndex = 11;
            btnDequeue.Text = "Dequeue";
            btnDequeue.UseVisualStyleBackColor = true;
            btnDequeue.Click += btnDequeue_Click;
            // 
            // btnEnqueue
            // 
            btnEnqueue.Location = new Point(12, 34);
            btnEnqueue.Name = "btnEnqueue";
            btnEnqueue.Size = new Size(73, 41);
            btnEnqueue.TabIndex = 10;
            btnEnqueue.Text = "Enqueue";
            btnEnqueue.UseVisualStyleBackColor = true;
            btnEnqueue.Click += btnEnqueue_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnInsert);
            groupBox3.Location = new Point(499, 22);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(200, 100);
            groupBox3.TabIndex = 10;
            groupBox3.TabStop = false;
            groupBox3.Text = "Tree";
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(15, 34);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(73, 41);
            btnInsert.TabIndex = 12;
            btnInsert.Text = "Insert Node";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // frmDatastructure
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(lblWarning);
            Controls.Add(groupBox1);
            Controls.Add(pnlAnimation);
            Controls.Add(btnBack);
            Name = "frmDatastructure";
            Text = "Data Structure";
            FormClosing += frmDatastructure_FormClosing;
            pnlAnimation.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBack;
        private Button btnPush;
        private Panel pnlAnimation;
        private GroupBox groupBox1;
        private Button btnPop;
        private Label lblWarning;
        private GroupBox groupBox2;
        private Button btnEnqueue;
        private Button btnDequeue;
        private GroupBox groupBox3;
        private Button btnInsert;
        private Panel pnlTree;
    }
}