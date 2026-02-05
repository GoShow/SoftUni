function printWall(input) {
    let wall = input.map(Number);
    const targetHeight = 30;
    const concretePerFoot = 195;
    const concreteCost = 1900;

    let dailyConcrete = [];

    while (wall.some(h => h < targetHeight)) {
        let workingCrews = 0;

        for (let i = 0; i < wall.length; i++) {
            if (wall[i] < targetHeight) {
                wall[i]++;
                workingCrews++;
            }
        }

        if (workingCrews > 0) {
            dailyConcrete.push(workingCrews * concretePerFoot);
        }
    }

    console.log(dailyConcrete.join(', '));

    let totalConcrete = 0;
    for (let concrete of dailyConcrete) {
        totalConcrete += concrete;
    }

    console.log(`${totalConcrete * concreteCost} pesos`);
}
