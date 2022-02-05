using WebApplicationTeste.DTO;

namespace WebApplicationTeste.Services

{
    public class CepService
    {
        public static string _path = "https://viacep.com.br/ws/";
        public static string _path_2 = "/json/";
        public static HttpClient client = new HttpClient();

        public static async Task<DadosImovelDTO> GetCepAsync(string cep)
        {
            if (cep == null || cep.ToString().Trim().Equals("")) {
                return new DadosImovelDTO();
            }
            DadosImovelDTO imovel = null;
            var path = _path + cep + _path_2;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                imovel = await response.Content.ReadFromJsonAsync<DadosImovelDTO>();
            }
            return imovel;
        }

    }
}
