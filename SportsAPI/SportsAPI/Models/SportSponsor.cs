//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SportsAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SportSponsor
    {
        public int SportSponsorID { get; set; }
        public string SportSponsorName { get; set; }
        public Nullable<int> SportID { get; set; }
        public Nullable<int> TypeSportID { get; set; }
    
        public virtual Sport Sport { get; set; }
        public virtual TypeSport TypeSport { get; set; }
    }
}
