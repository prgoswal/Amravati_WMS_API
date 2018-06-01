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
    public class DL_ProfileCreation
    {



        string msg = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlCommand cmd; SqlDataAdapter da; DataTable dt;

        public DataTable InsertProfile(PL_ProfileCreation ObjPlProfile)
        {
            DataTable dt = new DataTable();
            //  int i=0;
            try
            {
                cmd = new SqlCommand("SpProfileCreation", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ind", ObjPlProfile.Ind);
                cmd.Parameters.AddWithValue("@UserTypeID", ObjPlProfile.UserTypeId);
                cmd.Parameters.AddWithValue("@ItemId", ObjPlProfile.ItemId);
              
                con.Open();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);

                // cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex) { msg = ex.Message; }
            return dt;
        }

        public DataTable ProfileDelete(PL_ProfileCreation ObjPlProfile)
        {
            DataTable dt = new DataTable();
            //  int i=0;
            try
            {
                cmd = new SqlCommand("SpProfileCreation", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ind", ObjPlProfile.Ind);
                cmd.Parameters.AddWithValue("@UserTypeID", ObjPlProfile.UserTypeId);

                con.Open();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);

                // cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex) { msg = ex.Message; }
            return dt;
        }

        public DataTable GetProfileName(PL_ProfileCreation ObjPlProfile)
        {
            DataTable dt = new DataTable();
            //  int i=0;
            try
            {
                cmd = new SqlCommand("SPGetAllMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ind", ObjPlProfile.Ind);
                cmd.Parameters.AddWithValue("@ItemID", ObjPlProfile.ItemId);    
                con.Open();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);

                // cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex) { msg = ex.Message; }
            return dt;
        }
        public DataTable ShowProfile(PL_ProfileCreation ObjPlProfile)
        {
            DataTable dt = new DataTable();
            //  int i=0;
            try
            {
                cmd = new SqlCommand("SpProfileCreation", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ind", ObjPlProfile.Ind);              
                con.Open();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);

                // cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex) { msg = ex.Message; }
            return dt;
        }
    }
}