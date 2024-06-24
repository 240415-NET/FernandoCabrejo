import React, { useState, useEffect} from 'react' 
import ItemList from './ItemList';

interface UserInfoProps {
    loggedInUserFromApp: any;
}

function UserInfo( {loggedInUserFromApp}: UserInfoProps) {

    const [userFromLocalStorage, setuser] = useState<any>(null);

    const [itemListFromAPI, setItemList] = useState<any[]>([]);

    useEffect(() => {
 
        const storedUser = JSON.parse(localStorage.getItem('user') || 'null');
        if (storedUser) {
            setuser(storedUser);
        }
    }, []);

    async function fetchUserItems(userId: string) {
        try{
            const response = await fetch(`http://localhost:5192/Items?userId=${userId}`);
            const ItemList = await response.json();

            setItemList(ItemList);
        }catch (error) {
            console.error('Error fetching user items: ', error)
        }
    }

    return userFromLocalStorage ? (
        <div id="user-container">
            <h2 id="welcome-message">Welcome {userFromLocalStorage.userName} </h2>
            <br />
            <h4>Your items:</h4>
            <ItemList itemsFromUserInfo={itemListFromAPI}/>
        </div>
    ) : null;
}

export default UserInfo