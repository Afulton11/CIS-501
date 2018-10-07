using Project1.Entities;
using System.Collections.Generic;

namespace Project1.Verification
{
    public class VerificationManager
    {
        private IEnumerable<IScheduleConstraint> _scheduleConstraints;
        private IScheduleReader _scheduleReader;

        private Schedule _localSchedule, _remoteSchedule;
        private string _localSchedulePath, _remoteSchedulePath;

        public VerificationManager(
            IScheduleReader scheduleReader,
            IEnumerable<IScheduleConstraint> scheduleConstraints)
        {
            _scheduleReader = scheduleReader;
            _scheduleConstraints = scheduleConstraints;
        }
        
        public string LocalSchedulePath
        {
            get => _localSchedulePath;
            set
            {
                if (value != _localSchedulePath)
                {
                    _localSchedulePath = value;
                    if (!string.IsNullOrWhiteSpace(_localSchedulePath))
                        LoadLocalSchedule();
                }
            }
        }

        public string RemoteSchedulePath
        {
            get => _remoteSchedulePath;
            set
            {
                if (value != _remoteSchedulePath)
                {
                    _remoteSchedulePath = value;
                    if (!string.IsNullOrWhiteSpace(_remoteSchedulePath))
                        LoadRemoteSchedule();
                }
            }
        }

        public void Verify()
        {
            foreach (var constraint in _scheduleConstraints)
                constraint.Verify(_localSchedule, _remoteSchedule);
        }

        private void LoadLocalSchedule() => _localSchedule = _scheduleReader.Read(LocalSchedulePath);
        private void LoadRemoteSchedule() => _remoteSchedule = _scheduleReader.Read(RemoteSchedulePath);
    }
}
