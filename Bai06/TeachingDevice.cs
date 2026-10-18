/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
using System;

namespace Bai06
{
    //đồ mượn giảng dạy
    public abstract class TeachingDevice : Device
    {
        //mượn tối đa mấy ngày
        public int MaxBorrowDays { get; set; }

        public TeachingDevice(string id, string name, int year, decimal price, int maxDays)
            : base(id, name, year, price)
        {
            MaxBorrowDays = maxDays;
        }

        //đổi sang đã mượn
        public void MarkAsBorrowed()
        {
            Status = DeviceStatus.Borrowed;
        }

        //đổi về sẵn sàng
        public void MarkAsAvailable()
        {
            Status = DeviceStatus.Available;
        }

        public override string ToString()
        {
            return Id + " - " + Name + " | Tối đa: " + MaxBorrowDays + " ngày | TT: " + Status;
        }
    }
}
