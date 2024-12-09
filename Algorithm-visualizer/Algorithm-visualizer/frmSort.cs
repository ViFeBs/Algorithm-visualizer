using Microsoft.VisualBasic.Logging;

namespace Algorithm_visualizer
{
    public partial class frmSort : Form
    {
        private Random rnd = new Random();
        private int[] array;
        private int highlightIndex1 = -1; // Índice 1 para destaque
        private int highlightIndex2 = -1; // Índice 2 para destaque
        public frmSort()
        {
            InitializeComponent();
            array = new int[] { rnd.Next(1000), rnd.Next(1000), rnd.Next(1000), rnd.Next(1000), rnd.Next(1000), rnd.Next(1000) };
            updatelblArray();
            this.DoubleBuffered = true;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            pnlAnimation.Paint += (s, e) => DrawArray(e.Graphics); // Desenha o array na tela
        }

        //Desenha a array na tela
        private void DrawArray(Graphics g)
        {
            int barWidth = pnlAnimation.ClientSize.Width / array.Length; // Largura da barra

            for (int i = 0; i < array.Length; i++)
            {
                int barHeight = (int)((array[i] / 1000.0) * pnlAnimation.ClientSize.Height); // Altura proporcional

                // Definir cores: destaque em vermelho, barras normais em azul
                Brush brush = Brushes.Black; // Cor padrão
                if (i == highlightIndex1 || i == highlightIndex2)
                    brush = Brushes.Red; // Cor de destaque (comparação/troca)

                // Desenhar a barra
                g.FillRectangle(brush, i * barWidth, pnlAnimation.ClientSize.Height - barHeight, barWidth - 2, barHeight);
                g.DrawRectangle(Pens.Black, i * barWidth, pnlAnimation.ClientSize.Height - barHeight, barWidth - 2, barHeight);

                // Desenhar o número no meio da barra
                string number = array[i].ToString();
                Font font = new Font("Arial", 10, FontStyle.Bold);
                SizeF textSize = g.MeasureString(number, font);

                float textX = i * barWidth + (barWidth - textSize.Width) / 2;
                float textY = pnlAnimation.ClientSize.Height - barHeight + (barHeight - textSize.Height) / 2;

                g.DrawString(number, font, Brushes.White, textX, textY);
            }
        }

        //Função que vai chamar a draw array
        private void updateDraw(int a, int b)
        {
            pnlAnimation.Invalidate(); // Solicita que o painel seja redesenhado
            pnlAnimation.Update(); // Força a atualização imediata
            this.highlightIndex1 = a;
            this.highlightIndex2 = b;

        }

        //Atualiza a label que mostra a array atual
        private void updatelblArray()
        {
            string text = "[ ";
            for (int i = 0; i < array.Length - 1; i++)
            {
                text += array[i] + ", ";
            }
            lblArray.Text = text + array[array.Length - 1] + " ]";
        }

        //Atualiza a label que mostra o resultado do sort
        private void updatelblResult()
        {
            string text = "[ ";
            for (int i = 0; i < array.Length - 1; i++)
            {
                text += array[i] + ", ";
            }
            lblResult.Text = text + array[array.Length - 1] + " ]";
        }

        //Botão de voltar pro menu
        private void btnBack_Click(object sender, EventArgs e)
        {
            frmMenu frmMenu = new frmMenu();
            frmMenu.Show();
            this.Close();
        }

        //Botão que gera uma nova array
        private void btnArray_Click(object sender, EventArgs e)
        {
            array = new int[] { rnd.Next(1000), rnd.Next(1000), rnd.Next(1000), rnd.Next(1000), rnd.Next(1000), rnd.Next(1000) };
            // Atualizar o desenho
            updateDraw(0);
            updatelblArray();
        }

        //----------------------------------------------------------------------Começo bubble Sort------------------------------------
        private async void btnBubbleSort_Click(object sender, EventArgs e)
        {
            int i, j, temp;
            int n = array.Length;

            for (i = 0; i < n - 1; i++)
            {

                for (j = 0; j < n - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {

                        // Swap arr[j] and arr[j+1]
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        // Atualizar o desenho
                        updateDraw(j, j + 1);

                        // Aguardar para criar a animação
                        await Task.Delay(500);
                    }
                }


            }
            updatelblResult();
        }
        //----------------------------------------------------------------------Fim Bubble Sort------------------------------------
        //----------------------------------------------------------------------Começo Quick Sort------------------------------------
        private async void btnQuickSort_Click(object sender, EventArgs e)
        {
            int n = array.Length;
            await QuickSort(array, 0, n - 1);
            updatelblResult();
        }

        // The QuickSort function implementation
        private async Task QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {

                // pi is the partition return index of pivot
                int pi = await Partition(arr, low, high);

                // Recursion calls for smaller elements
                // and greater or equals elements
                await QuickSort(arr, low, pi - 1);
                await QuickSort(arr, pi + 1, high);
            }
        }

        // Partition function
        private async Task<int> Partition(int[] arr, int low, int high)
        {

            // Choose the pivot
            int pivot = arr[high];

            // Index of smaller element and indicates 
            // the right position of pivot found so far
            int i = low - 1;

            // Traverse arr[low..high] and move all smaller
            // elements to the left side. Elements from low to 
            // i are smaller after every iteration
            for (int j = low; j <= high - 1; j++)
            {
                updateDraw(j, high);
                await Task.Delay(500);

                if (arr[j] < pivot)
                {
                    i++;
                    await Swap(arr, i, j);
                }
            }

            // Move pivot after smaller elements and
            // return its position
            await Swap(arr, i + 1, high);
            return i + 1;
        }

        // Swap function
        private async Task Swap(int[] arr, int i, int j)
        {

            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
            // Atualizar o desenho
            updateDraw(i, j);
            // Aguardar para criar a animação
            await Task.Delay(500);
        }
        //----------------------------------------------------------------------Fim Quick Sort------------------------------------

        //----------------------------------------------------------------------Começo Merge Sort------------------------------------
        private async void btnMergeSort_Click(object sender, EventArgs e)
        {
            await MergeSort(array, 0, array.Length - 1);
            updateDraw(); // Atualiza o desenho final sem destaques
            updatelblResult();
        }

        private async Task MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;

                // Ordena as duas metades recursivamente
                await MergeSort(arr, left, mid);
                await MergeSort(arr, mid + 1, right);

                // Mescla as duas metades ordenadas
                await Merge(arr, left, mid, right);
            }
        }

        private async Task Merge(int[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1; // Tamanho da metade esquerda
            int n2 = right - mid;    // Tamanho da metade direita

            // Arrays temporários
            int[] L = new int[n1];
            int[] R = new int[n2];

            // Copia os elementos para os arrays temporários
            for (int i = 0; i < n1; i++)
                L[i] = arr[left + i];
            for (int j = 0; j < n2; j++)
                R[j] = arr[mid + 1 + j];

            int iL = 0, iR = 0; // Índices iniciais das duas metades
            int k = left;       // Índice inicial do array mesclado

            // Mescla os arrays temporários de volta ao array original
            while (iL < n1 && iR < n2)
            {
                if (L[iL] <= R[iR])
                {
                    arr[k] = L[iL];
                    iL++;
                }
                else
                {
                    arr[k] = R[iR];
                    iR++;
                }

                updateDraw(k); // Atualiza o painel destacando a posição atual
                await Task.Delay(500); // Aguarda para visualizar a animação

                k++;
            }

            // Copia os elementos restantes da metade esquerda (se houver)
            while (iL < n1)
            {
                arr[k] = L[iL];
                iL++;
                updateDraw(k);
                await Task.Delay(500);
                k++;
            }

            // Copia os elementos restantes da metade direita (se houver)
            while (iR < n2)
            {
                arr[k] = R[iR];
                iR++;
                updateDraw(k);
                await Task.Delay(500);
                k++;
            }
        }

        private void updateDraw(int highlightIndex = -1)
        {
            this.highlightIndex1 = highlightIndex; // Índice a ser destacado
            pnlAnimation.Invalidate(); // Solicita redesenho do painel
            pnlAnimation.Update(); // Força a atualização imediata
        }

        private void frmSort_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
