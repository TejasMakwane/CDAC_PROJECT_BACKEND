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
    
    public partial class T_Sloats
    {
        public T_Sloats()
        {
            this.T_Booking = new HashSet<T_Booking>();
        }
    
        public int SloatId { get; set; }
        public System.TimeSpan Sloat_StartTime { get; set; }
        public int TheaterId { get; set; }
        public int MovieId { get; set; }
    
        public virtual ICollection<T_Booking> T_Booking { get; set; }
        public virtual T_Movie T_Movie { get; set; }
        public virtual T_Theater T_Theater { get; set; }
    }
}