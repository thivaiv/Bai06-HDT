/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
namespace Bai06
{
    public class TeachingAssistant : IBorrower
    {
        public string BorrowerId { get; set; }

        public string FullName { get; set; }

        public TeachingAssistant(string id, string name)
        {
            BorrowerId = id;
            FullName = name;
        }

        public int GetMaximumDevices()
        {
            return 5;
        }
    }
}
