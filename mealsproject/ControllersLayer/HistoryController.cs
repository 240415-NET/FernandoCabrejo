namespace MealsProject.ControllersLayer
{
    using MealsProject.DataAccessLayer;
    using MealsProject.Models;

    internal class HistoryController
    {
        private readonly HistoryRepository _historyRepository;

        public HistoryController()
        {
         this._historyRepository = new HistoryRepository();
        }

        public Response GetAllHistoryForUser(int userId)
        {
            var response = new Response();

            try
            {
                var histories = this._historyRepository.GetAll().Where(HistoryController => HistoryController.UserId == userId).ToList();
                response.ObjectResponse = histories;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;

        }

        public Response AddHistory(History history)
        {
            var response = new Response();
            try
            {

                var result = this._historyRepository.Add(history);
                if (result != null)
                {
                    response.Message = $"History Added for UserID: {history.UserId}";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"History Not Added, {ex.Message}";
            }

            return response;
        }
    }
}