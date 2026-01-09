function printPyramidOfKingDjoser(base, increment) {
    let stone = 0;
    let marble = 0;
    let lapis = 0;
    let gold = 0;

    let step = 0;
    let currentBase = base;

    while (currentBase > 2) {
        step++;

        let totalArea = currentBase * currentBase;
        let innerArea = (currentBase - 2) * (currentBase - 2);
        let outerArea = totalArea - innerArea;

        stone += innerArea * increment;

        if (step % 5 === 0) {
            lapis += outerArea * increment;
        } else {
            marble += outerArea * increment;
        }

        currentBase -= 2;
    }

    step++;
    gold += currentBase * currentBase * increment;

    let finalHeight = Math.floor(step * increment);

    console.log(`Stone required: ${Math.ceil(stone)}`);
    console.log(`Marble required: ${Math.ceil(marble)}`);
    console.log(`Lapis Lazuli required: ${Math.ceil(lapis)}`);
    console.log(`Gold required: ${Math.ceil(gold)}`);
    console.log(`Final pyramid height: ${finalHeight}`);
}
