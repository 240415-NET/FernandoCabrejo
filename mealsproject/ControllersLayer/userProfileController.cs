using MealsProject.Models;
using MealsProject.PresentationLayer;

namespace MealsProject.ControllersLayer;

    public class UserProfileController
    {
        public static void CreateUser(string userName)
        {

            UserProfile newUser = new UserProfile(userName); // Creates a new user profile from the model

            Console.WriteLine($"User {newUser.userName} has been created!"); // Confirms user creation
            Console.WriteLine($"Your User ID is: {newUser.userId}"); // Displays the user ID

        }

        public static bool UserExists(string userName)
        {
            return false;
        }


        public static void GetReturningUser()
        {

        }
    }
