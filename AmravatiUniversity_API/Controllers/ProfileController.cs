using AmravatiUniversity_API.Models.DL;
using System;
using System.Collections.Generic;
using AmravatiUniversity_API.Models.PL;
using AmravatiUniversity_API.Models;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;

namespace AmravatiUniversity_API.Controllers
{
    public class ProfileController : ApiController
    {
        PL_ProfileCreation ObjPlProfile = new PL_ProfileCreation();
        DL_ProfileCreation ObjDlProfile = new DL_ProfileCreation();
        [HttpPost]
        public DataTable InsertProfile(PL_ProfileCreation ObjPlProfile)
        {
            //ObjPlProfile.UserTypeId = UserTypeID;
            //ObjPlProfile.Ind = Ind;
            //ObjPlProfile.ItemId = ItemId;
            DataTable dt = new DataTable();
           // SqlDataAdapter da = new SqlDataAdapter();
            dt = ObjDlProfile.InsertProfile(ObjPlProfile);
            return dt;
        }

        [HttpPost]
        public DataTable ProfileDelete(PL_ProfileCreation ObjPlProfile)
        {
            //ObjPlProfile.UserTypeId = UserTypeID;
            //ObjPlProfile.Ind = Ind;
            //ObjPlProfile.ItemId = ItemId;
            DataTable dt = new DataTable();
            // SqlDataAdapter da = new SqlDataAdapter();
         dt= ObjDlProfile.ProfileDelete(ObjPlProfile);
          return dt;
        }
        [HttpGet]
        public DataTable ShowProfile(int Ind)
        {
            DataTable dt = new DataTable();
            ObjPlProfile.Ind = Ind;
            dt = ObjDlProfile.ShowProfile(ObjPlProfile);
            return dt;
        }
        [HttpGet]
        public DataTable GetProfileName(int Ind,int ItemID)
        {
            DataTable dt = new DataTable();
            ObjPlProfile.Ind = Ind;
            ObjPlProfile.ItemId = ItemID;
            dt = ObjDlProfile.GetProfileName(ObjPlProfile);
            return dt;
        }
     //// GET api/profile
     //   public IEnumerable<string> Get()
     //   {
     //       return new string[] { "value1", "value2" };
     //   }   

     //   // GET api/profile/5
     //   public string Get(int id)
     //   {
     //       return "value";
     //   }

     //   // POST api/profile
     //   public void Post([FromBody]string value)
     //   {
     //   }

     //   // PUT api/profile/5
     //   public void Put(int id, [FromBody]string value)
     //   {
     //   }

     //   // DELETE api/profile/5
     //   public void Delete(int id)
     //   {
     //   }
    }
}
