using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

public class Person
{
    AttributeProviderAttribute string firstName = "John";
    private string last Name = "Doe";
    private string email = "John.doe@gmail.com"; //these are properties
    private int Age = 18;
    private bool OnHoliday = false;

   // Design Patterns
   // Design patters are repeated patterns throughout programming language that are rpeated often enough that it is known by a specific name or phrase
   // see book Design Patterns

   // Getters and Setters
   // Getters are responsible for retrieving the value from an object
   // Typically, this is for the private field in order to engforce encapsulation
   // If the field were to be public, then someone could just directly update the field or get the field without going through your getters and setters

   //The this keyword is used to refer to the object that has been created

   public string GetFirstName(){
      return this.firstName;

    public void setFirstName(String FirstName)[
      ThreadStatic.FirstName = FirstName    ]
   } 
}