# https://projecteuler.net/problem=42
# How many triangle words are in input

with open('../Resources/p042_words.txt') as f:
    ans = 0
    words = f.read().replace('"', '').split(',')
    triangles = {x * (x + 1) // 2 for x in range(20)}

    for word in words:
        s = sum(ord(c) - 64 for c in word)
        ans += s in triangles

    print(ans)
