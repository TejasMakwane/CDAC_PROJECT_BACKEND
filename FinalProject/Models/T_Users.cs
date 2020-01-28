//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_Users
    {
        public T_Users()
        {
            this.T_OTP_Details = new HashSet<T_OTP_Details>();
            this.T_PasswordHistoryLog = new HashSet<T_PasswordHistoryLog>();
            this.T_Theater = new HashSet<T_Theater>();
            this.T_Booking = new HashSet<T_Booking>();
            this.T_Cart = new HashSet<T_Cart>();
            this.T_Ratting = new HashSet<T_Ratting>();
        }
    
        public int UserId { get; set; }
        public string EmailId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string MobileNo { get; set; }
        public bool IsOnline { get; set; }
        public bool IsLocked { get; set; }
        public int RoleId { get; set; }
    
        public virtual ICollection<T_OTP_Details> T_OTP_Details { get; set; }
        public virtual ICollection<T_PasswordHistoryLog> T_PasswordHistoryLog { get; set; }
        public virtual T_Roles T_Roles { get; set; }
        public virtual ICollection<T_Theater> T_Theater { get; set; }
        public virtual ICollection<T_Booking> T_Booking { get; set; }
        public virtual ICollection<T_Cart> T_Cart { get; set; }
        public virtual ICollection<T_Ratting> T_Ratting { get; set; }
    }
}