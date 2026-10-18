/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
using System;

namespace Bai06
{
    //điều khiển máy chiếu
    public class ProjectorRemote : TeachingDevice
    {
        public ProjectorRemote(string id, string name, int year, decimal price, int maxDays = 1)
            : base(id, name, year, price, maxDays)
        {
        }

        //tiền bảo trì 8%
        public override decimal CalculateAnnualMaintenanceCost()
        {
            return PurchasePrice * 0.08m;
        }
    }
}
