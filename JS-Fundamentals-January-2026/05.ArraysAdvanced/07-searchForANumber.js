function printNumberCount(numbers, commands) {
    let takeCount = commands[0];
    let deleteCount = commands[1];
    let searchNumber = commands[2];

    let takenNumbers = numbers.slice(0, takeCount);
    takenNumbers.splice(0, deleteCount);

    let count = 0;
    for (let number of takenNumbers) {
        if (number === searchNumber) {
            count++;
        }
    }

    console.log(`Number ${searchNumber} occurs ${count} times.`);
}
