# https://projecteuler.net/problem=53
# How many, not necessarily distinct, values of  nCr, for 1 ≤ n ≤ 100,
# are greater than one-million?

from math import factorial as f

def C(n, r): return f(n) // (f(r) * f(n - r))
print(sum(C(n, r) > 1000000 for n in range(23, 101) for r in range(1, n)))
