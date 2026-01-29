function printLoadingBar(percentage) {
    function concatCharacters(character, count) {
        let result = '';
        for (let i = 0; i < count; i++) {
            result += character;
        }
        return result;
    }

    let completedCount = percentage / 10;
    let remainingCount = 10 - completedCount;

    let percents = concatCharacters('%', completedCount);
    let dots = concatCharacters('.', remainingCount);

    let bar = `[${percents}${dots}]`;

    if (percentage === 100) {
        console.log("100% Complete!");
        console.log(bar);
    } else {
        console.log(`${percentage}% ${bar}`);
        console.log("Still loading...");
    }
}
