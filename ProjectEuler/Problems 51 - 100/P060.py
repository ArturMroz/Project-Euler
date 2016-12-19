def eratosthenes(lim):
    a = [True] * lim
    a[0] = a[1] = False

    for i, v in enumerate(a):
        if v:
            yield i
            for n in range(i * i, lim, i):
                a[n] = False


# faster than converting numbers to strings and joining them
def concat(a, b):
    order = 10
    while b >= order:
        order *= 10
    return a * order + b


def is_prime(n):
    if n == 2 or n == 3:
        return True
    if n % 2 == 0 or n % 3 == 0:
        return False

    i = 5
    w = 2
    while i * i <= n:
        if n % i == 0:
            return False
        i += w
        w = 6 - w
    return True


def all_prime(a, *others):
    for b in others:
        if not is_prime(concat(a, b)) or not is_prime(concat(b, a)):
            return False
    return True


P = list(eratosthenes(25000))
min_sum = float('inf')
lim = len(P) - 1

# brute force with 5 nested loops
# break the loops if current values sum is highger than found lowest sum
for i in range(0, 10):
    for j in range(i + 1, lim):
        if P[i] + P[j] * 4 >= min_sum:
            break
        if all_prime(P[i], P[j]):
            for k in range(j + 1, lim):
                if P[i] + P[j] + P[k] * 3 >= min_sum:
                    break
                if all_prime(P[k], P[i], P[j]):
                    for l in range(k + 1, lim):
                        if P[i] + P[j] + P[k] + P[l] * 2 >= min_sum:
                            break
                        if all_prime(P[l], P[i], P[j], P[k]):
                            for m in range(l + 1, lim):
                                if P[i] + P[j] + P[k] + P[l] + P[m] >= min_sum:
                                    break
                                if all_prime(P[m], P[i], P[j], P[k], P[l]):
                                    s = sum((P[m], P[i], P[j], P[k], P[l]))
                                    min_sum = min(min_sum, s)

print(min_sum)
