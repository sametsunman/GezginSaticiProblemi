using System;
using System.Collections.Generic;
using System.Text;

namespace GezginSaticiProblemi
{
    public class Link
    {
        // birinci nokta bağlantısı
        private int connection1;
        // birinci şehir bağlantısı
        public int Connection1
        { get
            { return connection1;
            }
            set
            { connection1 = value; ;
            }
        }
        //ikinci nokta bağlantısı
        private int connection2;
        //ikinci şehir bağlantısı
        public int Connection2
        { get
            { return connection2;
            }
            set
            { connection2 = value;
            }
        }
    }
}
