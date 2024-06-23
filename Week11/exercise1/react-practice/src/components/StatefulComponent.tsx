import {useState} from 'react'

function StatefulComponent(){

// examples
const [stateVariable, setStateVariable] = useState('defaultValue');
const [text, setText] = useState("");
const [clickCount, setClickCount] = useState(0);

// using them
// function to handle text input change
function handleInputChange(event: any) {
    setText(event.target.value);
}

// function to handle button click
function handleButtonClick() {
    setClickCount(clickCount + 1);
}

return(
      <>
  <p>Input Text: {text}</p>
<input type="text" value={text} onChange={handleInputChange} />

<p>Button Clicked: {clickCount} times</p>
<button onClick={handleButtonClick}>Click Me</button>
      </>
  )
}

export default StatefulComponent