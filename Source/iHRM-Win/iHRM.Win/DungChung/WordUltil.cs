using System;
using System.Collections.Generic;
using Word = Microsoft.Office.Interop.Word;
using System.Data;
using System.Data.OleDb;

namespace iHRM.Win.DungChung
{
    class WordUltil
    {
        private Word.Application _app;
        Word.Document _doc;
        private object _pathFile;
        public WordUltil(string vPath, bool vCreateApp)
        {
            _pathFile = vPath;
            _app = new Word.Application();
            _app.Visible = vCreateApp;
            object ob = System.Reflection.Missing.Value;
            _doc = _app.Documents.Add(ref _pathFile, ref ob, ref ob, ref ob);

            //E:\SVN1\SVN\iHRM-Win\iHRM.Win\bin\Debug/ExcelTemplate/TuyenDung

        }
        public void WriteFields(Dictionary<string, string> vValues)
        {
            foreach (Word.Field field in _doc.Fields)
            {
                string fieldName = field.Code.Text.Substring(11, field.Code.Text.IndexOf("\\") - 12).Trim();
                if (vValues.ContainsKey(fieldName))
                {
                    field.Select();
                    _app.Selection.TypeText(vValues[fieldName]);
                }
            }
        }
        public void WriteTable(DataTable vDataTable, int vIndexTable)
        {

            Word.Table tbl = _doc.Tables[vIndexTable];
            int lenrow = vDataTable.Rows.Count;
            int lencol = vDataTable.Columns.Count;
            for (int i = 0; i < lenrow; ++i)
            {
                
                //object ob = System.Reflection.Missing.Value;
                //tbl.Rows.Add(ref ob);
                if (vIndexTable > 15)
                    break;
                if (vIndexTable >= 10)
                {
                    tbl = _doc.Tables[vIndexTable];
                    tbl.Cell(1, 1).Range.Text = "Tên doanh nghiệp: "+ vDataTable.Rows[i]["tenDoanhNghiep"].ToString();
                    tbl.Cell(1, 2).Range.Text = "Từ ngày: "+vDataTable.Rows[i]["tuNgay"].ToString();
                    tbl.Cell(2, 1).Range.Text = "Chức danh: "+vDataTable.Rows[i]["chucDanh"].ToString();
                    tbl.Cell(2, 2).Range.Text = "Đến ngày: "+vDataTable.Rows[i]["denNgay"].ToString();
                    tbl.Cell(3, 1).Range.Text = "Trách nghiệm chính: \n"+vDataTable.Rows[i]["trachNghiemChinh"].ToString();
                    tbl.Cell(4, 2).Range.Text = "Khởi điểm: "+vDataTable.Rows[i]["thuNhapKhoiDiem"].ToString()+" đ";
                    tbl.Cell(5, 2).Range.Text = "Cuối cùng: "+vDataTable.Rows[i]["thuNhapCuoiCung"].ToString()+" đ";
                    tbl.Cell(6, 2).Range.Text = "Họ tên & chức danh , điện thoại người quản lý trực tiếp: \n"+vDataTable.Rows[i]["thongTinNguoiQuanLy"].ToString();
                    tbl.Cell(7, 2).Range.Text = "Lý do nghỉ việc: \n"+vDataTable.Rows[i]["lyDoNghiViec"].ToString();
                    tbl.Cell(8, 1).Range.Text = "Thành tích đạt được (nếu có): "+vDataTable.Rows[i]["thanhTichDatDuoc"].ToString();
                    tbl.Cell(9, 1).Range.Text = "Số nhân viên Anh/Chị quản lý (nếu có): "+vDataTable.Rows[i]["soNhanVienQuanLy"].ToString();
                    vIndexTable++;
                }
                else
                {
                    object ob = System.Reflection.Missing.Value;
                    tbl.Rows.Add(ref ob);
                    for (int j = 0; j < lencol; ++j)
                    {
                        tbl.Cell(i + 2, j + 1).Range.Text = vDataTable.Rows[i][j].ToString();
                    }
                }
                
            }
            if(vIndexTable >=10)
            {
                //xóa các table còn thừa
                for (int i = vIndexTable; i < 13; i++)
                {
                    tbl = _doc.Tables[vIndexTable];
                    tbl.Delete();
                }
            }
        }

        public void WriteTable_QDTV_001(DataTable vDataTable, int vIndexTable)
        {

            Word.Table tbl = _doc.Tables[vIndexTable];
            int lenrow = vDataTable.Rows.Count;
            int lencol = vDataTable.Columns.Count;
            for (int i = 0; i < lenrow; ++i)
            {
                for (int j = 0; j < lencol; ++j)
                {
                    try
                    {
                        tbl.Cell(i + 2, j + 1).Range.Text = vDataTable.Rows[i][j].ToString();
                    }
                    catch
                    {
                        continue;
                    }
                }

                if (i < lenrow - 1)
                {
                    object ob = System.Reflection.Missing.Value;

                    tbl.Rows.Add(ref ob);
                }
            }

            tbl.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
        }

        public void WriteTable_QDTV(DataTable vDataTable, int vIndexTable)
        {

            Word.Table tbl = _doc.Tables[vIndexTable];
            int lenrow = vDataTable.Rows.Count;
            int lencol = vDataTable.Columns.Count;
            for (int i = 0; i < lenrow; ++i)
            {
                

                for (int j = 0; j < lencol; ++j)
                {
                    try
                    {
                        tbl.Cell(i + 2, j + 1).Range.Text = vDataTable.Rows[i][j].ToString();
                    }
                    catch
                    {
                        continue;
                    }
                }

                if(i < lenrow - 1)
                {
                    object ob = System.Reflection.Missing.Value;

                    tbl.Rows.Add(ref ob);
                }            }

            tbl.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
        }
    }
}
