using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace GezginSaticiProblemi
{
    public class City
    {  //şehirlerin x ve y konumları
        public City(int x, int y)
        {Location = new Point(x, y); //konum belirlenir.
        }
        private Point location; // point lokasyonu ile lehirlerin konum değerleri okunur ve yazılır.
        public Point Location
        {  get
            { return location;
            }
            set
            { location = value;
            }
        }
        private List<double> distances = new List<double>();
        public List<double> Distances // distances adında liste tanımlanır.
        { get
            { return distances;
            }
            set
            { distances = value;
            }
        }
        private List<int> closeCities = new List<int>();
        public List<int> CloseCities // closeCities adında liste tanımlanır.
        { get
            { return closeCities;
            }
        }
        public void FindClosestCities(int numberOfCloseCities) // bulunan şehirler metodu
        {   double shortestDistance;
            int shortestCity = 0;
            double[] dist = new double[Distances.Count];
            Distances.CopyTo(dist);
            if (numberOfCloseCities > Distances.Count - 1)
            { numberOfCloseCities = Distances.Count - 1;
            }
            closeCities.Clear();
            for (int i = 0; i < numberOfCloseCities; i++)
            { shortestDistance = Double.MaxValue;
                for (int cityNum = 0; cityNum < Distances.Count; cityNum++)
                { if (dist[cityNum] < shortestDistance)
                    { shortestDistance = dist[cityNum];
                        shortestCity = cityNum;
                    }
                }
                closeCities.Add(shortestCity);
                dist[shortestCity] = Double.MaxValue;
            }
        }
      
    }
}
