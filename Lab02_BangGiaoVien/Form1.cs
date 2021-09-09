using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab02_BangGiaoVien
{
    public partial class frmGiaoVien : Form
    {

        private readonly QuanLyGiaoVien _dsGiaoVien = new QuanLyGiaoVien();

        public frmGiaoVien()
        {
            InitializeComponent();
        }

        private void frmGiaoVien_Load(object sender, EventArgs e)
        {
            string lienhe = "http://cntt.dlu.edu.vn/";
            linklbLienHe.Links.Add(0, lienhe.Length, lienhe);
            cbbMaSo.SelectedItem = cbbMaSo.Items[0];
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            int i = lbDanhSachMH.SelectedItems.Count - 1;
            while (i >= 0)
            {
                lbMonHocDay.Items.Add(lbDanhSachMH.SelectedItems[i]);
                lbDanhSachMH.Items.Remove(lbDanhSachMH.SelectedItems[i]);
                i--;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int i = lbMonHocDay.SelectedItems.Count - 1;
            while (i >= 0)
            {
                lbDanhSachMH.Items.Add(lbMonHocDay.SelectedItems[i]);
                lbMonHocDay.Items.Remove(lbMonHocDay.SelectedItems[i]);
                i--;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            cbbMaSo.Text = "";
            txtHoTen.Text = "";
            txtMail.Text = "";
            mtxtSoDT.Text = "";
            rdNam.Checked = true;
            for (int i = 0; i < chklbNgoaiNgu.Items.Count -1; i++)
            {
                chklbNgoaiNgu.SetItemChecked(i, false);
            }
            foreach (object ob in lbMonHocDay.Items)
            {
                lbDanhSachMH.Items.Add(ob);
            }
            lbMonHocDay.Items.Clear();
        }



        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linklbLienHe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string s = e.Link.LinkData.ToString();
            Process.Start(s);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            frmTBGiaoVien frm = new frmTBGiaoVien();
            frm.SetText(GetGiaoVien().ToString());
            frm.ShowDialog();
        }

        public GiaoVien GetGiaoVien()
        {
            string gt = "Nam";
            if (rdNu.Checked)
                gt = "Nữ";

            string ngoaingu = "";
            for (int i = 0; i < chklbNgoaiNgu.Items.Count - 1; i++)
            {
                if (chklbNgoaiNgu.GetItemChecked(i))
                    ngoaingu += chklbNgoaiNgu.Items[i] + ";";
            }

            DanhMucMonHoc mh = new DanhMucMonHoc();
            foreach (var ob in lbMonHocDay.Items)
            {
                mh.Them(new MonHoc(ob.ToString()));
            }
            GiaoVien gv = new GiaoVien()
            {
                MaSo = cbbMaSo.Text,
                GioiTinh = gt,
                HoTen = txtHoTen.Text,
                NgaySinh = dtpNgaySinh.Value,
                Mail = txtMail.Text,
                SoDT = mtxtSoDT.Text,
                NgoaiNgu = ngoaingu.Split(';'),
                dsMonHoc = mh
            };
            return gv;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            GiaoVien gv = GetGiaoVien();
            if (_dsGiaoVien.Them(gv))
                MessageBox.Show("Đã thêm giáo viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Mã giáo viên đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            frmTimKiemGiaoVien frm = new frmTimKiemGiaoVien();
            frm.LayDSGiaoVien(_dsGiaoVien);
            frm.ShowDialog();
        }
    }
}
