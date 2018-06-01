using AmravatiUniversity_API.Models.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AmravatiUniversity_API.Models.DL;
using System.Data;
namespace AmravatiUniversity_API.Controllers
{
    public class UserCreationController : ApiController
    {
        DataTable dt = null;
        PL_UserCreation ObjPl = new PL_UserCreation();
        Dl_UserCreation ObjDl = new Dl_UserCreation();
        // GET api/usercreation
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/usercreation/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet]
        public DataTable GetAllRegister( int Ind,int ItemId)
        {
            ObjPl.ItemID = ItemId;
            ObjPl.Ind = Ind;
           dt = new DataTable();
          dt= ObjDl.GetAllRegister(ObjPl);
            return dt;


        }
        [HttpGet]
        public DataTable GetLockedUsers(int Ind,int UserId)
        {
            ObjPl.Ind=Ind;
            ObjPl.UserId=UserId;
            dt = new DataTable();
            dt = ObjDl.GetLockedUsers(ObjPl);
            return dt;
        }


        [HttpGet]
        public DataSet GetAllUserInGrid(int Ind)
        {
           
            ObjPl.Ind = Ind;
            //dt = new DataTable();
            DataSet ds = new DataSet();

            ds = ObjDl.GetAllUserInGrid(ObjPl);
            return ds;
        }
        [HttpGet]
        public DataTable GetUpdateValidity(int Ind,int UserId)
        {

            ObjPl.Ind = Ind;
            ObjPl.UserId = UserId;
            dt = new DataTable();
            dt = ObjDl.GetUpdateValidity(ObjPl);
            return dt;
        }

        // POST api/usercreation
        [HttpPost]
        public DataTable InsertUserEntry(PL_UserCreation pl)
        {
            DataTable dt = new DataTable();
            dt = ObjDl.InsertUserEntry(pl);
            //int i =Convert.ToInt16(dt.Rows[0][0].ToString());
            return dt;
        }

        // PUT api/usercreation/5
        public void Put(int id, [FromBody]string value)
        {
        }
        [HttpPut]
        public int UpdateUnlockedUser(int Ind,int UserId,int LockId)
        {
            ObjPl.Ind = Ind;
            ObjPl.LockId = LockId;
            ObjPl.UserId = UserId;
            int i = ObjDl.UpdateUnlockedUser(ObjPl);
            return i;
        }
        [HttpGet]
        public DataTable UpdateUserValidity(int Ind, int UserId, string UserValidity, string MacAddress, string EmployeeID)
        {
            ObjPl.UserId = UserId;
            ObjPl.Ind = Ind;
          ObjPl.UserValidity =Convert.ToDateTime(UserValidity);
            ObjPl.MacAddress = MacAddress;
            ObjPl.EmployeeID = EmployeeID;
            DataTable dt = new DataTable();
            dt = ObjDl.UpdateUserValidity(ObjPl);
            return dt;

        }
        [HttpGet]
        public DataTable GetUserloginIdUnique(int Ind,string UserloginId)
        {
            ObjPl.UserLoginId = UserloginId;
            ObjPl.Ind = Ind;
            dt = new DataTable();
            dt = ObjDl.GetUserloginIdUnique(ObjPl);
            return dt;
        }
        [HttpGet]
        public DataTable GetMenuList(int Ind, int UserTypeID)
        {
            ObjPl.UserTypeID = UserTypeID;
            ObjPl.Ind = Ind;
            dt = new DataTable();
            dt = ObjDl.GetMenuList(ObjPl);
            return dt;
        }




        // DELETE api/usercreation/5
        public void Delete(int id)
        {
        }
    }
}
