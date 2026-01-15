function printConvertedDistance(meters) {
    const metersInKm = 1000;
    const milesInKm = 0.621371;

    let km = meters / metersInKm;
    let miles = km * milesInKm;
    
    console.log(`${meters} meters is equal to ${km} kilometers.`);
    console.log(`${km} kilometers is equal to ${miles.toFixed(2)} miles.`);
}