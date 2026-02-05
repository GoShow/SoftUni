function printGladiatorInventory(input) {
    let inventory = input.shift().split(' ');

    for (let line of input) {
        let [command, item] = line.split(' ');

        switch (command) {
            case 'Buy':
                if (!inventory.includes(item)) {
                    inventory.push(item);
                }
                break;

            case 'Trash':
                if (inventory.includes(item)) {
                    let index = inventory.indexOf(item);
                    inventory.splice(index, 1);
                }
                break;

            case 'Repair':
                if (inventory.includes(item)) {
                    let index = inventory.indexOf(item);
                    inventory.splice(index, 1);
                    inventory.push(item);
                }
                break;

            case 'Upgrade':
                let [equipment, upgrade] = item.split('-');
                if (inventory.includes(equipment)) {
                    let index = inventory.indexOf(equipment);
                    inventory.splice(index + 1, 0, `${equipment}:${upgrade}`);
                }
                break;
        }
    }

    console.log(inventory.join(' '));
}
