using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ITradeProcessor
{
    public interface ITradeProcessor
    {
        IEnumerable<string> ReadTradeData(Stream stream);

        IEnumerable<TradeRecord> ParseTrades(IEnumerable<string> tradeData);

        void StoreTrades(IEnumerable<TradeRecord> trades);

        void ProcessTrades(Stream stream)
        {
            var lines = ReadTradeData(stream);
            var trades = ParseTrades(lines);
            StoreTrades(trades);
        }
    }
}
