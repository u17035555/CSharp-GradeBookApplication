using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    class RankedGradebook : BaseGradeBook
    {
        public RankedGradebook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }
    }
}
