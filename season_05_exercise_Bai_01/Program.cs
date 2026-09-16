using Module3.Bai_01;
using System;
using System.Collections.Generic;
using System.Text;


class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        ChuyenXe[] danhSach = {
    new ChuyenXeNoiThanh("NT01","Nguyễn Văn An", "51A-001", 5_000_000, "Tuyến 1", 120),
    new ChuyenXeNoiThanh("NT02","Trần Thị Bình", "51B-002", 4_500_000, "Tuyến 3",  90),
    new ChuyenXeNgoaiThanh("NG01","Lê Văn Cường",  "51C-003", 8_000_000, "Đà Lạt",    3),
    new ChuyenXeNgoaiThanh("NG02","Phạm Thị Dung", "51D-004", 9_000_000, "Nha Trang", 2)
};

        double tongTatCa = 0;
        double tongNoiThanh = 0;
        double tongNgoaiThanh = 0;

        Console.WriteLine("========== DANH SÁCH CHUYẾN XE ==========");
        foreach (ChuyenXe cx in danhSach)
        {
            Console.WriteLine(cx);
            tongTatCa += cx.GetDoanhThu();

            if (cx is ChuyenXeNoiThanh)
                tongNoiThanh += cx.GetDoanhThu();
            else
                tongNgoaiThanh += cx.GetDoanhThu();
        }

        Console.WriteLine("==========================================");
        Console.WriteLine($"Tổng tất cả     : {tongTatCa,15:N0} VND");
        Console.WriteLine($"Tổng nội thành  : {tongNoiThanh,15:N0} VND");
        Console.WriteLine($"Tổng ngoại thành: {tongNgoaiThanh,15:N0} VND");
    }
}
