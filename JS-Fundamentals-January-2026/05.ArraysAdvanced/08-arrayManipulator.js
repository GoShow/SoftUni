function printManipulatedArray(numbers, commands) {
    for (let command of commands) {
        let tokens = command.split(' ');
        let action = tokens[0];

        switch (action) {
            case 'add': {
                let index = Number(tokens[1]);
                let element = Number(tokens[2]);
                numbers.splice(index, 0, element);
                break;
            }
            case 'addMany': {
                let index = Number(tokens[1]);
                let elements = tokens.slice(2).map(Number);
                numbers.splice(index, 0, ...elements);
                break;
            }
            case 'contains': {
                let element = Number(tokens[1]);
                console.log(numbers.indexOf(element));
                break;
            }
            case 'remove': {
                let index = Number(tokens[1]);
                numbers.splice(index, 1);
                break;
            }
            case 'shift': {
                let positions = Number(tokens[1]);
                for (let i = 0; i < positions; i++) {
                    numbers.push(numbers.shift());
                }
                break;
            }
            case 'sumPairs': {
                let summed = [];
                for (let i = 0; i < numbers.length; i += 2) {
                    if (i + 1 < numbers.length) {
                        summed.push(numbers[i] + numbers[i + 1]);
                    } else {
                        summed.push(numbers[i]);
                    }
                }
                numbers = summed;
                break;
            }
            case 'print': {
                console.log(`[ ${numbers.join(', ')} ]`);
                return;
            }
        }
    }
}
