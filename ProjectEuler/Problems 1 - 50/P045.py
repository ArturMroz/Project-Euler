# https://projecteuler.net/problem=45
# Find the next triangle number that is also pentagonal and hexagonal.

# start from n known from the problem description
n = 144
while True:
    h = n * (2 * n - 1)
    k = (1 + (1 + 24 * h) ** 0.5) / 6
    if k == int(k):
        print(h)
        break
    n += 1
