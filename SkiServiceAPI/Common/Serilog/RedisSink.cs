﻿using Newtonsoft.Json;
using Serilog.Core;
using Serilog.Events;
using StackExchange.Redis;

namespace SkiServiceAPI.Common.Serilog
{
    public class RedisSink : ILogEventSink
    {
        private readonly IConnectionMultiplexer _redis;
        private readonly string _listName;

        public RedisSink(IConnectionMultiplexer redis, string listName)
        {
            _redis = redis;
            _listName = listName;
        }

        public void Emit(LogEvent logEvent)
        {
            var message = JsonConvert.SerializeObject(logEvent);
            var db = _redis.GetDatabase();
            db.ListRightPush(_listName, message);
        }
    }
}
