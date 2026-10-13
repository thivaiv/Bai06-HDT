/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
using System;

namespace Bai06
{
    //ngoại lệ cơ sở
    public class BorrowingException : Exception
    {
        public BorrowingException(string message) : base(message)
        {
        }
    }
}
