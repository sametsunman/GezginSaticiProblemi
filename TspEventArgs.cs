using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace GezginSaticiProblemi
{
    public class TspEventArgs : EventArgs
    {
        public TspEventArgs()
        {
        }        
        public TspEventArgs(Cities cityList, Tour bestTour, int generation, bool complete) // şehir listesi, en iyi tur, nesil
        {   this.cityList = cityList; // ve uygulamanın tamamlanması ile ilgili metod oluşturulur.
            this.bestTour = bestTour;
            this.generation = generation;
            this.complete = complete;
        }
        private Cities cityList;
        public Cities CityList
        {get
            { return cityList;
            }
        }
        private Tour bestTour;
        public Tour BestTour
        {get
            { return bestTour;
            }
        }
        private int generation;
        public int Generation
        {get
            { return generation;
            }
            set
            { generation = value;
            }
        }
        private bool complete = false; // tamamlama değeri olarak false değeri atanırç
        public bool Complete
        {get
            { return complete;
            }
            set
            { complete = value;
            }
        }// değerler okunur ve yazılır.
    }
}
