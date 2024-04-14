namespace CRUDWithEFDbFirstWebApi.Models
{
    // We are not taking data from data base so we get data from constant
    public class UserConstants
    {
        public static List<UserModel> Users = new()
        {
            new UserModel(){Username="manideep",Password="manideep@123",Role="Admin"}
        };
    }
}
