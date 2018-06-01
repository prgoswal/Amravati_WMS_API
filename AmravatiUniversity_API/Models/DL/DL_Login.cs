using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using AmravatiUniversity_API.Models.PL;

namespace AmravatiUniversity_API.Models
{
    public class DL_Login
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlCommand cmd; SqlDataAdapter da; DataTable dt;
        string msg = "";

        public DataTable GetAllRegister(PL_Login pl, int Ind)
        {
            try
            {
                cmd = new SqlCommand("SPGetAllMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ind", Ind);
                if (Ind == 6)
                    cmd.Parameters.AddWithValue("@ItmId", pl.ItemID);

                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return dt;
        }

        public DataTable GetExamName(int Ind, int facultytype)
        {
            try
            {
                cmd = new SqlCommand("SPRegister", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ind", Ind);
                cmd.Parameters.AddWithValue("@Facultytype", facultytype);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                msg = ex.Message;

            }
            return dt;
        }
        public DataTable GetLoginDetails(PL_Login pl)
        {
            try
            {
                cmd = new SqlCommand("SPLoginDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ind", pl.Ind);
                cmd.Parameters.AddWithValue("@LoginId", pl.UserLoginId);
                cmd.Parameters.AddWithValue("@LoginPwd", pl.LoginPwd);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return dt;
        }
        public int ChackLoginId(PL_Login pl)
        {
            int i = 0;
            try
            {
                cmd = new SqlCommand("SPLoginDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ind", pl.Ind);
                cmd.Parameters.AddWithValue("@LoginId", pl.UserLoginId);
                cmd.Parameters.AddWithValue("@LoginPwd", pl.LoginPwd);
                con.Open();
                i = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
            }
            catch (Exception
                 ex)
            {
                msg = ex.Message;
            }

            return i;
        }
        public int ChangeLoginIdStatus(PL_Login pl)
        {
            int i = 0;
            try
            {
                cmd = new SqlCommand("SPLoginDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ind", pl.Ind);
                cmd.Parameters.AddWithValue("@UserId", pl.UserId);
                con.Open();
                i = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
            }
            catch (Exception
                ex) { msg = ex.Message; }

            return i;
        }

        public int CheckLockInd(PL_Login pl)
        {
            int i = 0;
            try
            {
                cmd = new SqlCommand("SPLoginDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ind", pl.Ind);
                cmd.Parameters.AddWithValue("@LoginId", pl.UserLoginId);
                con.Open();
                i = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
            }
            catch (Exception ex) { msg = ex.Message; } return i;
        }

        public DataTable GetLoginDetailsfromAPI(PL_Login pl)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand("SPLoginDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ind", 11);
                cmd.Parameters.AddWithValue("@LoginId", pl.UserLoginId);
                cmd.Parameters.AddWithValue("@LoginPwd", pl.LoginPwd);

                da = new SqlDataAdapter(cmd);


                da.Fill(dt);
            }
            catch (Exception
                ex) { msg = ex.Message; }
            return dt;
        }

        public DataSet GetUserLoginID(PL_Login pl)
        {
            DataSet ds = new DataSet();

            cmd = new SqlCommand("SPLoginDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ind", 12);
            cmd.Parameters.AddWithValue("@LoginId", pl.UserLoginId);
            cmd.Parameters.AddWithValue("@MacAddress", pl.MacAddress);         
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;

        }
        public DataTable UpdateActiveStatus(PL_Login pl)
        {
            cmd = new SqlCommand("SPLoginDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ind", pl.Ind);
            cmd.Parameters.AddWithValue("@UserId", pl.UserId);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable SelectOldPwd(PlChangePwd pl)
        {
            cmd = new SqlCommand("SPLoginDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ind", pl.Ind);
            cmd.Parameters.AddWithValue("@UserId", pl.UserId);
            cmd.Parameters.AddWithValue("@LoginPwd", pl.OldPwd);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);            //int i = Convert.ToInt32(cmd.ExecuteScalar());                             
            return dt;
        }

        public DataTable UpdateInvalidAttempts(PL_Login pl)
        {
            cmd = new SqlCommand("SPLoginDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ind", pl.Ind);
            cmd.Parameters.AddWithValue("@LoginId", pl.UserLoginId);
            cmd.Parameters.AddWithValue("@LoginPwd", pl.UserLoginPwd);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();          
            da.Fill(dt);
            return dt;
        }


        public DataTable ChangePasswordFirst(PL_Login objpllogin)
        {
            cmd = new SqlCommand("SPLoginDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ind", objpllogin.Ind);
            cmd.Parameters.AddWithValue("@NewPwd", objpllogin.LoginPwd);
            cmd.Parameters.AddWithValue("@UserId", objpllogin.UserId);

            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable GetPasswordHistory(PL_Login objpllogin)
        {
            cmd = new SqlCommand("SPLoginDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ind", objpllogin.Ind);
            cmd.Parameters.AddWithValue("@UserLoginID", objpllogin.UserLoginId);
            cmd.Parameters.AddWithValue("@NewPwd", objpllogin.NewPassword);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            return dt;
        }
        public DataTable GetLogoutPassword(PL_Login objpllogin)
        {
            cmd = new SqlCommand("SPLoginDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ind", 17);
            cmd.Parameters.AddWithValue("@UserId", objpllogin.UserId);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            return dt;
        }

        public DataTable CheckPassword(PlChangePwd pl)
        {
            cmd = new SqlCommand("SPLoginDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ind", pl.Ind);
            cmd.Parameters.AddWithValue("@UserId", pl.UserId);
            cmd.Parameters.AddWithValue("@NewPwd", pl.NewPwd);
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public DataTable ChangePwd(PlChangePwd pl)
        {
            cmd = new SqlCommand("SPLoginDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ind", pl.Ind);
            cmd.Parameters.AddWithValue("@UserId", pl.UserId);
            cmd.Parameters.AddWithValue("@LoginPwd", pl.OldPwd);
            cmd.Parameters.AddWithValue("@NewPwd", pl.NewPwd);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            //con.Open();
            //int j = Convert.ToInt32(cmd.ExecuteScalar());           
            //dt = cmd.ExecuteNonQuery();
            //con.Close();
            return dt;
        }

        public DataTable FinalLogin(PL_Login pl)
        {
            cmd = new SqlCommand("SPLoginDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ind", pl.Ind);
            cmd.Parameters.AddWithValue("@LoginId", pl.UserLoginId);
            cmd.Parameters.AddWithValue("@LoginPwd", pl.LoginPwd);
            cmd.Parameters.AddWithValue("@MacAddress", pl.MacAddress);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        public DataSet GetLockList(PL_Login pl)
        {
            DataSet ds = new DataSet();

            cmd = new SqlCommand("SPLoginDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ind", 9);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;

        }
        public DataTable UpdateLockUnlock(PL_Login pl)
        {
            DataTable dt = new DataTable();
            cmd = new SqlCommand("SPLoginDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ind", pl.Ind);
            cmd.Parameters.AddWithValue("@UserInd", pl.UserInd);
            cmd.Parameters.AddWithValue("@UserId", pl.UserId);
            cmd.Parameters.AddWithValue("@Remark", pl.Remark);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        public DataTable InsertUserLevel(PL_Login pl)
        {
            DataTable dt = new DataTable();
            cmd = new SqlCommand("SPGetAllMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ind", pl.Ind);         
            cmd.Parameters.AddWithValue("@ItemDesc", pl.ItemDesc);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public DataTable GetUserLevel(PL_Login objpllogin)
        {
            cmd = new SqlCommand("SPGetAllMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ind", objpllogin.Ind);         
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable GetMenu(PL_Login objpllogin)
        {
            cmd = new SqlCommand("SPGetAllMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ind", objpllogin.Ind);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable UpdateUserLevel(PL_Login objpllogin)
        {
            cmd = new SqlCommand("SPGetAllMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ind", objpllogin.Ind);
            cmd.Parameters.AddWithValue("@ItemID", objpllogin.ItemID);
            cmd.Parameters.AddWithValue("@ItemDesc", objpllogin.ItemDesc);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable InsertProfileCreation(PL_Login objpllogin)
        {
            cmd = new SqlCommand("SPGetAllMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ind", objpllogin.Ind);
            cmd.Parameters.AddWithValue("@ItemID", objpllogin.ItemID);
            cmd.Parameters.AddWithValue("@UserTypeId", objpllogin.UserTypeId);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable GetusertypeID(PL_Login objpllogin)
        {
            cmd = new SqlCommand("SPGetAllMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ind", objpllogin.Ind);
            cmd.Parameters.AddWithValue("@UserTypeId", objpllogin.UserTypeId);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable DeleteProfileCreation(PL_Login objpllogin)
        {
            cmd = new SqlCommand("SPGetAllMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ind", objpllogin.Ind);
            cmd.Parameters.AddWithValue("@UserTypeId", objpllogin.UserTypeId);
            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


    }
}