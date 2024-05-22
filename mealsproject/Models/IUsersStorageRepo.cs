using System.Reflection.Metadata;

namespace MealsProject.Models;

    public interface IUsersStorageRepo
    {
        public User RetrieveStoredUser(string userNameToFind);

    }