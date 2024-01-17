using iHRM.Core.Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iHRM.Core.FileDB
{
    public class FileStorageHelper
    {
        public void DownLoadAndShowFILE( byte[] dataFile, string extensionfile)
        {
            string folderFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"ExcelTemplate\$Temporary");
            if (!Directory.Exists(folderFilePath))
            {
                Directory.CreateDirectory(folderFilePath);
            }
            string tempFilePath = Path.Combine(folderFilePath + @"\" + Guid.NewGuid() + extensionfile);
            System.IO.File.WriteAllBytes(tempFilePath, dataFile);
            Process.Start(tempFilePath);
        }
        public void DownLoadAndShowFILE(Binary dataFile, string extensionfile)
        {
            string folderFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"ExcelTemplate\$Temporary");
            if (!Directory.Exists(folderFilePath))
            {
                Directory.CreateDirectory(folderFilePath);
            }
            string tempFilePath = Path.Combine(folderFilePath + @"\" + Guid.NewGuid() + extensionfile);
            System.IO.File.WriteAllBytes(tempFilePath, dataFile.ToArray());
            Process.Start(tempFilePath);
        }
        public void DownLoadAndShowFILE_NoSave(Binary dataFile, string extensionfile)
        {
            string fullPathToATempFile = System.IO.Path.GetTempFileName();
            // or
            string tempDirPath = System.IO.Path.GetTempPath();
            string tempFilePath = Path.Combine(System.IO.Path.GetTempPath(),System.IO.Path.GetTempFileName() + Guid.NewGuid() + extensionfile);
            System.IO.File.WriteAllBytes(tempFilePath, dataFile.ToArray());
            Process.Start(tempFilePath);
        }
        public bool InsertOrUpdateDBFiles(Guid idFile, byte[] dataFile, string extensionfile, string tenfile = "")
        {
            return Provider.ExecNoneQuery("InsertOrUpdateFile",
                 new System.Data.SqlClient.SqlParameter("idFile", idFile),
                 new System.Data.SqlClient.SqlParameter("dataFile", dataFile),
                 new System.Data.SqlClient.SqlParameter("duoiFile", extensionfile),
                 new System.Data.SqlClient.SqlParameter("tenfile", tenfile)
                 ) > 0 ? true : false;
        }
        public bool DeleteFileByIDDBFiles(Guid idFileDelete)
        {
            return Provider.ExecNoneQuery("DeleteFile",
                 new System.Data.SqlClient.SqlParameter("idFile", idFileDelete)
                 ) > 0 ? true : false;
        }
        public DataRow GetFileByIDDBFiles(Guid idFile)
        {
            return Provider.ExecuteDataRow("GetFile", new System.Data.SqlClient.SqlParameter("idFile", idFile));
        }
    }
}
