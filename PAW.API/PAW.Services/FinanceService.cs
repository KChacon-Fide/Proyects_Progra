using APW.Architecture;
using PAW.Architecture.Providers;
using PAW.Models;
using PAW.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW.Services
{
    public interface IFinanceService
    {
        Task<ExchangeRate> GetTodaysExchangeRateAsync();
    }

    public class FinanceService(IRestProvider restProvider) : IFinanceService
    {
        private readonly IRestProvider _restProvider = restProvider;

        public async Task<ExchangeRate> GetTodaysExchangeRateAsync()
        {
            var today = DateTime.Today;
            var data = await _restProvider.GetAsync($"https://tipodecambio.paginasweb.cr/api//{today.Day}/{today.Month}/{today.Year}", null);
            var result = await JsonProvider.DeserializeAsync<ExchangeRate>(data);

            return result;
        }
    }


}
