using Algorithm_visualizer.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Algorithm_visualizer
{
    public partial class frmSearch : Form
    {
        Graph currentGraph = Graph.GenerateRandomGraph(6, 8);

        public frmSearch()
        {
            InitializeComponent();

            lblGraph.Text = currentGraph.GetGraphAsText();
        }

        public async Task BFS(Graph graph, int start, Panel pnlAnimation)
        {
            bool[] visited = new bool[graph.GetVerticesCount()];
            Queue<int> queue = new Queue<int>();
            string result = "( ";

            // Marcar o nó inicial como visitado e enfileirar
            visited[start] = true;
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                int currentNode = queue.Dequeue();
                result += currentNode + " ";
                // Atualizar o desenho (mostrar o nó atual sendo visitado)
                DrawGraph(pnlAnimation, graph, currentNode);
                await Task.Delay(800); // Delay para animação

                // Percorrer os vizinhos do nó atual
                foreach (int neighbor in graph.GetNeighbors(currentNode))
                {
                    if (!visited[neighbor])
                    {
                        visited[neighbor] = true;
                        queue.Enqueue(neighbor);
                    }
                }
            }
            lblResult.Text = result + ")";
        }



        //Desenha o Grafo na tela
        private void DrawGraph(Panel pnl, Graph graph, int currentNode = -1)
        {
            Graphics g = pnl.CreateGraphics();
            g.Clear(Color.White);

            // Ativar Antialiasing para suavizar as linhas
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int nodeRadius = 30; // Raio do nó
            int centerX = pnlAnimation.ClientSize.Width / 2;
            int centerY = pnlAnimation.ClientSize.Height / 2;
            int circleRadius = Math.Min(centerX, centerY) - 50; // Raio do círculo onde os nós serão posicionados

            Point[] nodePositions = new Point[graph.GetVerticesCount()];

            // 1. Calcular posições em um círculo
            for (int i = 0; i < graph.GetVerticesCount(); i++)
            {
                double angle = 2 * Math.PI * i / graph.GetVerticesCount(); // Ângulo para distribuir os nós
                int x = centerX + (int)(circleRadius * Math.Cos(angle));
                int y = centerY + (int)(circleRadius * Math.Sin(angle));
                nodePositions[i] = new Point(x, y);
            }

            // 2. Desenhar as arestas (linhas)
            Pen edgePen = new Pen(Color.Gray, 2); // Linha das arestas
            foreach (int i in Enumerable.Range(0, graph.GetVerticesCount()))
            {
                foreach (int neighbor in graph.GetNeighbors(i))
                {
                    if (i < neighbor) // Desenha apenas uma vez cada aresta
                    {
                        g.DrawLine(edgePen, nodePositions[i], nodePositions[neighbor]);
                    }
                }
            }

            // 3. Desenhar os nós (círculos)
            for (int i = 0; i < graph.GetVerticesCount(); i++)
            {
                Brush brush = (i == currentNode) ? Brushes.Red : Brushes.Blue;

                Point pos = nodePositions[i];
                g.FillEllipse(brush, pos.X - nodeRadius / 2, pos.Y - nodeRadius / 2, nodeRadius, nodeRadius);
                g.DrawEllipse(Pens.Black, pos.X - nodeRadius / 2, pos.Y - nodeRadius / 2, nodeRadius, nodeRadius);

                // Exibir o número do nó
                string text = i.ToString();
                g.DrawString(text, new Font("Arial", 12), Brushes.White, pos.X - 8, pos.Y - 8);
            }
        }

        //metodo Draw do DFS
        private void DrawGraph(Graphics g, int highlightNode = -1)
        {
            int nodeRadius = 20;
            int totalNodes = currentGraph.getAdjlist().Length;

            // Desenha as arestas
            for (int i = 0; i < totalNodes; i++)
            {
                Point from = GetNodePosition(i, totalNodes, pnlAnimation.Width, pnlAnimation.Height);
                foreach (int neighbor in currentGraph.getAdjlist()[i])
                {
                    Point to = GetNodePosition(neighbor, totalNodes, pnlAnimation.Width, pnlAnimation.Height);
                    g.DrawLine(Pens.Black, from, to);
                }
            }

            // Desenha os nós
            for (int i = 0; i < totalNodes; i++)
            {
                Point position = GetNodePosition(i, totalNodes, pnlAnimation.Width, pnlAnimation.Height);
                Brush brush = (i == highlightNode) ? Brushes.Red : Brushes.LightGray;

                // Desenha o nó
                g.FillEllipse(brush, position.X - nodeRadius, position.Y - nodeRadius, nodeRadius * 2, nodeRadius * 2);
                g.DrawEllipse(Pens.Black, position.X - nodeRadius, position.Y - nodeRadius, nodeRadius * 2, nodeRadius * 2);

                // Desenha o índice do nó
                g.DrawString(i.ToString(), new Font("Arial", 10), Brushes.Black, position.X - 10, position.Y - 10);
            }
        }

        private Point GetNodePosition(int index, int totalNodes, int panelWidth, int panelHeight)
        {
            double angle = (2 * Math.PI / totalNodes) * index; // Divide o círculo igualmente entre os nós
            int centerX = panelWidth / 2;
            int centerY = panelHeight / 2;
            int radius = Math.Min(panelWidth, panelHeight) / 3; // Raio do círculo onde os nós ficarão

            int x = centerX + (int)(radius * Math.Cos(angle));
            int y = centerY + (int)(radius * Math.Sin(angle));

            return new Point(x, y);
        }


        private async void RunDFSAnimation()
        {
            bool[] visited = new bool[currentGraph.getAdjlist().Length];
            Stack<int> stack = new Stack<int>();
            stack.Push(0); // Começa no nó 0 (ou outro inicial)
            string result = "( ";

            while (stack.Count > 0)
            {
                int currentNode = stack.Pop();

                if (!visited[currentNode])
                {
                    visited[currentNode] = true;

                    result += currentNode + " ";
                    // Atualiza o desenho destacando o nó atual
                    pnlAnimation.Invalidate();
                    pnlAnimation.Paint += (s, e) => DrawGraph(e.Graphics, currentNode);
                    await Task.Delay(500);

                    // Adiciona os vizinhos à pilha
                    foreach (int neighbor in currentGraph.getAdjlist()[currentNode])
                    {
                        if (!visited[neighbor])
                            stack.Push(neighbor);
                    }
                }
            }

            result += " )";
            lblResult.Text = result;
            
        }


        private async void btnBFS_Click(object sender, EventArgs e)
        {
            // Executar BFS a partir do nó 0
            await BFS(currentGraph, 0, pnlAnimation);
        }

        private void btnGraph_Click(object sender, EventArgs e)
        {
            int vertices = 6; // Número de nós (pode ser alterado)
            int edges = 8;    // Número de arestas (pode ser alterado)

            currentGraph = Graph.GenerateRandomGraph(vertices, edges);
            lblGraph.Text = currentGraph.GetGraphAsText();
            pnlAnimation.Invalidate(); // Redesenha o painel
        }

        private void pnlAnimation_Paint(object? sender, PaintEventArgs e)
        {
            if (currentGraph != null)
            {
                DrawGraph(pnlAnimation, currentGraph);
            }
        }


        private void frmSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmMenu frmMenu = new frmMenu();
            frmMenu.Show();
            this.Hide();
        }

        private void btnDFS_Click(object sender, EventArgs e)
        {
            
            RunDFSAnimation();
        }

    }
}
