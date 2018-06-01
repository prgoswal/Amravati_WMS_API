using AmravatiUniversity_API.Models.DL;
using AmravatiUniversity_API.Models.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
namespace AmravatiUniversity_API.Controllers
{
    public class DocumentApprovalController : ApiController
    {
        // GET api/documentapproval
        PL_DocumentApprovalLevel ObjPldocumentApproval = new PL_DocumentApprovalLevel();
        DL_DocumentApprovalLevel ObjDldocumentApproval = new DL_DocumentApprovalLevel();
        [HttpGet]
        public DataTable GetDocumentLevel(int Ind)
        {
            ObjPldocumentApproval.Ind = Ind;           
            DataTable dt = new DataTable();          
            dt = ObjDldocumentApproval.GetDocumentLevel(ObjPldocumentApproval);
            return dt;
        }

        [HttpPost]
        public DataTable InsertDocumentApprovalLevel(PL_DocumentApprovalLevel pl)
        {
            //ObjPlProfile.UserTypeId = UserTypeID;
            //ObjPlProfile.Ind = Ind;
            //ObjPlProfile.ItemId = ItemId;
            DataTable dt = new DataTable();
            // SqlDataAdapter da = new SqlDataAdapter();
            dt = ObjDldocumentApproval.InsertDocumentApprovalLevel(pl);
            return dt;
        }



             [HttpGet]
        public DataTable GetUserLevel(int Ind)
        {
            //ObjPlProfile.UserTypeId = UserTypeID;
            ObjPldocumentApproval.Ind = Ind;   
            //ObjPlProfile.ItemId = ItemId;
            DataTable dt = new DataTable();
            // SqlDataAdapter da = new SqlDataAdapter();
            dt = ObjDldocumentApproval.GetUserLevel(ObjPldocumentApproval);
            return dt;
        }
        [HttpPost]
             public DataTable ApprovalDelete(PL_DocumentApprovalLevel ObjPlUserProfile)
        {
            //ObjPlProfile.UserTypeId = UserTypeID;
           // ObjPldocumentApproval.Ind = Ind;
           // ObjPldocumentApproval.ItemId = ItemId;
            DataTable dt = new DataTable();
            // SqlDataAdapter da = new SqlDataAdapter();
            dt = ObjDldocumentApproval.ApprovalDelete(ObjPlUserProfile);
            return dt;
        }
        [HttpGet]
        public DataTable ShowApproval(int Ind)
        {
            DataTable dt = new DataTable();
           // ObjPlProfile.Ind = Ind;
            dt = ObjDldocumentApproval.ShowApproval(Ind);
            return dt;
        }

    }
}
