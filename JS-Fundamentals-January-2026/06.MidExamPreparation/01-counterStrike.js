function solve(input) {
    let energy = Number(input[0]);
    let wonBattles = 0;

    for (let i = 1; i < input.length; i++) {
        let command = input[i];

        if (command === "End of battle") {
            console.log(`Won battles: ${wonBattles}. Energy left: ${energy}`);
            return;
        }

        let distance = Number(command);

        if (energy < distance) {
            console.log(`Not enough energy! Game ends with ${wonBattles} won battles and ${energy} energy`);
            return;
        }

        energy -= distance;
        wonBattles++;

        if (wonBattles % 3 === 0) {
            energy += wonBattles;
        }
    }
}