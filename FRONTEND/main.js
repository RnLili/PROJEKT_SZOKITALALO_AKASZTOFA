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

download()