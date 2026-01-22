function printTopIntegers(numbers) {
    let result = [];

    for (let i = 0; i < numbers.length; i++) {
        let isTopInteger = true;

        for (let j = i + 1; j < numbers.length; j++) {
            if (numbers[i] <= numbers[j]) {
                isTopInteger = false;
                break;
            }
        }

        if (isTopInteger) {
            result.push(numbers[i]);
        }
    }

    console.log(result.join(' '));
}