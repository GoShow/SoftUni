function charactersInRange(char1, char2) {
    function getSmallerNumber(num1, num2) {
        return num1 < num2 ? num1 : num2;
    }

    function getBiggerNumber(num1, num2) {
        return num1 > num2 ? num1 : num2;
    }

    function getRange(start, end) {
        let result = [];

        for (let i = start + 1; i < end; i++) {
            result.push(String.fromCharCode(i));
        }

        return result;
    }

    let code1 = char1.charCodeAt(0);
    let code2 = char2.charCodeAt(0);

    let start = getSmallerNumber(code1, code2);
    let end = getBiggerNumber(code1, code2);

    let characters = getRange(start, end);

    console.log(characters.join(' '));
}
