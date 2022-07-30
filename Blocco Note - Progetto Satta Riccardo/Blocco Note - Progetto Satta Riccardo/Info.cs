using System;
using System.Windows.Forms;

namespace Blocco_Note___Progetto_Satta_Riccardo
{
    public partial class Info : Form
    {
        public Info()
        {
            InitializeComponent();
        }
        private void Info_Load(object sender, EventArgs e)
        {}
        private void btn_accedereAlBloccoNote_Click(object sender, EventArgs e)
        {
            MainForm MainForm = new MainForm();
            MainForm.Show();
            Hide();
        }
    }
}
