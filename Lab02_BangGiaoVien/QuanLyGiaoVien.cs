using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02_BangGiaoVien
{
    public class QuanLyGiaoVien
    {
        public enum KieuTim
        {
            TheoMa,
            TheoHoTen,
            TheoSDT
        };

        public List<GiaoVien> dsGiaoVien;

        public QuanLyGiaoVien()
        {
            dsGiaoVien = new List<GiaoVien>();
        }

        public bool Them (GiaoVien gv)
        {
            foreach (var item in dsGiaoVien)
            {
                if (item.MaSo == gv.MaSo)
                    return false;
            }
            dsGiaoVien.Add(gv);
             return true;
        }

        public GiaoVien TimKiem(KieuTim kieu, string soSanh)
        {
            GiaoVien gv = null;
            if (kieu == KieuTim.TheoMa)
                gv = dsGiaoVien.Find(p => p.MaSo == soSanh);
            if (kieu == KieuTim.TheoHoTen)
                gv = dsGiaoVien.Find(p => p.HoTen == soSanh);
            if (kieu == KieuTim.TheoSDT)
                gv = dsGiaoVien.Find(p => p.SoDT == soSanh);
            return gv;
        }

    }
}
