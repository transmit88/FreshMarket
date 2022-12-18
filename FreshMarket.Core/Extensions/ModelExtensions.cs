using FreshMarket.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FreshMarket.Core.Extensions
{
    public static class ModelExtensions
    {
        public static string GetInformation(this IProductModel product)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(product.Title.Replace(" ", "-"));
            sb.Append("-");
            sb.Append(GetAddress(product.Address));

            return sb.ToString();
        }

        private static string GetAddress(string address)
        {
            string result = string
                .Join("-", address.Split(" ", StringSplitOptions.RemoveEmptyEntries).Take(3));
            return Regex.Replace(address, @"[^a-zA-Z0-9\-]", string.Empty);

        }
    }
}
