using System;
using System.Collections.Generic;
using System.Text;
using Model.Bai_02;
using System.Linq;

namespace Model.Bai_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // ===== TẠO DANH SÁCH =====
            Sach[] danhSach =
            {
                // 3 sách giáo khoa
                new SachGiaoKhoa("SGK001", new DateOnly(2024, 1, 10), 50000, 5, "NXB Giáo Dục", true),
                new SachGiaoKhoa("SGK002", new DateOnly(2024, 2, 15), 80000, 3, "NXB Trẻ", false),
                new SachGiaoKhoa("SGK003", new DateOnly(2024, 3, 20), 60000, 4, "NXB Giáo Dục", true),

                // 3 sách tham khảo
                new SachThamKhao("STK001", new DateOnly(2024, 1, 5), 120000, 2, "NXB Trẻ", 10000),
                new SachThamKhao("STK002", new DateOnly(2024, 2, 10), 150000, 1, "NXB Giáo Dục", 15000),
                new SachThamKhao("STK003", new DateOnly(2024, 3, 15), 200000, 3, "NXB Trẻ", 20000)
            };

            // ===== IN DANH SÁCH =====
            Console.WriteLine("========== DANH SÁCH SÁCH ==========");

            foreach (Sach s in danhSach)
            {
                Console.WriteLine(s);
            }

            // ===== TÍNH TỔNG THÀNH TIỀN =====
            double tongSGK = 0;
            double tongSTK = 0;

            foreach (Sach s in danhSach)
            {
                if (s is SachGiaoKhoa)
                    tongSGK += s.GetThanhTien();
                else if (s is SachThamKhao)
                    tongSTK += s.GetThanhTien();
            }

            Console.WriteLine("\n========== TỔNG THÀNH TIỀN ==========");
            Console.WriteLine($"Tổng SGK: {tongSGK:N0} VND");
            Console.WriteLine($"Tổng STK: {tongSTK:N0} VND");

            // ===== TÌM SÁCH CÓ THÀNH TIỀN CAO NHẤT =====
            Sach sachMax = danhSach[0];

            foreach (Sach s in danhSach)
            {
                if (s.GetThanhTien() > sachMax.GetThanhTien())
                {
                    sachMax = s;
                }
            }

            Console.WriteLine("\n========== SÁCH CÓ THÀNH TIỀN CAO NHẤT ==========");
            Console.WriteLine(sachMax);
            Console.WriteLine($"Thành tiền: {sachMax.GetThanhTien():N0} VND");

            // ===== TÌM SÁCH GIÁO KHOA THEO NXB =====
            Console.WriteLine("\n===== HƯỚNG DẪN TÌM SÁCH GIÁO KHOA THEO NXB =====");
            Console.WriteLine("Nhập Giao_Duc -> NXB Giáo Dục");
            Console.WriteLine("Nhập Tre      -> NXB Trẻ");

            Console.Write("\nNhập NXB K: ");
            string k = (Console.ReadLine() ?? "").Trim();

            string nxbCanTim = "";

            switch (k)
            {
                case "Giao_Duc":
                    nxbCanTim = "NXB Giáo Dục";
                    break;

                case "Tre":
                    nxbCanTim = "NXB Trẻ";
                    break;

                default:
                    Console.WriteLine("NXB không hợp lệ!");
                    Console.WriteLine("Chỉ được nhập: Giao_Duc, Tre");
                    return;
            }

            Console.WriteLine($"\n===== SGK CỦA {nxbCanTim} =====");

            bool timThay = false;

            foreach (Sach s in danhSach)
            {
                if (s is SachGiaoKhoa && s.NhaXuatBan == nxbCanTim)
                {
                    Console.WriteLine(s);
                    timThay = true;
                }
            }

            if (!timThay)
            {
                Console.WriteLine("Không tìm thấy sách giáo khoa.");
            }
        }
    }
}