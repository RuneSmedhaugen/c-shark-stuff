using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Binance.Net;
using Binance.Net.Clients;
using Binance.Net.Objects;
using Binance.Net.Objects.Models.Spot;
using CryptoExchange.Net.Authentication;

namespace CryptoBot
{
    internal class BinanceService
    {
        private readonly BinanceRestClient _client;

        public BinanceService(string apiKey, string secretKey)
        {
            _client = new BinanceClient(new BinanceClientOptions
                {
                    ApiCredentials = new ApiCredentials(apiKey, secretKey)
                }
            );
        }

        public async Task<BinanceAccountInfo> GetAccountInfo()
        {
            var accountInfo = await _client.SpotApi.Account.GetAccountInfoAsync();
            return accountInfo.Data;
        }

        public async Task<BinanceSymbolPrice> GetCurrentPrice(string symbol)
        {
            var price = await _client.SpotApi.ExchangeData.GetPriceAsync(symbol);
            return price.Data;
        }

        public async Task<BinancePlacedOrder> PlaceBuyOrder(string symbol, decimal quantity)
        {
            var order = await _client.SpotApi.Trading.PlaceOrderAsync(
                symbol,
                Binance.Net.Enums.OrderSide.Buy,
                Binance.Net.Enums.OrderType.Market,
                quantity);
            return order.Data;
        }
    }
}
