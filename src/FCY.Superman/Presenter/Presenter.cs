using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FCY.Superman.Presenter
{
    public class Presenter
    {
        public async Task<List<T>> Get<T>(string api)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(api);

                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();

                        return JsonConvert.DeserializeObject<List<T>>(result);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
