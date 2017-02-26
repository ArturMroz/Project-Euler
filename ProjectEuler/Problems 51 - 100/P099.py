# Using base_exp.txt, a 22K text file containing one thousand lines
# with a base/exponent pair on each line, determine which line number has
# the greatest numerical value.


from math import log

maxnum = maxi = 0
i = 1

# solution: we can determine if a**b > c**d
# by checking instead if log(a**b) > log(c**d)
# which can be further rewritten as b * log(a) > d * log(c)
with open('../Resources/p099_base_exp.txt') as f:
    for line in f:
        base, exp = map(int, line.split(','))
        curr = exp * log(base)

        if curr > maxnum:
            maxnum = curr
            maxi = i

        i += 1

print(maxi)
