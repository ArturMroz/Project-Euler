# https://projecteuler.net/problem=52
# Find the smallest positive integer, x, such that 2x, 3x, 4x, 5x, and 6x,
# contain the same digits.


def digs(i, n=1): return sorted(str(i * n))

for i in range(99999, 1000000, 9):
    if digs(i) == digs(i, 2) == digs(i, 3) == digs(i, 4) == digs(i, 5) == digs(i, 6):
        print(i)
        break
