function printLoginAttempts(passwords) {
    const username = passwords[0];
    const password = username.split('').reverse().join('');
    let attempts = 0;

    for (let i = 1; i < passwords.length; i++) {
        if (password === passwords[i]) {
            console.log(`User ${username} logged in.`);
            break;
        } else {
            attempts++;
            if (attempts < 4) {
                console.log("Incorrect password. Try again.");
            } else{
                console.log(`User ${username} blocked!`);
                break;
            }
        }
    }
}

printLoginAttempts(['sunny','rainy','cloudy','sunny','not sunny'])