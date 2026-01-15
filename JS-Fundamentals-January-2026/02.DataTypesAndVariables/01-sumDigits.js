function printSumOfDigits(number){
    let sum = 0;

    while(number > 0){
        let lastDigit = number % 10;
        number = parseInt(number / 10);
        sum += lastDigit;
    }
    
    console.log(sum);
}
