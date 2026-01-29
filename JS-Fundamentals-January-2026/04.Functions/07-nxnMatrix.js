function printNxNMatrix(number) {
    for (let row = 0; row < number; row++) {
        let currentRow = [];

        for (let col = 0; col < number; col++) {
            currentRow.push(number);
        }

        console.log(currentRow.join(' '));
    }
}