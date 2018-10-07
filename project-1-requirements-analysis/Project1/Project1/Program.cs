using Project1.Scheduler;
using System;
using System.Windows;

namespace Project1
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var app = new Application();
            var view = new SchedulerView();
            var presenter = new SchedulerPresenter(view);
            app.Run(view);
        }
    }
}
