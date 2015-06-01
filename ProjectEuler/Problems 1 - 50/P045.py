# https://projecteuler.net/problem=45
# Find the next triangle number that is also pentagonal and hexagonal.

# lim = 100000
# no need to generate triangle numbers as every
# triangle number is also a hexagonal number;
# pentagonal = {n * (3 * n - 1) // 2 for n in range(166, lim)}
# hexagonal = {n * (2 * n - 1) for n in range(144, lim)}
# print(pentagonal & hexagonal)

# start from n known from the problem description
n = 144
while True:
    h = n * (2 * n - 1)
    k = (1 + (1 + 24 * h) ** 0.5) / 6
    if k == int(k):
        print(h)
        break
    n += 1
