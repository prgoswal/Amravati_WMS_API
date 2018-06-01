using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using AmravatiUniversity_API.Models.PL;
using AmravatiUniversity_API.Models.DL;

namespace AmravatiUniversity_API.Controllers
{
    public class StudentDetailController : ApiController
    {
        DL_StudentDetail objDL_StudentDetail = new DL_StudentDetail();
        PL_StudentDetail objPL_StudentDetail = new PL_StudentDetail();


        // GET api/studentdetail
       [HttpGet]
        public DataTable GetExamYear()
        {   
            objDL_StudentDetail.GetExamYear(objPL_StudentDetail);
           
            return objPL_StudentDetail.dt;

        }
        [HttpGet]
        public DataTable GetExamSession(int ind)
        {
            objPL_StudentDetail.Ind = ind;
            objPL_StudentDetail.dt=objDL_StudentDetail.GetExamSession(objPL_StudentDetail);

            return objPL_StudentDetail.dt;

        }
         [HttpGet]
        public DataTable GetApply( int ind)
        {
            objPL_StudentDetail.Ind = ind;
          objPL_StudentDetail.dt=  objDL_StudentDetail.GetForApply(objPL_StudentDetail);

            return objPL_StudentDetail.dt;

        }
         [HttpGet]
        public DataTable GetStudentDetail(int ind, string ExamSession, string ExamYear, string StudentName, string Rollno)
        {
            objPL_StudentDetail.Ind = ind;
            objPL_StudentDetail.ExamSession = ExamSession;
            objPL_StudentDetail.ExamYear = ExamYear;
            objPL_StudentDetail.StudentName = StudentName;
            objPL_StudentDetail.Rollno = Rollno;
            objPL_StudentDetail.dt = objDL_StudentDetail.GetStudentDetail(objPL_StudentDetail);

            return objPL_StudentDetail.dt;

        }
  
        //[HttpPost]
        // public HttpResponseMessage SaveRecord(PL_StudentDetail objplstudetail)
        //{
                          
        //        objplstudetail.dt = objDL_StudentDetail.SaveStudentDetail(objplstudetail);
            
        //       var response = Request.CreateResponse(HttpStatusCode.Created, objplstudetail);

        //        string uri = Url.Link("DefaultApi1", new { id = objplstudetail.ApplicationID });
        //        response.Headers.Location = new Uri(uri);

        //        return response;
               

        //}
  
        [HttpPost]
        public DataTable SaveRecord(PL_StudentDetail objplstudetail)
        {

            objplstudetail.dt = objDL_StudentDetail.SaveStudentDetail(objplstudetail);
          //  objplstudetail.dt.TableName = "MyTable";
            return objplstudetail.dt;


        }
        [HttpGet]
        public DataTable GetLevelProfile(int Ind, int LevelProfile)
        {
            objPL_StudentDetail.Ind = Ind;
            objPL_StudentDetail.LevelProfile = LevelProfile;
            DataTable dt = new DataTable();
            dt = objDL_StudentDetail.GetLevelProfile(objPL_StudentDetail);
            return dt;
        }
        [HttpGet]
        public DataTable GetLevelidApproved(int Ind, int ApplicationId)
        {
            objPL_StudentDetail.Ind = Ind;
            objPL_StudentDetail.ApplicationID = ApplicationId;
            DataTable dt = new DataTable();
            dt = objDL_StudentDetail.GetLevelidApproved(objPL_StudentDetail);
            return dt;
        }

        [HttpGet]
        public DataSet GetEntryProcess(int Ind, int ApplicationID)
        {
            objPL_StudentDetail.Ind = Ind;
            objPL_StudentDetail.ApplicationID = ApplicationID;
            DataSet ds = new DataSet();
            ds = objDL_StudentDetail.GetEntryProcess(objPL_StudentDetail);
            return ds;
        }
        [HttpGet]
        public DataTable GetApplicationStatus(int Ind =0,string Fromdate="",string ToDate="",int LevelID=0,int UserID=0,int ForApplication=0)
        {
            // 
            objPL_StudentDetail.Ind = Ind;
            objPL_StudentDetail.FromDate = Fromdate;
            objPL_StudentDetail.ToDate = ToDate;
            objPL_StudentDetail.LevelID = LevelID;
            objPL_StudentDetail.UserID = UserID;
            objPL_StudentDetail.ForApplication = ForApplication;
            DataTable dt = new DataTable();
            dt = objDL_StudentDetail.GetApplicationStatus(objPL_StudentDetail);
            return dt;
        }
        [HttpGet]
        public DataTable GetApplicationMIS(int Ind = 0, string Fromdate = "", string ToDate = "", int LevelID = 0, int UserID = 0)
        {
            // 
            objPL_StudentDetail.Ind = Ind;
            objPL_StudentDetail.FromDate = Fromdate;
            objPL_StudentDetail.ToDate = ToDate;
            objPL_StudentDetail.LevelID = LevelID;
            objPL_StudentDetail.UserID = UserID;
          
            DataTable dt = new DataTable();
            dt = objDL_StudentDetail.GetApplicationMIS(objPL_StudentDetail);
            return dt;
        }
        // POST api/studentdetail
        public void Post([FromBody]string value)
        {
        }

        // PUT api/studentdetail/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/studentdetail/5
        public void Delete(int id)
        {
        }
    }
}
