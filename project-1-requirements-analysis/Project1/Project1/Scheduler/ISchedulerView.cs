using System;

namespace Project1.Scheduler
{
    public interface ISchedulerView
    {
        event EventHandler VerifyScheduleEvent;
        event EventHandler ClearEvent;
        event EventHandler ReloadEvent;
        event EventHandler AboutEvent;

        SchedulerViewModel ViewModel { get; }
    }
}
