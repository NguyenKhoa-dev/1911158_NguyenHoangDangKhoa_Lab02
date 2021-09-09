using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02_BangGiaoVien
{
    public class GiaoVien
    {
        public string MaSo { get; set; }

        public string HoTen { get; set; }

        public DateTime NgaySinh;

        public DanhMucMonHoc dsMonHoc;

        public string GioiTinh;

        public string[] NgoaiNgu;

        public string SoDT;

        public string Mail;

        public GiaoVien()
        {
            dsMonHoc = new DanhMucMonHoc();
            NgoaiNgu = new string[10];
        }

        public GiaoVien(string maso, string hoten, DateTime ngaysinh, DanhMucMonHoc ds, string gt, string[] nn, string sdt, string mail)
        {
            this.MaSo = maso;
            this.HoTen = hoten;
            this.NgaySinh = ngaysinh;
            this.dsMonHoc = ds;
            this.GioiTinh = gt;
            this.NgoaiNgu = nn;
            this.SoDT = sdt;
            this.Mail = mail;
        }

        public override string ToString()
        {
            string s = String.Format("Mã số: {0}\nHọ tên: {1}\nNgày sinh: {2}\nGiới tính: {3}\nSố ĐT: {4}\nMail: {5}\n", MaSo, HoTen, NgaySinh.ToString(), GioiTinh, SoDT, Mail);
            string sngoaingu = "Ngoại ngữ: ";
            foreach (var t in NgoaiNgu)            
                sngoaingu += t + ";";
            string MonDay = "Danh sách môn dạy: ";
            foreach (MonHoc mh in dsMonHoc.ds)
                MonDay += mh + ";";
            s += "\n" + sngoaingu + "\n" + MonDay;
            return s;
        }
    }
}
