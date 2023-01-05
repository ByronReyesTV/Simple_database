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

namespace Simple_database
{
    public partial class Form2 : Form
    {
        public SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-JSNHHF1\SQLEXPRESS;Initial Catalog=simple_databaseDB;Integrated Security=True");

        public Form2()
        {
            InitializeComponent();
        }

        SqlCommand cmd;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 11)
            {
                guna2Button1.Enabled = true;
            }
            else
            {
                guna2Button1.Enabled = false;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            /* Search Function */

            conn.Open();
            string sqlQuery = "SELECT first_name, middle_name, last_name, section, school_name FROM student_database WHERE student_number = '" + textBox1.Text + "'";
            cmd = new SqlCommand(sqlQuery, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();


            if (reader.HasRows)
            {
                textBox2.Text = reader[0].ToString();
                textBox3.Text = reader[1].ToString();
                textBox4.Text = reader[2].ToString();
                textBox5.Text = reader[3].ToString();
                textBox6.Text = reader[4].ToString();

                guna2Button3.Enabled = true;
                guna2Button4.Enabled = true;
            }
            else
            {
                MessageBox.Show("no record");

                textBox1.Clear();
                textBox1.Focus();

                guna2Button3.Enabled = false;
                guna2Button4.Enabled = false;
            }

            conn.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            /* Data insert function */

            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("Student number is empty!");
                textBox1.Focus();
            }
            else
            {
                if (textBox2.Text.Length == 0)
                {
                    MessageBox.Show("First Name is empty!");
                    textBox2.Focus();
                }
                else
                {
                    if (textBox3.Text.Length == 0)
                    {
                        MessageBox.Show("Middle Name is empty!");
                        textBox3.Focus();
                    }
                    else
                    {
                        if (textBox4.Text.Length == 0)
                        {
                            MessageBox.Show("Lasr Name is empty!");
                            textBox4.Focus();
                        }
                        else
                        {
                            if (textBox5.Text.Length == 0)
                            {
                                MessageBox.Show("Section is empty!");
                                textBox5.Focus();
                            }
                            else
                            {
                                if (textBox6.Text.Length == 0)
                                {
                                    MessageBox.Show("School Name is empty!");
                                    textBox6.Focus();
                                }
                                else
                                {

                                    conn.Open();
                                    string check = @"(SELECT COUNT (*) FROM student_database WHERE student_number = '" + textBox1.Text + "')";
                                    string sqlQuery = "INSERT INTO student_database (student_number, first_name, middle_name, last_name, section, school_name) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "')";
                                    SqlCommand cmd2 = new SqlCommand(check, conn);
                                    cmd = new SqlCommand(sqlQuery, conn);
                                    int count = (int)cmd2.ExecuteScalar();
                                    conn.Close();

                                    if (count > 0)
                                    {
                                        MessageBox.Show("Data Already Exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        textBox1.Clear();
                                        textBox2.Clear();
                                        textBox3.Clear();
                                        textBox4.Clear();
                                        textBox5.Clear();
                                        textBox6.Clear();

                                        textBox1.Focus();

                                        guna2Button3.Enabled = false;
                                        guna2Button4.Enabled = false;
                                    }
                                    else
                                    {
                                        conn.Open();
                                        cmd.ExecuteNonQuery();
                                        MessageBox.Show("Data Registered Successfully", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        conn.Close();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            /* Data update function */

            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("Student number is empty!");
                textBox1.Focus();
            }
            else
            {
                if (textBox2.Text.Length == 0)
                {
                    MessageBox.Show("First Name is empty!");
                    textBox2.Focus();
                }
                else
                {
                    if (textBox3.Text.Length == 0)
                    {
                        MessageBox.Show("Middle Name is empty!");
                        textBox3.Focus();
                    }
                    else
                    {
                        if (textBox4.Text.Length == 0)
                        {
                            MessageBox.Show("Lasr Name is empty!");
                            textBox4.Focus();
                        }
                        else
                        {
                            if (textBox5.Text.Length == 0)
                            {
                                MessageBox.Show("Section Name is empty!");
                                textBox5.Focus();
                            }
                            else
                            {
                                if (textBox6.Text.Length == 0)
                                {
                                    MessageBox.Show("School Name is empty!");
                                    textBox6.Focus();
                                }
                                else
                                {
                                    //1. address of SQL server and database (Connection String)
                                    String ConnectionString = "Data Source=DESKTOP-JSNHHF1\\SQLEXPRESS;Initial Catalog=simple_databaseDB;Integrated Security=True";

                                    //2. establish connection (c# sqlconnection class)
                                    SqlConnection con = new SqlConnection(ConnectionString);

                                    //3. open connection (c# sqlconnection open)
                                    con.Open();

                                    //4. prepare query
                                    string studentnumber = textBox1.Text;

                                    string Query = "UPDATE student_database SET first_name = '" + textBox2.Text + "', middle_name = '" + textBox3.Text + "', last_name = '" + textBox4.Text + "', section = '" + textBox5.Text + "', school_name = '" + textBox6.Text + "' WHERE student_number = " + studentnumber;
                                    SqlCommand cmd = new SqlCommand(Query, con);

                                    //5. execute query (c# sqlcommand class)
                                    var reader = cmd.ExecuteNonQuery();

                                    MessageBox.Show("Data Updated successfully", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    textBox1.Clear();
                                    textBox2.Clear();
                                    textBox3.Clear();
                                    textBox4.Clear();
                                    textBox5.Clear();
                                    textBox6.Clear();

                                    textBox1.Focus();

                                    guna2Button3.Enabled = false;
                                    guna2Button4.Enabled = false;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            /* Data delete function */

            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("Student number is empty");
            }
            else
            {
                if (textBox1.Text.Length < 11)
                {
                    MessageBox.Show("Invalid student number\nPlease try again");
                }
                else
                {
                    //1. address of SQL server and database (Connection String)
                    String ConnectionString = "Data Source=DESKTOP-JSNHHF1\\SQLEXPRESS;Initial Catalog=simple_databaseDB;Integrated Security=True";

                    //2. establish connection (c# sqlconnection class)
                    SqlConnection con = new SqlConnection(ConnectionString);

                    //3. open connection (c# sqlconnection open)
                    con.Open();

                    //4. prepare query
                    string studentnumber = textBox1.Text;

                    string Query = "DELETE FROM student_database WHERE student_number = " + studentnumber;
                    SqlCommand cmd = new SqlCommand(Query, con);

                    //5. execute query (c# sqlcommand class)
                    var reader = cmd.ExecuteNonQuery();

                    MessageBox.Show("Data deleted successufully");

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();

                    textBox1.Focus();

                    guna2Button3.Enabled = false;
                    guna2Button4.Enabled = false;
                }
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }
    }
}
