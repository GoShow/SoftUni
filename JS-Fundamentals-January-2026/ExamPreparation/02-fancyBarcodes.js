function solve(input) {
    let n = Number(input.shift());
    let pattern = /@#+([A-Z][A-Za-z0-9]{4,}[A-Z])@#+/;

    for (let i = 0; i < n; i++) {
        let barcode = input[i];
        let match = barcode.match(pattern);

        if (!match) {
            console.log("Invalid barcode");
        } else {
            let product = match[1];
            let digits = product.match(/\d/g)

            if (digits) {
                console.log(`Product group: ${digits.join("")}`);
            } else {
                console.log("Product group: 00");
            }
        }
    }
}