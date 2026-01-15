function printConvertedPoundsToDollars(pounds){
    const rate = 1.31;
    let dollars = pounds * rate;
    
    console.log(dollars.toFixed(3));
}