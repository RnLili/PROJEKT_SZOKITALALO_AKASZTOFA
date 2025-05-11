async function download()
{
    const response = await fetch('http://localhost:5278/word/GetRandomWord');
    let data = await response.json(); 
    let word = data.word;
    let inputNum = word.length;
    let container = document.querySelector("#inputs")
    console.log(container);
    console.log(data)
    console.log(word)
    console.log(inputNum)
    for (let index = 0; index < inputNum; index++) {
        let input = document.createElement('input')
        input.setAttribute('class', 'letter-input');
        input.setAttribute('type', 'text');
        input.setAttribute('maxlength', '1');
        container.appendChild(input);
        console.log('ok')
        
    }
}
document.getElementById("send").addEventListener("click", async () => {
    let inputs = document.querySelectorAll("#inputs input");
    let inputValues = [];

    inputs.forEach(input => {
        inputValues.push(input.value); 
    });

    let joined_inputs = {
        word: inputValues.join("")
    };
    console.log(joined_inputs)
    const response = await fetch("http://localhost:5278/word/check", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(joined_inputs)
    });
    let result = await response.json();
    let container = document.getElementById('results');
    const differences = result.differences;
    let counter = 0;
    for (let index = 0; index < differences.length; index++) {
        let output = document.createElement('p');
        output += differences[index];
        container.appendChild(output);
        if (differences[index] == 0) {
            counter += 1;
        }
    }
    

});
download()