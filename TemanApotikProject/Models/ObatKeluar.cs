//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TemanApotikProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ObatKeluar
    {
        public int id_Transaksi_Keluar { get; set; }
        public Nullable<System.DateTime> Tgl_Keluar { get; set; }
        public Nullable<int> Id_Pasien { get; set; }
        public Nullable<int> id_Obat { get; set; }
        public Nullable<int> id_Jenis_Obat { get; set; }
        public Nullable<int> Jumlah_Keluar { get; set; }
        public Nullable<int> Total_Harga { get; set; }
    
        public virtual Obat Obat { get; set; }
        public virtual Pasien Pasien { get; set; }
    }
}
