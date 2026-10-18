/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
using System;
using System.Collections.Generic;

namespace Bai06
{
    public class BorrowingSlip
    {
        public string SlipId { get; set; }

        public IBorrower Borrower { get; set; }

        public string TeachingRoom { get; set; }

        public DateTime BorrowedDate { get; set; }

        public List<BorrowItem> Items { get; set; }

        public BorrowingSlip(string slipId, IBorrower borrower, string teachingRoom)
        {
            SlipId = slipId;
            Borrower = borrower;
            TeachingRoom = teachingRoom;
            BorrowedDate = DateTime.Now;
            Items = new List<BorrowItem>();
        }

        //thêm đồ vào phiếu
        public void AddDevice(TeachingDevice device, int borrowDays)
        {
            //check null
            if (device == null)
            {
                throw new Exception("thiết bị không được null.");
            }

            //check ngày mượn
            if (borrowDays <= 0 || borrowDays > device.MaxBorrowDays)
            {
                throw new InvalidBorrowPeriodException(device.Id, borrowDays, device.MaxBorrowDays);
            }

            //check trùng đồ trong phiếu
            foreach (var i in Items)
            {
                if (i.Device.Id == device.Id)
                {
                    throw new DuplicateDeviceException(device.Id);
                }
            }

            //check mượn quá số lượng
            if (Items.Count >= Borrower.GetMaximumDevices())
            {
                throw new BorrowLimitExceededException(Borrower.BorrowerId, Borrower.GetMaximumDevices());
            }

            //check máy có sẵn sàng ko
            if (device.Status != DeviceStatus.Available)
            {
                throw new DeviceUnavailableException(device.Id, device.Status);
            }

            //thêm vào phiếu và đổi trạng thái máy
            DateTime dueDate = BorrowedDate.AddDays(borrowDays);
            device.MarkAsBorrowed();
            var item = new BorrowItem(device, BorrowedDate, dueDate);
            Items.Add(item);
        }

        //trả máy
        public decimal ReturnDevice(string deviceId, DateTime returnedDate)
        {
            //check mã
            if (deviceId == null || deviceId == "")
            {
                throw new Exception("mã thiết bị không hợp lệ.");
            }

            //tìm máy trong phiếu
            BorrowItem found = null;
            foreach (var item in Items)
            {
                if (item.Device.Id == deviceId)
                {
                    found = item;
                    break;
                }
            }

            if (found == null)
            {
                throw new DeviceNotInSlipException(deviceId);
            }

            //check đã trả trước đó chưa
            if (found.IsReturned)
            {
                throw new DeviceAlreadyReturnedException(deviceId);
            }

            //check ngày trả trước ngày mượn
            if (returnedDate < found.BorrowedDate)
            {
                throw new BorrowingException("ngày trả sớm hơn ngày mượn.");
            }

            //trả máy và set lại sẵn sàng
            found.Return(returnedDate);
            found.Device.MarkAsAvailable();

            //tính tiền phạt nếu trễ hạn
            decimal tienphat = 0;
            if (returnedDate > found.DueDate)
            {
                int late = (returnedDate - found.DueDate).Days;
                tienphat = late * 50000m; //50k một ngày trễ
            }

            return tienphat;
        }

        //tổng tiền phạt cả phiếu
        public decimal CalculateTotalLateFee()
        {
            decimal totalFee = 0;
            foreach (var item in Items)
            {
                if (item.IsReturned && item.ReturnedDate > item.DueDate)
                {
                    int lateDays = (item.ReturnedDate.Value - item.DueDate).Days;
                    totalFee += lateDays * 50000m; //50k một ngày trễ
                }
            }
            return totalFee;
        }
    }
}
