import re
import decimal as d
d.setcontext(d.Context(prec=2000))


def longest_substring(s):
    maxp = 0
    r = re.compile(r"(.+?)\1+")
    for match in r.finditer(s):
        maxp = max(maxp, len(match.group(1)))

    return maxp

ans = 0, 0
for i in range(2, 1000):
    m = 1 / d.Decimal(i)
    s = str(m)[2:]
    curr = longest_substring(s)
    if curr > ans[1]:
        ans = i, curr

print(ans[0])
