using System;

namespace Model.Bai_04
{
    // Lớp cha abstract chứa các thông tin chung của mọi loại sách.
    public abstract class Sach
    {
        // ===== THUỘC TÍNH =====
        private string maSach;
        private DateOnly ngayNhap;
        private double donGia;
        private int soLuong;
        private string nhaXuatBan;

        // ===== CONSTRUCTOR =====
        protected Sach()
        {
            maSach = string.Empty;
            ngayNhap = DateOnly.FromDateTime(DateTime.Now);
            donGia = 0;
            soLuong = 0;
            nhaXuatBan = string.Empty;
        }

        protected Sach(string maSach, DateOnly ngayNhap, double donGia,
                       int soLuong, string nhaXuatBan)
        {
            this.maSach = maSach;
            this.ngayNhap = ngayNhap;
            this.donGia = donGia >= 0 ? donGia : 0;
            this.soLuong = soLuong >= 0 ? soLuong : 0;
            this.nhaXuatBan = nhaXuatBan;
        }

        // ===== PROPERTY =====
        public string MaSach => maSach;
        public DateOnly NgayNhap => ngayNhap;
        public double DonGia => donGia;
        public int SoLuong => soLuong;
        public string NhaXuatBan => nhaXuatBan;

        // ===== PHƯƠNG THỨC =====
        public abstract double GetThanhTien();

        public abstract override string ToString();
    }
}
