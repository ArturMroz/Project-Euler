# https://projecteuler.net/problem=58
# What is the side length of the square spiral for which 
# the ratio of primes along both diagonals first falls below 10%?


using Primes

lenght = 1
primes_cnt = 0
total_cnt = 1
ratio = 1
i = 1

while ratio > 0.10
    lenght += 2

    for corner in 1:4
        i += lenght - 1
        primes_cnt += isprime(i)
        total_cnt += 1
    end
        
    ratio = primes_cnt / total_cnt
end

println(lenght) 