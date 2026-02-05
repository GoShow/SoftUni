function printTrain(arr) {
    let wagons = arr.shift().split(' ').map(Number);
    let maxCapacity = Number(arr.shift());

    function addPassengers(passengers) {
        for (let i = 0; i < wagons.length; i++) {
            if (wagons[i] + passengers <= maxCapacity) {
                wagons[i] += passengers;
                break;
            }
        }
    }

    for (let i = 0; i < arr.length; i++) {
        let tokens = arr[i].split(' ');

        if (tokens[0] === 'Add') {
            wagons.push(Number(tokens[1]));
        } else {
            addPassengers(Number(tokens[0]));
        }
    }

    console.log(wagons.join(' '));
}
