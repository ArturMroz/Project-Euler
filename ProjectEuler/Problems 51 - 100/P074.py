# https://projecteuler.net/problem=74
# How many chains, with a starting number below one million, contain exactly 
# sixty non-repeating terms?

from math import factorial


def get_digits(number):
    while number > 0:
        yield number % 10
        number //= 10


total = 0
cache = {}
for start in range(1000000):
    curr = start
    chain = [start]
    chain_lenght = 0

    while True:
        curr = sum(factorial(x) for x in get_digits(curr))

        # number already appeared in current chain, it's a loop
        if curr in chain:
            break

        # value of chain already caculated for that number
        # add it to current lenght
        if curr in cache:
            chain_lenght = cache[curr]
            break

        chain.append(curr)

    chain_lenght += len(chain)
    cache[start] = chain_lenght

    if chain_lenght == 60:
        total += 1

print(total)
