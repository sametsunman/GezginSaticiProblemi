using System;
using System.Collections.Generic;
using System.Text;

namespace GezginSaticiProblemi
{
    //bu class tüm şehirlerin ve bir tour un özelliğini göstermektedir.
    public class Tour : List<Link>
    {       public Tour(int capacity) // tour un kapasitesi oluşturulur.
            : base(capacity)
        { resetTour(capacity);
        }
        private double fitness;    
        // fitness toplam tur uzunluğudur.   
        public double Fitness
        { set
            { fitness = value;
            }
            get
            { return fitness;
            }
        }
        // Şehirlerin doğru sayıda tur oluşturur ve tüm -1 ilk bağlantılarını oluşturur.
        private void resetTour(int numberOfCities) 
        {   this.Clear();
            Link link;
            for (int i = 0; i < numberOfCities; i++)
            {   link = new Link();
                link.Connection1 = -1;
                link.Connection2 = -1;
                this.Add(link);
            }
        }   
        // Uygun olan tek bir uzunluk belirlenir.
       //Her iki şehir arasındaki mesafe alınır.
        public void DetermineFitness(Cities cities) 
        {   Fitness = 0;
            int lastCity = 0;
            int nextCity = this[0].Connection1;
            foreach (Link link in this)
            {   Fitness += cities[lastCity].Distances[nextCity];
                //listede sonraki şehir var mı yok mu kontrolü yapılır 1 veya 0.
                if (lastCity != this[nextCity].Connection1)
                {   lastCity = nextCity;
                    nextCity = this[nextCity].Connection1;
                }
                else
                {   lastCity = nextCity;
                    nextCity = this[nextCity].Connection2;
                }
            }
        }
        private static void joinCities(Tour tour, int[] cityUsage, int city1, int city2)
        {   // 0 veya 1 bulunan bağlantının kullanılabilir olup olmadığını belirler.
            if (tour[city1].Connection1 == -1)
            { tour[city1].Connection1 = city2;
            }
            else
            { tour[city1].Connection2 = city2;
            }
            if (tour[city2].Connection1 == -1)
            { tour[city2].Connection1 = city1;
            }
            else
            { tour[city2].Connection2 = city1;
            }
            cityUsage[city1]++;
            cityUsage[city2]++;
        }
        //parent ebeveynlere karşılık gelmektedir. Child oluşturulan çocuklara karşılık gelmektedir.
        // citylist tur şehirlerinin listesidir. cityUsage her çocuk için kullanılan tekrar sayısıdır.  
        private static int findNextCity(Tour parent, Tour child, Cities cityList, int[] cityUsage, int city) //sonraki şehir metodu
        {if (testConnectionValid(child, cityList, cityUsage, city, parent[city].Connection1))//şehir bağlantılarını kontrolü
            { return parent[city].Connection1; // ebeveyn bağlantısını döndürür.bağlantı-1
            }
            else if (testConnectionValid(child, cityList, cityUsage, city, parent[city].Connection2))
            { return parent[city].Connection2; // ebeveyn bağlantısını döndürür.bağlantı-2
            }
            return -1;
        }
        private static bool testConnectionValid(Tour tour, Cities cityList, int[] cityUsage, int city1, int city2)
        { // Quick check to see if cities already connected or if either already has 2 links
            if ((city1 == city2) || (cityUsage[city1] == 2) || (cityUsage[city2] == 2))
            {// eğer şehir1 şehir2 ye şitse veya her çocuk için kullanılan tekrar sayısı 1.şehir için 2 
                // veya tekrar sayısı şehir 2 için 2 ye eşitse yanlış değer döndür.
                return false;
            }
            //burada CPU işlemciyi yormamak ve de kurtarmak için her şehire gidilip bakılmaz. Bağlantılar kontrol edilir.
            if ((cityUsage[city1] == 0) || (cityUsage[city2] == 0))
            { return true;
            }
            // şehirlerin diğer yönlere göre bağlanıp bağlanılmadıklarına bakılır.
            for (int direction = 0; direction < 2; direction++)
            {   int lastCity = city1;
                int currentCity;
                if (direction == 0)
                { currentCity = tour[city1].Connection1;  // ilk geçişte ilk bağlantıyı kullanır.
                }
                else
                { currentCity = tour[city1].Connection2;  // ikinci geçişte diğer ikinci bağlantıyı kullanır.
                }
                int tourLength = 0;
                while ((currentCity != -1) && (currentCity != city2) && (tourLength < cityList.Count - 2))
                {  tourLength++;
                    // listede sonraki bir şehir var mı yok mu kontrol edilir.
                    if (lastCity != tour[currentCity].Connection1)
                    {   lastCity = currentCity;
                        currentCity = tour[currentCity].Connection1;
                    }
                    else
                    {   lastCity = currentCity;
                        currentCity = tour[currentCity].Connection2;
                    }
                }// eğer şehirler birbirine bağlı ve her şehirden geçiyorsa devam et.
                if (tourLength >= cityList.Count - 2)
                { return true;
                }
                // eğer şehirler birbirine bağlı değilse durdur.
                if (currentCity == city2)
                { return false;
                }
            }
            // eğer şehirler her iki yönde de bağlı ise işleme devam et.
            return true;
        }
         // burada yapılan işlem yeni bir tur oluşturmak için 2 ana turun çaprazlama işlemi gerçekleştirilir.
        // bu işlem çocukların oluşturulması için iki kez tekrar edilir.
        public static Tour Crossover(Tour parent1, Tour parent2, Cities cityList, Random rand)
        {// bu metod ile parça değişimi işlemi gerçekleştirilir.
            Tour child = new Tour(cityList.Count);      // yeni tur oluşturulur.
            int[] cityUsage = new int[cityList.Count];  // şehirleri 0-2 ile kaç tane bağlayan var bunun sayısını alır.
            int city;                                   // döngü değişkeni
            int nextCity;                               // başka diğer şehir için değişken

            for (city = 0; city < cityList.Count; city++)
            {
                cityUsage[city] = 0;
            }
            // her iki ebeveyn alınarak çocuklar oluşturulur.
            for (city = 0; city < cityList.Count; city++)
            { if (cityUsage[city] < 2)
                { if (parent1[city].Connection1 == parent2[city].Connection1)
                    {nextCity = parent1[city].Connection1;
                        if (testConnectionValid(child, cityList, cityUsage, city, nextCity))
                        { joinCities(child, cityUsage, city, nextCity);
                        }
                    }
                    if (parent1[city].Connection2 == parent2[city].Connection2)
                    {   nextCity = parent1[city].Connection2;
                        if (testConnectionValid(child, cityList, cityUsage, city, nextCity))
                        { joinCities(child, cityUsage, city, nextCity);
                        }
                    }
                    if (parent1[city].Connection1 == parent2[city].Connection2)
                    {  nextCity = parent1[city].Connection1;
                        if (testConnectionValid(child, cityList, cityUsage, city, nextCity))
                        {joinCities(child, cityUsage, city, nextCity);
                        }
                    }
                    if (parent1[city].Connection2 == parent2[city].Connection1)
                    {   nextCity = parent1[city].Connection2;
                        if (testConnectionValid(child, cityList, cityUsage, city, nextCity))
                        {joinCities(child, cityUsage, city, nextCity);
                        }
                    }// aynı işleme satır sonuna kadar devam edilir.
                }
            }
            for (city = 0; city < cityList.Count; city++)
            {if (cityUsage[city] < 2)
                { if (city % 2 == 1)  // tek şehirlerde 1 ebeveyn kullanılır.
                    {  nextCity = findNextCity(parent1, child, cityList, cityUsage, city);
                        if (nextCity == -1) // iki ebeveyn ile işleme devam edilir.
                        { nextCity = findNextCity(parent2, child, cityList, cityUsage, city); ;
                        }
                    }
                    else
                    {  nextCity = findNextCity(parent2, child, cityList, cityUsage, city);
                        if (nextCity == -1)
                        { nextCity = findNextCity(parent1, child, cityList, cityUsage, city);
                        }
                    }// sonraki şehire bulunan şehir, ebeveyn,çocuk,şehirlistesi atanır.
                    if (nextCity != -1)
                    { joinCities(child, cityUsage, city, nextCity);                        
                        if (cityUsage[city] == 1)
                        { if (city % 2 != 1) 
                            { nextCity = findNextCity(parent1, child, cityList, cityUsage, city);
                                if (nextCity == -1) 
                                {nextCity = findNextCity(parent2, child, cityList, cityUsage, city);
                                }
                            }
                            else 
                            { nextCity = findNextCity(parent2, child, cityList, cityUsage, city);
                                if (nextCity == -1)
                                { nextCity = findNextCity(parent1, child, cityList, cityUsage, city);
                                }
                            }
                            if (nextCity != -1)
                            {joinCities(child, cityUsage, city, nextCity);
                            }
                        }
                    }
                }
            }
            // bağlantılar rastgele olarak atanır.
            for (city = 0; city < cityList.Count; city++)
            { while (cityUsage[city] < 2)
                {do
                    {nextCity = rand.Next(cityList.Count);  // rastgele bir şehir seçilir.
                    } while (!testConnectionValid(child, cityList, cityUsage, city, nextCity));
                    joinCities(child, cityUsage, city, nextCity);
                }
            }
            return child;
        }        
        public void Mutate(Random rand) // Mutasyon için rastgele sayı üretme metodu
        {   int cityNumber = rand.Next(this.Count);
            Link link = this[cityNumber];
            int tmpCityNumber;
            if (this[link.Connection1].Connection1 == cityNumber)   
            { if (this[link.Connection2].Connection1 == cityNumber)
                {   tmpCityNumber = link.Connection2;
                    this[link.Connection2].Connection1 = link.Connection1;
                    this[link.Connection1].Connection1 = tmpCityNumber;
                }
                else                                                
                {   tmpCityNumber = link.Connection2;
                    this[link.Connection2].Connection2 = link.Connection1;
                    this[link.Connection1].Connection1 = tmpCityNumber;
                }
            }
            else                                                    
            { if (this[link.Connection2].Connection1 == cityNumber)
                {   tmpCityNumber = link.Connection2;
                    this[link.Connection2].Connection1 = link.Connection1;
                    this[link.Connection1].Connection2 = tmpCityNumber;
                }
                else                                               
                {   tmpCityNumber = link.Connection2;
                    this[link.Connection2].Connection2 = link.Connection1;
                    this[link.Connection1].Connection2 = tmpCityNumber;
                }
              }
            int replaceCityNumber = -1;
            do
            { replaceCityNumber = rand.Next(this.Count);
            }
            while (replaceCityNumber == cityNumber);
            Link replaceLink = this[replaceCityNumber];
            // burada rastgele tur içerisine şehirleri yerleştirme işlemi gerçekleştirilir.
            tmpCityNumber = replaceLink.Connection2;
            link.Connection2 = replaceLink.Connection2;
            link.Connection1 = replaceCityNumber;
            replaceLink.Connection2 = cityNumber;
            if (this[tmpCityNumber].Connection1 == replaceCityNumber)
            {this[tmpCityNumber].Connection1 = cityNumber;
            }
            else
            {this[tmpCityNumber].Connection2 = cityNumber;
            }
        }// rastgele şehir dağıtımına göre şehirler arası connectionlar oluşturulur.
    }
}
