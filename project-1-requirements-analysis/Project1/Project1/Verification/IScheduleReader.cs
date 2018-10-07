using Project1.Entities;

namespace Project1.Verification
{
    public interface IScheduleReader
    {
        Schedule Read(string filepath);
    }
}
