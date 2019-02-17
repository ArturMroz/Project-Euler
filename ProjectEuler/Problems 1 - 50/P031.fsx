let coins = [| 1; 2; 5; 10; 20; 50; 100; 200 |]
let n = 200;

let state = Array.zeroCreate (n + 1)
state.[0] <- 1;

for coin in coins do
    for j in coin..n do
        state.[j] <- state.[j] + state.[j - coin]

Array.last state