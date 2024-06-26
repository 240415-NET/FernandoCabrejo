//So this is my TypeScript file, notice that it ends in a .ts extention
//This file cannot be run as it is by node.  We need to call the TypeScript compiler
//using the tsc <NameOfMyFile>.ts to compile it (essentially translate) into a .js file
//Then you can node <NameOfMyFile>.js to run that generated Javascript File
//If you intend to work with .ts in your P2, you would generate the,js file and attach
//that via the script tag in your HTML file's body
//Simple/Variable types - These come in from JS. They are string, number, boolean, etc.
//We can use typescript's explicit typeing on these variables via the following syntax.
var myBoolean = true;
var accountBalance = 15.67;
var petName = "Ziggy";
//Unless disabled in the tsconfig.json file, we can still use implicit/infer typeing in typescript.
//However, the compiler will catch you while you're coding if you try to violate the type of that variable.
var username = "'jon123";
//username = 143; - This results in an error because TS is still enforcing it's type stystem even for variables
//who's type was inferred
//Tuples
//Tuples are useful when you want an array with both a fixed number of elements within it
//and different but defined types for each element
var myFirstTuple;
myFirstTuple = ["This is inside my tuple, at element 0. It HAS to be a string", 23, false];
console.log(myFirstTuple);
//Functions, work similarly to JS, but we can do things likle define return and argument types
function addTwoNumbers(x, y) {
    var sum = 0;
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
var numberList = [12, 45, 88];
numberList.push(55);
var petNameList = ['pancake', 'ellie'];
console.log(numberList);
console.log(petNameList);
petNameList.forEach(function (petName) {
    console.log(petName);
});
//Enums
//A special data structure (also in may other languagtes such as C# and Java) that represent a group of constants
//They can be either string or numeric
var stringCardinals;
(function (stringCardinals) {
    stringCardinals["North"] = "north1";
    stringCardinals["East"] = "east";
    stringCardinals["South"] = "south";
    stringCardinals["West"] = "west";
})(stringCardinals || (stringCardinals = {}));
console.log(stringCardinals.East);
var numericCardinals;
(function (numericCardinals) {
    numericCardinals[numericCardinals["North"] = 1] = "North";
    numericCardinals[numericCardinals["East"] = 2] = "East";
    numericCardinals[numericCardinals["South"] = 4] = "South";
    numericCardinals[numericCardinals["West"] = 8] = "West";
})(numericCardinals || (numericCardinals = {}));
console.log(numericCardinals.West);
var ellie = 'dog';
var myUserId = 789798;
var josh = { userId: "123-345", userName: 'Josh' };
console.log(josh);
var Bird = /** @class */ (function () {
    function Bird(species, height, weight, color) {
        this.species = species;
        this.birdHeight = height;
        this.birdWeight = weight;
        this.birdColor = color;
    }
    //unlike interfaces we can define methods that belong to objects of this class
    Bird.prototype.birdCall = function () {
        return "I am a ".concat(this.species);
    };
    return Bird;
}());
var yellowWarbler = new Bird('yellow warbler', 5, .36, 'yellow');
console.log(yellowWarbler.birdCall());
