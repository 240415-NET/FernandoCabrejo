

import React, { useState, useEffect} from 'react'

//Within my function login(), ....
function Login() {



    //First, I wil linitialize our state when a user first arrives at our application
    const[username, setUsername] = useState('');
    const[userObject, setUserObject] = useState<any>(null);

    useEffect(() => {
        const userFromLocalStorage = JSON.parse(localStorage.getItem('user') || 'null');

        if (userFromLocalStorage) {
            setUserObject(userFromLocalStorage);
        }
    }, [])

    async function handleUserLogin() {
        if (username) {
            try{
                //Fetch GET to our API for our user
                const response = await fetch(`http://localholst:5192/Users/${username}`);

                //Parse our response body as json, we must remember to await this as it is asynchronous
                const userFromAPI = await response.json();
                
                //Storing our userOject data. We need to store it in locatStorage
                localStorage.setItem('user', JSON.stringify(userFromAPI));
                setUserObject(userFromAPI);

            } catch (error) {
                console.error('Error logging in: ', error);
            }
        }//end if-block to check if username is still empty

    }//end handleUserLogin()

  //Here in the return, we will render what the User will see, .....
  return !userObject ? (
    <div id='login-container'>
      <h2>Login</h2>
      <input 
        type="text"
        id='username'
        placeholder='username'
        value={username}
        onChange={(userNameFromInutField) => setUsername(userNameFromInutField.target.value)}
        
     />{/*Again, we need to close our normally self closing tags for React*/}
     <br />
     {/*This is our login button. When it is clicked, we will call handleUserLogin(), from above */}
     <button onClick={}></button>
    </div>
  ) : null;

}

export default Login;