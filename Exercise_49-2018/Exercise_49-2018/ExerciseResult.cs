using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_49_2018
{
    class ExerciseResult
    {
        private static int idd = 0;
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string StudentIndex { get; set; }
        public int Point { get; set; }

        public ExerciseResult(string name, string index, int point)
        {
            Id = idd++;
            StudentName = name;
            StudentIndex = index;
            Point = point;
        }
        public ExerciseResult() { }
    }
}
