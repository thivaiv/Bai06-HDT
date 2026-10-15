/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
using System;

namespace Bai06
{
    //dieu khien may chieu
    public class ProjectorRemote : TeachingDevice
    {
        public string SupportedProjector { get; set; }

        public ProjectorRemote(string id, string name, int year, decimal price, string projector, int maxDays = 1)
            : base(id, name, year, price, maxDays)
        {
            SupportedProjector = projector;
        }

        //8% gia mua
        public override decimal CalculateAnnualMaintenanceCost()
        {
            return PurchasePrice * 0.08m;
        }

        public override string ToString()
        {
            return base.ToString() + " | May chieu: " + SupportedProjector;
        }
    }
}
