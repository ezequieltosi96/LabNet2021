using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Lab.EF.UI.MVC.Models.Coin
{
    public class CoinViewModel
    {
        public string Id { get; set; }

        public string Symbol { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        [DisplayName("Current Price")]
        public decimal Current_Price { get; set; }

        [DisplayName("All Time High Price")]
        public decimal Ath { get; set; }

        [DisplayName("All Time High Price")]
        public decimal Atl { get; set; }

    }
}