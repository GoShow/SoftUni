function printMergedArrays(strings1, strings2) {
    let result = [];

    for (let i = 0; i < strings1.length; i++) {
        if (i % 2 === 0) {
            result[i] = Number(strings1[i]) + Number(strings2[i]);
        } else {
            result[i] = strings1[i] + strings2[i];
        }
    }

    console.log(result.join(' - '));
}
