function ladybugs(input) {
    let fieldSize = Number(input[0]);

    // Create field filled with 0
    let field = [];
    for (let index = 0; index < fieldSize; index++) {
        field[index] = 0;
    }

    // Read initial ladybug positions
    let initialPositions = input[1].split(' ');
    for (let i = 0; i < initialPositions.length; i++) {
        let position = Number(initialPositions[i]);

        if (position >= 0 && position < fieldSize) {
            field[position] = 1;
        }
    }

    // Process commands
    for (let i = 2; i < input.length; i++) {
        let commandParts = input[i].split(' ');

        let startIndex = Number(commandParts[0]);
        let direction = commandParts[1];
        let flyLength = Number(commandParts[2]);

        // Invalid index or no ladybug → do nothing
        if (
            startIndex < 0 ||
            startIndex >= fieldSize ||
            field[startIndex] !== 1
        ) {
            continue;
        }

        // Ladybug leaves current position
        field[startIndex] = 0;

        // Change direction
        if (direction === 'left') {
            flyLength = -flyLength;
        }

        let currentIndex = startIndex;

        while (true) {
            currentIndex += flyLength;

            // Fly out of the field
            if (currentIndex < 0 || currentIndex >= fieldSize) {
                break;
            }

            // Empty cell → land
            if (field[currentIndex] === 0) {
                field[currentIndex] = 1;
                break;
            }
        }
    }

    console.log(field.join(' '));
}
