using FreshMarket.Core.Contracts;
using FreshMarket.Infrastructure.Data;
using FreshMarket.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreshMarket.Core.Services
{
    public class CreatorService : ICreatorService
    {
        private readonly IRepository repo;

        public async Task<bool> ExistById(string userId)
        {
            return await repo.All<Creator>()
                .AnyAsync(c => c.UserId == userId); // chek if exist
        }


        public CreatorService(IRepository _repo)
        {
            this.repo = _repo;   
        }

        public async Task Create(string userId, string phoneNumber)
        {
            var creator = new Creator()
            {
                UserId = userId,
                PhoneNumber = phoneNumber,
            };

            await repo.AddAsync(creator);
            repo.SaveChangesAsync();
        }

        
        public async Task<bool> UserHasBuy(string userId)
        {
            return await repo.All<Product>()
               .AnyAsync(p => p.BuyerId == userId);
        }

        public async Task<bool> UserWithPhoneNumberExists(string phoneNumber)
        {
            return await repo.All<Creator>()
                .AnyAsync(c => c.PhoneNumber == phoneNumber);
        }

        public async Task<int> GetCreatorId(string userId)
        {
            return (await repo.AllReadonly<Creator>()
                .FirstOrDefaultAsync(a => a.UserId == userId))?.Id ?? 0;
        }
    }
}
