using VerificationTool.Entities;

namespace VerificationTool.Verification.Readers
{
    public interface IScheduleReader
    {
        Schedule Read(string filepath);
    }
}
