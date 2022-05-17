using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViDuProject1605
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //Mo ket noi toi CSDL
            DAO.Connect();
        }

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Application.Exit();

        }
        
        

        private void chấtLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                frmDMChatLieu f = new frmDMChatLieu();
                f.StartPosition = FormStartPosition.CenterScreen;
                f.Show();
            
        }
    }
    }

