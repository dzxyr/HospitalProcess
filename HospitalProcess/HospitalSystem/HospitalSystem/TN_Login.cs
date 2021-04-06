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
using System.Configuration;

namespace HospitalSystem
{
    public partial class TN_Login : Form
    {
        public TN_Login()
        {
            InitializeComponent();
        }

        private void but_Black_Click(object sender, EventArgs e)
        {
            this.Close();
           
           
        }

        private void but_Suer_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString =
                 ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText =
                "SELECT COUNT(1) FROM Workers WHERE StaffNo=@StaffNo AND Password=@Password;";
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "@StaffNo";
            sqlParameter.Value = this.tex_Staff.Text.Trim();
            sqlParameter.SqlDbType = SqlDbType.Char;
            sqlParameter.Size = 7;
            sqlCommand.Parameters.Add(sqlParameter);
            sqlCommand.Parameters.AddWithValue("@Password", this.tex_Password.Text.Trim());
            sqlConnection.Open();
            int rowCount = (int)sqlCommand.ExecuteScalar();
            sqlConnection.Close();
            if (rowCount == 1)
            {

                MessageBox.Show("登录成功。");
                this.Hide();
                OutPatient o = new OutPatient();
                o.ShowDialog();
            }
            else
            {
                MessageBox.Show("账号/密码有误，请重新输入！");
                this.tex_Staff.Focus();
                this.tex_Staff.SelectAll();
                this.tex_Password.Focus();
                this.tex_Password.SelectAll();
            }
        }
    }
  }

