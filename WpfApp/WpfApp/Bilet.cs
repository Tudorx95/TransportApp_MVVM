//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bilet
    {
        public int id_unic { get; set; }
        public int tip_bilet { get; set; }
        public System.DateTime valabilitate { get; set; }
        public int id_calator { get; set; }
        public int nr_bilete { get; set; }
    
        public virtual Tip_Bilet Tip_Bilet1 { get; set; }
        public virtual User User { get; set; }
    }
}
