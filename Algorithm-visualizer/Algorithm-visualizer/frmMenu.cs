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

        private void frmMenu_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmSearch frmSearch = new frmSearch();
            frmSearch.Show();
            this.Hide();
        }

        private void btnData_Click(object sender, EventArgs e)
        {
            frmDatastructure frmData = new frmDatastructure();
            frmData.Show();
            this.Hide();
        }
    }

}
