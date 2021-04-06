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
    public partial class User_Login : Form
    {
        public User_Login()
        {
            InitializeComponent();
            
            
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString =
                 ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText =
                "SELECT COUNT(1) FROM Users WHERE Account=@Account AND Password=@Password;";
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "@Account";
            sqlParameter.Value = this.User_Account.Text.Trim();
            sqlParameter.SqlDbType = SqlDbType.Char;
            sqlParameter.Size = 10;
            sqlCommand.Parameters.Add(sqlParameter);
            sqlCommand.Parameters.AddWithValue("@Password", this.User_Password.Text.Trim());
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
                this.User_Account.Focus();
                this.User_Password.SelectAll();
                this.User_Password.Focus();
                this.User_Password.SelectAll();
            }
        }

        private void btn_Resigter_Click(object sender, EventArgs e)
        {
            this.Hide();
            User_Resigter  u = new User_Resigter ();
            u.ShowDialog();
            
        }

        private void llb_Modify_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            User_Modify u = new User_Modify();
            u.ShowDialog();
        }

        private void lin_Staff_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            TN_Login  T = new TN_Login ();
            T.ShowDialog();
        }
    }
}


