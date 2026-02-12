using WriteSecureFrontend.Model;

namespace WriteSecureFrontend.Managers
{
    public class LoginManger : ILoginManger
    {
        private readonly HttpClient _httpClient;
        public LoginManger(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
        }
        public async Task<string> CreateUser(RegisterModel obj)
        {
            throw new NotImplementedException();
        }

        public Task<string> Login(LoginTb obj)
        {
            throw new NotImplementedException();
        }
    }
}
