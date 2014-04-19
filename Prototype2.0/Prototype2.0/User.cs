using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prototype2._0
{
    public class User
    {
        private String name;
        private List<Problem> solve;
        private int rank;
        private int problemsSubmitted;
        private int problemsSolved;
        private int submissions;
        private int accepted;
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        public List<Problem> Solve
        {
            get { return solve; }
            set { solve = value; }
        }
        public int Rank
        {
            get { return rank; }
            set { rank = value; }
        }
        public int ProblemsSubmitted
        {
            get { return problemsSubmitted; }
            set { problemsSubmitted = value; }
        }
        public int ProblemsSolved
        {
            get { return problemsSolved; }
            set { problemsSolved = value; }
        }
        public int Submissions
        {
            get { return submissions; }
            set { submissions = value; }
        }
        public int Accepted
        {
            get { return accepted; }
            set { accepted = value; }
        }
    }
}
