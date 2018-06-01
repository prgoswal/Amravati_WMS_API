using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using AmravatiUniversity_API.Models.PL;
using AmravatiUniversity_API.Models;
using System.Configuration;


namespace AmravatiUniversity_API.Models.DL
{

    public class DL_SecondLevel
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlCommand cmd; SqlDataAdapter da; DataTable dt; DataSet ds;
        string msg = "";
        //For DL for Pending and Complete Data Grid for Level id 2 (Office assistent)     
        public DataSet GetAppDetailZeroLevel(PL_SecondLevel pl)
        {
            try
            {

                cmd = new SqlCommand("SPApplicationDetail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ind", pl.Ind);
                cmd.Parameters.AddWithValue("@UserID", pl.UserID);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);

            }
            catch (Exception ex)
            { msg = ex.Message; }
            return ds;
        }
        //For DL for Pending and Complete Data Grid for Level id >2 (3 to 7)
        public DataSet GetAppDetail(PL_SecondLevel pl)
        {
            try
            {
                cmd = new SqlCommand("SPApplicationDetail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@levelid", pl.levelid);
                cmd.Parameters.AddWithValue("@Ind", pl.Ind);
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
            }
            catch (Exception ex)
            { msg = ex.Message; }
            return ds;

        }
        public DataTable GetLevelRemark(PL_SecondLevel pl)
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
            catch (Exception ex)
            { msg = ex.Message; }
            return dt;
        }
        public DataTable GetRecordId(PL_SecondLevel pl)
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
            catch (Exception ex)
            { msg = ex.Message; }
            return dt;
        }
        public DataTable GetApprovalCount(PL_SecondLevel pl)
        {
            try
            {
                cmd = new SqlCommand("SPApplicationEntry", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ApplicationID", pl.ApplicationID);
                cmd.Parameters.AddWithValue("@Ind", pl.Ind);
                cmd.Parameters.AddWithValue("@DocType", pl.DocType);
                cmd.Parameters.AddWithValue("@IsConfirmed", pl.isconfirmed);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
            }
            catch (Exception ex)
            { msg = ex.Message; }
            return dt;
        }
        int j;
        public DataTable SubmitPopDetail(Pl_SubmitZeroLevel pl)
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand("SPApplicationEntry", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ind", pl.Ind);
            cmd.Parameters.AddWithValue("@ApplicationID", pl.ApplicationID);
            cmd.Parameters.AddWithValue("@RollNo", pl.Rollno);
            cmd.Parameters.AddWithValue("@StudentName", pl.SName);
            cmd.Parameters.AddWithValue("@ExamName", pl.ExamName);
            cmd.Parameters.AddWithValue("@BranchName", pl.BranchName);
            cmd.Parameters.AddWithValue("@ExamSession", 0);
            cmd.Parameters.AddWithValue("@EnrollmentNo", pl.EnrollmentNo);
            cmd.Parameters.AddWithValue("@College", pl.College);
            cmd.Parameters.AddWithValue("@CGPA", pl.CGPA);
            cmd.Parameters.AddWithValue("@Division", pl.Division);
            cmd.Parameters.AddWithValue("@UserID", pl.UserID);
            cmd.Parameters.AddWithValue("@EntryByIP", pl.EntryByIP);
            cmd.Parameters.AddWithValue("@DocType", pl.DocType);
            cmd.Parameters.AddWithValue("@ExamPassingYear", pl.PassingYear);
            cmd.Parameters.AddWithValue("@ExamMedium", pl.ExamMedium);
            cmd.Parameters.AddWithValue("@MeritNo", pl.MeritNo);
            cmd.Parameters.AddWithValue("@SubjectName", pl.SubjectName);
            cmd.Parameters.AddWithValue("@DistinctionSubject", pl.DistinctionSub);
            cmd.Parameters.AddWithValue("@LetterRefNo", pl.LaterReferenceNo);
            cmd.Parameters.AddWithValue("@LetterRefDate", pl.LaterReferenceDate);
            cmd.Parameters.AddWithValue("@Ranking", pl.Rank);
            cmd.Parameters.AddWithValue("@AwardedBy", pl.AwardedBy);

            cmd.Parameters.AddWithValue("@AwardPrize", pl.AwardPrize);


            con.Open();
            int i = Convert.ToInt16(cmd.ExecuteScalar());
            con.Close();
            if (i > 0)
            {
                SqlCommand cmd1 = new SqlCommand("SPApplicationEntry", con);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@Ind", 2);
                cmd1.Parameters.AddWithValue("@ApplicationID", pl.ApplicationID);
                //  cmd1.Parameters.AddWithValue("@ApplicationID", pl.UserID);
                //   cmd1.Parameters.AddWithValue("@DocType", pl.DocTypeID);
                cmd1.Parameters.AddWithValue("@DocType", pl.DocType);
                cmd1.Parameters.AddWithValue("@UserID", pl.UserID);
                cmd1.Parameters.AddWithValue("@LevelID", pl.UserTypeId);
                cmd1.Parameters.AddWithValue("@LevelRemark", pl.Remarks);
                cmd1.Parameters.AddWithValue("@EntryByIP", pl.EntryByIP);
                cmd1.Parameters.AddWithValue("@ApprovalCount", 0);
                //  cmd1.Parameters.AddWithValue("@MaxApproval",pl.ApprovalCount);


                cmd1.Parameters.AddWithValue("@RecordID", i);
                cmd1.Parameters.AddWithValue("@IsConfirmed", false);
                cmd1.Parameters.AddWithValue("@IsRejected", false);
                cmd1.Parameters.AddWithValue("@IsCorrectionReqd", false);
                con.Open();
                // j = Convert.ToInt16(cmd1.ExecuteScalar());               
                da = new SqlDataAdapter(cmd1);
                con.Close();
                da.Fill(dt);
                if (dt != null && dt.Rows.Count > 0)
                {
                    //  return dt;
                }
                else
                {
                    dt = null;
                }
            }


            return dt;
        }


        public DataTable SubmitRejection(Pl_SubmitZeroLevel pl)
        {

            SqlCommand cmd1 = new SqlCommand("SPApplicationEntry", con);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@Ind", pl.Ind);
            cmd1.Parameters.AddWithValue("@ApplicationID", pl.ApplicationID);
            cmd1.Parameters.AddWithValue("@DocType", pl.DocType);
            cmd1.Parameters.AddWithValue("@LevelID", pl.UserTypeId);
            cmd1.Parameters.AddWithValue("@UserID", pl.UserID);
            cmd1.Parameters.AddWithValue("@LevelRemark", pl.Remarks);
            cmd1.Parameters.AddWithValue("@EntryByIP", pl.EntryByIP);
            cmd1.Parameters.AddWithValue("@ApprovalCount", pl.acnt);
            // cmd1.Parameters.AddWithValue("@MaxApproval",pl.maxaproval);
            cmd1.Parameters.AddWithValue("@RecordID", pl.recordId);
            cmd1.Parameters.AddWithValue("@IsConfirmed", false);
            cmd1.Parameters.AddWithValue("@IsRejected", true);
            cmd1.Parameters.AddWithValue("@IsCorrectionReqd", false);
            da = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        public DataTable SubmitCorrection(PL_SecondLevel pl)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand("SPApplicationEntry", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Ind", pl.Ind);
                cmd.Parameters.AddWithValue("@IsConfirmed", false);
                cmd.Parameters.AddWithValue("@IsRejected", false);
                cmd.Parameters.AddWithValue("@IsCorrectionReqd", true);
                con.Open();
                int i = Convert.ToInt16(cmd.ExecuteScalar());
                con.Close();
                if (i > 0)
                {
                    SqlCommand cmd1 = new SqlCommand("SPApplicationEntry", con);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@Ind", 2);
                    cmd1.Parameters.AddWithValue("@ApplicationID", pl.ApplicationID);
                    cmd1.Parameters.AddWithValue("@DocType", pl.DocTypeID);
                    cmd1.Parameters.AddWithValue("@LevelID", pl.UserID);
                    cmd1.Parameters.AddWithValue("@LevelRemark", "");
                    cmd1.Parameters.AddWithValue("@EntryByIP", pl.EntryByIP);
                    cmd1.Parameters.AddWithValue("@ApprovalCount", 1);
                    cmd1.Parameters.AddWithValue("@MaxApproval", pl.maxaproval);
                    cmd1.Parameters.AddWithValue("@RecordID", i);
                    cmd1.Parameters.AddWithValue("@IsConfirmed", false);
                    cmd1.Parameters.AddWithValue("@IsRejected", false);
                    cmd1.Parameters.AddWithValue("@IsCorrectionReqd", true);
                    da = new SqlDataAdapter(cmd1);
                    con.Close();
                    da.Fill(dt);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        //  return dt;
                    }
                    else
                    {
                        dt = null;
                    }
                }
            }
            catch (Exception ex)

            { msg = ex.Message; }
            return dt;
        }

        public DataTable SubmitApproval(Pl_SubmitZeroLevel pl)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd1 = new SqlCommand("SPApplicationEntry", con);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@Ind", 2);
                cmd1.Parameters.AddWithValue("@ApplicationID", pl.ApplicationID);
                cmd1.Parameters.AddWithValue("@DocType", pl.DocType);
                cmd1.Parameters.AddWithValue("@LevelID", pl.UserTypeId);
                cmd1.Parameters.AddWithValue("@LevelRemark", pl.Remarks);
                cmd1.Parameters.AddWithValue("@EntryByIP", pl.EntryByIP);
                cmd1.Parameters.AddWithValue("@ApprovalCount", pl.acnt);
                cmd1.Parameters.AddWithValue("@UserID", pl.UserID);
                cmd1.Parameters.AddWithValue("@RecordID", pl.recordId);
                cmd1.Parameters.AddWithValue("@IsConfirmed", true);
                cmd1.Parameters.AddWithValue("@IsRejected", false);
                cmd1.Parameters.AddWithValue("@IsCorrectionReqd", false);
                da = new SqlDataAdapter(cmd1);
                con.Close();
                da.Fill(dt);
                if (dt != null && dt.Rows.Count > 0)
                {
                    //  return dt;
                }
                else
                {
                    dt = null;
                }
            }
            catch (Exception ex)

            { msg = ex.Message; }
            return dt;
        }
        public DataTable ShowExamDetail(PL_SecondLevel plSecondLevel)
        {
            cmd = new SqlCommand("SPApplicationDetail", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ind", plSecondLevel.Ind);
            cmd.Parameters.AddWithValue("@Rollno", Convert.ToInt32(plSecondLevel.Rollno));
            cmd.Parameters.AddWithValue("@ExamYear", Convert.ToInt32(plSecondLevel.ExamYear));
            cmd.Parameters.AddWithValue("@OccCtrl", Convert.ToInt32(plSecondLevel.OccCtrl));
            cmd.Parameters.AddWithValue("@ExamSession", Convert.ToInt32(plSecondLevel.ExamSession));
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        internal DataTable CancelPopDetail(Pl_SubmitZeroLevel pl)
        {
            cmd = new SqlCommand("SPApplicationDetail", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ind", pl.Ind);
            cmd.Parameters.AddWithValue("@AppID", pl.ApplicationID);
            cmd.Parameters.AddWithValue("@UserID", pl.UserID);
            cmd.Parameters.AddWithValue("@CancelInd", pl.CancelInd);
            cmd.Parameters.AddWithValue("@CancelReason", pl.CancelReason);
            cmd.Parameters.AddWithValue("@CancelDateTime", pl.CancelDateTime);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        internal DataTable CancelApplicationList(Pl_SubmitZeroLevel pl)
        {
            cmd = new SqlCommand("SPApplicationDetail", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ind", pl.Ind);
            cmd.Parameters.AddWithValue("@UserID", pl.UserID);
            cmd.Parameters.AddWithValue("@CancelInd", pl.CancelInd);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}