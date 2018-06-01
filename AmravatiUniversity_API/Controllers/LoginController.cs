using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AmravatiUniversity_API.Models.PL;
using AmravatiUniversity_API.Models;
using System.Data;

namespace AmravatiUniversity_API.Controllers
{
   

    public class LoginController : ApiController
    {
        PL_Login objpllogin = new PL_Login();
        DL_Login objdllogin = new DL_Login();
        

        // GET api/login
        public IEnumerable<string> Get()
        {

            return new string[] { "value1", "value2" };
        }
        public DataTable Get(string Password, string UserLoginID)
        {

            objpllogin.UserLoginId = UserLoginID;
            objpllogin.LoginPwd = Password;
        
            DataTable dt = new DataTable();
            dt=objdllogin.GetLoginDetailsfromAPI(objpllogin);
            return dt;

        }

        [HttpGet]
        public DataSet GetUserLoginID(int Ind,string UserLoginId,string MacAddress)
        {
            objpllogin.UserLoginId = UserLoginId;
            objpllogin.Ind = Ind;
            objpllogin.MacAddress = MacAddress;
            DataSet ds = new DataSet();
            ds = objdllogin.GetUserLoginID(objpllogin);
                return ds;
        }
        [HttpGet]
        public DataTable UpdateActiveStatus(int Ind, int  UserId)
        {

            objpllogin.Ind=Ind;
            objpllogin.UserId = UserId;
            DataTable dt=new DataTable();
            dt=objdllogin.UpdateActiveStatus(objpllogin);
            return dt;
        }
        [HttpGet]
        public DataTable UpdateInvalidAttempts(int Ind, string UserLoginId ,string UserLoginPwd)
        {
            objpllogin.UserLoginId = UserLoginId;
            objpllogin.Ind = Ind;
            objpllogin.UserLoginPwd = UserLoginPwd;
            DataTable dt = new DataTable();
            dt = objdllogin.UpdateInvalidAttempts(objpllogin);
            return dt;

        }
        [HttpGet]
        public DataTable ChangePwd(int Ind, int UserId, string LoginPwd, string NewPwd)
        {
            PlChangePwd pl = new PlChangePwd();
            pl.Ind = Ind;
            pl.UserId = UserId;
            pl.OldPwd = LoginPwd;
            pl.NewPwd = NewPwd;
            DataTable dt = new DataTable();
            dt = objdllogin.ChangePwd(pl);
            return dt;
        }

        [HttpGet]
        public DataTable FinalLogin(int Ind, string UserLoginId, string LoginPwd, string MacAddress)
        {
            PL_Login pl = new PL_Login();
            pl.Ind = Ind;
            pl.UserLoginId = UserLoginId;
            pl.LoginPwd = LoginPwd;
            pl.MacAddress = MacAddress;
            DataTable dt = new DataTable();
            dt = objdllogin.FinalLogin(pl);
            return dt;
        }
        [HttpGet]
        public DataSet GetLockList(int Ind)
        {
            PL_Login pl = new PL_Login();
            pl.Ind = Ind;
            DataSet ds = new DataSet();
            ds = objdllogin.GetLockList(pl);
            return ds;

        }
        [HttpGet]
        public DataTable UpdateLockUnlock(int Ind, int UserInd, int UserId, string Remark)
        {
            PL_Login pl = new PL_Login();
            pl.Ind = Ind;
            pl.UserInd = UserInd;
            pl.UserId = UserId;
            pl.Remark = Remark;
            DataTable dt = new DataTable();
            dt = objdllogin.UpdateLockUnlock(pl);
            return dt;
        }

        [HttpGet]
        public DataTable InsertUserLevel(int Ind,string ItemDesc)
        {
            PL_Login pl = new PL_Login();
            pl.Ind = Ind;     
            pl.ItemDesc = ItemDesc;       
            DataTable dt = new DataTable();
            dt = objdllogin.InsertUserLevel(pl);
            return dt;

        }
        [HttpGet]
        public DataTable GetUserLevel(int ind)
        {
            PL_Login pl = new PL_Login();
            pl.Ind = ind;
            DataTable dt = new DataTable();
            dt = objdllogin.GetUserLevel(pl);
            return dt;
         
        }
        [HttpGet]
        public DataTable GetMenu(int ind)
        {
            PL_Login pl = new PL_Login();
            pl.Ind = ind;
            DataTable dt = new DataTable();
            dt = objdllogin.GetMenu(pl);
            return dt;

        }
        [HttpGet]
        public DataTable UpdateUserLevel(int ind, string ItemDesc, int ItemID)
        {
            PL_Login pl = new PL_Login();
            pl.Ind = ind;
            pl.ItemDesc = ItemDesc;
            pl.ItemID = ItemID;
            DataTable dt = new DataTable();
            dt = objdllogin.UpdateUserLevel(pl);
            return dt;

        }
        [HttpGet]
        public DataTable InsertProfileCreation(int ind, int UserTypeId, int ItemID)
        {
            PL_Login pl = new PL_Login();
            pl.Ind = ind;
            pl.UserTypeId = UserTypeId;
            pl.ItemID = ItemID;
            DataTable dt = new DataTable();
            dt = objdllogin.InsertProfileCreation(pl);
            return dt;

        }
        [HttpGet]
        public DataTable GetusertypeID(int ind, int UserTypeId)
        {
            PL_Login pl = new PL_Login();
            pl.Ind = ind;
            pl.UserTypeId = UserTypeId;
      
            DataTable dt = new DataTable();
            dt = objdllogin.GetusertypeID(pl);
            return dt;
        }
        
        [HttpGet]
        public DataTable DeleteProfileCreation(int ind, int UserTypeId)
        {
            PL_Login pl = new PL_Login();
            pl.Ind = ind;
            pl.UserTypeId = UserTypeId;      
            DataTable dt = new DataTable();
            dt = objdllogin.DeleteProfileCreation(pl);
            return dt;
        }

        [HttpGet]
        public DataTable GetLogoutPassword(int UserId)
        {
            objpllogin.UserId = UserId;

            DataTable dt = new DataTable();
            dt = objdllogin.GetLogoutPassword(objpllogin);
            return dt;

        }
        [HttpPost]
        public DataTable ChangePasswordFirst(int Ind, int UserId, string LoginPwd)
        {
            objpllogin.UserId = UserId;
            objpllogin.LoginPwd = LoginPwd;

            objpllogin.Ind = Ind;
            DataTable dt = new DataTable();
            dt = objdllogin.ChangePasswordFirst(objpllogin);
            return dt;
        }


        [HttpGet]
        public DataTable GetPasswordHistory(int Ind, string UserLoginID, string NewPassword)
        {
            objpllogin.Ind = Ind;
            objpllogin.UserLoginId = UserLoginID;
            objpllogin.NewPassword = NewPassword;
            DataTable dt = new DataTable();
            dt = objdllogin.GetPasswordHistory(objpllogin);
            return dt;
        }

        [HttpGet]
        public DataTable SelectOldPwd(int Ind, int UserId, string OldPwd)
        {
            PlChangePwd pl = new PlChangePwd();
            pl.Ind = Ind;
            pl.UserId = UserId;
            pl.OldPwd = OldPwd;
            DataTable dt = new DataTable();
            dt = objdllogin.SelectOldPwd(pl);
            return dt;
        }
        [HttpGet]
        public DataTable CheckPassword(int Ind, int UserId, string NewPwd)
        {
            PlChangePwd pl = new PlChangePwd();
            pl.Ind = Ind;
            pl.UserId = UserId;
            pl.NewPwd = NewPwd;
            DataTable dt = new DataTable();
            dt = objdllogin.CheckPassword(pl);
            return dt;

        }
       
    }
}
