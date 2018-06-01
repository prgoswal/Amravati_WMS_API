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
    public class DL_DocumentApprovalLevel
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlCommand cmd; SqlDataAdapter da=null ; DataTable dt=null;
        string msg = "";



        public DataTable InsertDocumentApprovalLevel(PL_DocumentApprovalLevel pl)
        {
            DataTable dt = new DataTable();
            //  int i=0;
            try
            {
                cmd = new SqlCommand("SpMenus", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ind", pl.Ind);
                cmd.Parameters.AddWithValue("@ParentMenuId", pl.ParentMenuId);
                cmd.Parameters.AddWithValue("@Title", "ApprovalMenus");
                cmd.Parameters.AddWithValue("@Url", "Home.aspx");
                cmd.Parameters.AddWithValue("@LevelProfile",pl.LevelProfile);
                cmd.Parameters.AddWithValue("@AllowMenu", pl.AllowMenu);

                con.Open();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);

                // cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex) { msg = ex.Message; }
            return dt;
        }

        public DataTable GetDocumentLevel(PL_DocumentApprovalLevel pl)
        {
            cmd = new SqlCommand("SpGetAllMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ind", pl.Ind);
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0 && dt != null)
            { }
            else
                dt = null;
            return dt;
        }

        public DataTable GetUserLevel(PL_DocumentApprovalLevel pl)
        {
            cmd = new SqlCommand("SpGetAllMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ind", pl.Ind);
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);          
            da.Fill(dt);
            if (dt.Rows.Count > 0 && dt != null)
            { }
            else
                dt = null;
            return dt;
        }


        public DataTable ApprovalDelete(PL_DocumentApprovalLevel pl)
        {
            DataTable dt = new DataTable();
            //  int i=0;
            try
            {
                cmd = new SqlCommand("SPMenus", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ind", pl.Ind);
                cmd.Parameters.AddWithValue("@AllowMenu", pl.AllowMenu);

                con.Open();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);

                // cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex) { msg = ex.Message; }
            return dt;
        }
        
        public DataTable ShowApproval(int Ind)
        {
            DataTable dt = new DataTable();
            //  int i=0;
            try
            {
                cmd = new SqlCommand("SPMenus", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ind", Ind);
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