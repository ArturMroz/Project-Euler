# https://projecteuler.net/problem=63
# How many n-digit positive integers exist which are also an nth power?

ans = 0
for x in range(1, 100):
    for y in range(1, 100):
        ans += len(str(x ** y)) == y

print(ans)
