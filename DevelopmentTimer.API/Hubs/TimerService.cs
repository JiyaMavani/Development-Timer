using Microsoft.AspNetCore.SignalR;
using System.Timers;

namespace DevelopmentTimer.API.Hubs
{
    public class TimerService
    {
        private readonly IHubContext<TimerHub> hubContext;
        private readonly Dictionary<int, System.Timers.Timer> _timers = new();
        private readonly Dictionary<int, TimeSpan> _remainingTime = new();

        public TimerService(IHubContext<TimerHub> hubContext)
        {
            this.hubContext = hubContext;
        }

        public void StartTimer(int devId, string connectionId, double hours)
        {
            TimeSpan timeLeft = _remainingTime.ContainsKey(devId) ? _remainingTime[devId] : TimeSpan.FromHours(hours);

            if (_timers.ContainsKey(devId))
            {
                _timers[devId].Stop();
                _timers.Remove(devId);
            }

            var timer = new System.Timers.Timer(1000);
            timer.Elapsed += async (s, e) =>
            {
                timeLeft = timeLeft.Subtract(TimeSpan.FromSeconds(1));
                _remainingTime[devId] = timeLeft;

                if (timeLeft.TotalSeconds <= 0)
                {
                    timer.Stop();
                    _timers.Remove(devId);
                    _remainingTime.Remove(devId);
                    await hubContext.Clients.Client(connectionId).SendAsync("TimerEnded");
                }
                else
                {
                    await hubContext.Clients.Client(connectionId).SendAsync("TimerUpdate", timeLeft.ToString(@"hh\:mm\:ss"));
                }
            };
            timer.Start();

            _timers[devId] = timer;
        }

        public void StopTimer(int devId)
        {
            if (_timers.TryGetValue(devId, out var timer))
            {
                timer.Stop();
                _timers.Remove(devId);
            }
        }
    }

}
