﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    
    public partial class BanHangGUI : Form
    {
        private int ProductsPerPage = 10;  // Số sản phẩm trên mỗi trang
        private int TotalPages;  // Tổng số trang
        private int CurrentPage = 1;  // Trang hiện tại
        List<Product> productList = new List<Product>();
        public void loadSP()
        {
            productList.Add(new Product
            {
                ProductId = "SP001",
                ProductName = "Bánh quy Cosy Marie",
                Price = 20000
            });
            productList.Add(new Product
            {
                ProductId = "P001",
                ProductName = "Sản phẩm 1",
                Price = 19.99
            });
            productList.Add(new Product
            {
                ProductId = "P001",
                ProductName = "Sản phẩm 1",
                Price = 19.99
            });
            productList.Add(new Product
            {
                ProductId = "P001",
                ProductName = "Sản phẩm 1",
                Price = 19.99
            });
            productList.Add(new Product
            {
                ProductId = "P001",
                ProductName = "Sản phẩm 1",
                Price = 19.99
            });
            productList.Add(new Product
            {
                ProductId = "P001",
                ProductName = "Sản phẩm 1",
                Price = 19.99
            });
            productList.Add(new Product
            {
                ProductId = "P001",
                ProductName = "Sản phẩm 1",
                Price = 19.99
            });
            productList.Add(new Product
            {
                ProductId = "P001",
                ProductName = "Sản phẩm 1",
                Price = 19.99
            });
            productList.Add(new Product
            {
                ProductId = "P001",
                ProductName = "Sản phẩm 1",
                Price = 19.99
            });
            productList.Add(new Product
            {
                ProductId = "P001",
                ProductName = "Sản phẩm 1",
                Price = 19.99
            });
            productList.Add(new Product
            {
                ProductId = "P001",
                ProductName = "Sản phẩm 1",
                Price = 19.99
            });
            productList.Add(new Product
            {
                ProductId = "P001",
                ProductName = "Sản phẩm 1",
                Price = 19.99
            });
            productList.Add(new Product
            {
                ProductId = "P001",
                ProductName = "Sản phẩm 1",
                Price = 19.99
            });
            productList.Add(new Product
            {
                ProductId = "P001",
                ProductName = "Sản phẩm 1",
                Price = 19.99
            });
        }
        public BanHangGUI()
        {
            InitializeComponent();
            // Thêm dữ liệu mẫu vào danh sách

            loadSP();
            // Gọi hàm tính toán số trang
            CalculateTotalPages(productList);

            // Hiển thị trang hiện tại
            UpdateCurrentPage();
            addProductToCart();
        }

        // Các hàm khác ở đây

        private void CalculateTotalPages(List<Product> productList)
        {
            TotalPages = (int)Math.Ceiling((double)productList.Count / ProductsPerPage);
        }
        private void addProductToCart()
        {
            this.flpGioHang.Controls.Clear();
            for(int i = 0;i < 5;i++)
            {
                MyCustom.MyProductInCart item = new MyCustom.MyProductInCart();
                this.flpGioHang.Controls.Add(item);
            }
        }
        private void UpdateCurrentPage()
        {
            int startIndex = (CurrentPage - 1) * ProductsPerPage;
            int endIndex = Math.Min(startIndex + ProductsPerPage, productList.Count);

            this.flpDanhSachSanPham.Controls.Clear();

            for (int i = startIndex; i < endIndex; i++)
            {
                MyCustom.MyProductItem item = new MyCustom.MyProductItem();
                item.lblMaSP.Text = productList[i].ProductId;
                item.lblTenSP.Text = productList[i].ProductName;
                item.lblDonGia.Text = productList[i].Price.ToString();
                item.Margin = new Padding(4); // 4 pixels cho mỗi hướng
                item.ItemClicked += Item_ItemClicked; // Gán sự kiện ở đây, đảm bảo chỉ gán một lần

                this.flpDanhSachSanPham.Controls.Add(item);
            }

            // Cập nhật thông tin phân trang
            lblPagination.Text = $"{CurrentPage}/{TotalPages}";
        }
        private void Item_ItemClicked(object sender, EventArgs e)
        {
            // Đây là nơi bạn có thể xử lý khi item được click
            // Dựa vào item để lấy thông tin sản phẩm và hiển thị nó lên màn hình
            MyCustom.MyProductItem clickedItem = (MyCustom.MyProductItem)sender;
            string maSP = clickedItem.lblMaSP.Text;
            string tenSP = clickedItem.lblTenSP.Text;
            string donGia = clickedItem.lblDonGia.Text;

            txtMaSP.Texts = maSP;
            txtTenSP.Texts = tenSP;
            txtDonGia.Texts = donGia;

        }
        // Các sự kiện nút "Previous" và "Next" ở đây

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (CurrentPage > 1)
            {
                CurrentPage--;
                UpdateCurrentPage();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (CurrentPage < TotalPages)
            {
                CurrentPage++;
                UpdateCurrentPage();
            }
        }
    }
    public class Product
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price
        {
            get; set;
        }
    }
}
