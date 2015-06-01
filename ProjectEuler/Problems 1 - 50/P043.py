# https://projecteuler.net/problem=43
# Find the sum of all 0 to 9 pandigital numbers with property described

from itertools import permutations

ans = 0
for nextperm in permutations("0123456789"):
    if nextperm[0] == '0':
        continue
    p = ''.join(nextperm)
    if int(p[7:10]) % 17 == 0 and int(p[6:9]) % 13 == 0 and \
       int(p[5:8]) % 11 == 0 and int(p[4:7]) % 7 == 0 and \
       int(p[3:6]) % 5 == 0 and int(p[2:5]) % 3 == 0 and int(p[1:4]) % 2 == 0:
        ans += int(p)
print(ans)
