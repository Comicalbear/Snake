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
    public partial class Newad : Form
    {
        public Newad()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sqlhelp.Close();
            string sql = "select admin from persen where admin='" + textBox1.Text + "'";
            SqlDataReader sqlData = Sqlhelp.ExecuteSql(sql);
            if (!sqlData.HasRows)
            {
                if (textBox2.Text == textBox3.Text)
                {
                    Sqlhelp.Close();
                    sql = "insert into persen values('" + textBox1.Text + "','" + textBox2.Text + "')";
                    sqlData = Sqlhelp.ExecuteSql(sql);
                    MessageBox.Show("注册成功！");
                    Sqlhelp.Close();
                    Close();
                }
                else
                {
                    MessageBox.Show("两次密码不一致！");
                    Sqlhelp.Close();
                }
            }
            else { MessageBox.Show("用户已存在！"); Sqlhelp.Close(); }
    }

        private void Newad_Load(object sender, EventArgs e)
        {

        }
    }
}
