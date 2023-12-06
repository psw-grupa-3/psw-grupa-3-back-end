using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Payments.API.Dtos;
using Explorer.Payments.API.Public;
using Explorer.Payments.Core.Domain.RepositoryInterfaces;
using Explorer.Payments.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Payments.Core.UseCases.Shopping
{
    public class SaleService : CrudService<SaleDto, Sale>, ISaleService
    {
        public SaleService(ICrudRepository<Sale> repository, IMapper mapper, ISaleRepository saleRepository) : base(repository, mapper)
        {

        }
    }
}
