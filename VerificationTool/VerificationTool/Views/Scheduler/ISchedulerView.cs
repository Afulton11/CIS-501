using System;
namespace VerificationTool.Views.Scheduler
{
    public interface ISchedulerView
    {
        event EventHandler VerifySchedulesEvent;
        event EventHandler ClearEvent;
        event EventHandler ReloadEvent;
        event EventHandler LoadLocalScheduleEvent;


    }
}
