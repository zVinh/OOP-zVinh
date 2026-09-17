using System;
using System.Text;
using System.Collections.Generic;
using Model.Bai_01;

namespace Model.Bai_01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Tạo sẵn mỗi loại 2 chuyến xe
            ChuyenXe[] danhSach =
            {
                new ChuyenXeNoiThanh("NT01", "Nguyễn Văn An", "51A-001", 5000000, "Tuyến 1", 120),
                new ChuyenXeNoiThanh("NT02", "Trần Thị Bình", "51B-002", 4500000, "Tuyến 3", 90),

                new ChuyenXeNgoaiThanh("NG01", "Lê Văn Cường", "51C-003", 8000000, "Đà Lạt", 3),
                new ChuyenXeNgoaiThanh("NG02", "Phạm Thị Dung", "51D-004", 9000000, "Nha Trang", 2)
            };

            Console.WriteLine("========== DANH SÁCH CHUYẾN XE ==========");
            foreach (ChuyenXe cx in danhSach)
            {
                Console.WriteLine(cx); // đa hình: gọi ToString() của lớp con
            }

            Console.WriteLine("\n========== THỐNG KÊ DOANH THU ==========");
            Console.WriteLine($"Tổng doanh thu tất cả      : {TinhTongDoanhThu(danhSach):N0} VND");
            Console.WriteLine($"Tổng doanh thu nội thành   : {TinhTongDoanhThuNoiThanh(danhSach):N0} VND");
            Console.WriteLine($"Tổng doanh thu ngoại thành : {TinhTongDoanhThuNgoaiThanh(danhSach):N0} VND");
        }

        // ===== CÁC PHƯƠNG THỨC XỬ LÝ =====

        public static double TinhTongDoanhThu(ChuyenXe[] danhSach)
        {
            double tong = 0;
            foreach (ChuyenXe cx in danhSach)
            {
                tong += cx.DoanhThu;
            }
            return tong;
        }

        public static double TinhTongDoanhThuNoiThanh(ChuyenXe[] danhSach)
        {
            double tong = 0;
            foreach (ChuyenXe cx in danhSach)
            {
                if (cx is ChuyenXeNoiThanh)
                {
                    tong += cx.DoanhThu;
                }
            }
            return tong;
        }

        public static double TinhTongDoanhThuNgoaiThanh(ChuyenXe[] danhSach)
        {
            double tong = 0;
            foreach (ChuyenXe cx in danhSach)
            {
                if (cx is ChuyenXeNgoaiThanh)
                {
                    tong += cx.DoanhThu;
                }
            }
            return tong;
        }
    }
}