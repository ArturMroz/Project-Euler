# https://projecteuler.net/problem=56
# Considering natural numbers of the form, a^b, where a, b < 100,
# what is the maximum digital sum?


maxs = 0
for a in range(1, 100):
    for b in range(1, 100):
        maxs = max(sum(int(x) for x in str(a ** b)), maxs)
print(maxs)
