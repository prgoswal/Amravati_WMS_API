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
    public class DL_ApplicationProgress
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
        PL_ApplicationProgress plapplicationprogress = new PL_ApplicationProgress();
        string msg = "";
        //for entry process
        public DataSet GetEntryProcess(PL_ApplicationProgress pl)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("SPApplicationEntry", con);
                cmd.Parameters.AddWithValue("@ApplicationID", pl.ApplicationID);
                cmd.Parameters.AddWithValue("@Ind", pl.Ind);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
      
                ad.Fill(ds);
            }
            catch (Exception
                ex) { msg = ex.Message; }

            return ds;

        }
        //public DataTable GetZerolevelProcess(PL_ApplicationProgress pl)
        //{
        //    SqlCommand cmd = new SqlCommand("SPApplicationEntry", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    SqlDataAdapter ad = new SqlDataAdapter();
        //    DataTable dt = new DataTable();
        //    ad.Fill(dt);
        //    return dt;

        //}
    }


}