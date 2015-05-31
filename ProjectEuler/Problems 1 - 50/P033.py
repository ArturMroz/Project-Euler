# https://projecteuler.net/problem=33
# Find the value of the denominator of the product
# of four non-trivial fractions

import fractions as f

result = 1
n = 100


def check(a, b, i, j):
    global result
    x = f.Fraction(int(a), int(b))
    y = f.Fraction(i, j)
    if x == y:
        result *= x

for i in range(11, n):
    for j in range(i + 1, n):
        if not i % 10 or not j % 10:
            continue

        a, b = str(i), str(j)

        if a[0] == b[0]:
            check(a[1], b[1], i, j)
        elif a[0] == b[1]:
            check(a[0], b[1], i, j)
        elif a[1] == b[0]:
            check(a[0], b[1], i, j)
        elif a[1] == b[1]:
            check(a[0], b[0], i, j)

print(result.denominator)
