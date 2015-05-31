# https://projecteuler.net/problem=38
# What is the largest 1 to 9 pandigital 9-digit number that can be
# formed as the concatenated product of an integer with (1,2, ... , n)

maxn = ''
for i in range(100000):
    s = ''
    for j in range(1, 10):
        s += str(i * j)
        if len(s) > 9 or '0' in s:
            break
        if len(s) == 9 == len(set(s)):
            maxn = max(maxn, s)
            break
print(maxn)
