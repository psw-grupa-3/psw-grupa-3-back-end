using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Payments.API.Dtos;
using Explorer.Payments.API.Public;
using Explorer.Payments.Core.Domain.RepositoryInterfaces;
using Explorer.Payments.Core.Domain;
using FluentResults;

namespace Explorer.Payments.Core.UseCases.Shopping
{
    public class WalletService : CrudService<WalletDto, Wallet>, IWalletService
    {
        private readonly IWalletRepository _walletRepository;
        public WalletService(ICrudRepository<Wallet> repository, IMapper mapper, IWalletRepository walletRepository) : base(repository, mapper)
        {
            _walletRepository = walletRepository;
        }

        public Result<WalletDto> CreateWallet(int userId)
        {
            var wallet = _walletRepository.CreateWallet(userId);
            return MapToDto(wallet.Value);
        }
    }
}
