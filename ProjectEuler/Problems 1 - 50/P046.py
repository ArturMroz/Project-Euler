# https://projecteuler.net/problem=46
# What is the smallest odd composite that cannot be written
# as the sum of a prime and twice a square?

squares = [2 * x ** 2 for x in range(1, 1000)]


def eratosthenes(lim):
    a = [True] * lim
    a[0] = a[1] = False

    for i, v in enumerate(a):
        if v:
            yield i
            for n in range(i * i, lim, i):
                a[n] = False


def solve():
    lim = 10000
    primes = set(eratosthenes(lim))
    for n in (x for x in range(2, lim) if x % 2 and x not in primes):
        for s in squares:
            if n - s in primes:
                break
            elif s >= n:
                return n

print(solve())
