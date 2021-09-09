using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2_Demo
{
    public partial class frmTrungTam : Form
    {
        public frmTrungTam()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            cbbMaHV.Text = "";
            txtHoTen.Text = "";
            dtpNgayDangKy.Value = DateTime.Now;
            rdNam.Checked = true;
            chkTiengAnhA.Checked = false;
            chkTiengAnhB.Checked = false;
            chkTinHocA.Checked = false;
            chkTinHocB.Checked = false;
            txtTongTien.Text = "";
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            int s = 0;
            if (chkTinHocA.Checked)
                s += int.Parse(lblTienTHA.Text.Split('.')[0]);
            if (chkTinHocB.Checked)
                s += int.Parse(lblTHB.Text.Split('.')[0]);
            if (chkTiengAnhA.Checked)
                s += int.Parse(lblTAA.Text.Split('.')[0]);
            if (chkTiengAnhB.Checked)
                s += int.Parse(lblTAB.Text.Split('.')[0]);
            txtTongTien.Text = s + ".000 đồng";
        }
    }
}
