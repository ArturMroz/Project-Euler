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


def isleft(i):
    n = i // 10
    while n:
        if n not in primes:
            return False
        n //= 10
    return True


def isright(i):
    k = 10
    while i > k:
        n = i % k
        if n not in primes:
            return False
        k *= 10
    return True

# there are 11 truncatable primes - info known from problem description
primesn = 11
lim = 1000000
ans = 0
primes = list(eratosthenes(lim))

# skipping first 5 primes as they aren't considered truncatable
for i in primes[5:]:
    if isleft(i) and isright(i):
        ans += i
        primesn -= 1
        if not primesn:
            break

print(ans)
