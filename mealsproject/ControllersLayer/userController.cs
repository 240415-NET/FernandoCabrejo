namespace MealsProject.ControllersLayer
{
  using System.Linq;
  using MealsProject.DataAccessLayer;
  using MealsProject.Models;
internal class UserController
{
    private readonly UserRepository _userRepository;

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

    // Add user needs to include password
    public Response AddUser(string username)
    {
        var response = new Response();
        try
        {
            if (GetUserByName (username).ObjectResponse != null)
            {
                throw new Exception($"{username} already exists.");
            }

            var result = this._userRepository.Add(new User(username));
            if (result != null)
            {
                response.Message = $"User Added UserID: {result.Id}, UserName: {result.UserName}";
            }
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = $"User Not Added, {ex.Message}";
        }

        return response;

    }

        public Response DeleteUser(string username)
        {
            var response = new Response();
            try
            {
                var user = (User)this.GetUserByName(username).ObjectResponse;
                if (this._userRepository.Delete(user))
                {
                    response.Message = $"user: {user.UserName} Deleted Successfully";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"User Not added, {ex.Message}";
            }

            return response;

        }
    }

}