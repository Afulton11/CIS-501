using System;
namespace VerificationTool.Views.Scheduler
{
    public interface ISchedulerView
    {
        event EventHandler VerifyScheduleEvent;
        event EventHandler ClearEvent;
        event EventHandler ReloadEvent;
        event EventHandler LoadLocalSchedulesEvent;


    }
}
