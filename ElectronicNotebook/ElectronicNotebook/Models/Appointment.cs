//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ElectronicNotebook.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Appointment
    {
        public System.DateTime date { get; set; }
        public System.TimeSpan time { get; set; }
        public int patientId { get; set; }
        public int professionalId { get; set; }
    
        public virtual Patient Patient { get; set; }
        public virtual Professional Professional { get; set; }
    }
}
