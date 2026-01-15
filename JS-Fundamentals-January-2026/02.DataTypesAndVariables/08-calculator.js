function calculator(a, operator, b) {
    let result = 0;
    switch (operator) {
        case '+': result = a + b; break;
        case '-': result = a - b; break;
        case '*': result = a * b; break;
        case '/': result = a / b; break;
    }

    console.log(result.toFixed(2));
}