/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
using System;

namespace Bai06
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== KIEM TRA THIET BI GIANG DAY ===");

            //1. khoi tao thiet bi
            AirConditionerRemote dh = new AirConditionerRemote("DH01", "Dieu khien Daikin phong 302", 2023, 250000m, "Daikin", 1);
            Microphone mic = new Microphone("MIC01", "Mic khong day Shure", 2022, 800000m, "Pin AA", 1);
            ProjectorRemote mc = new ProjectorRemote("MC01", "Dieu khien Sony phong D9", 2021, 400000m, "Sony VPL", 1);

            Console.WriteLine("\n1. Danh sach thiet bi khoi tao:");
            Console.WriteLine("- " + dh);
            Console.WriteLine("  * Phi bao tri 1 nam: " + dh.CalculateAnnualMaintenanceCost().ToString("N0") + "d");

            Console.WriteLine("- " + mic);
            Console.WriteLine("  * Phi bao tri 1 nam: " + mic.CalculateAnnualMaintenanceCost().ToString("N0") + "d");

            Console.WriteLine("- " + mc);
            Console.WriteLine("  * Phi bao tri 1 nam: " + mc.CalculateAnnualMaintenanceCost().ToString("N0") + "d");

            //2. kiem tra doi trang thai
            Console.WriteLine("\n2. Kiem tra chuyen trang thai thiet bi:");
            Console.WriteLine("- Trang thai ban dau: " + dh.Status);
            dh.MarkAsBorrowed();
            Console.WriteLine("- Sau khi muon: " + dh.Status);
            dh.MarkAsAvailable();
            Console.WriteLine("- Sau khi tra lai: " + dh.Status);

            //3. kiem tra bat loi
            Console.WriteLine("\n3. Kiem tra bat loi du lieu dau vao:");
            try
            {
                Console.Write("- Thu tao may co nam 2099: ");
                Microphone micLoi = new Microphone("M99", "Mic fake", 2099, 100000m, "Pin", 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi -> " + ex.Message);
            }

            try
            {
                Console.Write("- Thu tao may co gia -5000d: ");
                AirConditionerRemote dhLoi = new AirConditionerRemote("DH99", "Gia am", 2020, -5000m, "LG", 1);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi -> " + ex.Message);
            }

            Console.WriteLine("\n===================================");
        }
    }
}