function bombNumbers(numbers, bombInfo) {
    let bomb = bombInfo[0];
    let power = bombInfo[1];

    while (numbers.includes(bomb)) {
        let index = numbers.indexOf(bomb);

        let start = Math.max(index - power, 0);
        let count = power * 2 + 1;

        numbers.splice(start, count);
    }

    let sum = 0;
    for (let num of numbers) {
        sum += num;
    }

    console.log(sum);
}