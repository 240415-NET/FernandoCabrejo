//So this is my TypeScript file, notice that it ends in a .ts extention
//This file cannot be run as it is by node.  We need to call the TypeScript compiler
//using the tsc <NameOfMyFile>.ts to compile it (essentially translate) into a .js file
//Then you can node <NameOfMyFile>.js to run that generated Javascript File
//If you intend to work with .ts in your P2, you would generate the,js file and attach
//that via the script tag in your HTML file's body

//Simple/Variable types - These come in from JS. They are string, number, boolean, etc.
//We can use typescript's explicit typeing on these variables via the following syntax.
let myBoolean: boolean = true;
let accountBalance: number = 15.67;
let petName: string = "Ziggy";

//Unless disabled in the tsconfig.json file, we can still use implicit/infer typeing in typescript.
//However, the compiler will catch you while you're coding if you try to violate the type of that variable.
let username = "'jon123";
//username = 143; - This results in an error because TS is still enforcing it's type stystem even for variables
//who's type was inferred

//Tuples
//Tuples are useful when you want an array with both a fixed number of elements within it
//and different but defined types for each element
let myFirstTuple: [string, number, boolean];
myFirstTuple = ["This is inside my tuple, at element 0. It HAS to be a string", 23, false];

console.log(myFirstTuple);

//Functions, work similarly to JS, but we can do things likle define return and argument types
function addTwoNumbers(x : number, y : number): number {

    let sum : number = 0;

    sum = x + y;

    return sum;
}

console.log(addTwoNumbers(3.67, 113.7));

//This sum is outside the scope of the addTwoNumbers function
//let sum: number = 9;

//console.log(sum);

//Arrays
//Arrays in TS are going to work th esame as in JS with the added benefit of type safety
//(behaves like a C# list)

let numberList: number[] = [12, 45, 88];
numberList.push(55);

let petNameList: string[] = ['pancake', 'ellie'];

console.log(numberList);
console.log(petNameList);

petNameList.forEach((petName) => {
    console.log(petName)
});

//Enums
//A special data structure (also in may other languagtes such as C# and Java) that represent a group of constants
//They can be either string or numeric

enum stringCardinals {
    North = 'north1',
    East = 'east',
    South = 'south',
    West = 'west'
}

console.log(stringCardinals.East);

enum numericCardinals{
    North = 1,
    East = 2,
    South = 4,
    West = 8
}

console.log(numericCardinals.West);

//Type Aliases
//Type aliases are used to create a new name for a user defined type
//Here we say that we have a 'pet' type and it MUST be either 'cat' or 'dog'
//If we try to give a variable of type 'pet' a vale of 'gator
type pet = 'cat' | 'dog';

let ellie: pet = 'dog';
//let pancake: pet = 'gator';

//Here we define a user defined type of type userId,m and say that it MUST be a number
type userId = number;

let myUserId: userId = 789798;

//Interfaces
//Interfaces are used to define the structure of an object 
//They provide a way to ensure that an object adheres to a specific 'shap' (this can be leveraged to make sure we get specific types of JSON return for example)
interface User{
    userId: string;
    userName: string;
    age?: number; //we can use the question mark to mark a property in an interface as optional.
} //It is not that the property will be null, it's that it's not required to be in the object of this interface at all

let josh : User = {userId: "123-345", userName: 'Josh'};


console.log(josh);

//Classes
//Classes can provide implementation details like methods and contructors, whereas interfaces are used
//to define only the structure of the object.  Classes form the blueprint for objects and their behavious, and can
//be instantiated, interfaces cannot.

interface Animal {
    species: string;
}

class Bird implements Animal{

    species: string;
    birdHeight: number;
    birdWeight: number;
    birdColor: string;

    constructor(species: string, height: number, weight: number, color: string){
        this.species = species;
        this.birdHeight = height;
        this.birdWeight = weight;
        this.birdColor = color;
    }

    //unlike interfaces we can define methods that belong to objects of this class
    birdCall(): string {
        return "I am a ".concat(this.species);
    }
}

let yellowWarbler = new Bird('yellow warbler', 5, .36, 'yellow');

console.log(yellowWarbler.birdCall());