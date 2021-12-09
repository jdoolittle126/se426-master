using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JsonFrameworkExample
{
    public partial class _Default : Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            var geoResult = "http://www.geoplugin.net/json.gp?ip=64.17.241.5";
            HttpClient httpClient1 = new HttpClient();
            // Do the actual request and await the response
            var httpResponse = await httpClient1.GetAsync(geoResult);
            // if you do not have a successful status code, it will throw an exception
            httpResponse.EnsureSuccessStatusCode();
            string resultGeo = httpResponse.Content.ReadAsStringAsync().Result;

            JsonDocument jDoc = JsonDocument.Parse(resultGeo);
            JsonElement root = jDoc.RootElement;
            JsonElement geoLatitude = root.GetProperty("geoplugin_latitude");
            Latitude.Text = geoLatitude.ToString();
        }
    }
}