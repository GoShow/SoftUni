function printAddAndSubtract(a, b, c) {
    function add(num1, num2) {
        return num1 + num2;
    }

    function subtract(num1, num2) {
        return num1 - num2;
    }

    let sumResult = add(a, b);
    let result = subtract(sumResult, c);

    console.log(result);
}