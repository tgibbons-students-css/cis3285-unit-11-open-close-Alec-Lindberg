using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITradeProcessor
{
    class TradeProcessorVersion2 : ITradeProcessor
    {
        protected IEnumerable<string> ReadTradeData(Stream stream)
        {
            var tradeData = new List<string>();
            LogMessage("INFO: Simulating ReadTradeData version 2");
            return tradeData;
        }

        protected IEnumerable<TradeRecord> ParseTrades(IEnumerable<string> tradeData)
        {
            var trades = new List<TradeRecord>();
            LogMessage("INFO: Simulating ParseTrades version 2");
            return trades;
        }


        protected void StoreTrades(IEnumerable<TradeRecord> trades)
        {
            LogMessage("INFO: Simulating database connection in StoreTrades version 2");
            // Not really connecting to database in this sample
            LogMessage("INFO: {0} trades processed", trades.Count());
        }
        protected void LogMessage(string message, params object[] args)
        {
            Console.WriteLine(message, args);
            // added for Request 408
            using (StreamWriter logfile = File.AppendText("log.xml"))
            {
                logfile.WriteLine("<log>" + message + "</log>", args);
            }

        }
        public virtual void ProcessTrades(Stream stream)
        //public void ProcessTrades(string url)
        {
            var lines = ReadTradeData(stream);
            //var lines = ReadURLTradeData(url);
            var trades = ParseTrades(lines);
            StoreTrades(trades);
        }

        IEnumerable<string> ITradeProcessor.ReadTradeData(Stream stream)
        {
            throw new NotImplementedException();
        }

        IEnumerable<TradeRecord> ITradeProcessor.ParseTrades(IEnumerable<string> tradeData)
        {
            throw new NotImplementedException();
        }

        void ITradeProcessor.StoreTrades(IEnumerable<TradeRecord> trades)
        {
            throw new NotImplementedException();
        }
    }
}
