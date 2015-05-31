# https://projecteuler.net/problem=37
# Find the sum of the only eleven primes that are both
# truncatable from left to right and right to left.


def eratosthenes(lim):
    a = [True] * lim
    a[0] = a[1] = False

    for i, v in enumerate(a):
        if v:
            yield i
            for n in range(i * i, lim, i):
                a[n] = False

ans = count = 0
primes = set(eratosthenes(1000000))

for i in primes:
    right = 0
    left = i
    k = 1
    while left > 9:
        right += (left % 10) * k
        left //= 10
        k *= 10
        if left not in primes or right not in primes:
            break
        if left < 10:
            ans += i
            count += 1
    # there are 11 possible solutions - info known from problem description
    if count == 11:
        break
print(ans)
