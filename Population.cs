using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GezginSaticiProblemi
{
    class Population : List<Tour> // populasyon class ı tour listesinden miras alır.
    {
        private Tour bestTour = null; // besttour değerine null değeri atanır.
        public Tour BestTour   // get ve set blokları ile değer okunması ve yazılması sağlanır.
        { set
            {  bestTour = value;
            }
            get
            {  return bestTour;
            }
        }
        public void CreateRandomPopulation(int populationSize, Cities cityList, Random rand, int chanceToUseCloseCity) 
        {//turlar için rastgele başlangıç kümesi oluşturulur.
            int firstCity, lastCity, nextCity;
            for (int tourCount = 0; tourCount < populationSize; tourCount++)
            {  // tour class ını oluşturara şehir liste sayısını buna atanır.
                Tour tour = new Tour(cityList.Count);
                // tur için başlangıç noktası oluşturulur.
                firstCity = rand.Next(cityList.Count); //birinci şehire rastgele şehir listesi sayısı atanır.
                lastCity = firstCity; // önceki şehir birinci şehire atanır.
                for (int city = 0; city < cityList.Count - 1; city++)
                { do
                    { // bir sonraki şehir için rastgele şehir listesi tutulur.
                        if ((rand.Next(100) < chanceToUseCloseCity) && (cityList[city].CloseCities.Count > 0))
                        { // %75 olasılıkla birbirne yakın şehirleri bulur.
                            nextCity = cityList[city].CloseCities[rand.Next(cityList[city].CloseCities.Count)];
                        }
                        else
                        { // eğer yukarıdaki işlem gerçekleşmezse rastgele bir şehir seçilir.
                            nextCity = rand.Next(cityList.Count);
                        }
                        // şehirlerin turları ve bağlatıları kontrol edilir.
                    } while ((tour[nextCity].Connection2 != -1) || (nextCity == lastCity));
                    // a şehrinden b ye giderken [1] için A = B ve [1]  B = A olur.
                    tour[lastCity].Connection2 = nextCity; // önceki şehir bağlantısı sonraki şehir bağlantısına atanır.
                    tour[nextCity].Connection1 = lastCity; // sonraki şehir bağlantısı önceki şehir bağlantısına atanır.
                    lastCity = nextCity; // bir önceki şehir sonraki şehir olmuş olur.
                }
                // iki şehir birbirne bağlanır.
                tour[lastCity].Connection2 = firstCity;
                tour[firstCity].Connection1 = lastCity;
                tour.DetermineFitness(cityList);
                Add(tour); // tur a eklenir
                if ((bestTour == null) || (tour.Fitness < bestTour.Fitness))
                {  BestTour = tour; // tur değeri null sa veya  tur değeri bulunan en iyi tur değerinden küçükse
                } // en iyi tur değerine bulunan tur atanır.
            }
        }
    }
}
