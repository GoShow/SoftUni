function dungeonestDark(dungeonRooms) {
    let health = 100;
    let coins = 0;

    let rooms = dungeonRooms.split('|');

    for (let roomIndex = 0; roomIndex < rooms.length; roomIndex++) {
        let roomParts = rooms[roomIndex].split(' ');
        let command = roomParts[0];
        let value = Number(roomParts[1]);

        if (command === 'potion') {
            let healedAmount = value;

            if (health + healedAmount > 100) {
                healedAmount = 100 - health;
            }

            health += healedAmount;

            console.log(`You healed for ${healedAmount} hp.`);
            console.log(`Current health: ${health} hp.`);
        } 
        else if (command === 'chest') {
            coins += value;
            console.log(`You found ${value} coins.`);
        } 
        else {
            // monster
            health -= value;

            if (health > 0) {
                console.log(`You slayed ${command}.`);
            } else {
                console.log(`You died! Killed by ${command}.`);
                console.log(`Best room: ${roomIndex + 1}`);
                return;
            }
        }
    }

    console.log("You've made it!");
    console.log(`Coins: ${coins}`);
    console.log(`Health: ${health}`);
}
