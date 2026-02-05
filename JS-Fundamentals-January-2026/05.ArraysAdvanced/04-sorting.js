function printSortedArray(arr) {
    let numbers = arr.sort((a, b) => a - b);
    let result = [];

    while (numbers.length > 0) {
        let biggest = numbers.pop();
        
        result.push(biggest);
        
        if (numbers.length > 0) {
            let smallest = numbers.shift()

            result.push(smallest); 
        }
    }

    console.log(result.join(' '));
}