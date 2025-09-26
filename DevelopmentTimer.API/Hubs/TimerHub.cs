using Microsoft.AspNetCore.SignalR;
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

        public Task StartTimer(int devId, double minutes, int thresholdMinutes)
        {
            _timerService.StartTimer(devId, Context.ConnectionId, minutes, thresholdMinutes);
            return Task.CompletedTask;
        }

        public Task StopTimer(int devId)
        {
            _timerService.StopTimer(devId);
            return Task.CompletedTask;
        }

        public Task PauseTimer(int devId)
        {
            _timerService.PauseTimer(devId);
            return Task.CompletedTask;
        }

        public Task ResumeTimer(int devId)
        {
            _timerService.ResumeTimer(devId, Context.ConnectionId);
            return Task.CompletedTask;
        }

        public Task AddExtension(int devId, int extraHours)
        {
            _timerService.AddExtension(devId, extraHours, Context.ConnectionId);
            return Task.CompletedTask;
        }

        public Task UpdateTimer(int developerId, double remainingMinutes)
        {
            return _timerService.UpdateTimerAsync(developerId, remainingMinutes);
        }
    }
}

