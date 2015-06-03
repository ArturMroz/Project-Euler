# https://projecteuler.net/problem=50
# Which prime, below one-million, can be written as the sum of the most
# consecutive primes?


def eratosthenes(lim):
    a = [True] * lim
    a[0] = a[1] = False

    for i, v in enumerate(a):
        if v:
            yield i
            for n in range(i * i, lim, i):
                a[n] = False

maxlen = ans = 0
lim = 1000000

# creating set for fast access and list for iterating over
primes = set(eratosthenes(lim))
primeslist = sorted(primes)
for i in range(5):
    maxcurr = s = 0
    for p in primeslist[i:]:
        s += p
        if s > lim:
            break
        maxcurr += 1
        if s in primes and maxcurr > maxlen:
            maxlen = maxcurr
            ans = s
print(ans)
