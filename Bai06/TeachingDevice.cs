/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
using System;

namespace Bai06
{
    public class TeachingDevice : Device
    {
        public int MaxBorrowDays { get; set; }

        public TeachingDevice(string id, string name, int year, decimal price, int maxBorrowDays)
            : base(id, name, year, price)
        {
            MaxBorrowDays = maxBorrowDays;
        }

        public override decimal CalculateAnnualMaintenanceCost()
        {
            return PurchasePrice * 0.1m;
        }
    }
}
