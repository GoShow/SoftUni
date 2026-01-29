function passwordValidator(password) {
    let isValid = true;

    function isInRange(value, min, max) {
        return value >= min && value <= max;
    }

    function isLengthValid(password) {
        return isInRange(password.length, 6, 10);
    }

    function hasOnlyLettersAndDigits(password) {
        for (let character of password) {
            let asciiCode = character.charCodeAt(0);

            let isDigit = isInRange(asciiCode, 48, 57);
            let isUppercaseLetter = isInRange(asciiCode, 65, 90);
            let isLowercaseLetter = isInRange(asciiCode, 97, 122);

            if (!isDigit && !isUppercaseLetter && !isLowercaseLetter) {
                return false;
            }
        }
        return true;
    }

    function hasAtLeastTwoDigits(password) {
        let digitCount = 0;

        for (let character of password) {
            let asciiCode = character.charCodeAt(0);

            if (isInRange(asciiCode, 48, 57)) {
                digitCount++;
            }
        }

        return digitCount >= 2;
    }

    if (!isLengthValid(password)) {
        console.log("Password must be between 6 and 10 characters");
        isValid = false;
    }

    if (!hasOnlyLettersAndDigits(password)) {
        console.log("Password must consist only of letters and digits");
        isValid = false;
    }

    if (!hasAtLeastTwoDigits(password)) {
        console.log("Password must have at least 2 digits");
        isValid = false;
    }

    if (isValid) {
        console.log("Password is valid");
    }
}
