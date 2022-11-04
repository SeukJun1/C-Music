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

namespace Music
{
    public partial class Form3 : Form
    {
        string connstr = "data source =210.125.197.61; database =univ; uid=scott; pwd=tiger;";
        SqlConnection conn;
        SqlCommand cmd;

        public Form3()
        {
            InitializeComponent();
        }

       

        private void Form3_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection();
            conn.ConnectionString = connstr;
            cmd = new SqlCommand();
            try
            {
                conn.Open();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string sqlstr = "insert into Music ";
            sqlstr += "values(@Anum, @Disk1, @Mnum, @Mname, @Disi)";
            cmd.Connection = conn;
            cmd.CommandText = sqlstr;

            cmd.Parameters.Add("@Anum", SqlDbType.Int);
            cmd.Parameters["@Anum"].Value = textBox1.Text;

            cmd.Parameters.Add("@Disk1", SqlDbType.Int);
            cmd.Parameters["@Disk1"].Value = textBox2.Text;

            cmd.Parameters.Add("@Mnum", SqlDbType.Int);
            cmd.Parameters["@Mnum"].Value = textBox3.Text;

            cmd.Parameters.Add("@Mname", SqlDbType.VarChar);
            cmd.Parameters["@Mname"].Value = textBox4.Text;

            cmd.Parameters.Add("@Disi", SqlDbType.VarChar);
            cmd.Parameters["@Disi"].Value = textBox5.Text;

          
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
            MessageBox.Show(textBox1.Text + "의 음악 정보가 입력되었습니다.");
            cmd.Parameters.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
           


        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlstr = "select *from Music where Anum= @Anum";
                cmd.Connection = conn;
                cmd.CommandText = sqlstr;
                cmd.Parameters.Add("@Anum", SqlDbType.Int);
                cmd.Parameters["@Anum"].Value = textBox1.Text;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows == false)
                {
                    MessageBox.Show(textBox1.Text + "인 노래정보가 존재하지 않습니다.");
                    cmd.Parameters.Clear();
                }

                reader.Read();
                string s1 = reader["DISK1"].ToString();
                string s2 = reader["Mnum"].ToString();
                string s3 = reader["MNAME"] as string;
                string s4 = reader["DISI"] as string;
                textBox2.Text = s1.ToString();
                textBox3.Text = s2.ToString();
                textBox4.Text = s3;
                textBox5.Text = s4;
                cmd.Parameters.Clear();
                reader.Close();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sqlstr = "update Music set Anum=@Anum, Disk1=@Disk1, Mnum=@Mnum, Mname=@Mname, Disi=@Disi"; 
            cmd.Connection = conn;
            cmd.CommandText = sqlstr;

            cmd.Parameters.Add("@Anum", SqlDbType.Int);
            cmd.Parameters["@Anum"].Value = textBox1.Text;

            cmd.Parameters.Add("@Disk1", SqlDbType.Int);
            cmd.Parameters["@Disk1"].Value = textBox2.Text;

            cmd.Parameters.Add("@Mnum", SqlDbType.Int);
            cmd.Parameters["@Mnum"].Value = textBox3.Text;

            cmd.Parameters.Add("@Mname", SqlDbType.VarChar);
            cmd.Parameters["@Mname"].Value = textBox4.Text;

            cmd.Parameters.Add("@Disi", SqlDbType.VarChar);
            cmd.Parameters["@Disi"].Value = textBox5.Text;



            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
            MessageBox.Show(textBox1.Text + "의 음악 정보가 변경되었습니다.");
            cmd.Parameters.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();



        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sqlstr = "delete from Music where Anum=@Anum";

            cmd.Connection = conn;
            cmd.CommandText = sqlstr;
            cmd.Parameters.Add("@Anum", SqlDbType.Int);
            cmd.Parameters["@Anum"].Value = textBox1.Text;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
            MessageBox.Show(textBox1.Text + "의 음악 정보가 삭제되었습니다.");
            cmd.Parameters.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Close();


            conn.Close();

        }
    }
    }
    

