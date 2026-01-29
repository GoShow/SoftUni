function printIsPerfectNumber(number) {
    let divisorSum = 0;

    for (let divisor = 1; divisor <= number / 2; divisor++) {
        if (number % divisor === 0) {
            divisorSum += divisor;
        }
    }

    if (divisorSum === number) {
        console.log("We have a perfect number!");
    } else {
        console.log("It's not so perfect.");
    }
}
