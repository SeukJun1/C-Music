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


namespace Music
{
    public partial class Form2 : Form
    {
        string connstr = "data source =210.125.197.61; database =univ; uid=scott; pwd=tiger;";
        SqlConnection conn;
        SqlCommand cmd;
        public Form2()
        {
            InitializeComponent();
        }


        private void Form2_Load(object sender, EventArgs e)
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
            string sqlstr = "insert into ablum ";
            sqlstr += "values(@Anum, @Title, @Atist, @Much, @Ddate, @Rat, @Star)";
            cmd.Connection = conn;
            cmd.CommandText = sqlstr;

            cmd.Parameters.Add("@Anum", SqlDbType.Int);
            cmd.Parameters["@Anum"].Value = textBox1.Text;

            cmd.Parameters.Add("@Title", SqlDbType.VarChar);
            cmd.Parameters["@Title"].Value = textBox2.Text;

            cmd.Parameters.Add("@Atist", SqlDbType.VarChar);
            cmd.Parameters["@Atist"].Value = textBox3.Text;

            cmd.Parameters.Add("@Much", SqlDbType.Int);
            cmd.Parameters["@Much"].Value = textBox4.Text;

            cmd.Parameters.Add("@Ddate", SqlDbType.DateTime);
            cmd.Parameters["@Ddate"].Value = textBox5.Text;

            cmd.Parameters.Add("@Rat", SqlDbType.VarChar);
            cmd.Parameters["@Rat"].Value = textBox6.Text;

            cmd.Parameters.Add("@Star", SqlDbType.Decimal);
            cmd.Parameters["@Star"].Value = textBox7.Text;
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
            textBox6.Clear();
            textBox7.Clear();
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlstr = "select *from ablum where Anum= @Anum";
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
                string s1 = reader["TITLE"] as string;
                string s2 = reader["ATIST"] as string;
                string s3 = reader["MUCH"].ToString();
                object ov = reader["DDATE"];
                DateTime s4 = (DateTime)ov;
                string s5 = reader["RAT"] as string;
                string s6 = reader["STAR"].ToString();
                textBox2.Text = s1;
                textBox3.Text = s2;
                textBox4.Text = s3.ToString();
                textBox5.Text = DateTime.Parse(s4.ToString()).ToShortDateString();
                textBox6.Text = s5;
                textBox7.Text = s6.ToString();
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
            string sqlstr = "update ablum set Anum=@Anum, Title=@Title, Atist=@Atist, Much=@Much, Ddate=@Ddate, Rat=@Rat, Star=@Star";
    
            cmd.Connection = conn;
            cmd.CommandText = sqlstr;
            cmd.Parameters.Add("@Anum", SqlDbType.Int);
            cmd.Parameters["@Anum"].Value = textBox1.Text;

            cmd.Parameters.Add("@Title", SqlDbType.VarChar);
            cmd.Parameters["@Title"].Value = textBox2.Text;

            cmd.Parameters.Add("@Atist", SqlDbType.VarChar);
            cmd.Parameters["@Atist"].Value = textBox3.Text;

            cmd.Parameters.Add("@Much", SqlDbType.Int);
            cmd.Parameters["@Much"].Value = textBox4.Text;

            cmd.Parameters.Add("@Ddate", SqlDbType.DateTime);
            cmd.Parameters["@Ddate"].Value = textBox5.Text;

            cmd.Parameters.Add("@Rat", SqlDbType.VarChar);
            cmd.Parameters["@Rat"].Value = textBox6.Text;

            cmd.Parameters.Add("@Star", SqlDbType.Decimal);
            cmd.Parameters["@Star"].Value = textBox7.Text;
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
            textBox6.Clear();
            textBox7.Clear();
            
           


        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sqlstr = "delete from ablum where Anum=@Anum";

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
            textBox6.Clear();
            textBox7.Clear();

          


        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();

          
            conn.Close();

            
        }
    }
}

