using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        private double rankWeight = 0.2;

        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override void CalculateStatistics()
        {
            if (this.Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (this.Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }

        public override char GetLetterGrade(double averageGrade)
        {
            var letterGrade = 'F';
            if (this.Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            var placement = this.Students.Where(x => x.AverageGrade > averageGrade).Count() + 1;

            switch (placement)
            {
                case 1:
                    letterGrade = 'A';
                    break;

                case 2:
                    letterGrade = 'B';
                    break;

                case 3:
                    letterGrade = 'C';
                    break;

                case 4:
                    letterGrade = 'D';
                    break;

                default:
                    letterGrade = 'F';
                    break;
            }

            return letterGrade;
        }
    }
}