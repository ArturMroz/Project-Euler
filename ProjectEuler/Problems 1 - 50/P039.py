# https://projecteuler.net/problem=39
# For which value of perimeter p ≤ 1000, is the number of
# possible right angle triangles maximised?

ans = maxn = 0
for p in range(1000):
    maxcurr = 0
    a = 1
    while a < p // 3:
        a += 1
        b = a + 1
        c = p - a - b
        while b < c:
            b += 1
            c -= 1
            if a * a + b * b == c * c:
                maxcurr += 1
                if maxcurr > maxn:
                    maxn = maxcurr
                    ans = p
print(ans)
