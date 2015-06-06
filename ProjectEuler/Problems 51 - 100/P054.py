# https://projecteuler.net/problem=54
# The file, poker.txt, contains one-thousand random hands dealt to two players
# How many hands does Player 1 win?

from collections import Counter

order = '23456789TJQKA'

def val(x): return order.index(x)

def rank(h):
    c = Counter(x[0] for x in h).most_common()
    sh = sorted((val(c[0]) for c in h), reverse=True)

    # all of the same suit
    if all(h[0][1] == rest[1] for rest in h[1:]):
        if sh[0] - sh[-1] == 4 and len(c) == 5:
            if sh[0] == 13:
                # royal flush
                return 9,
            else:
                # straight flush
                return 8, sh[0]
        else:
            # flush
            return 5, sh[0]

    # four of a kind
    if c[0][1] == 4:
        return 7, val(c[0][0])

    # full house
    if c[0][1] == 3 and c[1][1] == 2:
        return 6, val(c[0][0])

    # straight
    if sh[0] - sh[-1] == 4 and len(c) == 5:
        return 4, sh[0]

    # three of a kind
    if c[0][1] == 3:
        return 3, val(c[0][0])

    # two pairs
    if c[0][1] == c[1][1] == 2:
        return 2, val(c[0][0]), val(c[1][0]), val(c[2][0])

    # one pair
    if c[0][1] == 2:
        return 1, val(c[0][0]), sh

    return 0, sh

hands = (l.split() for l in open("../Resources/p054_poker.txt"))
print(sum(rank(hand[:5]) > rank(hand[5:]) for hand in hands))
