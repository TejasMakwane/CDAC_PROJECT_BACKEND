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
    
    public partial class T_Theater
    {
        public T_Theater()
        {
            this.T_Seat = new HashSet<T_Seat>();
            this.T_Sloats = new HashSet<T_Sloats>();
        }
    
        public int TheaterId { get; set; }
        public string TheaterName { get; set; }
        public string TheaterAddress { get; set; }
        public int UserId { get; set; }
    
        public virtual T_Users T_Users { get; set; }
        public virtual ICollection<T_Seat> T_Seat { get; set; }
        public virtual ICollection<T_Sloats> T_Sloats { get; set; }
    }
}
