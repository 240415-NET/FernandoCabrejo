namespace MealsProject.Models;

    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }

        public User([NotNull] string userName)                    //Constructor
        {
            this.UserName = userName;
        }

        public User(){}

    //    public bool IsLoggedIn { get; set; }
    }


/*
using MealsProject.PresentationLayer; //from video, here says .Models

namespace MealsProject.Models
{                                   //from video corresponds to User, instead of UserProfile
    public class UserProfile
    {

        public Guid userId { get; set; }     //public int userId {get; private set;} = 1; then got rid of the 1
        public string userName { get; set; } // string userName {get; set;}

        public UserProfile() { } ///probably don't need this
        public UserProfile(string _userName)
        {
            userId = Guid.NewGuid(); /// Generates a new userID for the user
            userName = _userName;
        }
                                            //from video: //Constructors
                                            //Default/No argument Constructor
                                            //public user() {}
                                            //This constructor takes two arguments
                                            //public User(int _userId, string _userName){
                                            //userId = _userId;
                                            //userName = _userName;
    }
}
*/