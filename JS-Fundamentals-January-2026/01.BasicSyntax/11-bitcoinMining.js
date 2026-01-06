function printBitcoinMiningResult(input) {
    const bitcoinPrice = 11949.16;
    const goldPrice = 67.51;

    let money = 0;
    let bitcoins = 0;
    let firstDay = 0;

    for (let i = 0; i < input.length; i++) {
        let gold = input[i];

        if ((i + 1) % 3 === 0) {
            gold *= 0.7;
        }

        money += gold * goldPrice;

        while (money >= bitcoinPrice) {
            money -= bitcoinPrice;
            bitcoins++;

            if (bitcoins === 1) {
                firstDay = i + 1;
            }
        }
    }

    console.log(`Bought bitcoins: ${bitcoins}`);

    if (bitcoins > 0) {
        console.log(`Day of the first purchased bitcoin: ${firstDay}`);
    }

    console.log(`Left money: ${money.toFixed(2)} lv.`);
}
