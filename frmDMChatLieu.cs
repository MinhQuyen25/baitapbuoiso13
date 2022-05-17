using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ViDuProject1605
{
    public partial class frmDMChatLieu : Form
    {
        public frmDMChatLieu()
        {
            InitializeComponent();
        }

        DataTable tblCL;
        private void frmDMChatlieu_Load(object sender, EventArgs e)
        {
            txtMaChatLieu.Enabled = false;
            btnLuu.Enabled = false;

            Load_gridviewtableChatLieu();
        }

        private void Load_gridviewtableChatLieu()
        {
            string sql;
            sql = "SELECT Machatlieu, Tenchatlieu FROM tblChatlieu";
            tblCL = DAO.GetDataToTable(sql);
            gridviewChatLieu.DataSource = tblCL;
            gridviewChatLieu.Columns[0].HeaderText = "Mã chất liệu";
            gridviewChatLieu.Columns[1].HeaderText = "Tên chất liệu";
            gridviewChatLieu.Columns[0].Width = 100;
            gridviewChatLieu.Columns[1].Width = 300;
            // Không cho phép thêm mới dữ liệu trực tiếp trên lưới
            gridviewChatLieu.AllowUserToAddRows = false;
            // Không cho phép sửa dữ liệu trực tiếp trên lưới
            gridviewChatLieu.EditMode =
            DataGridViewEditMode.EditProgrammatically;
        }

        

        private void btnThem_Click(object sender, EventArgs e)
            {
           
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnCapNhat.Enabled = false;
                btnLuu.Enabled = true;
                btnThem.Enabled = false;
                ResetValues();
                txtMaChatLieu.Enabled = true;
                txtMaChatLieu.Focus();
            }

                private void ResetValues()
                {
                txtMaChatLieu.Text = "";
                txtTenChatLieu.Text = "";
                }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            
                string sql;
                if (txtMaChatLieu.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập mã chất liệu", "Thông báo",

                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    txtMaChatLieu.Focus();
                    return;
                 }
                if (txtTenChatLieu.Text.Trim().Length == 0)
                {
                MessageBox.Show("Bạn phải nhập tên chất liệu", "Thông báo",

                MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtTenChatLieu.Focus();
                return ;
                 }

                sql = "SELECT MaChatlieu FROM tblChatlieu WHERE MaChatlieu = N'" +

                txtMaChatLieu.Text.Trim() + " ' ";

                if (DAO.CheckKey(sql))
                {
                    MessageBox.Show("Mã chất liệu này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    txtMaChatLieu.Focus();
                    txtMaChatLieu.Text = "" ;
                return;
            }
            sql = "INSERT INTO tblChatlieu(Machatlieu, Tenchatlieu) VALUES(N '" +

            txtMaChatLieu.Text + "',N'" + txtTenChatLieu.Text + "')";

            DAO.RunSql(sql);
            
            ResetValues();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnCapNhat.Enabled = false;
            btnLuu.Enabled = false;
            txtMaChatLieu.Enabled = false;
        }

        
    }
}

      