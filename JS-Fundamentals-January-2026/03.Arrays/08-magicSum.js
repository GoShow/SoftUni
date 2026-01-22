function printUniquePairs(numbers, magicSum) {
    for (let firstIndex = 0; firstIndex < numbers.length; firstIndex++) {
        for (let secondIndex = firstIndex + 1; secondIndex < numbers.length; secondIndex++) {
            let currentSum = numbers[firstIndex] + numbers[secondIndex];

            if (currentSum === magicSum) {
                console.log(numbers[firstIndex] + ' ' + numbers[secondIndex]);
            }
        }
    }
}