using System;
using System.Collections.Generic;
using System.Text;
using Model.Bai_02;

Console.OutputEncoding = Encoding.UTF8;

// ===== TẠO DANH SÁCH =====
Sach[] danhSach = {
    // 3 sách giáo khoa
    new SachGiaoKhoa("SGK001", new DateTime(2024,1,10),
                     50_000, 5, "NXB Giáo Dục", true),
    new SachGiaoKhoa("SGK002", new DateTime(2024,2,15),
                     80_000, 3, "NXB Trẻ", false),
    new SachGiaoKhoa("SGK003", new DateTime(2024,3,20),
                     60_000, 4, "NXB Kim Đồng", true),
    // 3 sách tham khảo
    new SachThamKhao("STK001", new DateTime(2024,1,5),
                     120_000, 2, "NXB Khoa Học", 10_000),
    new SachThamKhao("STK002", new DateTime(2024,2,10),
                     150_000, 1, "NXB Giáo Dục", 15_000),
    new SachThamKhao("STK003", new DateTime(2024,3,15),
                     200_000, 3, "NXB Trẻ", 20_000)
};

// ===== IN DANH SÁCH =====
Console.WriteLine("========== DANH SÁCH SÁCH ==========");
foreach (Sach s in danhSach)
    Console.WriteLine(s);

// ===== TÍNH TỔNG =====
double tongSGK = 0, tongSTK = 0;
foreach (Sach s in danhSach)
{
    if (s is SachGiaoKhoa)
        tongSGK += s.GetThanhTien();
    else
        tongSTK += s.GetThanhTien();
}

Console.WriteLine("=====================================");
Console.WriteLine($"Tổng thành tiền SGK: {tongSGK,12:N0} VND");
Console.WriteLine($"Tổng thành tiền STK: {tongSTK,12:N0} VND");
Console.WriteLine($"Tổng tất cả        : {tongSGK + tongSTK,12:N0} VND");