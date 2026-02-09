function inventory(input) {
    let items = input[0].split(", ");

    for (let i = 1; i < input.length; i++) {
        let tokens = input[i].split(" - ");;

        let command = tokens[0];

        if (command === "Craft!") {
            break;
        }

        let data = tokens[1];

        switch (command) {
            case "Collect":
                if (!items.includes(data)) {
                    items.push(data);
                }
                break;
            case "Drop":
                let dropIndex = items.indexOf(data);
                if (dropIndex !== -1) {
                    items.splice(dropIndex, 1);
                }
                break;
            case "Combine Items":
                let itemTokens = data.split(":");
                let oldItem = itemTokens[0];
                let newItem = itemTokens[1];
                let oldIndex = items.indexOf(oldItem);
                if (oldIndex !== -1) {
                    items.splice(oldIndex + 1, 0, newItem);
                }
                break;
            case "Renew":
                let renewIndex = items.indexOf(data);
                if (renewIndex !== -1) {
                    items.splice(renewIndex, 1);
                    items.push(data);
                }
                break;
        }
    }

    console.log(items.join(", "));
}
