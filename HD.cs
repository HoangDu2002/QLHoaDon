using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_OOP_demo
{
   public class HD
    {
        int stt, SoLuong, MaSP;
        string TenSP;
        decimal DonGia, TongTien;
        DateTime time;
        public int STT { get => stt; set => stt = value; }
        public int SL { get => SoLuong; set => SoLuong = value; }
        public int Masp { get => MaSP; set => MaSP = value; }
        public string Tensp { get => TenSP; set => TenSP = value; }
        public decimal Dongia { get => DonGia; set => DonGia = value; }
        public decimal Tongtien { get => TongTien; set => TongTien = value; }
        public DateTime Time { get => time; set => time = value; }
    }
}
