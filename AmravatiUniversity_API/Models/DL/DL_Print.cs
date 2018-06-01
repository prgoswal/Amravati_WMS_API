using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using AmravatiUniversity_API.Models.PL;

namespace AmravatiUniversity_API.Models.DL
{
    public class DL_Print
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlCommand cmd; SqlDataAdapter da; DataTable dt;
        string msg = "";

        public DataTable GetAllPrintCount(PL_Print objPlPrint)
        {
            try
            {
                cmd = new SqlCommand("SPGetAllMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ind", objPlPrint.Ind);
                cmd.Parameters.AddWithValue("@UserID", objPlPrint.UserID);
                cmd.Parameters.AddWithValue("@UserTypeID", objPlPrint.LevelID);
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
        public DataTable TestPrintDetail(PL_Print objPlPrint)
        {
            try
            {
                cmd = new SqlCommand("SPWMSReports", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ind", objPlPrint.Ind);
                cmd.Parameters.AddWithValue("@UserID", objPlPrint.UserID);
                cmd.Parameters.AddWithValue("@LevelID", objPlPrint.LevelID);
                cmd.Parameters.AddWithValue("@DocType", objPlPrint.DocTypeId);
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



        public DataTable PrintCertificate(PL_Print objPlPrint)
        {
            try
            {
                cmd = new SqlCommand("SPWMSReports", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ind", objPlPrint.Ind);
                cmd.Parameters.AddWithValue("@ApplicationID", objPlPrint.ApplicationID);
                cmd.Parameters.AddWithValue("@DocType", objPlPrint.DocTypeId);
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

        internal DataTable PrintFinalCertificate(PL_Print objPlPrint)
        {
            try
            {
                cmd = new SqlCommand("SPWMSReports", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ind", objPlPrint.Ind);
                cmd.Parameters.AddWithValue("@ApplicationID", objPlPrint.ApplicationID);
                cmd.Parameters.AddWithValue("@DocType", objPlPrint.DocTypeId);
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
    }
}