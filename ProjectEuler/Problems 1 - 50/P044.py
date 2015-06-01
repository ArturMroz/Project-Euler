# https://projecteuler.net/problem=44
# Find the pair of pentagonal numbers, Pj and Pk, for which their sum and
# difference are pentagonal and D = |Pk − Pj| is minimised;
# what is the value of D?


def solve():
    # set for fast access and list for iterating over
    pentagonals = {x * (3 * x - 1) // 2 for x in range(1, 10000)}
    pentlist = sorted(pentagonals)
    for i, x in enumerate(pentlist):
        for y in pentlist[i:]:
            if x + y in pentagonals and y - x in pentagonals:
                return y - x

print(solve())
