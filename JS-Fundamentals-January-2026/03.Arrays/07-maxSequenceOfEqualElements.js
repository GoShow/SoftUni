function printLongestEqualSequence(numbers) {
    let longestSequenceLength = 1;
    let longestSequenceValue = 0;

    let currentSequenceLength = 1;
    let currentSequenceValue = 0;

    for (let index = 0; index < numbers.length; index++) {
        if (numbers[index] === numbers[index - 1]) {
            currentSequenceLength++;
        } else {
            currentSequenceLength = 1;
            currentSequenceValue = numbers[index];
        }

        if (currentSequenceLength > longestSequenceLength) {
            longestSequenceLength = currentSequenceLength;
            longestSequenceValue = numbers[index];
        }
    }

    let result = [];
    for (let i = 0; i < longestSequenceLength; i++) {
        result.push(longestSequenceValue);
    }

    console.log(result.join(' '));
}

