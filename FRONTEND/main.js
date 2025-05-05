async function download()
{
    const response = await fetch('http://localhost:5278/word/GetRandomWord');
    const word = await response.json();
    console.log(word)
}

download()