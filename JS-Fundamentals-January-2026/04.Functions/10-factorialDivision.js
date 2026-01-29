function printFactorialDivisionResult(firstNumber, secondNumber) {
    function factorial(number) {
        let result = 1;
        for (let i = 2; i <= number; i++) {
            result *= i;
        }
        return result;
    }

    let firstFactorial = factorial(firstNumber);
    let secondFactorial = factorial(secondNumber);

    let divisionResult = firstFactorial / secondFactorial;

    console.log(divisionResult.toFixed(2));
}
