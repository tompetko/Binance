﻿using Binance.Candlesticks;
using Binance.Trades.Cache;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Binance
{
    public interface ICandlesticksCache : IDisposable
    {
        #region Public Events

        /// <summary>
        /// Candlesticks update event.
        /// </summary>
        event EventHandler<CandlesticksCacheEventArgs> Update;

        #endregion Public Events

        #region Public Properties

        /// <summary>
        /// The candlesticks. Can be empty if not yet synchronized or out-of-sync.
        /// </summary>
        IEnumerable<Candlestick> Candlesticks { get; }

        /// <summary>
        /// The client that provides candlestick information.
        /// </summary>
        IKlineWebSocketClient Client { get; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="interval"></param>
        /// <param name="limit"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task SubscribeAsync(string symbol, KlineInterval interval, int limit = default, CancellationToken token = default);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="interval"></param>
        /// <param name="callback"></param>
        /// <param name="limit"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task SubscribeAsync(string symbol, KlineInterval interval, Action<CandlesticksCacheEventArgs> callback, int limit = default, CancellationToken token = default);

        #endregion Public Methods
    }
}
