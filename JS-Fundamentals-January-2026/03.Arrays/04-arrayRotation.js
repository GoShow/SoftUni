function printRotatedArray(array, rotationsCount) {
    let rotatedArray = [];

    let rotationsIndex = rotationsCount % array.length;

    if (rotationsIndex > 0) {
        for (let index = rotationsIndex; index < array.length; index++) {
            rotatedArray.push(array[index]);
        }

        for (let index = 0; index < rotationsIndex; index++) {
            rotatedArray.push(array[index]);
        }

        console.log(rotatedArray.join(' '));
    }
    else{
        console.log(array.join(' '))
    }

    // for(let i = 0; i < rotationsCount; i++){
    //     let element = array.shift();
    //     array.push(element);
    // }

    // console.log(array.join(' '));
}