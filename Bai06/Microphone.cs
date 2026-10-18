/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
using System;

namespace Bai06
{
    //micro giảng dạy
    public class Microphone : TeachingDevice
    {
        public Microphone(string id, string name, int year, decimal price, int maxDays = 1)
            : base(id, name, year, price, maxDays)
        {
        }

        //tiền bảo trì 15%
        public override decimal CalculateAnnualMaintenanceCost()
        {
            return PurchasePrice * 0.15m;
        }
    }
}
