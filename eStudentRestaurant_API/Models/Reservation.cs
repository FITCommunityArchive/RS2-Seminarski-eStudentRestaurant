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
    using System.Collections.Generic;
    
    public partial class Reservation
    {
        public int ReservationID { get; set; }
        public int ClinetID { get; set; }
        public Nullable<int> ReservationTypeID { get; set; }
        public System.DateTime ReservationDateTime { get; set; }
        public int PlacesNamber { get; set; }
        public string Note { get; set; }
        public bool Approved { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual ReservationType ReservationType { get; set; }
    }
}
