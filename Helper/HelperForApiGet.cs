using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
   public class HelperForApiGet
    {
        public static async Task<string> GetAll(string controllerName, string methodName)
        {

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(HelperForApi.baseURL + controllerName + "/" + methodName))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return data;
                        }
                    }
                }
            }
            return string.Empty;

        }
        public static async Task<string> Get(string controllerName, string methodName, int id)
        {

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(HelperForApi.baseURL + controllerName + "/" + methodName + "/" + id))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return data;
                        }
                    }
                }
            }
            return string.Empty;

        }
        public static async Task<string> Get(string controllerName, string methodName, string id)
        {

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(HelperForApi.baseURL + controllerName + "/" + methodName + "/" + id))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return data;
                        }
                    }
                }
            }
            return string.Empty;

        }


        public static async Task<string> Get(string controllerName, string methodName, string team, string model, string date, string status, bool lenghtPath)
        {


            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(HelperForApi.baseURL + controllerName + "/" + methodName + "/ " + team + "/ " + model + "/ " + date + "/ " + status + "/ " + lenghtPath))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return data;
                        }
                    }
                }
            }
            return string.Empty;

        }

    }
}
