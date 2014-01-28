using System;

namespace ProjectEuler
{
    // How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?
    public static class P019
    {
        public static int Solve()
        {
            var date = new DateTime(1901, 1, 1);
            int sum = 0;

            while (date < new DateTime(2000, 12, 31))
            {
                if (date.DayOfWeek == DayOfWeek.Sunday)
                {
                    sum++;
                }

                date = date.AddMonths(1);
            }

            return sum;
        }
    }
}
