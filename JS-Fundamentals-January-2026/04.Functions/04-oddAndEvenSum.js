function printOddAndEvenSum(number) {
    function sumOdd(num) {
        let oddSum = 0;
        while (num > 0) {
            let digit = num % 10;
            if (digit % 2 !== 0) {
                oddSum += digit;
            }
            num = parseInt(num / 10);
        }
        return oddSum;
    }

    function sumEven(num) {
        let evenSum = 0;
        while (num > 0) {
            let digit = num % 10;
            if (digit % 2 === 0) {
                evenSum += digit;
            }
            num = parseInt(num / 10);
        }
        return evenSum;
    }

    const oddSum = sumOdd(number);
    const evenSum = sumEven(number);

    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
}