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
        private PaintEventHandler currentPaintHandler;

        public frmSearch()
        {
            InitializeComponent();

            lblGraph.Text = currentGraph.GetGraphAsText();
        }


        //Desenha o Grafo na tela
        private void DrawGraph(Graphics g, Graph graph, int currentNode = -1)
        {
            g.Clear(Color.White);

            // Ativar Antialiasing para suavizar as linhas
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int nodeRadius = 30; // Raio do nó
            int panelWidth = pnlAnimation.Width;
            int panelHeight = pnlAnimation.Height;

            // Calcula as posições dos nós como uma árvore
            Dictionary<int, Point> nodePositions = new Dictionary<int, Point>();
            CalculateTreePositions(graph, panelWidth, panelHeight, nodePositions);

            // Verifica se todas as posições foram calculadas
           

            // Desenhar as arestas (linhas)
            Pen edgePen = new Pen(Color.Gray, 2); 
            foreach (int i in Enumerable.Range(0, graph.GetVerticesCount())) { 
                foreach (int neighbor in graph.GetNeighbors(i)) { 
                    if (i < neighbor) { 
                        g.DrawLine(edgePen, nodePositions[i], nodePositions[neighbor]); 
                    } 
                } 
            }

            // Desenhar as nós (circulos)
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

        private void CalculateTreePositions(Graph graph, int panelWidth, int panelHeight, Dictionary<int, Point> positions)
        {
            int root = 0; // Supondo que o nó 0 é a raiz
            int level = 0; 
            int xOffset = panelWidth / 2; 
            int yOffset = 50;
            CalculateTreePositionsRecursive(graph, root, level, xOffset, yOffset, panelWidth / 4, positions);
        }

        private void CalculateTreePositionsRecursive(Graph graph, int node, int level, int x, int y, int xSpacing, Dictionary<int, Point> positions) 
        {
            int panelHeight = pnlAnimation.Height;
            y = Math.Min(y, panelHeight - 50);

            positions[node] = new Point(x, y); 
            var neighbors = graph.GetNeighbors(node).Where(n => !positions.ContainsKey(n)).ToList(); 
            int numNeighbors = neighbors.Count; 
            int childXSpacing = xSpacing / (numNeighbors > 1 ? numNeighbors : 2); 
            for (int i = 0; i < numNeighbors; i++) 
            { 
                int childX = x + (i - numNeighbors / 2) * childXSpacing; 
                int childY = y + 100; 
                CalculateTreePositionsRecursive(graph, neighbors[i], level + 1, childX, childY, childXSpacing, positions); 
            } 
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
                    
                    // Atualizar o desenho (mostrar o nó atual sendo visitado)
                    if (currentPaintHandler != null)
                        pnlAnimation.Paint -= currentPaintHandler;


                    currentPaintHandler = (s, e) => DrawGraph(e.Graphics, currentGraph, currentNode);
                    pnlAnimation.Paint += currentPaintHandler;
                    pnlAnimation.Invalidate();
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
            btnBFS.Enabled = true;
            btnDFS.Enabled = true;

        }

        public async Task BFS(Graph graph, int start, Panel pnl)
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
                if (currentPaintHandler != null)
                    pnlAnimation.Paint -= currentPaintHandler;


                currentPaintHandler = (s, e) => DrawGraph(e.Graphics, graph, currentNode);
                pnlAnimation.Paint += currentPaintHandler;
                pnl.Invalidate();
                await Task.Delay(500);
                //await Task.Delay(500);

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
            btnBFS.Enabled = true;
            btnDFS.Enabled = true;
        }


        private async void btnBFS_Click(object sender, EventArgs e)
        {
            btnBFS.Enabled = false;
            btnDFS.Enabled = false;
            // Executar BFS a partir do nó 0
            await BFS(currentGraph, 0, pnlAnimation);
        }

        private void btnGraph_Click(object sender, EventArgs e)
        {
            int vertices = 6; // Número de nós (pode ser alterado)
            int edges = 8;    // Número de arestas (pode ser alterado)

            currentGraph = Graph.GenerateRandomGraph(vertices, edges);
            lblGraph.Text = currentGraph.GetGraphAsText();
            //redesenha painel
            // Remove o event handler atual para evitar duplicações
            if (currentPaintHandler != null) { 
                pnlAnimation.Paint -= currentPaintHandler; 
            } 
            // Define o novo event handler
            currentPaintHandler = (s, e) => DrawGraph(e.Graphics, currentGraph); 
            pnlAnimation.Paint += currentPaintHandler;
            pnlAnimation.Invalidate();
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
            btnBFS.Enabled = false;
            btnDFS.Enabled = false;
            RunDFSAnimation();
        }

    }
}
