# https://projecteuler.net/problem=49
# Concatenate the three terms in sequence where
# (i) each of the three terms are prime, and,
# (ii) each of the 4-digit numbers are permutations of one another.


def eratosthenes(lim):
    a = [True] * lim
    a[0] = a[1] = False

    for i, v in enumerate(a):
        if v:
            yield i
            for n in range(i * i, lim, i):
                a[n] = False


def solve():
    primes = set(eratosthenes(9999))
    for p in sorted(primes):
        if p < 1488:
            continue
        for step in range(1, 3333):
            p2, p3 = p + step, p + step * 2
            if p2 in primes and p3 in primes:
                s1, s2, s3 = str(p), str(p2), str(p3)
                if sorted(s1) == sorted(s2) == sorted(s3):
                    return s1 + s2 + s3

print(solve())
