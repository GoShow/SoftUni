function printIndexBetweenEqualSums(numbers) {
    let totalSum = 0;

    for (let number of numbers) {
        totalSum += number;
    }

    let leftSum = 0;

    for (let index = 0; index < numbers.length; index++) {
        let rightSum = totalSum - leftSum - numbers[index];

        if (leftSum === rightSum) {
            console.log(index);

            return;
        }

        leftSum += numbers[index];
    }

    console.log("no");
}