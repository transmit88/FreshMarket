using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshMarket.Core.Contracts
{
    public interface ICreatorService
    {

        Task<bool> ExistById(string userId);

        Task<bool> UserWithPhoneNumberExists(string phoneNumber);

        Task<bool> UserHasBuy(string userId);

        Task Create(string userId, string phoneNumber);

        Task<int> GetCreatorId(string userId);
    }
}
