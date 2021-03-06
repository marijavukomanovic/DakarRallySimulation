﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
  public  class HelperForApiPost
    {

        public static async Task<string> Post(string controllerName, string methodName, int year)
        {
            var inputDic = new Dictionary<string, string> { { "year", year.ToString() } };


            var input = new FormUrlEncodedContent(inputDic);
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.PostAsync(HelperForApi.baseURL + controllerName + "/" + methodName + "/" + year, input))
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
                using (HttpResponseMessage res = await client.PostAsync(HelperForApi.baseURL + "Vehicles/AddVehicle" + "/" + team + "/" + model + "/" + date, input))
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
