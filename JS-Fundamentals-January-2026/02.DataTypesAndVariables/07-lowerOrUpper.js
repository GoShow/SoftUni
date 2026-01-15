function printLowerOrUpper(character) {
    let asciiCode = character.charCodeAt(0);
    
    if (asciiCode >= 65 && asciiCode <= 90) {
        console.log('upper-case');
    } else {
        console.log('lower-case');
    }
}