/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
using System;

namespace Bai06
{
    //ngoại lệ cơ sở
    public class BorrowingException : Exception
    {
        public BorrowingException(string message) : base(message)
        {
        }

        public BorrowingException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

    //máy chưa sẵn sàng
    public class DeviceUnavailableException : BorrowingException
    {
        public string DeviceId { get; }

        public DeviceStatus CurrentStatus { get; }

        public DeviceUnavailableException(string deviceId, DeviceStatus currentStatus) 
            : base("thiết bị " + deviceId + " : " + currentStatus)
        {
            DeviceId = deviceId;
            CurrentStatus = currentStatus;
        }
    }

    //mượn quá số lượng
    public class BorrowLimitExceededException : BorrowingException
    {
        public string BorrowerId { get; }

        public int MaximumDevices { get; }

        public BorrowLimitExceededException(string borrowerId, int maximumDevices) 
            : base("số lượng thiết bị " + borrowerId + " vượt quá giới hạn: " + maximumDevices)
        {
            BorrowerId = borrowerId;
            MaximumDevices = maximumDevices;
        }
    }

    //số ngày mượn ko hợp lệ
    public class InvalidBorrowPeriodException : BorrowingException
    {
        public string BorrowerId { get; }

        public int RequestedDays { get; }

        public int MaximumDays { get; }

        public InvalidBorrowPeriodException(string borrowerId, int requestedDays, int maximumDays) 
            : base("người mượn " + borrowerId + " muốn mượn " + requestedDays + " ngày, không hợp lệ, tối đa: " + maximumDays + " ngày")
        {
            BorrowerId = borrowerId;
            RequestedDays = requestedDays;
            MaximumDays = maximumDays;
        }
    }

    //trùng máy trong phiếu
    public class DuplicateDeviceException : BorrowingException
    {
        public string DeviceId { get; }

        public DuplicateDeviceException(string deviceId) 
            : base("thiết bị " + deviceId + " đã có trong phiếu mượn")
        {
            DeviceId = deviceId;
        }
    }

    //trả máy ko có trong phiếu
    public class DeviceNotInSlipException : BorrowingException
    {
        public string DeviceId { get; }

        public DeviceNotInSlipException(string deviceId) 
            : base("thiết bị " + deviceId + " không có trong phiếu mượn")
        {
            DeviceId = deviceId;
        }
    }

    //máy này đã trả rồi
    public class DeviceAlreadyReturnedException : BorrowingException
    {
        public string DeviceId { get; }

        public DeviceAlreadyReturnedException(string deviceId) 
            : base("thiết bị " + deviceId + " đã được trả")
        {
            DeviceId = deviceId;
        }
    }
}
