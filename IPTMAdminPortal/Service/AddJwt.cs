using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace IPTMAdminPortal.Service
{
    public class AddJwt
    {

        void jwt()
        {

            var client = new HttpClient();
            try
            {
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri(" http://localhost:3830/api/authorization/getToken"),
                    Method = HttpMethod.Get,
                };
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
                var task = client.SendAsync(request)
                    .ContinueWith((taskwithmsg) =>
                    {
                        var response = taskwithmsg.Result;

                        var jsonTask = response.Content.ReadAsAsync<JsonObject>();
                        jsonTask.Wait();
                        var jsonObject = jsonTask.Result;
                        client.DefaultRequestHeaders.Add("JWT", Convert.ToString(jsonObject));
                    });
                task.Wait();
            }
            catch
            {

            }
            
        }
    }
    
}
