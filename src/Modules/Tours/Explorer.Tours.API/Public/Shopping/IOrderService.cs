using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Dtos.Tour.DataIn;
using FluentResults;

namespace Explorer.Tours.API.Public.Shopping
{
    public interface IOrderService
    {
        Result<PagedResult<ShoppingCartDto>> GetPaged(int page, int pageSize);
        Result<ShoppingCartDto> GetByIdUser(int id);
        Result<ShoppingCartDto> Create(ShoppingCartDto cart);
        Result<ShoppingCartDto> Update(ShoppingCartDto cart);
        Result Delete(int id);
    }
}
