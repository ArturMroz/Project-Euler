# https://projecteuler.net/problem=47
# Find the first four consecutive integers to have four distinct prime factors.
# What is the first of these numbers?

from collections import deque


def eratosthenes(lim):
    a = [True] * lim
    a[0] = a[1] = False

    for i, v in enumerate(a):
        if v:
            yield i
            for n in range(i * i, lim, i):
                a[n] = False


def distinct_prime_factors(n):
    i = 0
    s = set()
    while n > 1:
        curr = primes[i]
        if n % primes[i] == 0:
            n //= curr
            s.add(curr)
        else:
            i += 1
    return len(s)


def solve():
    seq = deque(maxlen=4)
    for i in range(lim):
        seq.append(distinct_prime_factors(i))
        if seq.count(4) == 4:
            return i - 3

lim = 1000000
primes = list(eratosthenes(lim))
print(solve())
