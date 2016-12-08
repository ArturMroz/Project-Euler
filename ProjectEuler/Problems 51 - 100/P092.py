# https://projecteuler.net/problem=92
# A number chain is created by continuously adding the square of the digits
# in a number to form a new number until it has been seen before.
# How many starting numbers below ten million will arrive at 89?


def get_digits(number):
    while number > 0:
        digit = number % 10
        number //= 10
        yield digit


answer = 0
cache = set()
for i in range(2, 10000000):
    new_number = i
    # store numbers which appeared in current chain
    temp = [new_number]
    while new_number != 1:
        if new_number in cache or new_number == 89:
            answer += 1
            # add current chain to cache
            cache.update(temp)
            break
        new_number = sum(d * d for d in get_digits(new_number))
        temp.append(new_number)

print(answer)
