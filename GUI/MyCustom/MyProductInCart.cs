﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.MyCustom
{
    public partial class MyProductInCart : UserControl
    {
        public MyProductInCart()
        {
            InitializeComponent();
            lblTongTien.Text = lblDonGia.Text;
        }

        private void btnTang_Click(object sender, EventArgs e)
        {
            int soLuong = int.Parse(txtSoLuong.Texts);
            soLuong += 1;
            txtSoLuong.Texts = soLuong.ToString();
            
            int donGia = 0;
            int tongTien = 0;
            if (lblDonGia.Text.EndsWith("đ"))
            {
                donGia = int.Parse(lblDonGia.Text.Substring(0, lblDonGia.Text.Length - 1));
            }
            tongTien = tongTien + (soLuong * donGia);
            
            lblTongTien.Text = tongTien.ToString() + "đ";

        }

        private void btnGiam_Click(object sender, EventArgs e)
        {
            int soLuong = int.Parse(txtSoLuong.Texts);
            if (soLuong == 0)
            {
                return;
            }
            soLuong -= 1;
            txtSoLuong.Texts = soLuong.ToString();

            int donGia = 0;
            int tongTien = 0;
            if (lblDonGia.Text.EndsWith("đ"))
            {
                donGia = int.Parse(lblDonGia.Text.Substring(0, lblDonGia.Text.Length - 1));
            }
            tongTien = tongTien + (soLuong*donGia);
            lblTongTien.Text = tongTien.ToString() + "đ";

        }
    }
}
