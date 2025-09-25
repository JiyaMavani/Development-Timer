using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace DevelopmentTimer.API.Hubs
{
    public class TimerHub : Hub
    {
        private readonly TimerService _timerService;

        public TimerHub(TimerService timerService)
        {
            _timerService = timerService;
        }

        public Task StartTimer(int devId, double hours)
        {
            _timerService.StartTimer(devId, Context.ConnectionId, hours);
            return Task.CompletedTask;
        }

        public Task StopTimer(int devId)
        {
            _timerService.StopTimer(devId);
            return Task.CompletedTask;
        }
    }

}
