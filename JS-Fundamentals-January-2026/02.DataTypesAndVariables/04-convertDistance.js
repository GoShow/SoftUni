function printConvertedDistance(meters){
    const metersInKm = 1000;
    const milesInKm = 0.621371

    let kilometers = meters / metersInKm;
    let miles = kilometers * milesInKm;

    console.log(`${meters} meters is equal to ${kilometers} kilometers.`);
    console.log(`${kilometers} kilometers is equal to ${miles.toFixed(2)} miles.`);
}