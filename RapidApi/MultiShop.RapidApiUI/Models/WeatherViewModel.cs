namespace MultiShop.RapidApiUI.Models
{
    public class WeatherViewModel
    {
      
         
            public Main main { get; set; }
         
     
        public class Main
        {
            public float temp { get; set; }
            public float feels_like { get; set; }
            public float temp_min { get; set; }
            public float temp_max { get; set; }
            public int pressure { get; set; }
            public int humidity { get; set; }
        }

     
      
     
     

    }
}
