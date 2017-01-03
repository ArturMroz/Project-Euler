# https://projecteuler.net/problem=62
# Find the smallest cube for which exactly five permutations of its digits
# are cube.

from collections import defaultdict


def solve():
    cubes_dict = defaultdict(list)
    i = 1
    while True:
        cube = i ** 3
        # create a key by ordering digits in current cube;
        # all permutations will have the same key
        key = ''.join(sorted(str(cube)))
        cubes_dict[key].append(cube)
        if len(cubes_dict[key]) == 5:
            return cubes_dict[key][0]
        i += 1


print(solve())
