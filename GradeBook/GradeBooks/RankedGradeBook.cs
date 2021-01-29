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
            if (!AreEnoughStudents())
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
                return (GetRanking(averageGrade) / (double)Students.Count) * 100;
            }
            catch (DivideByZeroException)
            {
                throw new InvalidOperationException();
            }
        }

        public override void CalculateStatistics()
        {
            if (!AreEnoughStudents())
            {
                DisplayNotEnoughStudentsErrorMessage();
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (!AreEnoughStudents())
            {
                DisplayNotEnoughStudentsErrorMessage();
                return;
            }

            base.CalculateStudentStatistics(name);
        }

        public bool AreEnoughStudents()
        {
            if (Students.Count < 5) 
            {
                return false;
            }

            return true;
        }

        public void DisplayNotEnoughStudentsErrorMessage()
        {
            Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
        }
    }
}
