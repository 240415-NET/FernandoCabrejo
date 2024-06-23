/* first run and comment console.log("hello js");

let number = 20;

console.log(number);

number = "Hello world!";

console.log(number);

// Variable Declaration   */

//let is used for variables that we want to be cabaple of being reassigned.
//It is block scoped, so if I declare using let inside of a function it can only be seen within the scope of that function
let name = "pancake"

//cost is used for "constants" variaboles that we do not want to change during run time.  is block scoped that same way that let is
const age = 17;

//There is a forbidden third way to declare variables in JS, called "var"
//Variables declared using var are globally scoped AND mutable.  This can cause many many issues.

var dontDoThis = "seriously please don't";

//Data-types
//JS has primitive types, the most often used are:
//numbers - used to represent both integers and floating point numbers
let myNumber = 11.5;

//strings
//represents a series of characters - we can use single quotes, double quotes or backticks for template strings 
let dogName = "Ellie";
let steveName = 'Steve';

//String literal example
let message = `${dogName} is due for a vet appointment!`;

console.log(message);

//undefined - represents an uninitialized variable
let corey;
console.log(corey);

//Null - represents an INTENTIONAL absence of any value
let ross = null;
console.log(ross);

//Object data types
//Objects
let person = {
    name: "Ron",
    hobby: "Birding",
    vehicle: { // Our objects can have other objects nested inside of them
        make: "Morgan",
        model: "3-Wheeler thing"
    }
}

//We can access the properties
console.log(person.name);
console.log(person.vehicle.model);

//Arrays - Arrays in JS behave like lists in C#. they are dynamic and have their own built in functions.
//we can also access specific indexes using the myArray[3] syntax
//They are last in - first out with things 
let numbers = [2, 4, 7, 10, 1];

//This method sorts the array alphabetically.
numbers.sort();

console.log(numbers);

//I can also add to arrays and remove items from arrays dynamically
numbers.push(33); //adding anew item to my array
numbers.pop();

//Dates - dates in javascript are *TECHNICALLY* represented under the hood by an integers
//This integer denots the time IN MILLISECONDS that have passed since the beginning of the UNIX ever
//So, it's the time in milliseconds since Jan 1st 1970 UTC time.

let firstDate = new Date("2024");
console.log(firstDate);

//Maps - equivalent to a C# dictionary
let myMap = new Map();
myMap.set("pet", "ellie");
myMap.set(2, "The value of 2");

console.log(myMap.get(2));

//sets - collection of unique values (cannot have duplicates)
let mySet = new Set([1, 3, 4, 6]);
console.log(mySet);

//mySet add(1);
console.log(mySet);

//Note - In javascript, functions themselves are first-class objects like all the others above.
//That means, we can do some weirder stuff.  We can assign a function to a variable, we can pass
//functions as arguments to other functions, and we can even return a function as the result of 

//we do have a way to check type in Javascript, similar to C# using "typeof"

console.log(typeof 5);
console.log(typeof 'hello');
console.log(typeof true);
console.log(typeof firstDate);

//Type coercion in Javascript
//Strings - when a non-string is added to a string, javascript converts the non-string into a string and concats the value
let example = "5" + 5;
console.log(example);
console.log(typeof example);

//Numbers - when a string or boolean is used in a math operation, JS converts it to a number
//For booleans, true will convert to 1 and false to 0
let result = '5' - 3;
console.log(result);
console.log(typeof result);

let result2 = 1 + true;  //Since true evaluates to the number 1, this resolves to 2
console.log(result2);

//Boolean coercion - everthing in JS is either "truthy" or "falsy"
//Thruthy - literally everything that is not "falsy"
//Falsy - flase, 0, -0, 0n "" (empty string), null, undefined, Nan.

if ('') {
    console.log("This will not run, because empty strings are falsy");
}
if (27) {
    console.log("this should run, as any number besides 0 and -0 is truthy");
}
if (mySet) {
    console.log("Again, this should run as it's not a in the list of falsy values");
}

//Functions in javascript
//Functions in javascript allow us to re-use code, the say way as C#
//Functions declared as part of an object are referred to as methods
//There are a few different ways to create functions in Javascript

//Function declarations - using the keyword function
function Greet(name) {
    console.log(`Hello ${name}!`);
}

Greet("Yenny");

//Function expressions - defining a function as part of an expression
//(looks similar to variable declaration)

const AddTwoNumbers = function (x, y) {
    return x + y;
}

let sum = AddTwoNumbers(5, 8, 89);
console.log(sum);

//We can declare a function using arrow synjtax as a shorthans. This is really popular
//and youw ill probably encounter it in existing codebasses that you go on to work whitin

const NewGreet = (newName) => {
    console.log(`Hello ${newName}, welcome from my arrow greeting function`);
};

NewGreet("Fernando");


















//Classes in JS

//Constructor functions/methods
//We delcare our class using the class keywor, it serves as a tamplate for objects
//...same as C#
//class Person2{
//lets create a constructo method! - In JS we only get one constructor
//    personName;
//    hobby;
//    vehicle = {
//        make,
//        model
//    }
//}    







//Create a vehicle class, that is then called to create a vehicle object in my person
class Vehicle {

    //Unlike C#, we set the properties of our class within the constructor itself
    //We don not do things like declaring properties to hold those values
    //i.e
    //No let make;
    //No let model;
    //We just take them as arguments for out constructor method, and then set them
    //using this.propertyName = argumentFromConstructor
    constructor(make, model) 
    {
        this.make = make;
        this.model = model;
    }
}

class DefaultPerson {
    //Lets create a constructor method!  - In JS we only get on e constructor
    //and if you don't create one you get the default no-arg constructor
    constructor (personName, hobby, make, model) {
        this.personName = personName;
        this.hobby = hobby;
        //this.vehicle.make = make;
        //this.vehicle.model = model;
        this.vehicle = new Vehicle(make, model);
    }
    AboutMe() {//We can also store functions inside of classes, like in C#
        //A function that belongs to a class is referred to as a method
        console.log(`My name is ${this.personName}, my vehicle is a 
             ${this.vehicle.make} ${this.vehicle.model}`);
    }
};
//let josh = new Person2("Josh", "volleyball", "Ford", "1972 Pinto");
let josh = new DefaultPerson("Josh", "volleyball", "Ford", "1972 Pinto");

console.log(josh);

//Inheritance in JS - instead of the C# colon notation, we use the "extends" keyword
class Employee extends DefaultPerson {
    //When I create a constructor for Employee, I will call the parent class constructor/
    //using super()
    constructor(personName, hobby, make, model, jobTitle) {
         //This is how we user super() to call the parent class constructor
        super(personName, hobby, make, model);
        //We must call the super90 (parent class constructor) before setting any new properties
        //in the child with the normal this.
        this.jobTitle = jobTitle;
    }
    //Lets say I want to override and provide a new implementation of AboutMe() in my employee class
    AboutMe() {
        console.log(`My name is ${this.personName}, my job is ${this.jobTitle}`);
    }
}

let marcus = new Employee("marcus", "sleeping", "reliant", "robin", "Trust fund baby");

console.log(marcus);
josh.AboutMe(); //josh is a default person object
marcus.AboutMe(); //marcus is an employee object