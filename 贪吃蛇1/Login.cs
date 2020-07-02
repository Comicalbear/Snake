using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 贪吃蛇1.NewFolder1;

namespace 贪吃蛇1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "select admin,password from persen where admin='" + username_text.Text + "'";
            SqlDataReader sqlData = Sqlhelp.ExecuteSql(sql);
            if (sqlData.HasRows)
            {
                Sqlhelp.Close();
                sql = "select password from persen where password = '" + password_text.Text + "'";
                sqlData = Sqlhelp.ExecuteSql(sql);
                if (sqlData.HasRows)
                {
                    MessageBox.Show("登陆成功！");
                    Close();
                    Sqlhelp.Close();
                }
                else { MessageBox.Show("密码错误！"); }
            }
            else { MessageBox.Show("账号或密码错误！"); Sqlhelp.Close(); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Newad newad = new Newad();
            newad.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
