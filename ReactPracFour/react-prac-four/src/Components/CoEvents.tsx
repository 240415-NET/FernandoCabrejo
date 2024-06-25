import React, { useState} from "react";

const MyForm: React.FC = () => {
    const [inputValue, setInputValue] = useState('');

    const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setInputValue(e.target.value);
    };

    const handleButtonClick = () => {
        console.log('Button clicked!');
    }

    return (
        <div>
         <input
           type="text"
           value={inputValue}
           onChange={handleInputChange}
           placeholder="Enter something..."
         />
         <button onClick={handleButtonClick}>Click me</button>
        </div>
    );
};

export default MyForm;