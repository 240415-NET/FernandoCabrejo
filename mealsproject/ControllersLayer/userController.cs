namespace MealsProject.ControllersLayer
{
    using System.Linq;
    using System.Reflection.Metadata;
    using MealsProject.DataAccessLayer;
    using MealsProject.Models;
    public class UserController
    {
        //private readonly UserRepository _userRepository;    //communicates with userRepository
        public static UserRepository _userRepository = new UserRepository();
      
        public static bool CheckIfUserExists(string userName)
        {
            if(_userData.RetrieveStoredUser(userName) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static UserStringHandle GetExistingUser(string userName)
        {
            UserStringHandle existingUser = _userData.RetrieveStoredUser(userName);
            return existingUser;
        }

    }





/* Code used previously with json
        public UserController()
        {
            this._userRepository = new UserRepository();
        }

        public Response GetUserByName(string username)
        {
            var response = new Response();
            try
            {
                var users = this._userRepository.GetAll();
                var user = users.FirstOrDefault(x => string.Equals(x.UserName, username, StringComparison.OrdinalIgnoreCase));
                if (user == null)
                {
                    throw new InvalidDataException("User Not Found");
                }
                response.ObjectResponse = user;
                response.Message = $"User {user.UserName} Found!";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        //Added this code to validate the user name and password entered
        public Response ValidateUserByNameAndPassword(string username, string password)
        {
            var response = new Response();
            try
            {
                var users = this._userRepository.GetAll();
                var user = users.FirstOrDefault(x => string.Equals(x.UserName, username, StringComparison.OrdinalIgnoreCase) &&
                                                     string.Equals(x.Password, password, StringComparison.OrdinalIgnoreCase));
                if (user == null)
                {
                    throw new InvalidDataException("Invalid User Name or Password");
                }
                //  user.IsLoggedIn = true;
                //  this._userRepository.Update(user);
                response.ObjectResponse = user;
                response.Message = $"User {user.UserName} Logged In!";
            }

            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
*/