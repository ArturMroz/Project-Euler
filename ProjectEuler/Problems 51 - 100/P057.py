# https://projecteuler.net/problem=57
# In the first one-thousand expansions the square root of two, how many
# fractions contain a numerator with more digits than denominator?


ans = 0
num, den = 3, 2
for _ in range(1000):
    # formula for the next numerator and denominator can be derived by
    # analysing the first few fractions in the sequence
    num, den = num + 2 * den, num + den
    ans += len(str(num)) > len(str(den))

print(ans)
