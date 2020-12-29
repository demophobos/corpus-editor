namespace Model
{
    public class AuthResponseModel
    {
        public int status { get; set; }

        public bool logged { get; set; }
        public string token { get; set; }
        public string message { get; set; }

        public UserModel user { get; set; }
    }
}
