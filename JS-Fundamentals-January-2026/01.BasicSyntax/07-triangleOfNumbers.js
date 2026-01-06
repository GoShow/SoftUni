function printTriangleOfNumbers(count) {
    for (let i = 1; i <= count; i++) {
        let result = '';

        for (let j = 1; j <= i; j++) {
            result += `${i} `
        }   

        console.log(result.trim())
    }
}
