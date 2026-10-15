/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
using System;

namespace Bai06
{
    //thiet bi giang day
    public abstract class TeachingDevice : Device
    {
        //so ngay cho muon toi da
        public int MaxBorrowDays { get; set; }

        public TeachingDevice(string id, string name, int year, decimal price, int maxDays)
            : base(id, name, year, price)
        {
            MaxBorrowDays = maxDays;
        }

        //chuyen sang da muon
        public void MarkAsBorrowed()
        {
            Status = DeviceStatus.Borrowed;
        }

        //chuyen sang san sang
        public void MarkAsAvailable()
        {
            Status = DeviceStatus.Available;
        }

        public override string ToString()
        {
            return base.ToString() + " | Toi da: " + MaxBorrowDays + " ngay";
        }
    }
}
