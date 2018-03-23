using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Globalization;

namespace GezginSaticiProblemi
{
    public class Cities : List<City>
    { public void CalculateCityDistances(int numberOfCloseCities) // her kentin arasındaki mesafeler belirlenir.
        { foreach (City city in this) 
            { city.Distances.Clear();
                for (int i = 0; i < Count; i++) // şehirlerin konum bilgilerini x ve y koordinatı şeklinde alır
                { city.Distances.Add(Math.Sqrt(Math.Pow((double)(city.Location.X - this[i].Location.X), 2D) +
                                       Math.Pow((double)(city.Location.Y - this[i].Location.Y), 2D)));
                }
            }
           foreach (City city in this)
            { city.FindClosestCities(numberOfCloseCities); // şehirler bulunur ve sıralanır.
            }
        }
        public void OpenCityList(string fileName) // XML dosyasını açma metodu
        {  DataSet cityDS = new DataSet(); // dataset nesnemizi oluşturuyoruz.
            try
            {  this.Clear(); 
               cityDS.ReadXml(fileName); // filename ile alınan xml dosyası okunur.
               DataRowCollection cities = cityDS.Tables[0].Rows;
                foreach (DataRow city in cities)
                {this.Add(new City(Convert.ToInt32(city["X"], CultureInfo.CurrentCulture), Convert.ToInt32(city["Y"], CultureInfo.CurrentCulture)));
                } //datarowcollections nesnesi ile picture nesnesi içerisine şehirler yerleştirilir.
            }
            finally
            { cityDS.Dispose();
            }
        }
    }
}
