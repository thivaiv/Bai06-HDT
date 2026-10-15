/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
using System;

namespace Bai06
{
    //trang thai
    public enum DeviceStatus
    {
        Available,
        Borrowed,
        UnderMaintenance
    }

    public abstract class Device
    {
        //ma chi set 1 lan luc tao
        public string Id { get; }

        public string Name { get; set; }

        int namSuDung;
        public int YearPutIntoUse
        {
            get { return namSuDung; }
            set
            {
                //check nam
                if (value > DateTime.Now.Year)
                {
                    throw new Exception("nam ko hop le.");
                }
                namSuDung = value;
            }
        }

        decimal giaMua;
        public decimal PurchasePrice
        {
            get { return giaMua; }
            set
            {
                //check gia
                if (value <= 0)
                {
                    throw new Exception("gia phai > 0.");
                }
                giaMua = value;
            }
        }

        public DeviceStatus Status { get; set; }

        public Device(string id, string name, int year, decimal price)
        {
            //check ma rong
            if (id == null || id == "")
            {
                throw new Exception("ma ko dc de trong.");
            }

            Id = id;
            Name = name;
            YearPutIntoUse = year;
            PurchasePrice = price;
            Status = DeviceStatus.Available; //mac dinh available
        }

        //tinh tien bao tri
        public abstract decimal CalculateAnnualMaintenanceCost();

        public override string ToString()
        {
            return "[" + GetType().Name + "] " + Id + " - " + Name + " | Gia: " + PurchasePrice.ToString("N0") + "d | TT: " + Status;
        }
    }
}
