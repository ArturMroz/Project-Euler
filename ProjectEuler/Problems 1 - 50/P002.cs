namespace ProjectEuler
{
    // By considering the terms in the Fibonacci sequence whose values 
    // do not exceed four million, find the sum of the even-valued terms
    public static class P002
    {
        public static int Solve()
        {
            int sum = 0, previous = 1, current = 1, temp;

            while (current < 4000000)
            {
                if (current % 2 == 0)
                {
                    sum += current;
                }

                temp = previous + current;
                previous = current;
                current = temp;
            } 

            return sum;
        }
    }
}
