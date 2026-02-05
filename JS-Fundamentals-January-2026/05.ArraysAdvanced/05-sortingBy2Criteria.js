function printArraySortByTwoCriteria(arr) {
    arr.sort((a, b) => {
        if (a.length !== b.length) {
            return a.length - b.length;
        }

        return a.toLowerCase().localeCompare(b.toLowerCase());
    });

    console.log(arr.join('\n'));
}