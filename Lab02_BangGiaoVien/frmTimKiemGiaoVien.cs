using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab02_BangGiaoVien
{
    public partial class frmTimKiemGiaoVien : Form
    {
        private readonly QuanLyGiaoVien _dsGiaoVien = new QuanLyGiaoVien();
        public frmTimKiemGiaoVien()
        {
            InitializeComponent();
        }

        private void frmTimKiemGiaoVien_Load(object sender, EventArgs e)
        {
            LoadDefault();
        }

        public void LayDSGiaoVien(QuanLyGiaoVien dsGV)
        {
            _dsGiaoVien.dsGiaoVien = dsGV.dsGiaoVien;
        }

        private void LoadDefault()
        {
            rdMaGV.Checked = true;
            lblNhan.Text = rdMaGV.Text;
        }

        private void rdMaGV_CheckedChanged(object sender, EventArgs e)
        {
            lblNhan.Text = rdMaGV.Text;
            mtxtTimKiem.Mask = "";
        }

        private void rdHoTen_CheckedChanged(object sender, EventArgs e)
        {
            lblNhan.Text = rdHoTen.Text;
            mtxtTimKiem.Mask = "";
        }

        private void rdSDT_CheckedChanged(object sender, EventArgs e)
        {
            lblNhan.Text = rdSDT.Text;
            mtxtTimKiem.Mask = "(\\0633).000.000";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            GiaoVien gv = new GiaoVien();
            if (String.IsNullOrWhiteSpace(mtxtTimKiem.Text))
                MessageBox.Show("Ô tìm kiếm không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {                      
                if (rdMaGV.Checked)
                {
                    gv = _dsGiaoVien.TimKiem(QuanLyGiaoVien.KieuTim.TheoMa, mtxtTimKiem.Text);
                    LoadFormTBGiaoVien(gv);
                }
                    
                if (rdHoTen.Checked)
                {
                    gv = _dsGiaoVien.TimKiem(QuanLyGiaoVien.KieuTim.TheoHoTen, mtxtTimKiem.Text);
                    LoadFormTBGiaoVien(gv);
                }
                    
                if (rdSDT.Checked)
                {
                    gv = _dsGiaoVien.TimKiem(QuanLyGiaoVien.KieuTim.TheoSDT, mtxtTimKiem.Text);
                    LoadFormTBGiaoVien(gv);
                }                    
            }
        }

        private void LoadFormTBGiaoVien(GiaoVien gv)
        {
            if (gv == null)
                MessageBox.Show("Không tìm thấy thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                frmTBGiaoVien frm = new frmTBGiaoVien();
                frm.SetText(gv.ToString());
                frm.ShowDialog();
            }
        }
    }
}
