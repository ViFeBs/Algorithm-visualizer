using Algorithm_visualizer.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Algorithm_visualizer
{
    public partial class frmDatastructure : Form
    {
        //stack
        private Stack<int> stack = new Stack<int>();

        //queue
        private Queue<int> queue = new Queue<int>();

        //tree
        private model.TreeNode root = null;
        private const int NodeDiameter = 30;
        private const int MaxDepth = 3;

        //drawing setting
        private const int ItemHeight = 30;
        private const int ItemWidth = 100;

        public frmDatastructure()
        {
            InitializeComponent();
        }

        private void frmDatastructure_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmMenu frmMenu = new frmMenu();
            frmMenu.Show();
            this.Hide();
        }

        //stack push button
        private void btnPush_Click(object sender, EventArgs e)
        {
            int newItem = new Random().Next(100);
            if (stack.Count < 9)
            {
                stack.Push(newItem);
            }
            else
            {
                lblWarning.Text = "You reached the stack limit";
            }

            pnlAnimation.Invalidate();
        }

        //stack pop button
        private void btnPop_Click(object sender, EventArgs e)
        {
            if (stack.Count > 0)
            {
                stack.Pop();
                lblWarning.Text = "";
                pnlAnimation.Invalidate(); // Re-desenha o panel
            }
        }

        private void pnlAnimation_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(pnlAnimation.BackColor);

          
            //Draw stack
            int yStack = pnlAnimation.Height - ItemHeight;

            foreach (var item in stack)
            {
                e.Graphics.FillRectangle(Brushes.LightBlue, new Rectangle(10, yStack, ItemWidth, ItemHeight));
                e.Graphics.DrawRectangle(Pens.Black, new Rectangle(10, yStack, ItemWidth, ItemHeight));
                e.Graphics.DrawString(item.ToString(), this.Font, Brushes.Black, 15, yStack + 5);
                yStack -= ItemHeight + 5;
            }

            //Draw queue
            int yQueue = pnlAnimation.Height - ItemHeight;
            int xQueue = ItemWidth + 20;
            foreach (var item in queue)
            {
                e.Graphics.FillRectangle(Brushes.LightGreen, new Rectangle(xQueue, yQueue, ItemWidth, ItemHeight));
                e.Graphics.DrawRectangle(Pens.Black, new Rectangle(xQueue, yQueue, ItemWidth, ItemHeight));
                e.Graphics.DrawString(item.ToString(), this.Font, Brushes.Black, xQueue + 15, yQueue + 5);
                xQueue += ItemWidth + 10;
            }
        }

        private void btnEnqueue_Click(object sender, EventArgs e)
        {
            int newItem = new Random().Next(100);
            if (queue.Count < 6)
            {
                queue.Enqueue(newItem);
            }
            else
            {
                lblWarning.Text = "You reached the queue limit";
            }
            pnlAnimation.Invalidate();
        }

        private void btnDequeue_Click(object sender, EventArgs e)
        {
            if (queue.Count > 0)
            {
                queue.Dequeue();
                lblWarning.Text = "";
                pnlAnimation.Invalidate();
            }
        }

        // Tree Section
        private model.TreeNode InsertNode(model.TreeNode root, int value, int depth)
        {
            if (root == null)
            {
                return new model.TreeNode(value);
            }

            if (depth >= MaxDepth)
            {
                lblWarning.Text = "Tree can´t get deeper";
                return root; // Não insere novos nós se a profundidade máxima for atingida
            }

            if (value < root.Value)
            {
                root.Left = InsertNode(root.Left, value, depth + 1);
            }
            else
            {
                root.Right = InsertNode(root.Right, value, depth + 1);
            }
            return root;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            int newItem = new Random().Next(100);
            root = InsertNode(root, newItem, 0);
            pnlTree.Invalidate();
        }

        private void DrawTree(Graphics g, model.TreeNode node, int x, int y, int offsetX, int offsetY)
        {
            if (node == null) return;

            // Desenhar o Nó
            g.FillEllipse(Brushes.LightCoral, x - NodeDiameter / 2, y - NodeDiameter / 2, NodeDiameter, NodeDiameter);
            g.DrawEllipse(Pens.Black, x - NodeDiameter / 2, y - NodeDiameter / 2, NodeDiameter, NodeDiameter);
            g.DrawString(node.Value.ToString(), this.Font, Brushes.Black, x - NodeDiameter / 4, y - NodeDiameter / 4);

            // Calcular limites de deslocamento horizontal para não sair do painel
            int panelWidth = pnlAnimation.Width;
            int minX = NodeDiameter / 2;
            int maxX = panelWidth - NodeDiameter / 2;

            // Ajustar a posição dos nós filhos para que fiquem dentro dos limites
            int newOffsetX = Math.Min(offsetX, (maxX - minX) / 2);

            // Desenhar as Conexões e Nós Filhos
            if (node.Left != null)
            {
                int childX = Math.Max(x - newOffsetX, minX);
                g.DrawLine(Pens.Black, x, y, childX, y + offsetY);
                DrawTree(g, node.Left, childX, y + offsetY, newOffsetX / 2, offsetY);
            }

            if (node.Right != null)
            {
                int childX = Math.Min(x + newOffsetX, maxX);
                g.DrawLine(Pens.Black, x, y, childX, y + offsetY);
                DrawTree(g, node.Right, childX, y + offsetY, newOffsetX / 2, offsetY);
            }
        }


        private void pnlTree_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(pnlTree.BackColor);
            // Draw Tree
            int startX = pnlTree.Width / 2;
            int startY = 20;
            int offsetX = 100;
            int offsetY = 60;
            DrawTree(e.Graphics, root, startX, startY, offsetX, offsetY);
        }
    }
}
