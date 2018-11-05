using System;
namespace designassessment.Enrollment
{
    public class EnrollmentTypeOne : IEnrollment
    {
        public double GetDiscount(double tuition)
        {
            return tuition - 100;
        }
    }
}
