function printTownInfo(townName, population, area) {
    let isTownInfoValid = true;

    if (townName.length < 3) {
        console.log("Town name must be at least 3 characters!");
        isTownInfoValid = false;
    }

    if (population < 0) {
        console.log("Population must be a positive number!");
        isTownInfoValid = false;
    }

    if (area < 0) {
        console.log("Area must be a positive number!");
        isTownInfoValid = false;
    }

    if (isTownInfoValid){
        console.log(`Town ${townName} has population of ${population} and area ${area} square km.`)
    }
}