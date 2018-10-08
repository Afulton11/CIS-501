using Project1.Scheduler;
using Project1.Verification;
using Project1.Verification.Constraint;
using System;
using System.Collections.Generic;
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
            var verificationManager = new VerificationManager(new CSVScheduleReader(),
                new List<IScheduleConstraint>
                {
                    
                });
            var presenter = new SchedulerPresenter(view, verificationManager);
            app.Run(view);
        }
    }
}
