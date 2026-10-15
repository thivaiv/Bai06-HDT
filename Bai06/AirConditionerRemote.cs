/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
using System;

namespace Bai06
{
    //dieu khien dieu hoa
    public class AirConditionerRemote : TeachingDevice
    {
        public string Brand { get; set; }

        public AirConditionerRemote(string id, string name, int year, decimal price, string brand, int maxDays = 1)
            : base(id, name, year, price, maxDays)
        {
            Brand = brand;
        }

        //10% gia mua
        public override decimal CalculateAnnualMaintenanceCost()
        {
            return PurchasePrice * 0.10m;
        }

        public override string ToString()
        {
            return base.ToString() + " | Hang: " + Brand;
        }
    }
}
