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
    
    public partial class T_SeatBooked
    {
        public int SeatBookId { get; set; }
        public int SeatId { get; set; }
        public int BookingId { get; set; }
    
        public virtual T_Booking T_Booking { get; set; }
        public virtual T_Seat T_Seat { get; set; }
    }
}
