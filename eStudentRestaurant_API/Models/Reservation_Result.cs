//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eStudentRestaurant_API.Models
{
    using System;
    
    public partial class Reservation_Result
    {
        public int ReservationID { get; set; }
        public int ClinetID { get; set; }
        public string Name_ { get; set; }
        public System.DateTime ReservationDateTime { get; set; }
        public int PlacesNamber { get; set; }
        public string Note { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public string Status { get; set; }
    }
}
