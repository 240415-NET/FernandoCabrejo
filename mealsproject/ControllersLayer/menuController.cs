namespace MealsProject.ControllersLayer
{
    using MealsProject.DataAccessLayer;
    using MealsProject.Models;

    internal class MenuController
    {
        private readonly MenuRepository _menuRepository;                //communicates with menuRepository

        public MenuController()
        {
            this._menuRepository = new MenuRepository();
        }

        public Response GetAllMenuItems()
        {

            var response = new Response();
            try
            {
                var menu = this._menuRepository.GetAll();
                response.Message = $"***Menu***";
                response.ObjectResponse = menu;
            }
            catch (Exception ex)
            {   
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public Response GetMenuItem(int menuItemNumber)
        {
            var response = new Response();
            try
            {
                var menuItem = this._menuRepository.Get(menuItemNumber);

                if (menuItem == null)
                {
                    throw new InvalidDataException("Menu Item Not Found");
                }

                response.ObjectResponse = menuItem;
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