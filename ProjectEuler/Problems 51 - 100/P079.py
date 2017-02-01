# https://projecteuler.net/problem=79
# The text file contains fifty successful login attempts.
# Analyse the file so as to determine the shortest possible passcode
# of unknown length.


# solution: find all successors for each digit analysing all the login attempts
# first digit in passcode should have the largest amount of successors in
# login attempts, last digit should have zero successors
with open('../Resources/p079_keylog.txt') as f:
    login_attempts = [line.strip() for line in f]

    # get only those digits that have been used in login attempts
    unique_digits = set(''.join(login_attempts))

    # dict holding number of unique successors for each digit
    successors = {}

    for digit in unique_digits:
        # array holding all successors for current digit
        temp_successors = []
        for attempt in login_attempts:
            ind = attempt.find(digit)

            # if login attempt contais digit, add all its successors
            # from this attempt to helper array
            if ind > -1:
                temp_successors += list(attempt[ind + 1::])

        # after all successors have been found for current digit,
        # save the number of unique successors to dict
        successors[digit] = len(set(temp_successors))

    # sort by number of successors
    sorted_succ = sorted(successors.items(),
                         key=lambda value: value[1],
                         reverse=True)

    answer = ''.join(x[0] for x in sorted_succ)
    print(answer)
