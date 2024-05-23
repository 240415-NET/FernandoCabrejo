namespace MealsProject.ControllersLayer
{
    using MealsProject.DataAccessLayer;
    using MealsProject.Models;

    public class HistoryController                                      //changed from internal to public
    {
        private readonly HistoryRepository _historyRepository;          //communicates with historyRepository

        public HistoryController()
        {
         this._historyRepository = new HistoryRepository();
        }

        public static List<History> GetAllHistoryForUser(int userId)
        {
            //var response = new Response();

            //try
            //{
              //var histories = this._historyRepository.GetAll().Where(HistoryController => HistoryController.UserId == userId).ToList();
                                                                               //Back to GetAll, check HistoryRepository

              //response.ObjectResponse = histories;                                                   //changed from null to histories;
            //}
            //catch (Exception ex)
            //{
             //   response.Success = false;
            //    response.Message = ex.Message;
            //}
            return HistoryRepository.RetrieveHistoryList(userId);
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