/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
using System;

namespace Bai06
{
    public enum DeviceStatus
    {
        Available,
        Borrowed,
        UnderMaintenance
    }

    public abstract class Device
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int YearUse { get; set; }

        public decimal PurchasePrice { get; set; }

        public DeviceStatus Status { get; set; }

        public Device(string id, string name, int year, decimal price)
        {
            Id = id;
            Name = name;
            YearUse = year;
            PurchasePrice = price;
            Status = DeviceStatus.Available;
        }

        public abstract decimal CalculateAnnualMaintenanceCost();

        public override string ToString()
        {
            return Id + " - " + Name;
        }
    }
}
