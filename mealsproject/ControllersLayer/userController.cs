namespace MealsProject.ControllersLayer;

using System.Linq;
using System.Reflection.Metadata;
using MealsProject.DataAccessLayer;
using MealsProject.Models;

public class UserController
{
     public static Response ValidateUserByNameAndPassword(string userName, string password)
     {
        return UserRepository.ValidateUserByNameAndPassword(userName, password);
     }
   
}