//this will be our javascript
//It is attached to our HTML file via a script tag at the bottom of the body element.

//So, first we have to wait for the DOM to fully finish loading.
//Inside of our javascript file, we can reference all the HTMOL (and the DOM structure) of 
//our index.html, using the "document" object.  We don't have to instantiate it or create it or anything,
//we can just start using it

//We referemce pit dpci,emt pbkect. then use dot notation to run a function to add an event listener.
//The event we are going to listen for, is 'DomContentLoaded'.
document.addEventListener('DOMContentLoaded', () => {
//All of our DOM manipulation will be done within this lambda within addEventListener

//So now, we will start to work with our HTML element as Javascript variables/objects
//To select our button (in our HTML) we will use getelementById
const changeTextButton = document.getElementById('changeTextButton');

//Now we will add a listener to that button we selected and store in changeTextbutton above
changeTextButton.addEventListener('click', () => {

    console.log('Yep, my button was indeed clicked!');

    //To update the text inside of out p-tag, we will select it via it's ID, as we did for the button above
    //the name of our Javascript variable does not need to match the name of the ID in the html element w34e select
    const paragraph = document.getElementById('textToChanges');
    
    paragraph.textContent = 'This is my new text that is coming in from my Javascript code!';
    

    });//Closing the button.addEventListener() method
}); //Closing the addEventListener() method