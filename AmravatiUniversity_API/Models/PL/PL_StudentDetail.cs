using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AmravatiUniversity_API.Models.PL
{
    public class PL_StudentDetail
    {
        public int ApplicationID { get; set; }
        public string StudentName { get; set; }

        public string ExamYear { get; set; }
        public string ExamSession { get; set; }
        public string ExamName { get; set; }
        public int Ind { get; set; }
        public decimal SubmittedFees { get; set; }
        public string Rollno { get; set; }
        public string AppliedFor { get; set; }
        public string Remarks { get; set; }
        public string InserttionDate { get; set; }
        public string InsertionBy { get; set; }
        public string InsertionByIP { get; set; }
        public string EstimateDate { get; set; }
        public string ItemDesc { get; set; }
        public int PartARegNo { get; set; }
        public string PartAImagePath { get; set; }
        public int PartBRegNo { get; set; }
        public string PartBImagePath { get; set; }

        public int itemId { get; set; }
        public DataTable dt { get; set; }

        public string DocumentType { get; set; }
        public string SName { get; set; }
        public string FilePath { get; set; }
        public int LevelProfile { get; set; }
        public int AllowMenu { get; set; }
        public int LevelID { get; set; }


        public int ReceiptNo { get; set; }
        public DateTime ReceiptDate { get; set; }
        public decimal ReceiptAMT { get; set; }
        public int PaymentMode { get; set; }
        public int ChequeDDNo { get; set; }
        public DateTime ChequeDDDate { get; set; }
        public string BankName { get; set; }

        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int UserID { get; set; }
        public int ForApplication { get; set; }
    
    }
}