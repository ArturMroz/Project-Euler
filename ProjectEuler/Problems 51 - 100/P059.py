# https://projecteuler.net/problem=59
# Decrypt the message and find the sum of the ASCII values in the original text

from itertools import cycle
from collections import Counter


# solution #1
# the most common character in english language is space (ASCII 32)
# because key length = 3, we can divide given text in 3 subarrays;
# first, we find encrypted value for space in each subarray of given text
# then by XORing it by 32 (space ASCII) we'll get the key
def frequency_map(numbers):

    def get_key(arr):
        return Counter(arr).most_common(1)[0][0] ^ 32

    a = get_key(numbers[::3])
    b = get_key(numbers[1::3])
    c = get_key(numbers[2::3])

    key = [a, b, c]
    it = cycle(key)

    decrypted = [i ^ next(it) for i in numbers]
    # print("".join(chr(i) for i in decrypted))
    print(sum(decrypted))


# solution #2
# decrypt text with every possible key combination
# until we find message that contains only plain text
def brute_force(numbers):
    decrypted = [0] * len(numbers)

    # key consist of three lower case characters: ASCII 97 - 122
    key = [97] * 3
    for x in range(0, 25):
        key[0] += 1
        key[1] = 97

        for y in range(0, 25):
            key[1] += 1
            key[2] = 97

            for z in range(0, 25):
                key[2] += 1
                it = cycle(key)
                found = True

                for i, n in enumerate(numbers):
                    # current decrypted character
                    c = n ^ next(it)

                    # check if character is alphanumeric or is one of
                    # allowed characters i.e. dot, space, bracket etc.
                    if c < 32 or c > 123 or c == 35 or (c > 90 and c < 97):
                        found = False
                        break

                    decrypted[i] = c

                if found:
                    # print("".join(chr(c) for c in decrypted))
                    print(sum(decrypted))
                    return


with open('../Resources/p059_cipher.txt') as f:
    numbers = [int(n) for n in f.read().split(',')]

    # brute_force(numbers)
    frequency_map(numbers)
