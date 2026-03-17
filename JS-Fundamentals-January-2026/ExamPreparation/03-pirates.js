function solve(input) {

    let cities = {};
    let line = input.shift();

    while (line !== "Sail") {
        let [town, population, gold] = line.split("||");
        population = Number(population);
        gold = Number(gold);

        if (!cities[town]) {
            cities[town] = { population: 0, gold: 0 };
        }

        cities[town].population += population;
        cities[town].gold += gold;

        line = input.shift();
    }

    line = input.shift();

    while (line !== "End") {

        let [command, town, value1, value2] = line.split("=>");

        if (command === "Plunder") {

            let people = Number(value1);
            let gold = Number(value2);

            cities[town].population -= people;
            cities[town].gold -= gold;

            console.log(`${town} plundered! ${gold} gold stolen, ${people} citizens killed.`);

            if (cities[town].population <= 0 || cities[town].gold <= 0) {
                delete cities[town];
                console.log(`${town} has been wiped off the map!`);
            }

        } else if (command === "Prosper") {

            let gold = Number(value1);

            if (gold < 0) {
                console.log("Gold added cannot be a negative number!");
            } else {
                cities[town].gold += gold;
                console.log(`${gold} gold added to the city treasury. ${town} now has ${cities[town].gold} gold.`);
            }
        }

        line = input.shift();
    }

    let citiesCount = Object.keys(cities).length;

    if (citiesCount > 0) {
        console.log(`Ahoy, Captain! There are ${citiesCount} wealthy settlements to go to:`);

        for (let town in cities) {
            console.log(`${town} -> Population: ${cities[town].population} citizens, Gold: ${cities[town].gold} kg`);
        }
    } else {
        console.log("Ahoy, Captain! All targets have been plundered and destroyed!");

    }
}