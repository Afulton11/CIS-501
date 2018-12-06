using VerificationTool.Entities;

namespace VerificationTool.Verification.Readers
{
    public interface IScheduleReader
    {
        Semester Read(string filepath);
    }
}
