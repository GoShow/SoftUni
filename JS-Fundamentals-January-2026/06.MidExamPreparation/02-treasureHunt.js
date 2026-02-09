function solve(input) {
    let chest = input[0].split("|");

    for (let i = 1; i < input.length; i++) {
        let tokens = input[i].split(" ");

        if (tokens[0] === "Yohoho!") {
            break;
        }

        let command = tokens[0];

        switch (command) {
            case "Loot":
                for (let j = 1; j < tokens.length; j++) {
                    let item = tokens[j];
                    if (!chest.includes(item)) {
                        chest.unshift(item);
                    }
                }
                break;
            case "Drop":
                let index = Number(tokens[1]);
                if (index >= 0 && index < chest.length) {
                    let dropped = chest.splice(index, 1);
                    chest.push(dropped[0]);
                }
                break;
            case "Steal":
                let count = Number(tokens[1]);
                let stolen = chest.splice(-count);

                console.log(stolen.join(", "));
                break;
        }
    }

    if (chest.length === 0) {
        console.log("Failed treasure hunt.");
    } else {
        let totalLength = 0;

        for (let item of chest) {
            totalLength += item.length;
        }

        let average = totalLength / chest.length;
        console.log(`Average treasure gain: ${average.toFixed(2)} pirate credits.`);
    }
}