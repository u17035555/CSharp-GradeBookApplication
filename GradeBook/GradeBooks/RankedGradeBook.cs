using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            double percentile = CalculatePercentile(averageGrade);

            if (percentile <= 20)
            {
                return 'A';
            }
            else if (percentile <= 40)
            {
                return 'B';
            }
            else if (percentile <= 60)
            {
                return 'C';
            }
            else if (percentile <= 80)
            {
                return 'D';
            }

            return 'F';
        }

        public int GetRanking(double averageGrade)
        {
            return Students.Count(student => student.AverageGrade >= averageGrade);
        }

        public double CalculatePercentile(double averageGrade)
        {
            try
            {
                return (GetRanking(averageGrade) / (double) Students.Count) * 100;
            }
            catch (DivideByZeroException)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
