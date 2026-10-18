/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
using System;

namespace Bai06
{
    //điều khiển điều hòa
    public class AirConditionerRemote : TeachingDevice
    {
        public AirConditionerRemote(string id, string name, int year, decimal price, int maxDays = 1)
            : base(id, name, year, price, maxDays)
        {
        }

        
        public override decimal CalculateAnnualMaintenanceCost()
        {
            return PurchasePrice * 0.10m;
        }
    }
}
