# https://projecteuler.net/problem=51
# Find the smallest prime which, by replacing part of the number
# with the same digit, is part of an eight prime value family.

from collections import Counter


# using eratosthenes sieve to pregenerate primes
def eratosthenes(lim):
    a = [True] * lim
    a[0] = a[1] = False

    for i, v in enumerate(a):
        if v:
            yield i
            for n in range(i * i, lim, i):
                a[n] = False


def number_to_digits(number):
    temp = []
    while number > 0:
        temp.append(number % 10)
        number //= 10

    return temp


def digits_to_number(digits):
    number = 0
    k = 1
    for d in digits:
        number += d * k
        k *= 10

    return number


def get_family(digits, digit_to_replace):
    fails = 0
    family = []
    # create family by replacing digits in current number
    for new_digit in range(0, 10):
        new_number = digits[:]
        for i, digit in enumerate(digits):
            if digit == digit_to_replace:
                new_number[i] = new_digit

        new_number = digits_to_number(new_number)
        if new_number not in primes_set:
            fails += 1
            # we're looking for 8 prime value family, so 2 fails are allowed
            if fails > 2:
                return None

            continue

        # make sure all new numbers have the same number of digits
        if len(str(new_number)) == len(digits):
            family.append(new_number)

    return family


lim = 1000000
primes = list(eratosthenes(lim))
# creating set for quick primality checks
primes_set = set(primes)

for prime in primes:
    if prime < 100000:
        continue

    digits = number_to_digits(prime)
    # get the most common digits in number so we can replace them
    cnt = Counter(digits)
    if len(digits) == len(cnt):    # no repeated digits, skip
        continue
    digit_to_replace = cnt.most_common(1)[0][0]

    family = get_family(digits, digit_to_replace)
    if family and len(family) == 8:
        print(family[0])
        break
