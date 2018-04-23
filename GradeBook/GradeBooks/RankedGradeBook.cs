using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            this.Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (this.Students.Count < 5) throw new System.InvalidOperationException();
            var studentsOrderedByGrades = this.Students.OrderByDescending(s => s.AverageGrade);
            var studentCount = this.Students.Count;
            var bucketWidth = (int)Math.Ceiling(0.2 * studentCount);
            var cutoff_A = studentsOrderedByGrades.ElementAt(bucketWidth - 1).AverageGrade;
            var cutoff_B = studentsOrderedByGrades.ElementAt(2*bucketWidth - 1).AverageGrade;
            var cutoff_C = studentsOrderedByGrades.ElementAt(3*bucketWidth-1).AverageGrade;
            var cutoff_D = studentsOrderedByGrades.ElementAt(4*bucketWidth-1).AverageGrade;
            if (averageGrade >= cutoff_A) return 'A';
            if (averageGrade >= cutoff_B) return 'B';
            if (averageGrade >= cutoff_C) return 'C';
            if (averageGrade >= cutoff_D) return 'D';
            return 'F';
        }
    }
}
