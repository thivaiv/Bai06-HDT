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

            Console.WriteLine("==========================================================");
            Console.WriteLine("                          TEST                            ");
            Console.WriteLine("==========================================================");

            // ==========================================================
            // phần 1: mượn trả chuẩn
            // ==========================================================
            Console.WriteLine("\n=== 1. MƯỢN TRẢ CHUẨN ===\n");

            //tạo 1 giảng viên
            Lecturer gvNam = new Lecturer("GV01", "Thầy Nghĩa");

            //tạo 3 thiết bị
            ProjectorRemote mc = new ProjectorRemote("MC01", "Điều khiển máy chiếu", 2022, 400000m);
            AirConditionerRemote dh = new AirConditionerRemote("DH01", "Điều khiển điều hòa", 2023, 250000m);
            Microphone mic = new Microphone("MIC01", "Micro không dây", 2021, 800000m);

            //in danh sách thiết bị
            Console.WriteLine("- Danh sách thiết bị ban đầu:");
            Console.WriteLine("  * " + mc);
            Console.WriteLine("  * " + dh);
            Console.WriteLine("  * " + mic);
            Console.WriteLine();

            //tạo phiếu mượn
            BorrowingSlip phieu = new BorrowingSlip("PH01", gvNam, "Phòng 01");
            Console.WriteLine("- Tạo phiếu mượn " + phieu.SlipId + " cho " + gvNam.FullName + " tại " + phieu.TeachingRoom);

            //thêm máy chiếu và mic (mượn 1 ngày)
            phieu.AddDevice(mc, 1);
            phieu.AddDevice(mic, 1);
            Console.WriteLine("- Đã thêm máy chiếu (MC01) và micro (MIC01) vào phiếu.");

            //trả máy chiếu đúng hạn
            DateTime ngayDungHan = phieu.BorrowedDate.AddDays(1);
            decimal tienPhatMC = phieu.ReturnDevice("MC01", ngayDungHan);
            Console.WriteLine("- Trả máy chiếu MC01 đúng hạn -> Tiền phạt: " + tienPhatMC.ToString("N0") + "đ");

            //trả mic trễ 2 ngày
            DateTime ngayTre2Ngay = phieu.BorrowedDate.AddDays(3);
            decimal tienPhatMic = phieu.ReturnDevice("MIC01", ngayTre2Ngay);
            Console.WriteLine("- Trả micro MIC01 trễ 2 ngày -> Tiền phạt: " + tienPhatMic.ToString("N0") + "đ");

            //in thông tin phiếu
            Console.WriteLine("\n- Chi tiết thiết bị trong phiếu " + phieu.SlipId + ":");
            foreach (var item in phieu.Items)
            {
                string trangThai = item.IsReturned 
                    ? ("Đã trả (" + item.ReturnedDate.Value.ToString("dd/MM/yyyy") + ")") 
                    : "Chưa trả";
                Console.WriteLine("  * " + item.Device.Name + " (" + item.Device.Id + ") | Hạn trả: " + item.DueDate.ToString("dd/MM/yyyy") + " | TT: " + trangThai);
            }
            Console.WriteLine("=> Tổng tiền phạt trễ hạn của phiếu: " + phieu.CalculateTotalLateFee().ToString("N0") + "đ");


            // ==========================================================
            // phần 2: kiểm thử ngoại lệ
            // ==========================================================
            Console.WriteLine("\n=== 2. LỖI ===");

            //test 1: máy đang bảo trì
            Console.WriteLine("\n[Test 1] Mượn thiết bị đang bảo trì (UnderMaintenance):");
            try
            {
                AirConditionerRemote dhHong = new AirConditionerRemote("DH_ERR", "Điều khiển điều hòa", 2020, 200000m);
                dhHong.Status = DeviceStatus.UnderMaintenance; //set sang bảo trì

                BorrowingSlip phieuTest1 = new BorrowingSlip("P_TEST1", gvNam, "Phòng 201");
                phieuTest1.AddDevice(dhHong, 1);
            }
            catch (DeviceUnavailableException ex)
            {
                Console.WriteLine("  -> Lỗi DeviceUnavailableException: " + ex.Message);
            }

            //test 2: trợ giảng mượn quá giới hạn (tối đa 2)
            Console.WriteLine("\n[Test 2] Trợ giảng mượn quá giới hạn (tối đa 2 thiết bị):");
            try
            {
                TeachingAssistant ta = new TeachingAssistant("TA01", "Trợ giảng Tuấn Anh");
                BorrowingSlip phieuTA = new BorrowingSlip("P_TA", ta, "Phòng Máy 1");

                AirConditionerRemote dev1 = new AirConditionerRemote("DEV01", "Điều khiển điều hòa 1", 2023, 200000m);
                Microphone dev2 = new Microphone("DEV02", "Micro không dây 2", 2023, 500000m);
                ProjectorRemote dev3 = new ProjectorRemote("DEV03", "Điều khiển máy chiếu 3", 2023, 300000m);

                phieuTA.AddDevice(dev1, 1);
                phieuTA.AddDevice(dev2, 1);
                Console.WriteLine("  - Trợ giảng đã mượn 2 máy thành công.");
                phieuTA.AddDevice(dev3, 1); //lỗi mượn máy thứ 3
            }
            catch (BorrowLimitExceededException ex)
            {
                Console.WriteLine("  -> Lỗi BorrowLimitExceededException: " + ex.Message);
            }

            //test 3: thêm trùng máy
            Console.WriteLine("\n[Test 3] Thêm cùng một micro hai lần vào một phiếu:");
            try
            {
                BorrowingSlip phieuTrung = new BorrowingSlip("P_TRUNG", gvNam, "Phòng 405");
                Microphone micTrung = new Microphone("MIC_TRUNG", "Micro không dây", 2022, 600000m);

                phieuTrung.AddDevice(micTrung, 1);
                phieuTrung.AddDevice(micTrung, 1); //thêm lại lần 2
            }
            catch (DuplicateDeviceException ex)
            {
                Console.WriteLine("  -> Lỗi DuplicateDeviceException: " + ex.Message);
            }

            //test 4: mượn quá số ngày cho phép
            Console.WriteLine("\n[Test 4] Mượn micro 3 ngày trong khi giới hạn là 1 ngày:");
            try
            {
                BorrowingSlip phieuNgay = new BorrowingSlip("P_NGAY", gvNam, "Phòng 102");
                Microphone mic1Ngay = new Microphone("MIC_1D", "Micro không dây", 2023, 700000m);

                phieuNgay.AddDevice(mic1Ngay, 3); //đòi mượn 3 ngày
            }
            catch (InvalidBorrowPeriodException ex)
            {
                Console.WriteLine("  -> Lỗi InvalidBorrowPeriodException: " + ex.Message);
            }

            //test 5: trả máy ko có trong phiếu
            Console.WriteLine("\n[Test 5] Trả thiết bị không thuộc phiếu mượn này:");
            try
            {
                BorrowingSlip phieuTra = new BorrowingSlip("P_TRA", gvNam, "Phòng 501");
                phieuTra.AddDevice(new Microphone("MIC_OK", "Micro không dây", 2023, 500000m), 1);

                //trả máy MC_LA ko có trong phiếu
                phieuTra.ReturnDevice("MC_LA", DateTime.Now);
            }
            catch (DeviceNotInSlipException ex)
            {
                Console.WriteLine("  -> Lỗi DeviceNotInSlipException: " + ex.Message);
            }

            //test 6: trả 1 máy 2 lần
            Console.WriteLine("\n[Test 6] Trả cùng một thiết bị hai lần:");
            try
            {
                BorrowingSlip phieuTra2Lan = new BorrowingSlip("P_TRA2", gvNam, "Phòng 303");
                Microphone micTra = new Microphone("MIC_TRA2", "Micro không dây", 2023, 500000m);

                phieuTra2Lan.AddDevice(micTra, 1);
                phieuTra2Lan.ReturnDevice("MIC_TRA2", DateTime.Now.AddDays(1)); //trả lần 1
                Console.WriteLine("  - Đã trả thiết bị lần 1 thành công.");
                phieuTra2Lan.ReturnDevice("MIC_TRA2", DateTime.Now.AddDays(1)); //trả tiếp lần 2
            }
            catch (DeviceAlreadyReturnedException ex)
            {
                Console.WriteLine("  -> Lỗi DeviceAlreadyReturnedException: " + ex.Message);
            }

            //test 7: ngày trả trước ngày mượn
            Console.WriteLine("\n[Test 7] Trả thiết bị với ngày trả trước ngày mượn:");
            try
            {
                BorrowingSlip phieuNgayAo = new BorrowingSlip("P_AO", gvNam, "Phòng 304");
                AirConditionerRemote dhNgayAo = new AirConditionerRemote("DH_AO", "Điều khiển điều hòa", 2023, 200000m);

                phieuNgayAo.AddDevice(dhNgayAo, 1);
                //mượn hôm nay nhưng ngày trả lại truyền 2 ngày trước
                phieuNgayAo.ReturnDevice("DH_AO", DateTime.Now.AddDays(-2));
            }
            catch (BorrowingException ex)
            {
                Console.WriteLine("  -> Lỗi BorrowingException: " + ex.Message);
            }

            Console.WriteLine("\n==========================================================");
            Console.WriteLine("                          TEST                            ");
            Console.WriteLine("==========================================================");
        }
    }
}