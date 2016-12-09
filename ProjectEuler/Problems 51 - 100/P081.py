# https://projecteuler.net/problem=81
# Find the minimal path sum, in matrix.txt  a 31K text file containing a 80 by 80 matrix,
# from the top left to the bottom right by only moving right and down.


with open("../Resources/p081_matrix.txt") as f:
    A = [[int(x) for x in line.split(',')] for line in f]

# fill top and left edge of matrix
for i in range(1, len(A)):
    A[0][i] += A[0][i - 1]
    A[i][0] += A[i - 1][0]

# dynamic programming approach: calculate minimal paths for submatrices first
# starting from top left corner
for y in range(1, len(A)):
    for x in range(1, len(A)):
        A[y][x] += min(A[y - 1][x], A[y][x - 1])

print(A[-1][-1])
