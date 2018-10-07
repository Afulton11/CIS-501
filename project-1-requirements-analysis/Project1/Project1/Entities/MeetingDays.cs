namespace Project1.Entities
{
    public class MeetingDays
    {
        private bool[] _days;

        public MeetingDays()
        {
            _days = new bool[7];
        }

        public void SetMonday(bool isMeeting) => _days[0] = isMeeting;
        public void SetTuesday(bool isMeeting) => _days[1] = isMeeting;
        public void SetWednesday(bool isMeeting) => _days[2] = isMeeting;
        public void SetThursday(bool isMeeting) => _days[3] = isMeeting;
        public void SetFriday(bool isMeeting) => _days[4] = isMeeting;
        public void SetSaturday(bool isMeeting) => _days[5] = isMeeting;
        public void SetSunday(bool isMeeting) => _days[6] = isMeeting;

        public override bool Equals(object obj)
        {
            if (obj is MeetingDays other)
            {
                for (int i = 0; i < _days.Length; i++)
                    if (other._days[i] != _days[i])
                        return false;
                return true;
            }

            return false;
        }

        public override int GetHashCode() => _days.GetHashCode();
    }
}
