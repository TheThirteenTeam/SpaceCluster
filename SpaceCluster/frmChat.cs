using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;

namespace SpaceCluster
{
    public partial class frmChat : Form
    {
        MySqlConnection cn;
        int user = 6;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
        public frmChat()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void frmChat_Load(object sender, EventArgs e)
        {
            lblNome.Parent = pcbPerfilInfo;
            lblNome.BackColor = Color.Transparent;

            lblRole.Parent = pcbPerfilInfo;
            lblRole.BackColor = Color.Transparent;

            lblMylogs.Parent = pcbMyLogs;
            lblMylogs.BackColor = Color.Transparent;

            pcbSearchBTN.Parent = pcbSearch;
            pcbSearchBTN.BackColor = Color.Transparent;

            lblMission.Parent = pcbMission;
            lblMission.BackColor = Color.Transparent;
            try
            {
                String strCon = @"server=34.95.171.244;user id=root;password=jhaxjB3AbpnNzv4d;database=spacecluster;SslMode=none";
                cn = new MySqlConnection(strCon);
                cn.Open();
            }
            catch
            {
                MessageBox.Show("Não foi possivel conectar ao banco de dados.");
                Application.Exit();
            }
            MySqlCommand comm = new MySqlCommand();
            comm.Connection = cn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from user where id_user='" + user + "';";
            DataTable dt = new DataTable();
            dt.Load(comm.ExecuteReader());
            lblNome.Text = dt.Rows[0][1].ToString();
            lblRole.Text = dt.Rows[0][5].ToString();
            timeAttdgv.Enabled = true;
        }

        private void timeAttdgv_Tick(object sender, EventArgs e)
        {
            MySqlCommand comm = new MySqlCommand();
            DataTable dt = new DataTable();

            comm.Connection = cn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select datalog_log, content_log from log where id_user='" + user + "' ORDER BY datalog_log DESC;";
            
            dt.Load(comm.ExecuteReader());
            dgvUser.DataSource = dt;
            dgvUser.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvUser.ClearSelection();
            dgvUser.CurrentCell = null;

            dt = new DataTable();
            comm.Connection = cn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select datalog_log, user_log, content_log from log ORDER BY datalog_log DESC;";
            dt.Load(comm.ExecuteReader());
            dgvGeneral.DataSource = dt;
            dgvGeneral.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvGeneral.ClearSelection();
            dgvGeneral.CurrentCell = null;

            dt = new DataTable();
            comm.Connection = cn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select datalog_log, content_log from log where id_user='1' ORDER BY datalog_log DESC;";
            dt.Load(comm.ExecuteReader());
            dgvFastTrack1.DataSource = dt;
            dgvFastTrack1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvFastTrack1.ClearSelection();
            dgvFastTrack1.CurrentCell = null;

            dt = new DataTable();
            comm.Connection = cn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select datalog_log, content_log from log where id_user='2' ORDER BY datalog_log DESC;";
            dt.Load(comm.ExecuteReader());
            dgvFastTrack2.DataSource = dt;
            dgvFastTrack2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvFastTrack2.ClearSelection();
            dgvFastTrack2.CurrentCell = null;

            dt = new DataTable();
            comm.Connection = cn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select datalog_log, content_log from log where id_user='3' ORDER BY datalog_log DESC;";
            dt.Load(comm.ExecuteReader());
            dgvFastTrack3.DataSource = dt;
            dgvFastTrack3.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvFastTrack3.ClearSelection();
            dgvFastTrack3.CurrentCell = null;

            dt = new DataTable();
            comm.Connection = cn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select datalog_log, content_log from log where id_user='4' ORDER BY datalog_log DESC;";
            dt.Load(comm.ExecuteReader());
            dgvFastTrack4.DataSource = dt;
            dgvFastTrack4.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvFastTrack4.ClearSelection();
            dgvFastTrack4.CurrentCell = null;

            dt = new DataTable();
            comm.Connection = cn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select datalog_log, content_log from log where id_user='5' ORDER BY datalog_log DESC;";
            dt.Load(comm.ExecuteReader());
            dgvFastTrack5.DataSource = dt;
            dgvFastTrack5.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvFastTrack5.ClearSelection();
            dgvFastTrack5.CurrentCell = null;

            dt = new DataTable();
            comm.Connection = cn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select datalog_log, content_log from log where id_user='6' ORDER BY datalog_log DESC;";
            dt.Load(comm.ExecuteReader());
            dgvFastTrack6.DataSource = dt;
            dgvFastTrack6.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvFastTrack6.ClearSelection();
            dgvFastTrack6.CurrentCell = null;

            dt = new DataTable();
            comm.Connection = cn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select datalog_log, content_log from log where id_user='7' ORDER BY datalog_log DESC;";
            dt.Load(comm.ExecuteReader());
            dgvFastTrack7.DataSource = dt;
            dgvFastTrack7.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvFastTrack7.ClearSelection();
            dgvFastTrack7.CurrentCell = null;

            dt = new DataTable();
            comm.Connection = cn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select datalog_log, content_log from log where id_user='8' ORDER BY datalog_log DESC;";
            dt.Load(comm.ExecuteReader());
            dgvFastTrack8.DataSource = dt;
            dgvFastTrack8.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvFastTrack8.ClearSelection();
            dgvFastTrack8.CurrentCell = null;
        }

        private void pcbClose_Click(object sender, EventArgs e)
        {
            cn.Close();
            Application.Exit();
        }

        private void txtText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MySqlCommand comm = new MySqlCommand();
                comm.Connection = cn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "insert into log values (0, '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + lblNome.Text + "','" + txtText.Text + "','" + user + "');";
                comm.ExecuteNonQuery();
                txtText.Text = "";
                txtText.PlaceholderText = "Text";
            }
        }
    }
}
