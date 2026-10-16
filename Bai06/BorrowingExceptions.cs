/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
using System;

namespace Bai06
{
    //base expception
    public class BorrowingException : Exception
    {
        public BorrowingException(string message) : base(message)
        {
        }
        public BorrowingException(string message,Exception innerException)
            : base(message, innerException)
        {
        }
    }

    // thiết bị không ở trạng thái Available
    public class DeviceUnavailableException : BorrowingException
    {

        public string DeviceId { get; }
        public DeviceStatus CurrentStatus { get; }

        public DeviceUnavailableException(string deviceId, DeviceStatus currentStatus) 
            : base("Thiet bi " + deviceId + " : " + currentStatus)
        {
            DeviceId = deviceId;
            CurrentStatus = currentStatus;
        }
    }


    // người mượn đã đạt số thiết bị tối đa
    public class BorrowLimitExceededException : BorrowingException
    {
        public string BorrowerId { get; }
        public int MaximumDevices { get; }

        public BorrowLimitExceededException(string borrowerId, int maximumDevices) : base("So luong thiet bi" + borrowerId + " vuot qua gioi han: " + maximumDevices)
        {
            BorrowerId = borrowerId;
            MaximumDevices = maximumDevices;
        }
    }


    //Số ngày mượn không dương. 
    public class InvalidBorrowPeriodException : BorrowingException
    {
        public string BorrowerId { get; }
        public int RequestedDays { get; }
        public int MaximumDays { get; }

        public InvalidBorrowPeriodException(string borrowerId, int requestedDays, int maximumDays) 
            : base("nguoi muon " + borrowerId + " muon muon " + requestedDays + " ngay, khong hop le, toi da: " + maximumDays + " ngay")
        {
            BorrowerId = borrowerId;
            RequestedDays = requestedDays;
            MaximumDays = maximumDays;
        }
    }


    //cùng một thiết bị đã tồn tại trong phiếu. 
    public class DuplicateDeviceException: BorrowingException
    {
        public string DeviceId { get; }
        public DuplicateDeviceException(string deviceId) : base("Thiet bi " + deviceId + " da co trong phieu muon")
        {
            DeviceId = deviceId;
        }
    }


    //yêu cầu trả một thiết bị không thuộc phiếu
    public class DeviceNotInSlipException: BorrowingException
    {
        public string DeviceId { get; }
        public DeviceNotInSlipException(string deviceId) : base("Thiet bi " + deviceId + " khong co trong phieu muon")
        {
            DeviceId = deviceId;
        }
    }


    //thiết bị trong phiếu đã được trả trước đó
    public class DeviceAlreadyReturnedException : BorrowingException
    {
        public string DeviceId { get; }
        public DeviceAlreadyReturnedException(string deviceId) : base("Thiet bi " + deviceId + " da duoc tra")
        {
            DeviceId = deviceId;
        }
    }




}
