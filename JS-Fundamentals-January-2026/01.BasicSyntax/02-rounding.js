function printRoundedNumber(number, precision) {
    if (precision > 15) {
        precision = 15;
    }

    let rounded = number.toFixed(precision);
    console.log(parseFloat(rounded));
}