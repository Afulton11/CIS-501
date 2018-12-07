using System;
namespace VerificationTool.Views.Scheduler
{
    public interface ISchedulerView
    {
        event EventHandler AboutEvent;
        event EventHandler ClearEvent;
        event EventHandler ReloadEvent;
        event EventHandler LoadLocalScheduleEvent;
        event EventHandler VerifySchedulesEvent;
    }
}
