function printArePalindromeIntegers(numbers) {
    function isPalindrome(num) {
        let numString = num.toString();
        let reversed = numString.split('').reverse().join('');
        return numString === reversed;
    }

    for (let number of numbers) {
        console.log(isPalindrome(number));
    }
}