using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using AmravatiUniversity_API.Models.PL;
using AmravatiUniversity_API.Models;


namespace AmravatiUniversity_API.Models.DL
{
     
    public class DL_StudentDetail
    {
        string msg = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlCommand cmd; SqlDataAdapter da; DataTable dt;
        public void GetExamYear(PL_StudentDetail pl)
        {
            cmd = new SqlCommand("SPGetAllMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ind", 3);
            da = new SqlDataAdapter(cmd);
            pl.dt = new DataTable();
            da.Fill(pl.dt);
        }
        public DataTable GetExamSession(PL_StudentDetail pl)
        {
            try
            {
                cmd = new SqlCommand("SPGetAllMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ind", pl.Ind);
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
        public DataTable GetExamType(PL_StudentDetail pl)
        {
            try
            {
                cmd = new SqlCommand("SPGetAllMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ind", pl.Ind);
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

        public DataTable GetExamName(PL_StudentDetail pl)
        {
            try
            {
                cmd = new SqlCommand("SPExamMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ind", pl.Ind);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
            }
            catch (Exception ex) { msg = ex.Message; }
            return dt;
        }

        public DataTable GetForApply(PL_StudentDetail pl)
        {
            try
            { 
            cmd = new SqlCommand("SPGetAllMaster", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ind", pl.Ind);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            }
            catch (Exception ex) { msg = ex.Message; }
            return dt;
        }
        public DataTable GetStudentDetail(PL_StudentDetail pl)
        {
            try
            {
                cmd = new SqlCommand("SPApplicationDetail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 10000;
                cmd.Parameters.AddWithValue("@Ind", pl.Ind);
               
                cmd.Parameters.AddWithValue("@ExamSession", pl.ExamSession);
                cmd.Parameters.AddWithValue("@ExamYear", pl.ExamYear);
                cmd.Parameters.AddWithValue("@StudentName", pl.StudentName);
                cmd.Parameters.AddWithValue("@Rollno", pl.Rollno);

                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dt.Rows[0]["RollNo"]) == 0)
                    {
                        dt = null;
                    }

                }
                else
                    dt = null;
         
            }
            catch(Exception ex)
            {
                 msg = ex.Message;
            }
            return dt;
        }
        public DataTable SaveStudentDetail(PL_StudentDetail pl)
        {
            try
            {
                cmd = new SqlCommand("SPApplicationDetail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ind", pl.Ind);
                cmd.Parameters.AddWithValue("@AppID", pl.ApplicationID);
                cmd.Parameters.AddWithValue("@ExamSession", Convert.ToInt32(pl.ExamSession));
                cmd.Parameters.AddWithValue("@ExamYear", Convert.ToInt32(pl.ExamYear));
                cmd.Parameters.AddWithValue("@ExamName", pl.ExamName);
                cmd.Parameters.AddWithValue("@StudentName", pl.StudentName);
                cmd.Parameters.AddWithValue("@RollNo", pl.Rollno);
                cmd.Parameters.AddWithValue("@Remarks", pl.Remarks);
                cmd.Parameters.AddWithValue("@AppliedFor", pl.AppliedFor);
                cmd.Parameters.AddWithValue("@SubmittedFees", pl.SubmittedFees);

                cmd.Parameters.AddWithValue("@PartARegNo", pl.PartARegNo);
                cmd.Parameters.AddWithValue("@PartAImagePath", pl.PartAImagePath);
                cmd.Parameters.AddWithValue("@PartBRegNo", pl.PartBRegNo);
                cmd.Parameters.AddWithValue("@PartBImagePath", pl.PartBImagePath);
                // cmd.Parameters.AddWithValue("@InsertionDate", pl.InserttionDate);
                cmd.Parameters.AddWithValue("@InsertionBy", pl.InsertionBy);
                cmd.Parameters.AddWithValue("@InsertionByIP", pl.InsertionByIP);
                cmd.Parameters.AddWithValue("@EstimateDate", Convert.ToDateTime(pl.EstimateDate));


                cmd.Parameters.AddWithValue("@ReceiptNo", pl.ReceiptNo);
               // cmd.Parameters.AddWithValue("@ReceiptDate", pl.ReceiptDate.Date);
                cmd.Parameters.AddWithValue("@ReceiptAMT", pl.ReceiptAMT);

                cmd.Parameters.AddWithValue("@PaymentMode", pl.PaymentMode);
                cmd.Parameters.AddWithValue("@ChequeDDNo", pl.ChequeDDNo);
               // cmd.Parameters.AddWithValue("@ChequeDDDate", pl.ChequeDDDate.Date);
                cmd.Parameters.AddWithValue("@BankName", pl.BankName);

                con.Open();

                int Ind = 0;
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                con.Close();
                if (dt != null)
                {

                    if (dt.Rows.Count > 0)
                    {

                        Ind = 1;

                    }
                }
                else
                    dt = null;
            
                    }
            catch (Exception ex) { msg = ex.Message; }
            return dt;
        }
        public DataSet GetEntryProcess(PL_StudentDetail pl)
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
            catch (Exception ex) { msg = ex.Message; }
            return ds;

        }
        public DataTable GetLevelProfile(PL_StudentDetail pl)
        {
            try
            {
                cmd = new SqlCommand("SPApplicationEntry", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ind", pl.Ind);
                cmd.Parameters.AddWithValue("@LevelProfile", pl.LevelProfile);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
            }
            catch (Exception ex) { msg = ex.Message; }
            return dt;
        }
        public DataTable GetLevelidApproved(PL_StudentDetail pl)
        {
            try
            { 
            cmd = new SqlCommand("SPApplicationEntry", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ind", pl.Ind);
            cmd.Parameters.AddWithValue("@ApplicationID", pl.ApplicationID);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            }
            catch (Exception ex) { msg = ex.Message; }
            return dt;
        }
        public DataTable GetApplicationStatus(PL_StudentDetail pl)
        {
            try
            {
                cmd = new SqlCommand("SPApplicationDetail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ind", pl.Ind);
                cmd.Parameters.AddWithValue("@ReceiptDate", pl.FromDate);
                cmd.Parameters.AddWithValue("@ChequeDDDate", pl.ToDate);
                cmd.Parameters.AddWithValue("@LevelID", pl.LevelID);
                cmd.Parameters.AddWithValue("@UserID", pl.UserID);
                cmd.Parameters.AddWithValue("@AppID", pl.ForApplication);   
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
            }
            catch (Exception ex) { msg = ex.Message; }
            return dt;
        }
        public DataTable GetApplicationMIS(PL_StudentDetail pl)
        {
            try
            {
                cmd = new SqlCommand("SPApplicationDetail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ind", pl.Ind);
                cmd.Parameters.AddWithValue("@ReceiptDate", pl.FromDate);
                cmd.Parameters.AddWithValue("@ChequeDDDate", pl.ToDate);
                cmd.Parameters.AddWithValue("@LevelID", pl.LevelID);
                cmd.Parameters.AddWithValue("@UserID", pl.UserID);
                cmd.Parameters.AddWithValue("@AppID", pl.ForApplication);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
            }
            catch (Exception ex) { msg = ex.Message; }
            return dt;
        }
    }
}