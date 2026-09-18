using System;

namespace Model.Bai_04
{
    // Lớp mô tả sách giáo khoa, kế thừa từ lớp Sach.
    public class SachGiaoKhoa : Sach
    {
        // ===== THUỘC TÍNH RIÊNG =====
        private bool tinhTrang;

        // ===== CONSTRUCTOR =====
        public SachGiaoKhoa() : base()
        {
            tinhTrang = true;
        }

        public SachGiaoKhoa(string maSach, DateOnly ngayNhap, double donGia,
                            int soLuong, string nhaXuatBan, bool tinhTrang)
            : base(maSach, ngayNhap, donGia, soLuong, nhaXuatBan)
        {
            this.tinhTrang = tinhTrang;
        }

        // ===== PROPERTY =====
        public bool TinhTrang => tinhTrang;

        // ===== PHƯƠNG THỨC =====
        // Sách mới: số lượng * đơn giá.
        // Sách cũ: số lượng * đơn giá * 50%.
        public override double GetThanhTien()
        {
            return tinhTrang ? SoLuong * DonGia : SoLuong * DonGia * 0.5;
        }

        public override string ToString()
        {
            return $"Mã sách: {MaSach} | " +
                   $"Ngày nhập: {NgayNhap:dd/MM/yyyy} | " +
                   $"Đơn giá: {DonGia:N0} | " +
                   $"Số lượng: {SoLuong} | " +
                   $"NXB: {NhaXuatBan} | " +
                   $"Tình trạng: {(TinhTrang ? "Mới" : "Cũ")} | " +
                   $"Thành tiền: {GetThanhTien():N0} VND";
        }
    }
}
