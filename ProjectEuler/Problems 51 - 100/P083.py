# https://projecteuler.net/problem=83
# Find the minimal path sum, in matrix.txt, a 31K text file containing
# a 80 by 80 matrix, from the top left to the bottom right by moving
# left, right, up, and down.

import heapq


def push(queue, path, cost, x, y):
    heapq.heappush(queue, (cost + A[x][y], (x, y), path))


def dijkstra(A, start, end):
    queue = [(0, start, [])]
    seen = set()
    while True:
        cost, v, path = heapq.heappop(queue)
        if v not in seen:
            path = path + [v]
            seen.add(v)
            if v == end:
                return cost
            x, y = v
            if x + 1 < len(A):
                push(queue, path, cost, x + 1, y)
            if y + 1 < len(A):
                push(queue, path, cost, x, y + 1)
            if x - 1 >= 0:
                push(queue, path, cost, x - 1, y)
            if y - 1 >= 0:
                push(queue, path, cost, x, y - 1)


with open("../Resources/p083_matrix.txt") as f:
    A = [[int(x) for x in line.split(',')] for line in f]

cost = dijkstra(A, (0, 0), ((len(A) - 1,) * 2))
cost += A[0][0]
print(cost)
