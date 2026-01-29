function printSmallestOfThreeNumbers(a, b, c) {
    function getSmallerNumber(x, y) {
        return x < y 
            ? x 
            : y;
    }

    let smallest = getSmallerNumber(a, b);
    smallest = getSmallerNumber(smallest, c);

    console.log(smallest);
}
