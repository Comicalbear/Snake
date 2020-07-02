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
using 贪吃蛇1.NewFolder1;

namespace 贪吃蛇1
{
    public partial class Form11 : Form
    {

        public Form11()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;

        }
        public class Di
        {
            public static int D;
            public static int s = 2;
            public static int score = -1;
        }
        void Add_food()
        {
            Label label = new Label();
            label.Name = "Lab" + Di.s;
            label.BackColor = System.Drawing.Color.Red;
            label.Size = new System.Drawing.Size(10, 10);
            label.Margin = new System.Windows.Forms.Padding(0);
            label.ForeColor = System.Drawing.Color.Red;
            label.AutoSize = false;
            Random rd = new Random();

        tag1:
            label.Location = new System.Drawing.Point(rd.Next(0, 35) * 10, rd.Next(3, 35) * 10);
            for (int i = 1; i < Di.s; i++)
            {
                Label lo = (Label)this.Controls.Find("Lab" + i, true)[0]; if (label.Location == lo.Location) goto tag1;
            }

            this.Controls.Add(label);
            panel1.SendToBack();
            Di.score++;
            scorenumber.Text = "得分：" + Di.score;
        }

        private void button1_Click(object sender, EventArgs e)//开始
        {
            Add_food();
            button1.Enabled = false;
            Di.D = 4;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Di.D == 1) { System.Windows.Forms.SendKeys.Send("{DOWN}"); return; };
            if (Di.D == 2) { System.Windows.Forms.SendKeys.Send("{UP}"); return; };
            if (Di.D == 3) { System.Windows.Forms.SendKeys.Send("{LEFT}"); return; };
            if (Di.D == 4) { System.Windows.Forms.SendKeys.Send("{RIGHT}"); return; };
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && Di.D != 2)
            {
                timer1.Enabled = false;
                Di.D = 1;
                Label lb = (Label)this.Controls.Find("Lab" + Di.s, true)[0];
                Label lbl = (Label)this.Controls.Find("Lab" + (Di.s - 1), true)[0];
                Point[,] Lo = new Point[101, 101];
                for (int i = 1; i <= Di.s; i++)//录入坐标
                {
                    Label lo = (Label)this.Controls.Find("Lab" + i, true)[0]; Lo[i, i] = new Point(lo.Location.X, lo.Location.Y);
                }
                Label le = new Label();
                le.Visible = false;

                if (e.KeyCode == Keys.Down && Di.s > 2 && lbl.BackColor != System.Drawing.Color.Red && Lab1.Location.Y != 340)//蛇身走
                {
                    for (int i = 2; i < Di.s; i++)
                    {
                        Label lo = (Label)this.Controls.Find("Lab" + i, true)[0]; lo.Location = Lo[i - 1, i - 1];
                    }
                }
                if (lb.Location == new System.Drawing.Point(Lab1.Location.X, Lab1.Location.Y + 10))//吃到食物
                {
                    lb.BackColor = System.Drawing.Color.Black;
                    le.Location = new System.Drawing.Point(Lab1.Location.X, Lab1.Location.Y);
                    Lab1.Location = new System.Drawing.Point(Lab1.Location.X, Lab1.Location.Y + 10);
                    lb.Location = le.Location;
                    this.Controls.Remove(le);
                    Di.s++;
                    Add_food();
                    timer1.Enabled = true;
                    return;
                }
                for (int i = 1; i < Di.s; i++)//游戏结束
                {
                    Label lo = (Label)this.Controls.Find("Lab" + i, true)[0]; 
                    if (lo.Location == new System.Drawing.Point(Lab1.Location.X, Lab1.Location.Y + 10)) 
                    { timer1.Enabled = false; MessageBox.Show("游戏结束！", "提示");
                        button2.Enabled = true;
                        return; }; ;
                }

                if (e.KeyCode == Keys.Down && Lab1.Location.Y == 340)
                {
                    timer1.Enabled = false; MessageBox.Show("游戏结束！", "提示");
                    button2.Enabled = true;

                    return;
                };
                Lab1.Top = Lab1.Top + 10;//蛇头走
                timer1.Enabled = true;
            }
            if (e.KeyCode == Keys.Up && Di.D != 1)
            {
                timer1.Enabled = false;
                Di.D = 2;
                Label lb = (Label)this.Controls.Find("Lab" + Di.s, true)[0];
                Label lbl = (Label)this.Controls.Find("Lab" + (Di.s - 1), true)[0];
                Point[,] Lo = new Point[101, 101];
                for (int i = 1; i <= Di.s; i++)
                {
                    Label lo = (Label)this.Controls.Find("Lab" + i, true)[0]; Lo[i, i] = new Point(lo.Location.X, lo.Location.Y);
                }
                Label le = new Label();
                le.Visible = false;

                if (e.KeyCode == Keys.Up && Di.s > 2 && lbl.BackColor != System.Drawing.Color.Red && Lab1.Location.Y != 30)
                {
                    for (int i = 2; i < Di.s; i++)
                    {
                        Label lo = (Label)this.Controls.Find("Lab" + i, true)[0]; lo.Location = Lo[i - 1, i - 1];
                    }
                }
                if (lb.Location == new System.Drawing.Point(Lab1.Location.X, Lab1.Location.Y - 10))
                {
                    lb.BackColor = System.Drawing.Color.Black;
                    le.Location = new System.Drawing.Point(Lab1.Location.X, Lab1.Location.Y);
                    Lab1.Location = new System.Drawing.Point(Lab1.Location.X, Lab1.Location.Y - 10);
                    lb.Location = le.Location;
                    this.Controls.Remove(le);
                    Di.s++;
                    Add_food();
                    timer1.Enabled = true;
                    return;
                }
                for (int i = 1; i < Di.s; i++)
                {
                    Label lo = (Label)this.Controls.Find("Lab" + i, true)[0]; 
                    if (lo.Location == new System.Drawing.Point(Lab1.Location.X, Lab1.Location.Y - 10)) 
                    { timer1.Enabled = false; MessageBox.Show("游戏结束！", "提示");
                        button2.Enabled = true;
                        return; }; ;
                }

                if (e.KeyCode == Keys.Up && Lab1.Location.Y == 30)
                {
                    timer1.Enabled = false; MessageBox.Show("游戏结束！", "提示");
                    button2.Enabled = true;
                    return;
                };
                Lab1.Top = Lab1.Top - 10;
                timer1.Enabled = true;
            }
            if (e.KeyCode == Keys.Left && Di.D != 4)
            {
                timer1.Enabled = false;
                Di.D = 3;
                Label lb = (Label)this.Controls.Find("Lab" + Di.s, true)[0];
                Label lbl = (Label)this.Controls.Find("Lab" + (Di.s - 1), true)[0];
                Point[,] Lo = new Point[101, 101];
                for (int i = 1; i <= Di.s; i++)
                {
                    Label lo = (Label)this.Controls.Find("Lab" + i, true)[0]; Lo[i, i] = new Point(lo.Location.X, lo.Location.Y);
                }
                Label le = new Label();
                le.Visible = false;

                if (e.KeyCode == Keys.Left && Di.s > 2 && lbl.BackColor != System.Drawing.Color.Red && Lab1.Location.X != 0)
                {
                    for (int i = 2; i < Di.s; i++)
                    {
                        Label lo = (Label)this.Controls.Find("Lab" + i, true)[0]; lo.Location = Lo[i - 1, i - 1];
                    }
                }
                if (lb.Location == new System.Drawing.Point(Lab1.Location.X - 10, Lab1.Location.Y))
                {
                    lb.BackColor = System.Drawing.Color.Black;
                    le.Location = new System.Drawing.Point(Lab1.Location.X, Lab1.Location.Y);
                    Lab1.Location = new System.Drawing.Point(Lab1.Location.X - 10, Lab1.Location.Y);
                    lb.Location = le.Location;
                    this.Controls.Remove(le);
                    Di.s++;
                    Add_food();
                    timer1.Enabled = true;
                    return;
                }
                for (int i = 1; i < Di.s; i++)
                {
                    Label lo = (Label)this.Controls.Find("Lab" + i, true)[0]; 
                    if (lo.Location == new System.Drawing.Point(Lab1.Location.X - 10, Lab1.Location.Y)) 
                    { timer1.Enabled = false; MessageBox.Show("游戏结束！", "提示");
                        button2.Enabled = true;
                        return; }; ;
                }

                if (e.KeyCode == Keys.Left && Lab1.Location.X == 0)
                {
                    timer1.Enabled = false; MessageBox.Show("游戏结束！", "提示");
                    button2.Enabled = true;
                    return;
                };
                Lab1.Left = Lab1.Left - 10;
                timer1.Enabled = true;
            }
            if (e.KeyCode == Keys.Right && Di.D != 3)
            {
                timer1.Enabled = false;
                Di.D = 4;
                Label lb = (Label)this.Controls.Find("Lab" + Di.s, true)[0];
                Label lbl = (Label)this.Controls.Find("Lab" + (Di.s - 1), true)[0];
                Point[,] Lo = new Point[101, 101];
                for (int i = 1; i <= Di.s; i++)
                {
                    Label lo = (Label)this.Controls.Find("Lab" + i, true)[0]; Lo[i, i] = new Point(lo.Location.X, lo.Location.Y);
                }
                Label le = new Label();
                le.Visible = false;

                if (e.KeyCode == Keys.Right && Di.s > 2 && lbl.BackColor != System.Drawing.Color.Red && Lab1.Location.X != 340)
                {
                    for (int i = 2; i < Di.s; i++)
                    {
                        Label lo = (Label)this.Controls.Find("Lab" + i, true)[0]; lo.Location = Lo[i - 1, i - 1];
                    }
                }
                if (lb.Location == new System.Drawing.Point(Lab1.Location.X + 10, Lab1.Location.Y))
                {
                    lb.BackColor = System.Drawing.Color.Black;
                    le.Location = new System.Drawing.Point(Lab1.Location.X, Lab1.Location.Y);
                    Lab1.Location = new System.Drawing.Point(Lab1.Location.X + 10, Lab1.Location.Y);
                    lb.Location = le.Location;
                    this.Controls.Remove(le);
                    Di.s++;
                    Add_food();
                    timer1.Enabled = true;
                    return;
                }
                for (int i = 1; i < Di.s; i++)
                {
                    Label lo = (Label)this.Controls.Find("Lab" + i, true)[0]; 
                    if (lo.Location == new System.Drawing.Point(Lab1.Location.X + 10, Lab1.Location.Y))
                    { timer1.Enabled = false; MessageBox.Show("游戏结束！", "提示");
                        button2.Enabled = true;
                        return; }; ;
                }

                if (e.KeyCode == Keys.Right && Lab1.Location.X == 340)
                {
                    timer1.Enabled = false; MessageBox.Show("游戏结束！", "提示");
                    button2.Enabled = true;
                    return;
                };
                Lab1.Left = Lab1.Left + 10;
                timer1.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)//重新开始
        {
            Application.Restart();
        }

        private void button3_Click(object sender, EventArgs e)//登陆
        {
            Login login  = new Login();
            login.ShowDialog();
            button1.Enabled = true;
            button3.Enabled = false;
        }

       

        private void toolStripButton1_Click(object sender, EventArgs e)//难度
        {
            timer1.Interval = 100;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            timer1.Interval = 200;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            timer1.Interval = 300;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)//暂停
        {
            Di.D = 0;
        }
    }
}
