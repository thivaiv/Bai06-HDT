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

        public void AddDevice(TeachingDevice device, int borrowDays)
        {
            //chưa xử lý ngoại lệ
            DateTime dueDate = BorrowedDate.AddDays(borrowDays);
            Items.Add(new BorrowItem(device, BorrowedDate, dueDate));
        }

        public decimal ReturnDevice(string deviceId, DateTime returnedDate)
        {
            return 0;
        }

        public decimal CalculateTotalLateFee()
        {
            return 0;
        }
    }
}
