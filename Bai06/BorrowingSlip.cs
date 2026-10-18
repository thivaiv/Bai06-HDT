/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
using System;
using System.Collections.Generic;
using System.Data;

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




        ////////
        public void AddDevice(TeachingDevice device, int borrowDays)
        {
            // check null
            if (device == null)
            {
                throw new Exception("thiet bi khong dc null");
            }
            //check số ngày mượn
            if (borrowDays <= 0 || borrowDays > device.MaxBorrowDays)
            {
                throw new InvalidBorrowPeriodException(device.Id, borrowDays, device.MaxBorrowDays);
            }

            //nếu đã tồn tại tiết bị trong phiếu
            foreach (var i in Items)
            {
                if (i.Device.Id == device.Id)
                {
                    throw new DuplicateDeviceException(device.Id);
                }
            }

            //khi vượt giới hạn tbi
            if (Items.Count >= Borrower.GetMaximumDevices())
            {
                throw new BorrowLimitExceededException(Borrower.BorrowerId , Borrower.GetMaximumDevices());
            }

            //check available
            if (device.Status != DeviceStatus.Available)
            {
                throw new DeviceUnavailableException(device.Id , device.Status);
            }

            ////
            DateTime dueDate = BorrowedDate.AddDays(borrowDays);

            device.MarkAsBorrowed();
            var item = new BorrowItem(device, BorrowedDate, dueDate);
            Items.Add(item);
            ////
        }




        ////////
        public decimal ReturnDevice(string deviceId, DateTime returnedDate)
        {

            //check ID
            if (deviceId == null || deviceId == "")
            {
                throw new Exception("deviceId ko hop le");
            }

            //tìm ID trong phiếu
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

            //nếu đã trả
            if(found.IsReturned)
            {
                throw new DeviceAlreadyReturnedException(deviceId);
            }

            //so sánh ngày trả và ngày mượn
            if(returnedDate < found.BorrowedDate)
            {
                throw new BorrowingException("ngay tra som hon ngay muon");
            }

            //confirm trả
            found.Return(returnedDate);
            found.Device.MarkAsAvailable();


            //tính phí trễ hạn
            decimal tienphat = 0;
            if (returnedDate > found.DueDate)
            {
                
                int late = (returnedDate - found.DueDate).Days;
                tienphat = late * 50000m; //50k một ngày
            }


            return tienphat;
        }


        // Tính tổng tiền phạt trễ hạn 
        public decimal CalculateTotalLateFee()
        {
            decimal totalFee = 0;
            foreach (var item in Items)
            {
                if (item.IsReturned && item.ReturnedDate > item.DueDate)
                {
                    int lateDays = (item.ReturnedDate.Value - item.DueDate).Days;
                    totalFee += lateDays * 50000m; // 50k một ngày
                }
            }
            return totalFee;
        }
    }
}
