function printAddAndSubtract(numbers) {
    let originalSum = 0;
    let modifiedSum = 0;
    let modifiedArr = [];

    for (let i = 0; i < numbers.length; i++) {
        let num = numbers[i];
        originalSum += num;

        if (num % 2 === 0) {
            modifiedArr[i] = num + i;
        } else {
            modifiedArr[i] = num - i;
        }

        modifiedSum += modifiedArr[i];
    }

    console.log(`[ ${modifiedArr.join(', ')} ]`);
    console.log(originalSum);
    console.log(modifiedSum);
}
