namespace Algorithm_visualizer
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        public void btnSort_Click(object sender, EventArgs e)
        {
            frmSort frmSort = new frmSort();
            frmSort.Show();
            this.Hide();
        }

        private void frmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }

}
