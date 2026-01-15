function printSumOfDigits(number) {
    let result = 0;
    do {
        let last = number % 10;
        number = parseInt(number / 10);
        result += last;
    } while (number > 0);
    
    console.log(result);
}