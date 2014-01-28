using System.Linq;

namespace ProjectEuler
{
    // What is the total of all the name scores in the file?
    public static class P022
    { 
        public static int Solve()
        {
            var names = ProjectEuler.Properties.Resources.names
                .Replace("\"", "")
                .Split(',')
                .OrderBy(n => n);

            int sum, i = 1, score = 0;

            foreach (var name in names)
            {
                sum = 0;
                foreach (var letter in name)
                {
                    sum += (int)letter - 64;
                }

                score += sum * i++;
            }

            return score;
        }
    }
}
