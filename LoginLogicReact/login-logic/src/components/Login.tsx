import React, {useState, useEffect} from 'react';


function Login() {

    const [username, setUsername] = useState('');
    const [userObject, setUserObject] = useState<any>(null);

    useEffect(() => {
        const userFromLocalStorage = JSON.parse(localStorage.getItem('user') || 'null');

        if (userFromLocalStorage) {
            setUserObject(userFromLocalStorage);
        }

    }, []);

    async function handleUserLogin() {
        if (username) {
            try{
                const response = await fetch(`http://localhost:5192/Users/${username}`);
                const userFromAPI = await response.json();
                localStorage.setItem('user', JSON.stringify(userFromAPI));
                setUserObject(userFromAPI);

            } catch (error) {
                console.error('Error logging in: ', error);
            }
        }
    }

  return !userObject ? (
    <div id='login-container'> 
        <h2>Login</h2>
        <input 
             type='text'
             id='username'
             placeholder='username'
             value={username}
             onChange={(userNameFromInputField) => setUsername(userNameFromInputField.target.value)}
        />
        <br />
        <button onClick={handleUserLogin}>Login</button>
    </div>
  ) : null;
}
export default Login;