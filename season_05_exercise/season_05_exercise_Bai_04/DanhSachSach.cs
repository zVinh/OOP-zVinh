using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Bai_04
{
    // Lớp quản lý danh sách các đối tượng Sach.
    public class DanhSachSach
    {
        // ===== THUỘC TÍNH =====
        private List<Sach> list;
        private int count;

        // ===== CONSTRUCTOR =====
        public DanhSachSach()
        {
            list = new List<Sach>();
            count = 0;
        }

        // ===== PROPERTY =====
        public int Count => count;

        // ===== PHƯƠNG THỨC =====
        public bool Them(Sach sach)
        {
            if (sach == null)
            {
                return false;
            }

            list.Add(sach);
            count = list.Count;
            return true;
        }

        public double TinhTongThanhTienSGK()
        {
            double tong = 0;

            foreach (Sach sach in list)
            {
                if (sach is SachGiaoKhoa)
                {
                    tong += sach.GetThanhTien();
                }
            }

            return tong;
        }

        public double TinhTongThanhTienSTK()
        {
            double tong = 0;

            foreach (Sach sach in list)
            {
                if (sach is SachThamKhao)
                {
                    tong += sach.GetThanhTien();
                }
            }

            return tong;
        }

        public List<Sach> TimSachGiaoKhoaTheoNXB(string nhaXuatBan)
        {
            List<Sach> ketQua = new List<Sach>();

            foreach (Sach sach in list)
            {
                if (sach is SachGiaoKhoa &&
                    string.Equals(sach.NhaXuatBan, nhaXuatBan,
                                  StringComparison.OrdinalIgnoreCase))
                {
                    ketQua.Add(sach);
                }
            }

            return ketQua;
        }

        public double TimThanhTienCaoNhat()
        {
            if (list.Count == 0)
            {
                return 0;
            }

            double caoNhat = list[0].GetThanhTien();

            foreach (Sach sach in list)
            {
                if (sach.GetThanhTien() > caoNhat)
                {
                    caoNhat = sach.GetThanhTien();
                }
            }

            return caoNhat;
        }

        public override string ToString()
        {
            if (list.Count == 0)
            {
                return "Danh sách sách đang rỗng.";
            }

            StringBuilder ketQua = new StringBuilder();

            foreach (Sach sach in list)
            {
                ketQua.AppendLine(sach.ToString());
            }

            return ketQua.ToString().TrimEnd();
        }
    }
}
