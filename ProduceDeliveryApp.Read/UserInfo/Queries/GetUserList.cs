using MediatR;
using ProduceDeliveryApp.DataRead.UsersInfo.ReadModels;
using System.Collections.Generic;

namespace ProduceDeliveryApp.DataRead.UsersInfo.Queries
{
    public class GetUserList : IRequest<IEnumerable<UserReadModel>>
    {
        //public GetUserList(int pageNo, int pageSize, string searchText)
        //{
        //    PageNo = pageNo;
        //    PageSize = pageSize;
        //    SearchText = searchText;
        //}

        //public int PageNo { get; }
        //public int PageSize { get; }
        //public string SearchText { get; }
    }
}
