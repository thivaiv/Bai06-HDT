/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
namespace Bai06
{
    //giảng viên mượn tối đa 3 thiết bị
    public class Lecturer : IBorrower
    {
        public string BorrowerId { get; set; }

        public string FullName { get; set; }

        public Lecturer(string id, string name)
        {
            BorrowerId = id;
            FullName = name;
        }

        
        public int GetMaximumDevices()
        {
            return 3;
        }
    }
}
