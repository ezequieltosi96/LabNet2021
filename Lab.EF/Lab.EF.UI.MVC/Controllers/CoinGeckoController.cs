using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Lab.EF.UI.MVC.Models.Coin;

namespace Lab.EF.UI.MVC.Controllers
{
    public class CoinGeckoController : Controller
    {
        private readonly string _endpoint =
            "https://api.coingecko.com/api/v3/coins/";


        public async Task<ActionResult> Index()
        {
            ViewBag.Error = "";
            try
            {
                IEnumerable<CoinViewModel> coins = null;
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(_endpoint);
                    var response = await httpClient.GetAsync("markets?vs_currency=usd&per_page=10");

                    if (response.IsSuccessStatusCode)
                    {
                        coins = await response.Content.ReadAsAsync<IList<CoinViewModel>>();
                    }
                    else
                    {
                        coins = new List<CoinViewModel>();
                        ViewBag.Error = "An error has occurred while trying to fetch data from the api.";
                    }
                }
                return View(coins);
            }
            catch (HttpRequestException e)
            {
                ViewBag.Error = e.Message;
                return View(new List<CoinViewModel>());
            }
        }
    }
}