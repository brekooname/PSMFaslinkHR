using AttMachineCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace AttMachineCore
{
    public class AttMachineTools
    {
        zkemkeeper.CZKEMClass axCZKEM1;
        public int iMachineNumber = 1;
        private bool isConnected = false;
        public AttMachineTools()
        {
            axCZKEM1 = new zkemkeeper.CZKEMClass();
        }
        #region Common operation with AMC
        /// <summary>
        /// Ping AMC
        /// </summary>
        /// <param name="IP">Địa chỉ AMC</param>
        /// <param name="miliSecond"> Timeout</param>
        /// <returns>bool</returns>
        public bool PingAddress(string IP, int miliSecond)
        {
            Ping ping = new Ping();
            if (ping.Send(IP, miliSecond).Status == IPStatus.Success)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Connect AMC bằng IP
        /// </summary>
        /// <param name="IP">IP của AMC</param>
        /// <param name="Port">Port của AMC</param>
        /// <returns>bool</returns>
        public bool Connect_Net(string IP, int Port)
        {
            if (IP.Trim() == "" || Port == 0 || !PingAddress(IP, Port))
            {
                isConnected = false;
            }
            isConnected = axCZKEM1.Connect_Net(IP, Port);
            return isConnected;
        }
        /// <summary>
        /// Lấy dữ liệu quẹt thẻ ở AMC
        /// </summary>
        /// <param name="startDate">Ngày bắt đầu</param>
        /// <param name="endDate">Ngày kết thúc</param>
        /// <returns>ICollection<InOutInfor></returns>
        public ICollection<InOutInfor> GetAttMachine(DateTime startDate, DateTime endDate)
        {
            startDate = startDate.Date;
            endDate = endDate.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            int idwVerifyMode = 0;
            string sdwEnrollNumber = "";
            int idwInOutMode = 0;
            int idwYear = 0;
            int idwMonth = 0;
            int idwDay = 0;
            int idwHour = 0;
            int idwMinute = 0;
            int idwSecond = 0;
            int idwWorkcode = 0;
            axCZKEM1.EnableDevice(iMachineNumber, false);//disable the device
            ICollection<InOutInfor> _lInOut = new List<InOutInfor>();
            //if (axCZKEM1.ReadGeneralLogData(iMachineNumber))//read all the attendance records to the memory
            //{
            //    // Đây là hàm lấy dữ liệu quẹt thẻ SSR_GetGeneralLogData.
            //    while (axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, out sdwEnrollNumber, out idwVerifyMode,
            //               out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour, out idwMinute, out idwSecond, ref idwWorkcode))//get records from the memory
            //    {
            //        DateTime tgQuet = new DateTime(idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond);
            //        if (startDate <= tgQuet && tgQuet <= endDate)
            //        {
            //            _lInOut.Add(new InOutInfor
            //            {
            //                EnrollNumber = sdwEnrollNumber,
            //                DateTimePunch = tgQuet,
            //                DatePunch = tgQuet.Date,
            //                TimePunch = tgQuet.TimeOfDay
            //            });
            //        }
            //    }
            //    axCZKEM1.EnableDevice(iMachineNumber, true);// Enable máy chấm công lên
            //}
            // Đây là hàm lấy dữ liệu quẹt thẻ SSR_GetGeneralLogData.
            while (axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, out sdwEnrollNumber, out idwVerifyMode,
                       out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour, out idwMinute, out idwSecond, ref idwWorkcode))//get records from the memory
            {
                DateTime tgQuet = new DateTime(idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond);
                if (startDate <= tgQuet && tgQuet <= endDate)
                {
                    _lInOut.Add(new InOutInfor
                    {
                        EnrollNumber = sdwEnrollNumber,
                        DateTimePunch = tgQuet,
                        DatePunch = tgQuet.Date,
                        TimePunch = tgQuet.TimeOfDay
                    });
                }
            }
            axCZKEM1.EnableDevice(iMachineNumber, true);// Enable máy chấm công lên
            return _lInOut;
        }
        /// <summary>
        /// Lấy thông tin nhân viên trong AMC (không có vân tay)
        /// </summary>
        /// <returns>ICollection<UserInfor></returns>
        public ICollection<UserInfor> getAllUserInfor()
        {
            ICollection<UserInfor> _lUser = new List<UserInfor>();
            if (isConnected)
            {
                string sdwEnrollNumber = "", cardNumber = "";
                string sName = "";
                string sPassword = "";
                int iPrivilege = 0;
                bool bEnabled = false;
                axCZKEM1.EnableDevice(iMachineNumber, false);//disable the device
                if (axCZKEM1.ReadAllUserID(iMachineNumber))//read all the attendance records to the memory
                {
                    // Đây là hàm lấy dữ liệu quẹt thẻ SSR_GetGeneralLogData.
                    while (axCZKEM1.SSR_GetAllUserInfo(iMachineNumber, out sdwEnrollNumber, out sName,
                               out sPassword, out iPrivilege, out bEnabled))//get records from the memory
                    {
                        axCZKEM1.GetStrCardNumber(out cardNumber);
                        _lUser.Add(new UserInfor()
                        {
                            EnrollNumber = sdwEnrollNumber,
                            Name = sName,
                            Password = sPassword,
                            Privilege = iPrivilege,
                            Enabled = bEnabled,
                            CardNumber = cardNumber
                        });
                    }
                    axCZKEM1.EnableDevice(iMachineNumber, true);// Enable máy chấm công lên
                }
                return _lUser;
            }
            else
                return _lUser;
        }
        /// <summary>
        ///  Lấy thông tin nhân viên trong AMC Màu (bao gồm vân tay (string) )
        /// </summary>
        /// <returns></returns>
        public ICollection<UserInfor> GetAllUserTemp_ColorDivice()
        {
            string sdwEnrollNumber = string.Empty, sName = string.Empty, sPassword = string.Empty, sTmpData = string.Empty;
            int iPrivilege = 0, iTmpLength = 0, iFlag = 0, idwFingerIndex;
            string card = "";
            bool bEnabled = false;

            ICollection<UserInfor> lstFPTemplates = new List<UserInfor>();

            //axCZKEM1.ReadAllUserID(iMachineNumber);
            //axCZKEM1.ReadAllTemplate(iMachineNumber);

            while (axCZKEM1.SSR_GetAllUserInfo(iMachineNumber, out sdwEnrollNumber, out sName, out sPassword, out iPrivilege, out bEnabled))
            {
                axCZKEM1.GetStrCardNumber(out card);
                UserInfor fpInfo = new UserInfor();
                fpInfo.EnrollNumber = sdwEnrollNumber;
                fpInfo.Name = sName;
                fpInfo.Privilege = iPrivilege;
                fpInfo.Password = sPassword;
                fpInfo.Enabled = bEnabled;
                fpInfo.CardNumber = card;
                for (idwFingerIndex = 0; idwFingerIndex < 10; idwFingerIndex++)
                {
                    if (axCZKEM1.GetUserTmpExStr(iMachineNumber, sdwEnrollNumber, idwFingerIndex, out iFlag, out sTmpData, out iTmpLength))
                    {
                        fpInfo._lFinger.Add(new Finger()
                        {
                            FingerStr = sTmpData,
                            FingerIdx = idwFingerIndex,
                            FingerLength = iTmpLength
                        });
                    }
                }
                lstFPTemplates.Add(fpInfo);

            }
            return lstFPTemplates;
        }
        /// <summary>
        ///  Lấy thông tin nhân viên trong AMC Màu (bao gồm vân tay (Byte) )
        /// </summary>
        /// <returns></returns>
        public ICollection<UserInfor> GetAllUserExTemp_ColorDivice()
        {
            string sdwEnrollNumber = string.Empty, sName = string.Empty, sPassword = string.Empty;
            byte sTmpData;
            int iPrivilege = 0, iTmpLength = 0, iFlag = 0, idwFingerIndex;
            string card = "";
            bool bEnabled = false;

            ICollection<UserInfor> lstFPTemplates = new List<UserInfor>();

            axCZKEM1.ReadAllUserID(iMachineNumber);
            axCZKEM1.ReadAllTemplate(iMachineNumber);

            while (axCZKEM1.SSR_GetAllUserInfo(iMachineNumber, out sdwEnrollNumber, out sName, out sPassword, out iPrivilege, out bEnabled))
            {
                axCZKEM1.GetStrCardNumber(out card);
                UserInfor fpInfo = new UserInfor();
                fpInfo.EnrollNumber = sdwEnrollNumber;
                fpInfo.Name = sName;
                fpInfo.Privilege = iPrivilege;
                fpInfo.Password = sPassword;
                fpInfo.Enabled = bEnabled;
                fpInfo.CardNumber = card;
                for (idwFingerIndex = 0; idwFingerIndex < 10; idwFingerIndex++)
                {
                    if (axCZKEM1.GetUserTmpEx(iMachineNumber, sdwEnrollNumber, idwFingerIndex, out iFlag, out sTmpData, out iTmpLength))
                    {
                        fpInfo._lFinger.Add(new Finger()
                        {
                            FingerData = sTmpData,
                            FingerIdx = idwFingerIndex,
                            FingerLength = iTmpLength
                        });
                    }
                }
                lstFPTemplates.Add(fpInfo);

            }
            return lstFPTemplates;
        }
        /// <summary>
        /// Lấy thông tin nhân viên trong AMC Trắng đen (bao gồm vân tay)
        /// </summary>
        /// <param name="objZkeeper"></param>
        /// <param name="machineNumber"></param>
        /// <returns></returns>
        public ICollection<UserInfor> GetAllUserTemp_WhiteBlack()
        {
            int sdwEnrollNumber = 0; string sName = "", sPassword = "", sTmpData = string.Empty;
            int iPrivilege = 0, iTmpLength = 0, iFlag = 0, idwFingerIndex;
            bool bEnabled = false;
            string card = "";
            ICollection<UserInfor> lstFPTemplates = new List<UserInfor>();

            axCZKEM1.ReadAllUserID(iMachineNumber);
            axCZKEM1.ReadAllTemplate(iMachineNumber);

            while (axCZKEM1.GetAllUserInfo(iMachineNumber, ref sdwEnrollNumber, ref sName, ref sPassword, ref iPrivilege, ref bEnabled))
            {
                axCZKEM1.GetStrCardNumber(out card);
                UserInfor fpInfo = new UserInfor();
                fpInfo.EnrollNumber = sdwEnrollNumber.ToString();
                fpInfo.Name = sName;
                fpInfo.Privilege = iPrivilege;
                fpInfo.Password = sPassword;
                fpInfo.Enabled = bEnabled;
                fpInfo.CardNumber = card;

                for (idwFingerIndex = 0; idwFingerIndex < 10; idwFingerIndex++)
                {
                    if (axCZKEM1.GetUserTmpExStr(iMachineNumber, sdwEnrollNumber.ToString(), idwFingerIndex, out iFlag, out sTmpData, out iTmpLength))
                    {
                        fpInfo._lFinger.Add(new Finger()
                        {
                            FingerStr = sTmpData,
                            FingerIdx = idwFingerIndex,
                            FingerLength = iTmpLength
                        });
                    }
                }
                lstFPTemplates.Add(fpInfo);
            }
            return lstFPTemplates;
        }
        /// <summary>
        /// Set vân tay cho user String
        /// </summary>
        /// <param name="sdwEnrollNumber">Mã chấm công của nhân viên</param>
        /// <param name="FingerIdx">số thứ tự ngón tay 0 -> 9</param>
        /// <param name="strTmpData">Chuỗi vân tay</param>
        /// <returns></returns>
        public bool setUserTempStr(string sdwEnrollNumber, int FingerIdx, string strTmpData)
        {
            bool isSuccess = false;
            if (!isConnected)
            {
                return false;
            }
            axCZKEM1.EnableDevice(iMachineNumber, false);
            isSuccess = axCZKEM1.SSR_SetUserTmpStr(iMachineNumber, sdwEnrollNumber, FingerIdx, strTmpData);
            axCZKEM1.EnableDevice(iMachineNumber, true);
            return isSuccess;
        }
        /// <summary>
        /// Set vân tay cho user Byte
        /// </summary>
        /// <param name="sdwEnrollNumber">Mã chấm công của nhân viên</param>
        /// <param name="FingerIdx">số thứ tự ngón tay 0 -> 9</param>
        /// <param name="ByteTmpData">Chuỗi vân tay</param>
        /// <returns></returns>
        public bool setUserTempByte(string sdwEnrollNumber, int FingerIdx, byte ByteTmpData)
        {
            bool isSuccess = false;
            if (!isConnected)
            {
                return false;
            }
            axCZKEM1.EnableDevice(iMachineNumber, false);
            isSuccess = axCZKEM1.SSR_SetUserTmp(iMachineNumber, sdwEnrollNumber, FingerIdx, ByteTmpData);
            axCZKEM1.EnableDevice(iMachineNumber, true);
            return isSuccess;
        }
        /// <summary>
        /// Set vân tay cho user bằng List Finger String
        /// </summary>
        /// <param name="sdwEnrollNumber">Mã chấm công của nhân viên</param>
        /// <param name="_lFinger">List vân tay</param>
        /// <returns></returns>
        public bool setUserTempStr_byLisFinger(string sdwEnrollNumber, ICollection<Finger> _lFinger)
        {
            _lFinger = _lFinger.ToList();
            bool isSuccess = false;
            if (!isConnected)
            {
                return false;
            }
            axCZKEM1.EnableDevice(iMachineNumber, false);
            isSuccess = true;
            foreach (var item in _lFinger)
            {
                if (!axCZKEM1.SetUserTmpExStr(iMachineNumber, sdwEnrollNumber, item.FingerIdx, 1, item.FingerStr))
                {
                    isSuccess = false;
                    int idwErrorCode = 0;
                    axCZKEM1.GetLastError(ref idwErrorCode);
                    var a = idwErrorCode;
                }
            }

            axCZKEM1.EnableDevice(iMachineNumber, true);
            return isSuccess;
        }
        /// <summary>
        /// Set vân tay cho user bằng List Finger Byte
        /// </summary>
        /// <param name="sdwEnrollNumber">Mã chấm công của nhân viên</param>
        /// <param name="_lFinger">List vân tay</param>
        /// <returns></returns>
        public bool setUserTempByte_byLisFinger(string sdwEnrollNumber, ICollection<Finger> _lFinger)
        {
            _lFinger = _lFinger.ToList();
            bool isSuccess = false;
            if (!isConnected)
            {
                return false;
            }
            axCZKEM1.EnableDevice(iMachineNumber, false);
            isSuccess = true;
            foreach (var item in _lFinger)
            {
                if (!axCZKEM1.SSR_SetUserTmp(iMachineNumber, sdwEnrollNumber, item.FingerIdx, item.FingerData))
                {
                    isSuccess = false;
                }
            }

            axCZKEM1.EnableDevice(iMachineNumber, true);
            return isSuccess;
        }
        public bool SetCardNumber(string sCardnumber, string sdwEnrollNumber, string sName, string sPassword, int iPrivilege, bool bEnabled)
        {
            bool isSuccess = false;
            if (isConnected)
            {
                axCZKEM1.EnableDevice(iMachineNumber, false);
                axCZKEM1.SetStrCardNumber(sCardnumber);//Before you using function SetUserInfo,set the card number to make sure you can upload it to the device
                if (axCZKEM1.SSR_SetUserInfo(iMachineNumber, sdwEnrollNumber, sName, sPassword, iPrivilege, bEnabled))//upload the user's information(card number included)
                {
                    axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
                    isSuccess = true;
                }
                else
                {
                    isSuccess = true;
                }
                axCZKEM1.EnableDevice(iMachineNumber, true);
            }
            else
                isSuccess = false;
            return isSuccess;
        }
        public bool DeleteUser(string sdwEnrollNumber)
        {
            bool isSuccess = false;
            if (isConnected)
            {
                axCZKEM1.EnableDevice(iMachineNumber, false);
                //12: device deletes the user (include all fingerprints, cardnumber, password and password of user).
                isSuccess = axCZKEM1.SSR_DeleteEnrollDataExt(iMachineNumber, sdwEnrollNumber, 12);
                axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
                axCZKEM1.EnableDevice(iMachineNumber, true);
            }
            else
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        public bool EnableUser(string sdwEnrollNumber, bool isEnabled)
        {
            bool isSuccess = false;
            if (!isConnected)
            {
                return false;
            }
            axCZKEM1.EnableDevice(iMachineNumber, false);
            if (axCZKEM1.SSR_EnableUser(iMachineNumber, sdwEnrollNumber, isEnabled))
            {
                isSuccess = true;
            }
            else
            {
                isSuccess = false;
            }
            axCZKEM1.RefreshData(iMachineNumber);
            axCZKEM1.EnableDevice(iMachineNumber, true);
            return isSuccess;
        }
        #endregion
        #region Chỉnh sửa thông số thiết bị
        /// <summary>
        /// Set ngày giờ cho AMC
        /// </summary>
        /// <param name="DateTimeOfDevice">thời gian cần set cho AMC</param>
        /// <returns></returns>
        public bool SetDeviceTime(DateTime DateTimeOfDevice)
        {
            bool isSuccess = false;
            if (isConnected)
            {
                axCZKEM1.EnableDevice(iMachineNumber, false);
                if (axCZKEM1.SetDeviceTime2(iMachineNumber, DateTimeOfDevice.Year, DateTimeOfDevice.Month, DateTimeOfDevice.Day, DateTimeOfDevice.Hour, DateTimeOfDevice.Minute, DateTimeOfDevice.Second))
                {
                    isSuccess = true;
                }
            }
            else
            {
                isSuccess = false;
            }
            axCZKEM1.EnableDevice(iMachineNumber, true);
            return isSuccess;
        }
        /// <summary>
        /// Restore tất cả data AMC BW từ file ...
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool RestoreData_BW(string path)
        {
            bool isSuccess = false;
            if (isConnected)
            {
                axCZKEM1.SaveTheDataToFile(iMachineNumber, path, 1);
            }
            else
            {
                isSuccess = false;
            }
            axCZKEM1.EnableDevice(iMachineNumber, true);
            return isSuccess;
        }
        /// <summary>
        /// Lưu tất cả data AMC vào file ... 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool SaveData_BW(string path)
        {
            bool isSuccess = false;
            if (isConnected)
            {
                isSuccess = axCZKEM1.SaveTheDataToFile(iMachineNumber, path, 1);
            }
            else
            {
                isSuccess = false;
            }
            axCZKEM1.EnableDevice(iMachineNumber, true);
            return isSuccess;
        }
        /// <summary>
        /// Xóa data operation của AMC BW
        /// </summary>
        /// <returns></returns>
        public bool ClearSLog()
        {
            bool isSuccess = false;
            if (isConnected)
            {
                axCZKEM1.ClearSLog(iMachineNumber);
            }
            else
            {
                isSuccess = false;
            }
            axCZKEM1.EnableDevice(iMachineNumber, true);
            return isSuccess;
        }
        /// <summary>
        /// Xóa dữ liệu quẹt thẻ của AMC
        /// </summary>
        /// <returns></returns>
        public bool ClearGLog()
        {
            bool isSuccess = false;
            if (isConnected)
            {
                axCZKEM1.ClearGLog(iMachineNumber);
            }
            else
            {
                isSuccess = false;
            }
            axCZKEM1.EnableDevice(iMachineNumber, true);
            return isSuccess;
        }
        /// <summary>
        /// Restart AMC
        /// </summary>
        /// <returns></returns>
        public bool RestartDevice()
        {
            bool isSuccess = false;
            if (!isConnected)
            {
                return false;
            }
            isSuccess = axCZKEM1.RestartDevice(iMachineNumber);
            return isSuccess;
        }
        /// <summary>
        /// Clear Admin trên AMC
        /// </summary>
        /// <returns></returns>
        public bool ClearAdministrator()
        {
            bool isSuccess = false;
            if (!isConnected)
            {
                return false;
            }
            axCZKEM1.EnableDevice(iMachineNumber, false);
            isSuccess = axCZKEM1.ClearAdministrators(iMachineNumber);
            axCZKEM1.RefreshData(iMachineNumber);
            axCZKEM1.EnableDevice(iMachineNumber, true);
            return isSuccess;
        }
        /// <summary>
        /// Lấy thời gian của AMC
        /// </summary>
        /// <returns>DateTime?</returns>
        public DateTime? GetDeviceTime()
        {
            DateTime? d = null;
            int day = 0, month = 0, year = 0, hour = 0, minute = 0, second = 0;
            if (!isConnected)
            {
                return null;
            }
            axCZKEM1.EnableDevice(iMachineNumber, false);
            if (axCZKEM1.GetDeviceTime(iMachineNumber, year, month, day, hour, minute, second))
            {
                d = new DateTime(year, month, day, hour, minute, hour);
            }
            else
                return null;
            axCZKEM1.RefreshData(iMachineNumber);
            axCZKEM1.EnableDevice(iMachineNumber, true);
            return d;
        }
        //public string GetDeviceInfo()
        //{
        //    if (!isConnected)
        //    {
        //        return null;
        //    }
        //    axCZKEM1.EnableDevice(iMachineNumber, false);
        //    if (axCZKEM1.GetDeviceInfo(iMachineNumber, year, month, day, hour, minute, second))
        //    {
        //        d = new DateTime(year, month, day, hour, minute, hour);
        //    }
        //    else
        //        return null;
        //    axCZKEM1.RefreshData(iMachineNumber);
        //    axCZKEM1.EnableDevice(iMachineNumber, true);
        //    return d;
        //}

        public bool ClearDataUserInfo()
        {
            bool isSuccess = false;
            if (!isConnected)
            {
                return false;
            }
            int iDataFlag = 5;
            axCZKEM1.EnableDevice(iMachineNumber, false);
            isSuccess = axCZKEM1.ClearData(iMachineNumber, iDataFlag);
            axCZKEM1.RefreshData(iMachineNumber);//the data in the device should be refreshed
            axCZKEM1.EnableDevice(iMachineNumber, true);
            return isSuccess;
        }


        #endregion
    }
}
