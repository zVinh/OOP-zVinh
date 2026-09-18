using System;

namespace Model.Bai_04
{
    // Lớp mô tả sách tham khảo, kế thừa từ lớp Sach.
    public class SachThamKhao : Sach
    {
        // ===== THUỘC TÍNH RIÊNG =====
        private double thue;

        // ===== CONSTRUCTOR =====
        public SachThamKhao() : base()
        {
            thue = 0;
        }

        public SachThamKhao(string maSach, DateOnly ngayNhap, double donGia,
                            int soLuong, string nhaXuatBan, double thue)
            : base(maSach, ngayNhap, donGia, soLuong, nhaXuatBan)
        {
            this.thue = thue >= 0 ? thue : 0;
        }

        // ===== PROPERTY =====
        public double Thue => thue;

        // ===== PHƯƠNG THỨC =====
        // Thành tiền = số lượng * đơn giá + thuế.
        public override double GetThanhTien()
        {
            return SoLuong * DonGia + Thue;
        }

        public override string ToString()
        {
            return $"Mã sách: {MaSach} | " +
                   $"Ngày nhập: {NgayNhap:dd/MM/yyyy} | " +
                   $"Đơn giá: {DonGia:N0} | " +
                   $"Số lượng: {SoLuong} | " +
                   $"NXB: {NhaXuatBan} | " +
                   $"Thuế: {Thue:N0} | " +
                   $"Thành tiền: {GetThanhTien():N0} VND";
        }
    }
}
