/****************/
//mã sinh viên: 202418989
//họ tên: Chu Đình Thi
/****************/
using System;

namespace Bai06
{
    //interface định nghĩa hành vi và thông tin của người mượn
    public interface IBorrower
    {
        string BorrowerId { get; }

        string FullName { get; }

        //số lượng thiết bị tối đa một phiếu
        int GetMaximumDevices();
    }
}
