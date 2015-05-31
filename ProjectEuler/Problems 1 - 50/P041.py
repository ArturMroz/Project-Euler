# https://projecteuler.net/problem=41
# What is the largest n-digit pandigital prime that exists?


def eratosthenes(lim):
    a = [True] * lim
    a[0] = a[1] = False

    for i, v in enumerate(a):
        if v:
            yield i
            for n in range(i * i, lim, i):
                a[n] = False

maxn = 0
for p in eratosthenes(10000000):
    s = str(p)
    if '0' not in s and max(s) == str(len(s)) and len(s) == len(set(s)):
        maxn = max(maxn, p)

print(maxn)
