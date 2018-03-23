using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Data;
using System.Drawing;

namespace GezginSaticiProblemi
{
    class Tsp
    {public delegate void NewBestTourEventHandler(Object sender, TspEventArgs e);    
        public event NewBestTourEventHandler foundNewBestTour;
        Random rand;// rastgelen değer üretecek rand nesnesi tanımlanır.
        Cities cityList;
        Population population;
        private bool halt = false;
        public bool Halt
        { get
            { return halt;
            }
            set
            { halt = value;
            }
        }
        public Tsp()
        {
        }
        //populationSize başlangıçtan önce rastgele tur sayısının büyüklüğü.
        //maxGenerations maksimum oluşan nesil sayısı.
        // groupSize nesillerin grup içerisindeki büyüklükleri.
        // mutation çocukların mutasyon olasılıkları.
        // seed rastgele sayı.
        // chanceToUseCloseCity yakın şehirler arası olasılık.
        // cityList şehir listelerindeki turlar.
        public void Begin(int populationSize, int maxGenerations, int groupSize, int mutation, int seed, int chanceToUseCloseCity, Cities cityList)
        {rand = new Random(seed);
            this.cityList = cityList;
            population = new Population();
            population.CreateRandomPopulation(populationSize, cityList, rand, chanceToUseCloseCity);
            displayTour(population.BestTour, 0, false);
            bool foundNewBestTour = false;
            int generation;
            for (generation = 0; generation < maxGenerations; generation++)
            { if (Halt)
                { break;  
                }
                foundNewBestTour = makeChildren(groupSize, mutation);
                if (foundNewBestTour)
                { displayTour(population.BestTour, generation, false);
                }
            }
            displayTour(population.BestTour, generation, true);
        }
        bool makeChildren(int groupSize, int mutation)
        {   int[] tourGroup = new int[groupSize];
            int tourCount, i, topTour, childPosition, tempTour;
            for (tourCount = 0; tourCount < groupSize; tourCount++)
            { tourGroup[tourCount] = rand.Next(population.Count);
            }
            for (tourCount = 0; tourCount < groupSize - 1; tourCount++)
            { topTour = tourCount;
                for (i = topTour + 1; i < groupSize; i++)
                { if (population[tourGroup[i]].Fitness < population[tourGroup[topTour]].Fitness)
                    {
                        topTour = i;
                    }
                }
                if (topTour != tourCount)
                {
                    tempTour = tourGroup[tourCount];
                    tourGroup[tourCount] = tourGroup[topTour];
                    tourGroup[topTour] = tempTour;
                }
            }
            bool foundNewBestTour = false;
            childPosition = tourGroup[groupSize - 1];
            population[childPosition] = Tour.Crossover(population[tourGroup[0]], population[tourGroup[1]], cityList, rand);
            if (rand.Next(100) < mutation)
            {
                population[childPosition].Mutate(rand);
            }
            population[childPosition].DetermineFitness(cityList);
            if (population[childPosition].Fitness < population.BestTour.Fitness)
            {   population.BestTour = population[childPosition];
                foundNewBestTour = true;
            }
            childPosition = tourGroup[groupSize - 2];
            population[childPosition] = Tour.Crossover(population[tourGroup[1]], population[tourGroup[0]], cityList, rand);
            if (rand.Next(100) < mutation)
            { population[childPosition].Mutate(rand);
            }
            population[childPosition].DetermineFitness(cityList);
            if (population[childPosition].Fitness < population.BestTour.Fitness)
            {   population.BestTour = population[childPosition];
                foundNewBestTour = true;
            }
            return foundNewBestTour;
        }
        void displayTour(Tour bestTour, int generationNumber, bool complete)
        { if (foundNewBestTour != null)
            { this.foundNewBestTour(this, new TspEventArgs(cityList, bestTour, generationNumber, complete));
            }
        }
    }
}
