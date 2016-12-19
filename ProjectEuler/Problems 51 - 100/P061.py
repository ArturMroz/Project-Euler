# https://projecteuler.net/problem=61
# Find the sum of the only ordered set of six cyclic 4-digit numbers for which
# each polygonal type: triangle, square, pentagonal, hexagonal, heptagonal,
# and octagonal, is represented by a different number in the set.


class SolutionFound(Exception):
    pass


def triangle(n): return (n * (n + 1)) // 2
def square(n): return n * n
def pentagonal(n): return (n * (3 * n - 1)) // 2
def hexagonal(n): return n * (2 * n - 1)
def heptagonal(n): return (n * (5 * n - 3)) // 2
def octagonal(n): return n * (3 * n - 2)


def solve(A, visited, chain):
    if len(chain) == 6 and chain[0] // 100 == chain[5] % 100:
        print(sum(chain))
        raise SolutionFound

    for i, polygonal in enumerate(A):
        if i in visited:
            continue

        # continue building chain for numbers that are cyclic (last two digits
        # of current number are first two of the next number)
        for num in [x for x in polygonal if x // 100 == chain[-1] % 100]:
            solve(A, visited + [i], chain + [num])


# reverse order of functions, so the functions with lower 
# number of elements are in front (less checks that way)
funs = [triangle, square, pentagonal, hexagonal, heptagonal, octagonal][::-1]

# array containing values for all 6 polygonal functions
A = []
for f in funs:
    temp = []
    n = 1
    while True:
        y = f(n)
        n += 1
        # we're interested only in 4-digit numbers 
        if y < 1000:
            continue
        if y > 9999:
            break
        temp.append(y)
    A.append(temp)


try:
    for y in A[0]:
        solve(A, [0], [y])
except SolutionFound:
    pass
