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



document.getElementById("send-btn").addEventListener("click", async () => {
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
        let output = document.createElement('span');
        output.setAttribute('class', 'result')
        if (differences[index] < 5) {
            output.setAttribute('class', 'badge text-bg-success')
        }
        else if (differences[index] >= 5 && differences[index] <= 10) {
            output.setAttribute('class', 'badge text-bg-warning')
        }
        else {
            output.setAttribute('class', 'badge text-bg-danger')
        }
        output.textContent += differences[index];
        container.appendChild(output);
        if (differences[index] == 0) {
            counter += 1;
        }

    }
    let refword = result.refWord
    let refword_div = document.getElementById('refword')
    let refword_p = document.createElement('h6')
    refword_p.textContent = "Az eredeti szó: " + refword
    refword_div.appendChild(refword_p)
    console.log(refword)
    let tipp = result.inputWord;
    let tipp_div = document.getElementById('tipp')
    let tipp_p = document.createElement('h6')
    tipp_p.textContent = "A tippelt szó: " + tipp;
    tipp_div.appendChild(tipp_p);
    let correct_div = document.getElementById('percentage');
    let correct = document.createElement('p');
    correct_num = Math.round((counter / differences.length)*100)
    if (correct_num < 40) {
        correct.setAttribute('class', 'badge text-bg-danger')
    }
    else if (correct_num >= 40 && correct_num <= 70) {
        correct.setAttribute('class', 'badge text-bg-warning')
    }
    else {
        correct.setAttribute('class', 'badge text-bg-success')
    }
    
    correct.textContent = "A szó " + correct_num + "%-át találtad el";
    correct_div.appendChild(correct);
    

});
download()