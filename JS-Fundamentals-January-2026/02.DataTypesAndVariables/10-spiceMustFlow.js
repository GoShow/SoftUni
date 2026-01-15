function printSpiceExtraction(startingYield) {
    let totalSpice = 0;
    let days = 0;
    let currentYield = startingYield;

    while (currentYield >= 100) {
        days++;
        totalSpice += currentYield;
        totalSpice -= 26;
        currentYield -= 10;
    }

    if (totalSpice >= 26) {
        totalSpice -= 26;
    } else {
        totalSpice = 0;
    }

    console.log(days);
    console.log(totalSpice);
}