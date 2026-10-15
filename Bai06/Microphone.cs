/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
using System;

namespace Bai06
{
    //micro giang day
    public class Microphone : TeachingDevice
    {
        public string BatteryType { get; set; } //loai pin

        public Microphone(string id, string name, int year, decimal price, string battery, int maxDays = 1)
            : base(id, name, year, price, maxDays)
        {
            BatteryType = battery;
        }

        //15% gia mua vi hay thay pin
        public override decimal CalculateAnnualMaintenanceCost()
        {
            return PurchasePrice * 0.15m;
        }

        public override string ToString()
        {
            return base.ToString() + " | Pin: " + BatteryType;
        }
    }
}
