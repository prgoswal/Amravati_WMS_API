using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmravatiUniversity_API.Models.PL
{
    public class PL_UserCreation
    {
        public int Ind { get; set; }
        public int UserType { get; set; }
        public string UserName { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string LoginId { get; set; }
        public string Pwd { get; set; }
        public int ItemID { get; set; }
        public DateTime UserValidity { get; set; }
        public int IsOutSideUser { get; set; }
        public int IsActive { get; set; }
        public DateTime CreationDate { get; set; }
        public int UserLoginStatus { get; set; }
        public string MacAddress { get; set; }
        public int LockId { get; set; }
        public int UserId { get; set; }
        public int InvalidAttempt { get; set; }
        public string UserState { get; set; }
        public string UserAddress { get; set; }
        public int UpdateValidity { get; set; }
        public string UserLoginId { get; set; }
        public string EmployeeID { get; set; }
        public int UserTypeID { get; set; }
    }
}