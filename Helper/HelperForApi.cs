using Helper;
using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
  public class HelperForApi
    { public static readonly string baseURL = "http://localhost:51907/api/";

        public static async Task<string> GetAll(string controllerName,string methodName)
        {
           
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(baseURL + controllerName + "/" + methodName))
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
        public static async Task<string> Get(string controllerName, string methodName,int id)
        {

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(baseURL + controllerName + "/" + methodName+"/"+id))
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
                using (HttpResponseMessage res = await client.GetAsync(baseURL + controllerName + "/" + methodName + "/" + id))
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

       
public static async Task<string> Get(string controllerName, string methodName, string team,string model,string date,string status,bool lenghtPath)
{
           

    using (HttpClient client = new HttpClient())
    {
        using (HttpResponseMessage res = await client.GetAsync(baseURL + controllerName + "/" + methodName + "/ " + team+"/ "+model+"/ "+date+"/ "+status+"/ "+ lenghtPath))
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

public static async Task<string> Post(string controllerName,string methodName,int year)
        {
            var inputDic = new Dictionary<string, string> { { "year", year.ToString() }};


            var input = new FormUrlEncodedContent(inputDic);
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.PostAsync(baseURL + controllerName+"/"+methodName + "/" + year, input))
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

        public static async Task<string> Post(string team, string model, string date)
        {
            var inputDic = new Dictionary<string, string> { { "TeamName", team }, { "VehicleModel", model }, { "VehicleManufacturingDate", date } };


            var input = new FormUrlEncodedContent(inputDic);
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.PostAsync(baseURL + "Vehicles/AddVehicle" +  "/" + team + "/" + model + "/" + date, input))
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

        

        public static async Task<string> Put(int id,string name,string model,string date)//Update
        {
            var inputDic = new Dictionary<string, string> { { "Id",id.ToString()} ,{ "TeamName", name },{ "VehicleModel",model },{ "VehicleManufacturingDate" ,date} };


            var input = new FormUrlEncodedContent(inputDic);
            using (HttpClient client = new HttpClient())
            {
                
                using (HttpResponseMessage res = await client.PutAsync(baseURL + "Vehicles/UpdateVehicle" + "/" + id+"/"+name+"/"+model+"/"+date, input))
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
        public static string RedableJson(string jsonString)
        {
            JToken paramsJson = JToken.Parse(jsonString);
            return paramsJson.ToString(Newtonsoft.Json.Formatting.Indented);
        }
    }
}
