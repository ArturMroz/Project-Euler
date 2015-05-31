# https://projecteuler.net/problem=36
# Find the sum of all numbers, less than one million,
# which are palindromic in base 10 and base 2.


def ispal(s): return s == s[::-1]
print(sum(x for x in range(1000000) if ispal(str(x)) and ispal(bin(x)[2:])))
