using AmravatiUniversity_API.Models.PL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AmravatiUniversity_API.Models.DL
{
    public class Dl_UserCreation
    {
        string msg = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlCommand cmd; SqlDataAdapter da; DataTable dt;

        public DataTable InsertUserEntry(PL_UserCreation pl)
        {
            DataTable dt = new DataTable();
          //  int i=0;
            try
            { 
            cmd = new SqlCommand("SPLoginDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ind", pl.Ind);
            cmd.Parameters.AddWithValue("@UserTypeID", pl.UserType);
            cmd.Parameters.AddWithValue("@UserName", pl.UserName);
            cmd.Parameters.AddWithValue("@UserState", pl.State);
            cmd.Parameters.AddWithValue("@UserCity", pl.City);
            cmd.Parameters.AddWithValue("@UserAddress", pl.Address);
            cmd.Parameters.AddWithValue("@UserMobileNo", pl.ContactNo);
            cmd.Parameters.AddWithValue("@UserEmailAddr", pl.Email);
            cmd.Parameters.AddWithValue("@UserLoginID", pl.LoginId);
            cmd.Parameters.AddWithValue("@UserLoginPwd", pl.Pwd);
            cmd.Parameters.AddWithValue("@IsOutSideUser", pl.IsOutSideUser);
            cmd.Parameters.AddWithValue("@IsActive", pl.IsActive);
            cmd.Parameters.AddWithValue("@CreationDate", pl.CreationDate);
            cmd.Parameters.AddWithValue("@UserLoginStatus", pl.UserLoginStatus);
            cmd.Parameters.AddWithValue("@UserValidity", pl.UserValidity);
            cmd.Parameters.AddWithValue("@MacAddress",pl.MacAddress);
            cmd.Parameters.AddWithValue("@EmployeeID", pl.EmployeeID);
            con.Open();            
             SqlDataAdapter ad = new SqlDataAdapter(cmd);
             ad.Fill(dt);
                
             // cmd.ExecuteNonQuery();
            con.Close();
            }
            catch (Exception ex) { msg = ex.Message; }
            return dt;
        }

        public DataTable GetLockedUsers(PL_UserCreation pl)
        {
            try { 
            cmd = new SqlCommand("SPLoginDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ind", pl.Ind);
            cmd.Parameters.AddWithValue("@UserId", pl.UserId);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            }
            catch (Exception ex) { msg = ex.Message; }
            return dt;
        }
        public int UpdateUnlockedUser(PL_UserCreation pl)
        {
            int i = 0;
            try
            {
                cmd = new SqlCommand("SPLoginDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ind", pl.Ind);
                cmd.Parameters.AddWithValue("@LockInd", pl.LockId);
                cmd.Parameters.AddWithValue("@UserId", pl.UserId);
                con.Open();
                 i = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex) { msg = ex.Message; }
            return i;
        }
        public DataTable GetAllRegister(PL_UserCreation pl)
        {
            try { 
            cmd = new SqlCommand("SPGetAllMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ind", pl.Ind);
            if (pl.Ind == 6)
                cmd.Parameters.AddWithValue("@ItmId", pl.ItemID);

            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            }
            catch (Exception ex) { msg = ex.Message; }
            return dt;
            
        }

        public DataSet GetAllUserInGrid(PL_UserCreation pl)
        {
            DataSet ds = new DataSet();
            try { 
            cmd = new SqlCommand("SPRegister", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ind", pl.Ind);
            da = new SqlDataAdapter(cmd);
            //dt = new DataTable();
            //da.Fill(dt);
 
            da.Fill(ds);
            }
            catch (Exception ex) { msg = ex.Message; }
            return ds;


        }
        
        public DataTable UpdateUserValidity(PL_UserCreation pl)
        {
            DataTable dt = new DataTable();
           
                cmd = new SqlCommand("SPRegister", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ind", pl.Ind);
                cmd.Parameters.AddWithValue("@UserValidity", pl.UserValidity);
                cmd.Parameters.AddWithValue("@UserID", pl.UserId);
                cmd.Parameters.AddWithValue("@MacAddress",pl.MacAddress);
                cmd.Parameters.AddWithValue("@EmployeeID",pl.EmployeeID);
                con.Open();
                // cmd.ExecuteNonQuery();          
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
                return dt;
              
        }
        //Get all user when click on edit button on grid.
        public DataTable GetUpdateValidity(PL_UserCreation pl)
        {
            try
            {
                cmd = new SqlCommand("SPRegister", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ind", pl.Ind);
                cmd.Parameters.AddWithValue("@UserID", pl.UserId);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
            }
            catch(Exception ex)
            { msg = ex.Message; }
            return dt;
        }
        public DataTable GetUserloginIdUnique(PL_UserCreation pl)
        {
            cmd = new SqlCommand("SPLoginDetails",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ind",pl.Ind);
            cmd.Parameters.AddWithValue("@UserLoginID",pl.UserLoginId);
            dt = new DataTable();
            da = new SqlDataAdapter();
            da.Fill(dt);
            return dt;
        }
        public DataTable GetMenuList(PL_UserCreation pl)
        {
            cmd = new SqlCommand("SPMenus", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ind", pl.Ind);
            cmd.Parameters.AddWithValue("@UserTypeID", pl.UserTypeID);
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
    }
}