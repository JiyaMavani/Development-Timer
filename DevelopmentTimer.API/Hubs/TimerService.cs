using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using Timer = System.Timers.Timer;
using System.Threading.Tasks;

namespace DevelopmentTimer.API.Hubs
{
    public class TimerService
    {
        private readonly IHubContext<TimerHub> hubContext;
        private readonly ConcurrentDictionary<int, Timer> _timers = new();
        private readonly ConcurrentDictionary<int, TimeSpan> _remainingTime = new();
        private readonly ConcurrentDictionary<int, string> _connectionIds = new(); 
        private readonly ConcurrentDictionary<int, bool> _thresholdNotified = new();

        public TimerService(IHubContext<TimerHub> hubContext)
        {
            this.hubContext = hubContext;
        }

        public void StartTimer(int devId, string connectionId, double minutes, int thresholdMinutes)
        {
            _connectionIds[devId] = connectionId;

            if (_timers.TryRemove(devId, out var existing))
            {
                try { existing.Stop(); existing.Dispose(); } catch { }
            }

            TimeSpan timeLeft = _remainingTime.ContainsKey(devId) ? _remainingTime[devId] : TimeSpan.FromMinutes(minutes);

            _thresholdNotified[devId] = false;

            _ = hubContext.Clients.Client(connectionId).SendAsync("TimerUpdate", timeLeft.ToString(@"hh\:mm\:ss"));

            var timer = new Timer(1000);
            timer.AutoReset = true;

            timer.Elapsed += async (s, e) =>
            {
                timeLeft = timeLeft.Subtract(TimeSpan.FromSeconds(1));
                _remainingTime[devId] = timeLeft;

                if (!_thresholdNotified.TryGetValue(devId, out var notified) || !notified)
                {
                    if (timeLeft.TotalMinutes <= thresholdMinutes)
                    {
                        _thresholdNotified[devId] = true;
                        await hubContext.Clients.Client(connectionId).SendAsync("ThresholdReached");
                    }
                }

                if (timeLeft.TotalSeconds <= 0)
                {
                    try { timer.Stop(); timer.Dispose(); } catch { }
                    _timers.TryRemove(devId, out _);
                    _remainingTime.TryRemove(devId, out _);
                    _ = hubContext.Clients.Client(connectionId).SendAsync("TimerEnded");
                }
                else
                {
                    await hubContext.Clients.Client(connectionId).SendAsync("TimerUpdate", timeLeft.ToString(@"hh\:mm\:ss"));
                }
            };

            timer.Start();
            _timers[devId] = timer;
            _remainingTime[devId] = timeLeft;
        }

        public void PauseTimer(int devId)
        {
            if (_timers.TryRemove(devId, out var timer))
            {
                try { timer.Stop(); timer.Dispose(); } catch { }
            }
            if (_connectionIds.TryGetValue(devId, out var connId))
            {
                _ = hubContext.Clients.Client(connId).SendAsync("TimerPaused");
            }
        }

        public void StopTimer(int devId)
        {
            if (_timers.TryRemove(devId, out var timer))
            {
                try { timer.Stop(); timer.Dispose(); } catch { }
            }
            _remainingTime.TryRemove(devId, out _);
            _thresholdNotified.TryRemove(devId, out _);
            _connectionIds.TryRemove(devId, out _);
        }

        public void ResumeTimer(int devId, string connectionId)
        {
            if (!string.IsNullOrEmpty(connectionId))
                _connectionIds[devId] = connectionId;

            if (_timers.ContainsKey(devId))
                return;

            if (!_remainingTime.TryGetValue(devId, out var timeLeft))
            {
                return;
            }

            if (!_connectionIds.TryGetValue(devId, out var connId))
                return;

            var timer = new Timer(1000);
            timer.AutoReset = true;
            timer.Elapsed += async (s, e) =>
            {
                timeLeft = timeLeft.Subtract(TimeSpan.FromSeconds(1));
                _remainingTime[devId] = timeLeft;

                if (!_thresholdNotified.TryGetValue(devId, out var notified) || !notified)
                {
                    // if threshold info not known, don't know minutes here; threshold notification should be triggered previously on StartTimer
                }

                if (timeLeft.TotalSeconds <= 0)
                {
                    try { timer.Stop(); timer.Dispose(); } catch { }
                    _timers.TryRemove(devId, out _);
                    _remainingTime.TryRemove(devId, out _);
                    await hubContext.Clients.Client(connId).SendAsync("TimerEnded");
                }
                else
                {
                    await hubContext.Clients.Client(connId).SendAsync("TimerUpdate", timeLeft.ToString(@"hh\:mm\:ss"));
                }
            };
            timer.Start();
            _timers[devId] = timer;
        }

        public void AddExtension(int devId, int extraHours, string connectionId)
        {

            if (!string.IsNullOrEmpty(connectionId))
                _connectionIds[devId] = connectionId;

            var add = TimeSpan.FromHours(extraHours);
            if (_remainingTime.TryGetValue(devId, out var current))
                current = current.Add(add);
            else
                current = add;

            _remainingTime[devId] = current;

            if (_connectionIds.TryGetValue(devId, out var connId))
            {
                _ = hubContext.Clients.Client(connId).SendAsync("TimerUpdate", current.ToString(@"hh\:mm\:ss"));
            }

            if (!_timers.ContainsKey(devId))
            {
                if (_connectionIds.TryGetValue(devId, out var conn2))
                {
                    ResumeTimer(devId, conn2);
                }
            }
        }

        public Task UpdateTimerAsync(int developerId, double remainingMinutes)
        {
            var ts = TimeSpan.FromMinutes(remainingMinutes);
            _remainingTime[developerId] = ts;

            if (_connectionIds.TryGetValue(developerId, out var connId))
            {
                return hubContext.Clients.Client(connId).SendAsync("TimerUpdate", ts.ToString(@"hh\:mm\:ss"));
            }
            return Task.CompletedTask;
        }
    }
}

