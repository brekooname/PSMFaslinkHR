using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iHRM.Core.i_Report
{
    public class BC_NvCoBH : i_ReportBase
    {
        public BC_NvCoBH()
        {
            Caption = "BC Nhân Viên Có Bảo Hiểm";
            ProcName = "i_rp_BC_NvCoBH";

            Filters.Add(new i_ReportItem() { DataIndex = "MaNV", Caption = "Mã Nhân viên", DataType = i_ReportDataType.MaNV });
            Filters.Add(new i_ReportItem() { DataIndex = "MaPB", Caption = "Phòng Ban", DataType = i_ReportDataType.PhongBan });

            Columns.Add(new i_ReportItem() { DataIndex = "EmployeeID", Caption = "Mã NV", DataType = i_ReportDataType.String, Column_Width = 55 });
            Columns.Add(new i_ReportItem() { DataIndex = "EmployeeName", Caption = "Họ và tên", DataType = i_ReportDataType.String, Column_Width = 125 });
            Columns.Add(new i_ReportItem() { DataIndex = "IDCard", Caption = "CMND", DataType = i_ReportDataType.String });
            Columns.Add(new i_ReportItem() { DataIndex = "EmpTypeName", Caption = "Loại nhân viên", DataType = i_ReportDataType.String });
            Columns.Add(new i_ReportItem() { DataIndex = "DepName_Final", Caption = "Phòng ban", DataType = i_ReportDataType.String });
            Columns.Add(new i_ReportItem() { DataIndex = "AppliedDate", Caption = "Ngày vào làm", DataType = i_ReportDataType.Date });
            Columns.Add(new i_ReportItem() { DataIndex = "LeftDate", Caption = "Ngày nghỉ việc", DataType = i_ReportDataType.Date });
            Columns.Add(new i_ReportItem() { DataIndex = "SIDate", Caption = "BH bắt đầu từ", DataType = i_ReportDataType.Date });
            Columns.Add(new i_ReportItem() { DataIndex = "SINo", Caption = "Số sổ bảo hiểm", DataType = i_ReportDataType.String });
            
           
        }
    }
}
