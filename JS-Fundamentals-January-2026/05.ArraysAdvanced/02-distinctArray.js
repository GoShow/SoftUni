function printDistinctArray(numbers) {
    let result = [];

    for (let number of numbers) {
        if (!result.includes(number)) {
            result.push(number);
        }
    }

    console.log(result.join(' '));
}