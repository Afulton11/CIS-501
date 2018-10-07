using Project1.Entities;
using Project1.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Verification
{
    public class VerificationManager
    {
        private IEnumerable<IScheduleConstraint> _scheduleConstraints;
        private IScheduleReader _scheduleReader;

        private Schedule _localSchedule, _remoteSchedule;

        public VerificationManager(
            IScheduleReader scheduleReader,
            IEnumerable<IScheduleConstraint> scheduleConstraints)
        {
            _scheduleReader = scheduleReader;
            _scheduleConstraints = scheduleConstraints;
        }
        
        public string LocalSchedulePath { get; set; }
        public string RemoteSchedulePath { get; set; }

        public void LoadLocalSchedule() => _localSchedule = _scheduleReader.Read(LocalSchedulePath);
        public void LoadRemoteSchedule() => _remoteSchedule = _scheduleReader.Read(RemoteSchedulePath);

        public void Verify()
        {
            foreach (var constraint in _scheduleConstraints)
                constraint.Verify(_localSchedule, _remoteSchedule);
        }

    }
}
