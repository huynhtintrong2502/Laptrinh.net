﻿using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class DiemRenLuyenDao
    {
        QuanLyRenLuyenDbConText1 db = null;
        public DiemRenLuyenDao()
        {
            db = new QuanLyRenLuyenDbConText1();
        }

        public DiemRenLuyen GetByRL(double MaSV, int Id_NamHoc, int Id_HocKi)
        {
            return db.DiemRenLuyens.Where(x => x.MaSV == MaSV && x.Id_NamHoc == Id_NamHoc && x.Id_HocKi == Id_HocKi).SingleOrDefault();
        }

        public List<DiemRenLuyen> ListRenLuyen(int Id_NamHoc, int Id_HocKi)
        {
            return db.DiemRenLuyens.OrderByDescending(x => x.MaSV).Where(x => x.Xoa == 0 && x.Id_NamHoc == Id_NamHoc && x.Id_HocKi == Id_HocKi).ToList();
        }

        public void create(double MaSV, int Id_NamHoc, int Id_HocKi)
        {
            if (GetByRL(MaSV, Id_NamHoc, Id_HocKi) == null)
            {
                DiemRenLuyen diemLop = new DiemRenLuyen();
                diemLop.MaSV = MaSV;
                diemLop.Id_NamHoc = Id_NamHoc;
                diemLop.Id_HocKi = Id_HocKi;
                diemLop.Muc1_1 = 0;
                diemLop.Muc1_2 = 0;
                diemLop.Muc1_3 = 0;
                diemLop.Muc1_4 = 0;
                diemLop.Muc2_1 = 0;
                diemLop.Muc2_2 = 0;
                diemLop.Muc2_3 = 0;
                diemLop.Muc3_1 = 0;
                diemLop.Muc3_2 = 0;
                diemLop.Muc4_1 = 0;
                diemLop.Muc4_2 = 0;
                diemLop.Muc4_3 = 0;
                diemLop.Muc5_1 = 0;
                diemLop.Muc5_2 = 0;
                diemLop.Muc5_3 = 0;
                diemLop.Muc6_1 = 0;
                diemLop.TongMuc1 = 0;
                diemLop.TongMuc2 = 0;
                diemLop.TongMuc3 = 0;
                diemLop.TongMuc4 = 0;
                diemLop.TongMuc5 = 0;
                diemLop.Xoa = 0;
                db.DiemRenLuyens.Add(diemLop);
                db.SaveChanges();
            }
            else return;
        }

        public int? DiemTong(double MaSV, int Id_NamHoc, int Id_HocKi)
        {
            if (GetByRL(MaSV, Id_NamHoc, Id_HocKi) != null)
            {
                DiemRenLuyen diem = new DiemRenLuyenDao().GetByRL(MaSV, Id_NamHoc, Id_HocKi);
                return diem.TongMuc1 + diem.TongMuc2 + diem.TongMuc3 + diem.TongMuc4 + diem.TongMuc5 + diem.Muc6_1;
            }
            else return null;
        }

        public int TienDo100(int Id_NamHoc, int Id_HocKy)
        {
            int dem = 0;
            foreach(var item in ListRenLuyen(Id_NamHoc, Id_HocKy))
            {
                if (item.TienDo == 100)
                    dem++;
            }
            return dem;
        }

        public int TienDo80_99(int Id_NamHoc, int Id_HocKy)
        {
            int dem = 0;
            foreach (var item in ListRenLuyen(Id_NamHoc, Id_HocKy))
            {
                if (item.TienDo >= 80 && item.TienDo < 100)
                    dem++;
            }
            return dem;
        }

        public int TienDo50_79(int Id_NamHoc, int Id_HocKy)
        {
            int dem = 0;
            foreach (var item in ListRenLuyen(Id_NamHoc, Id_HocKy))
            {
                if (item.TienDo >= 50 && item.TienDo < 80)
                    dem++;
            }
            return dem;
        }
        public int TienDo0_49(int Id_NamHoc, int Id_HocKy)
        {
            int dem = 0;
            foreach (var item in ListRenLuyen(Id_NamHoc, Id_HocKy))
            {
                if (item.TienDo >= 0 && item.TienDo < 50)
                    dem++;
            }
            return dem;
        }

        public void Update(double MaSV, int Id_NamHoc, int Id_HocKi, int? Diem_1_1, int? Diem_1_2, int? Diem_1_3, int? Diem_1_4, int? Diem_2_1, int? Diem_2_2, int? Diem_2_3, int? Diem_3_1, int? Diem_3_2, int? Diem_4_1, int? Diem_4_2, int? Diem_4_3, int? Diem_5_1, int? Diem_5_2, int? Diem_5_3, int? Diem_6_1,string GhiChu1_2,string GhiChu1_3, string GhiChu3_1,double DiemHKTruoc,double DiemHKNay )
        {
            var diem_Lop = db.DiemRenLuyens.Where(x => x.MaSV == MaSV && x.Id_NamHoc == Id_NamHoc && x.Id_HocKi == Id_HocKi).First();
            if (diem_Lop != null)
            {
                diem_Lop.Muc1_1 = Diem_1_1;
                if (Diem_1_1 != 0 && Diem_1_1 !=null)
                    diem_Lop.DD_Muc1_1 = 1;
                else diem_Lop.DD_Muc1_1 = 0;
                diem_Lop.Muc1_2 = Diem_1_2;
                if (Diem_1_2 != 0 && Diem_1_2 != null)
                    diem_Lop.DD_Muc1_2 = 1;
                else diem_Lop.DD_Muc1_2 = 0;
                diem_Lop.Muc1_3 = Diem_1_3;
                if (Diem_1_3 != 0 && Diem_1_3 != null)
                    diem_Lop.DD_Muc1_3 = 1;
                else diem_Lop.DD_Muc1_3 = 0;
                diem_Lop.Muc1_4 = Diem_1_4;
                if (Diem_1_4 != 0 && Diem_1_4 != null)
                    diem_Lop.DD_Muc1_4 = 1;
                else diem_Lop.DD_Muc1_4 = 0;
                diem_Lop.Muc2_1 = Diem_2_1;
                if (Diem_2_1 != 0 && Diem_2_1 != null)
                    diem_Lop.DD_Muc2_1 = 1;
                else diem_Lop.DD_Muc2_1 = 0;
                diem_Lop.Muc2_2 = Diem_2_2;
                if (Diem_2_2 != 0 && Diem_2_2 != null)
                    diem_Lop.DD_Muc2_2 = 1;
                else diem_Lop.DD_Muc2_2 = 0;
                diem_Lop.Muc2_3 = Diem_2_3;
                if (Diem_2_3 != 0 && Diem_2_3 != null)
                    diem_Lop.DD_Muc2_3 = 1;
                else diem_Lop.DD_Muc2_3 = 0;
                diem_Lop.Muc3_1 = Diem_3_1;
                if (Diem_3_1 != 0 && Diem_3_1 != null)
                    diem_Lop.DD_Muc3_1 = 1;
                else diem_Lop.DD_Muc3_1 = 0;
                diem_Lop.Muc3_2 = Diem_3_2;
                if (Diem_3_2 != 0 && Diem_3_2 != null)
                    diem_Lop.DD_Muc3_2 = 1;
                else diem_Lop.DD_Muc3_2 = 0;
                diem_Lop.Muc4_1 = Diem_4_1;
                if (Diem_4_1 != 0 && Diem_4_1 != null)
                    diem_Lop.DD_Muc4_1 = 1;
                else diem_Lop.DD_Muc4_1 = 0;
                diem_Lop.Muc4_2 = Diem_4_2;
                if (Diem_4_2 != 0 && Diem_4_2 != null)
                    diem_Lop.DD_Muc4_2 = 1;
                else diem_Lop.DD_Muc4_2 = 0;
                diem_Lop.Muc4_3 = Diem_4_3;
                if (Diem_4_3 != 0 && Diem_4_3 != null)
                    diem_Lop.DD_Muc4_3 = 1;
                else diem_Lop.DD_Muc4_3 = 0;
                diem_Lop.Muc5_1 = Diem_5_1;
                if (Diem_5_1 != 0 && Diem_5_1 != null)
                    diem_Lop.DD_Muc5_1 = 1;
                else diem_Lop.DD_Muc5_1 = 0;
                diem_Lop.Muc5_2 = Diem_5_2;
                if (Diem_5_2 != 0 && Diem_5_2 != null)
                    diem_Lop.DD_Muc5_2 = 1;
                else diem_Lop.DD_Muc5_2 = 0;
                diem_Lop.Muc5_3 = Diem_5_3;
                if (Diem_5_3 != 0 && Diem_5_3 != null)
                    diem_Lop.DD_Muc5_3 = 1;
                else diem_Lop.DD_Muc5_3 = 0;
                diem_Lop.Muc6_1 = Diem_6_1;
                if (Diem_6_1 != 0 && Diem_6_1 != null)
                    diem_Lop.DD_Muc6_1 = 1;
                else diem_Lop.DD_Muc6_1 = 0;
                if (GhiChu1_2 != null || GhiChu1_2.Equals(""))
                    diem_Lop.GhiChu1_2 = GhiChu1_2;
                if (GhiChu1_3 != null || GhiChu1_3.Equals(""))
                    diem_Lop.GhiChu1_3 = GhiChu1_3;
                if (GhiChu3_1 != null || GhiChu3_1.Equals(""))
                    diem_Lop.GhiChu3_1 = GhiChu3_1;
                diem_Lop.DiemKyTruoc = DiemHKTruoc;
                diem_Lop.DiemKyNay = DiemHKNay;
                var now = DateTime.Now;
                diem_Lop.DateUpdate = now;

                diem_Lop.TongMuc1 = Diem_1_1 + Diem_1_2 + Diem_1_3 + Diem_1_4;
                diem_Lop.TongMuc2 = Diem_2_1 + Diem_2_2 + Diem_2_3;
                diem_Lop.TongMuc3 = Diem_3_1 + Diem_3_2;
                diem_Lop.TongMuc4 = Diem_4_1 + Diem_4_2 + Diem_4_3;
                diem_Lop.TongMuc5 = Diem_5_1 + Diem_5_2 + Diem_5_3;
                diem_Lop.Xoa = 0;
                double dem = 0;
                if (diem_Lop.DD_Muc1_1 != 0 )
                {
                    dem++;
                }
                if (diem_Lop.DD_Muc1_2 != 0 )
                {
                    dem++;
                }
                if (diem_Lop.DD_Muc1_3 != 0 )
                {
                    dem++;
                }
                if (diem_Lop.DD_Muc1_4 != 0 )
                {
                    dem++;
                }
                if (diem_Lop.DD_Muc2_1 != 0 )
                {
                    dem++;
                }
                if (diem_Lop.DD_Muc2_2 != 0 )
                {
                    dem++;
                }
                if (diem_Lop.DD_Muc2_3 != 0 )
                {
                    dem++;
                }
                if (diem_Lop.DD_Muc3_1 != 0 )
                {
                    dem++;
                }
                if (diem_Lop.DD_Muc3_2 != 0 )
                {
                    dem++;
                }
                if (diem_Lop.DD_Muc4_1 != 0 )
                {
                    dem++;
                }
                if (diem_Lop.DD_Muc4_2 != 0 )
                {
                    dem++;
                }
                if (diem_Lop.DD_Muc4_3 != 0 )
                {
                    dem++;
                }
                if (diem_Lop.DD_Muc5_1 != 0 )
                {
                    dem++;
                }
                if (diem_Lop.DD_Muc5_2 != 0 )
                {
                    dem++;
                }
                if (diem_Lop.DD_Muc5_3 != 0 )
                {
                    dem++;
                }
                if (diem_Lop.DD_Muc6_1 != 0 )
                {
                    dem++;
                }
                diem_Lop.TienDo = ((dem / 16)) * 100;
                db.SaveChanges();
            }
            else return;
        }

    }
}
