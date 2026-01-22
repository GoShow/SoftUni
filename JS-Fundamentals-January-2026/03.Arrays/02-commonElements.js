function printCommonElements(elements1, elements2) {
    for (let element1 of elements1) {
        for (let element2  of elements2) {
            if (element1 === element2) {
                console.log(element1);
                break;
            }
        }
    }
}