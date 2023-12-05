using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.Payments.API.Dtos;
using FluentResults;

namespace Explorer.Payments.API.Public
{
    public interface IWalletService
    {
        Result<WalletDto> Create(WalletDto walletDto);
        Result<WalletDto> CreateWallet(int userId);
        Result<WalletDto> Update(WalletDto walletDto);
    }
}
