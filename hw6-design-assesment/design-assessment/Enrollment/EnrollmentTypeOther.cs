using System;
namespace designassessment.Enrollment
{
    public class EnrollmentTypeOther : IEnrollment
    {
        public double GetDiscount(double tuition)
        {
            return tuition - 50;
        }
    }
}
