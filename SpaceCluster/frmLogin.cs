using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SpaceCluster
{
    public partial class frmLogin : Form
    {
        MySqlConnection cn = null;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                String strCon = @"server=34.95.171.244;user id=root;password=jhaxjB3AbpnNzv4d;database=spacecluster;SslMode=none";
                cn = new MySqlConnection(strCon);
                cn.Open();
            }
            catch { 
                picBDConnection.Image = SpaceCluster.Properties.Resources.BDflagOFF;
                txtLogin.Enabled = false;
                txtPass.Enabled = false;
                btnLogin.Enabled = false;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.Connection = cn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from user where login_user='" + txtLogin.Text + "' and pass_user='" + txtPass.Text + "';";
            DataTable dt = new DataTable();
            dt.Load(comm.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                this.Hide();
                MessageBox.Show("Logado com Sucesso!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Falha no login, usuario não cadastrado!");
            }
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            cn.Close();
        }
    }
}
