# https://projecteuler.net/problem=26
# Find the value of d < 1000 for which 1/d contains the longest
# recurring cycle in its decimal fraction part.

import re
import decimal as d

lim = 1000
d.setcontext(d.Context(prec=2 * lim))


def longest_substring(s):
    maxlen = 0
    r = re.compile(r"(.+?)\1+")
    for match in r.finditer(s):
        maxlen = max(maxlen, len(match.group(1)))
    return maxlen

ans = 0, 0
for i in range(2, lim):
    s = str(1 / d.Decimal(i))[2:]
    curr = longest_substring(s)
    if curr > ans[1]:
        ans = i, curr

print(ans[0])
