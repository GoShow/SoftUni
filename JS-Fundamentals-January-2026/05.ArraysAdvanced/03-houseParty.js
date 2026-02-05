function printHousePartyGuests(input) {
    let guests = [];

    for (let line of input) {
        let tokens = line.split(' ');
        let name = tokens[0];

        if (line.includes('is going')) {
            if (guests.includes(name)) {
                console.log(`${name} is already in the list!`);
            } else {
                guests.push(name);
            }
        } else {
            if (!guests.includes(name)) {
                console.log(`${name} is not in the list!`);
            } else {
                let index = guests.indexOf(name);
                guests.splice(index, 1);
            }
        }
    }

    console.log(guests.join('\n'));
}