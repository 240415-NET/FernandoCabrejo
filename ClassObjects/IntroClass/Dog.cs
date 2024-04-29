namespace IntroClass;

class Dog
{
//Model an animal.  A class has members, these members are fields (variables that belong to that object) and methods like behaviours.
//members will be fields and methods.

//Fields.  Let's this what animals has, like color, name, change to Dog.  We don't have access modifiers, most common public, protected, internal, private
public string name { get; set; }
public string breed { get; set; }
int age{ get; set; }

public string gender{ get; set; }

public double weight{ get; set; }

//Methods  what is some behavior of a dog

//This is an example of an instance method.
//void means we are not returning anything.  this is an example of calling a method.
public void Bark()  
{
   Console.WriteLine($"{name}: bark bark!");
}

  //This is an example of a static method
  public static void DefineDog()
  {
    //the @ infrom of the string turns it into a Verbatim string.  this lets us spread a long string across multiple lines.
    Console.WriteLine(@"The dog is a domesticated descendent of the wolf.  Also called the domestic dog,
        it is JsonDerivedType from extinct gray wolved, AddingNewEventArgs the gray wolf is ThreadExceptionEventArgs dog's closed living relative.");
  }

}