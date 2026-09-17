using System;
using System.Text;
using System.Collections.Generic;
using Model.Bai_01;

namespace Model.Bai_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            ChuyenXe[] danhSach =
            {
                new ChuyenXeNoiThanh("NT01", "Nguyễn Văn An", "51A-001", 5_000_000, "Tuyến 1", 120),
                new ChuyenXeNoiThanh("NT02", "Trần Thị Bình", "51B-002", 4_500_000, "Tuyến 3", 90),
                new ChuyenXeNgoaiThanh("NG01", "Lê Văn Cường", "51C-003", 8_000_000, "Đà Lạt", 3),
                new ChuyenXeNgoaiThanh("NG02", "Phạm Thị Dung", "51D-004", 9_000_000, "Nha Trang", 2)
            };

            Console.WriteLine("========== DANH SÁCH CHUYẾN XE ==========");
            foreach (ChuyenXe cx in danhSach)
            {
                Console.WriteLine(cx); // đa hình gọi ToString() của lớp con
            }

            Console.WriteLine("==========================================");
            Console.WriteLine($"Tổng tất cả      : {TinhTongDoanhThu(danhSach),15:N0} VND");
            Console.WriteLine($"Tổng nội thành   : {TinhTongDoanhThuNoiThanh(danhSach),15:N0} VND");
            Console.WriteLine($"Tổng ngoại thành : {TinhTongDoanhThuNgoaiThanh(danhSach),15:N0} VND");
        }

        // ===== Các phương thức tách riêng theo sơ đồ =====

        static double TinhTongDoanhThu(ChuyenXe[] ds)
        {
            double tong = 0;
            foreach (ChuyenXe cx in ds)
                tong += cx.DoanhThu;
            return tong;
        }

        static double TinhTongDoanhThuNoiThanh(ChuyenXe[] ds)
        {
            double tong = 0;
            foreach (ChuyenXe cx in ds)
                if (cx is ChuyenXeNoiThanh)
                    tong += cx.DoanhThu;
            return tong;
        }

        static double TinhTongDoanhThuNgoaiThanh(ChuyenXe[] ds)
        {
            double tong = 0;
            foreach (ChuyenXe cx in ds)
                if (cx is ChuyenXeNgoaiThanh)
                    tong += cx.DoanhThu;
            return tong;
        }
    }
}