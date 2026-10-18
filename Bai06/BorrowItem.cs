/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
using System;

namespace Bai06
{
    //1 món đồ mượn trong phiếu
    public class BorrowItem
    {
        public TeachingDevice Device { get; set; }

        public DateTime BorrowedDate { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime? ReturnedDate { get; set; }

        public bool IsReturned
        {
            get { return ReturnedDate != null; }
        }

        public BorrowItem(TeachingDevice device, DateTime borrowedDate, DateTime dueDate)
        {
            Device = device;
            BorrowedDate = borrowedDate;
            DueDate = dueDate;
            ReturnedDate = null;
        }

        //lưu ngày trả
        public void Return(DateTime returnedDate)
        {
            ReturnedDate = returnedDate;
        }
    }
}
