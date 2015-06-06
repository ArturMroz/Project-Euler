# https://projecteuler.net/problem=55
# How many Lychrel numbers are there below ten-thousand?


ans = 0
for i in range(10000):
    for j in range(50):
        i += int(str(i)[::-1])
        if str(i) == str(i)[::-1]:
            break
    ans += j == 49
print(ans)
