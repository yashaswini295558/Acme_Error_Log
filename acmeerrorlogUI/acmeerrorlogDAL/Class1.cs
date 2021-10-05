using acmeerrorlogDTO
using acmeerrorlogDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acmeerrorlogDAL
{
    public class acmeDAL
    {
        SqlConnection conObj;
        string conStr = ConfigurationManager.ConnectionStrings["Entities"].ConnectionString;
        public acmeDAL()
        {
            conObj = new SqlConnection(conStr);
        }

        public List<acmeDTO> FetchAllUser()
        {
            try
            {
                List<acmeDTO> lstUsers = new List<acmeDTO>();

                SqlConnection conObj = new SqlConnection();
                conObj.ConnectionString = conStr;

                SqlCommand queryObj = new SqlCommand();
                queryObj.CommandText = @"SELECT [user_email], Description FROM [Users]";
                queryObj.CommandType = System.Data.CommandType.Text;
                queryObj.Connection = conObj;

                conObj.Open();
                SqlDataReader drUser = queryObj.ExecuteReader();
                while (drUser.Read())
                {
                    lstUsers.Add(new DTO()
                    {
                        User_email = drUser["User_email"].ToString(),
                        name_of_the_app = drUser["app_name"].ToString(),
                        Description = drUser["Description"].ToString(),
                    });
                }
                return lstUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<acmeDTO> FetchUserByEmail(string User_Email)
        {

            try
            {
                List<acmeDTO> lstUsers = new List<acmeDTO>();

                SqlConnection conObj = new SqlConnection();
                conObj.ConnectionString = conStr;

                SqlCommand queryObj = new SqlCommand();
                queryObj.CommandText = @"SELECT [User_email], AppName, Description FROM [Users] WHERE [User_email] LIKE @User_email";
                queryObj.Parameters.AddWithValue("@User_email", "%" + User_email + "%");
                queryObj.CommandType = System.Data.CommandType.Text;
                queryObj.Connection = conObj;

                conObj.Open();
                SqlDataReader drUser = queryObj.ExecuteReader();
                while (drUser.Read())
                {
                    lstUsers.Add(new acmeDTO()
                    {
                        User_Email = drUser["User_email"].ToString(),
                        name_of_the_app = drUser["name_of_the_app"].ToString(),
                        Description = drUser["Description"].ToString(),
                    });
                }
                return lstUsers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertUser(acmeDTO deptObj)
        {
            try
            {
                SqlConnection conObj = new SqlConnection();
                conObj.ConnectionString = conStr;

                SqlCommand queryObj = new SqlCommand();
                queryObj.CommandText = @"usp_InsertUser";
                queryObj.CommandType = System.Data.CommandType.StoredProcedure;
                queryObj.Connection = conObj;

                queryObj.Parameters.AddWithValue("@User_email", deptObj.User_Email);
                queryObj.Parameters.AddWithValue("@User_password", deptObj.User_Password);
                queryObj.Parameters.AddWithValue("@name_of_the_app", deptObj.name_of_the_app);
                queryObj.Parameters.AddWithValue("@Date", deptObj.Date);
                queryObj.Parameters.AddWithValue("@Description", deptObj.Description);
                SqlParameter prmReturn = new SqlParameter();
                prmReturn.Direction = System.Data.ParameterDirection.ReturnValue;
                prmReturn.SqlDbType = SqlDbType.Int;
                queryObj.Parameters.Add(prmReturn);
                conObj.Open();
                queryObj.ExecuteNonQuery();
                return Convert.ToInt32(prmReturn.Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
