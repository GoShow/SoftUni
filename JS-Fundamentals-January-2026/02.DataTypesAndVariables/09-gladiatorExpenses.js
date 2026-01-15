function printGladiatorExpenses(lost, helmet, sword, shield, armor) {
    let brokenHelmets = parseInt(lost / 2);
    let brokenSwords = parseInt(lost / 3);
    let brokenShields = parseInt(lost / 6);
    let brokenArmor = parseInt(brokenShields / 2);

    let total = 
        brokenHelmets * helmet + 
        brokenSwords * sword + 
        brokenShields * shield + 
        brokenArmor * armor;
    
    console.log(`Gladiator expenses: ${total.toFixed(2)} aureus`);
}