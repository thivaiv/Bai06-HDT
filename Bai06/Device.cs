/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
using System;

namespace Bai06
{
    //trạng thái máy
    public enum DeviceStatus
    {
        Available,
        Borrowed,
        UnderMaintenance
    }

    public abstract class Device
    {
        //mã máy, gán 1 lần lúc tạo
        public string Id { get; }

        public string Name { get; set; }

        int namSuDung;
        public int YearPutIntoUse
        {
            get { return namSuDung; }
            set
            {
                //check năm
                if (value > DateTime.Now.Year)
                {
                    throw new Exception("năm không hợp lệ.");
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
                //check giá
                if (value <= 0)
                {
                    throw new Exception("giá phải lớn hơn 0.");
                }
                giaMua = value;
            }
        }

        public DeviceStatus Status { get; set; }

        public Device(string id, string name, int year, decimal price)
        {
            //check mã rỗng
            if (id == null || id == "")
            {
                throw new Exception("mã không được để trống.");
            }

            Id = id;
            Name = name;
            YearPutIntoUse = year;
            PurchasePrice = price;
            Status = DeviceStatus.Available; //mặc định sẵn sàng
        }

        //tiền bảo trì trên năm
        public abstract decimal CalculateAnnualMaintenanceCost();

        public override string ToString()
        {
            return "[" + GetType().Name + "] " + Id + " - " + Name + " | Giá: " + PurchasePrice.ToString("N0") + "đ | TT: " + Status;
        }
    }
}
