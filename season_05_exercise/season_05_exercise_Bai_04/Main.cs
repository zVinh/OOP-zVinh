using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Bai_04
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Tạo sẵn 3 sách giáo khoa và 3 sách tham khảo.
            DanhSachSach danhSach = new DanhSachSach();

            danhSach.Them(new SachGiaoKhoa(
                "SGK001", new DateOnly(2024, 1, 10), 50000, 5,
                "NXB Giáo Dục", true));
            danhSach.Them(new SachGiaoKhoa(
                "SGK002", new DateOnly(2024, 2, 15), 80000, 3,
                "NXB Trẻ", false));
            danhSach.Them(new SachGiaoKhoa(
                "SGK003", new DateOnly(2024, 3, 20), 60000, 4,
                "NXB Giáo Dục", true));

            danhSach.Them(new SachThamKhao(
                "STK001", new DateOnly(2024, 1, 5), 120000, 2,
                "NXB Trẻ", 10000));
            danhSach.Them(new SachThamKhao(
                "STK002", new DateOnly(2024, 2, 10), 150000, 1,
                "NXB Giáo Dục", 15000));
            danhSach.Them(new SachThamKhao(
                "STK003", new DateOnly(2024, 3, 15), 200000, 3,
                "NXB Trẻ", 20000));

            int luaChon;

            do
            {
                Console.WriteLine("========== MENU BÀI 4 ==========");
                Console.WriteLine("1. Thêm sách");
                Console.WriteLine("2. Xuất danh sách sách");
                Console.WriteLine("3. Tính tổng thành tiền sách giáo khoa");
                Console.WriteLine("4. Tính tổng thành tiền sách tham khảo");
                Console.WriteLine("5. Tìm sách giáo khoa theo nhà xuất bản");
                Console.WriteLine("6. Tìm thành tiền cao nhất");
                Console.WriteLine("0. Thoát");
                Console.Write("Nhập lựa chọn: ");

                if (!int.TryParse(Console.ReadLine(), out luaChon))
                {
                    luaChon = -1;
                }

                switch (luaChon)
                {
                    case 1:
                        Console.WriteLine("========== THÊM SÁCH ==========");
                        Console.Write("Loại sách (1 - Giáo khoa, 2 - Tham khảo): ");
                        string loaiSach = (Console.ReadLine() ?? string.Empty).Trim();

                        Console.Write("Mã sách: ");
                        string maSach = Console.ReadLine() ?? string.Empty;
                        Console.Write("Ngày nhập (dd/MM/yyyy): ");
                        DateOnly.TryParse(Console.ReadLine(), out DateOnly ngayNhap);
                        Console.Write("Đơn giá: ");
                        double.TryParse(Console.ReadLine(), out double donGia);
                        Console.Write("Số lượng: ");
                        int.TryParse(Console.ReadLine(), out int soLuong);
                        Console.Write("Nhà xuất bản: ");
                        string nhaXuatBan = Console.ReadLine() ?? string.Empty;

                        if (loaiSach == "1")
                        {
                            Console.Write("Tình trạng mới? (1 - Có, 0 - Cũ): ");
                            bool tinhTrang = Console.ReadLine()?.Trim() == "1";

                            danhSach.Them(new SachGiaoKhoa(
                                maSach, ngayNhap, donGia, soLuong,
                                nhaXuatBan, tinhTrang));
                            Console.WriteLine("Đã thêm sách giáo khoa.");
                        }
                        else if (loaiSach == "2")
                        {
                            Console.Write("Thuế: ");
                            double.TryParse(Console.ReadLine(), out double thue);

                            danhSach.Them(new SachThamKhao(
                                maSach, ngayNhap, donGia, soLuong,
                                nhaXuatBan, thue));
                            Console.WriteLine("Đã thêm sách tham khảo.");
                        }
                        else
                        {
                            Console.WriteLine("Loại sách không hợp lệ.");
                        }

                        break;

                    case 2:
                        Console.WriteLine("========== DANH SÁCH SÁCH ==========");
                        Console.WriteLine(danhSach);
                        break;

                    case 3:
                        Console.WriteLine("========== TỔNG THÀNH TIỀN SGK ==========");
                        Console.WriteLine(
                            $"Tổng thành tiền sách giáo khoa: " +
                            $"{danhSach.TinhTongThanhTienSGK():N0} VND");
                        break;

                    case 4:
                        Console.WriteLine("========== TỔNG THÀNH TIỀN STK ==========");
                        Console.WriteLine(
                            $"Tổng thành tiền sách tham khảo: " +
                            $"{danhSach.TinhTongThanhTienSTK():N0} VND");
                        break;

                    case 5:
                        Console.WriteLine("===== TÌM SÁCH GIÁO KHOA THEO NXB =====");
                        Console.WriteLine("Nhập Giao_Duc -> NXB Giáo Dục");
                        Console.WriteLine("Nhập Tre      -> NXB Trẻ");
                        Console.Write("\nNhập NXB K: ");

                        string k = (Console.ReadLine() ?? string.Empty).Trim();
                        string nxbCanTim;

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
                                nxbCanTim = string.Empty;
                                break;
                        }

                        if (nxbCanTim != string.Empty)
                        {
                            List<Sach> ketQua =
                                danhSach.TimSachGiaoKhoaTheoNXB(nxbCanTim);

                            Console.WriteLine($"\n===== SGK CỦA {nxbCanTim} =====");

                            if (ketQua.Count == 0)
                            {
                                Console.WriteLine("Không tìm thấy sách giáo khoa.");
                            }
                            else
                            {
                                foreach (Sach sach in ketQua)
                                {
                                    Console.WriteLine(sach);
                                }
                            }
                        }

                        break;

                    case 6:
                        Console.WriteLine("========== THÀNH TIỀN CAO NHẤT ==========");
                        Console.WriteLine(
                            $"Thành tiền cao nhất: " +
                            $"{danhSach.TimThanhTienCaoNhat():N0} VND");
                        break;

                    case 0:
                        Console.WriteLine("Đã kết thúc chương trình.");
                        break;

                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ.");
                        break;
                }

                if (luaChon != 0)
                {
                    Console.WriteLine("\nNhấn Enter để quay lại menu...");
                    Console.ReadLine();
                }
            }
            while (luaChon != 0);
        }
    }
}
