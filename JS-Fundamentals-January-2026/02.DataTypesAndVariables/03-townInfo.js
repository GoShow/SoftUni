function printTownInfo(town, population, area) {
    let isValid = true;
    if (town.length < 3 ) {
        console.log('Town name must be at least 3 characters!');
        isValid = false;
    }
    
    if (population < 0) {
        console.log('Population must be a positive number!');
        isValid = false;
    }

    if (area < 0) {
        console.log('Area must be a positive number!');
        isValid = false;
    }

    if (isValid) {
        console.log(`Town ${town} has population of ${population} and area ${area} square km.`);
    }
}