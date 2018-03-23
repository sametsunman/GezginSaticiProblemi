using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Globalization;
using System.Xml;
using System.Xml.Serialization;
using GezginSaticiProblemi.Properties;

namespace GezginSaticiProblemi
{
    public partial class Gezgin : Form
    {
        Cities cityList = new Cities();
        Tsp tsp;
        Image cityImage;
        Image YcityImage;
        Graphics cityGraphics;
        public delegate void DrawEventHandler(Object sender, TspEventArgs e);
        public Gezgin()
        {
            InitializeComponent();
            YcityImage = new Bitmap(picture.Width, picture.Height);
            cityImage = new Bitmap(picture.Width, picture.Height);
        }

        private void tb1_Click(object sender, EventArgs e)
        {

        }
        public void DrawTour(object sender, TspEventArgs e)// tur çizim metodu
        {
            this.lblTur.Text = Math.Round(e.BestTour.Fitness, 2).ToString(CultureInfo.CurrentCulture);//tur sayısını yazdırır.
            this.lblTekrar.Text = e.Generation.ToString(CultureInfo.CurrentCulture);// tekrar sayısını yazdırır.

            if (cityImage == null)
            {
                cityImage = new Bitmap(picture.Width, picture.Height);
            }
            cityGraphics = Graphics.FromImage(cityImage);
            // resim alanı boş ise nokta, şehir belirlememizi sağlar.
            int lastCity = 0;
            int nextCity = e.BestTour[0].Connection1;
            Point ulCorner = new Point(0, 0);
            cityGraphics.FillRectangle(Brushes.White,0,0,picture.Width,picture.Height);
            cityGraphics.DrawImage(YcityImage, ulCorner);
            foreach (City city in e.CityList)
            {  //şehirleri daire olarak çizdirmemizi sağlar.
                cityGraphics.FillEllipse(Brushes.DarkRed, city.Location.X - 2, city.Location.Y - 2, 8, 8);
                // çizilen şehirlerin bağlantısını sağlar.
                cityGraphics.DrawLine(Pens.DarkRed, cityList[lastCity].Location, cityList[nextCity].Location);
                if (lastCity != e.BestTour[nextCity].Connection1)
                {
                    lastCity = nextCity;
                    nextCity = e.BestTour[nextCity].Connection1;
                }
                else
                {
                    lastCity = nextCity;
                    nextCity = e.BestTour[nextCity].Connection2;
                }
            }
            this.picture.Image = cityImage;
            if (e.Complete)
            {
                Start.Text = "Başlat";
                lblDurum.Text = "Şehir listesi açmak için tıklayın => Şehir Dosyası Aç ";
                lblDurum.ForeColor = Color.Black;
            }
        }
        private void DrawCityList(Cities cityList)// şehir listesini çiz metodu
        {// yüklenen xml dosyasındaki şehir koordinatlarına göre şehir noktalarını çizmemizi sağlar.
            Graphics graphics = Graphics.FromImage(cityImage);
            foreach (City city in cityList)
            {   //noktaları daire olarak çizdirir
                graphics.FillEllipse(Brushes.Black, city.Location.X - 2, city.Location.Y - 2, 8, 8);
            }
            this.picture.Image = cityImage;
            updateCityCount();
        }
        private void tsp_foundNewBestTour(object sender, TspEventArgs e)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new DrawEventHandler(DrawTour), new object[] { sender, e });
                    return;
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message);// exception döndürürse hatayı mesaj olarak aldırır.
                }
            }
            DrawTour(sender, e);
        }
        private void Gezgin_Click(object sender, EventArgs e) // Başlat butonun click event i
        {
            if (tsp != null)
            {
                tsp.Halt = true;
                return;
            }
            int populationSize = 0;
            int maxGenerations = 0;
            int mutation = 0;
            int groupSize = 0;
            int numberOfCloseCities = 0;
            int chanceUseCloseCity = 0;
            int seed = 0;
            try
            {
                populationSize = Convert.ToInt32(populationSizeTextBox.Text, CultureInfo.CurrentCulture);
                maxGenerations = Convert.ToInt32(maxGenerationTextBox.Text, CultureInfo.CurrentCulture);
                mutation = Convert.ToInt32(mutationTextBox.Text, CultureInfo.CurrentCulture);
                groupSize = Convert.ToInt32(groupSizeTextBox.Text, CultureInfo.CurrentCulture);
                numberOfCloseCities = Convert.ToInt32(NumberCloseCitiesTextBox.Text, CultureInfo.CurrentCulture);
                chanceUseCloseCity = Convert.ToInt32(CloseCityOddsTextBox.Text, CultureInfo.CurrentCulture);
                seed = Convert.ToInt32(randomSeedTextBox.Text, CultureInfo.CurrentCulture);
            }
            catch (FormatException)
            {
            }

            if (populationSize <= 0)
            {
                MessageBox.Show("Bir Nüfus Boyutu Belirtmelisiniz.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                return;
            }
            if (maxGenerations <= 0)
            {
                MessageBox.Show("Maksimum Nesil Sayısını Girmelisiniz.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                return;
            }
            if ((mutation < 0) || (mutation > 100))
            {
                MessageBox.Show("Mutasyon Değeri 0 İle 100 Arasında Olmalıdır.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                return;
            }
            if ((groupSize < 2) || (groupSize > populationSize))
            {
                MessageBox.Show("Popülasyon Boyutu Arasında Bir Grup Büyüklüğü Belirtmelisiniz.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                return;
            }
            if ((numberOfCloseCities < 3) || (numberOfCloseCities >= cityList.Count))
            {
                MessageBox.Show("Yakındaki Şehirlerin Sayısı 3 veya 3 ten Daha Fazla Olmalıdır.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                return;
            }
            if ((chanceUseCloseCity < 0) || (chanceUseCloseCity > 95))
            {
                MessageBox.Show("Başlangıç Popülasyonu Oluştururken Oran %0 ile %95 Arasında Olmalıdır.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                return;
            }
            if (seed < 0)
            {
                MessageBox.Show("Rastgele Sayı Üretmek İçin Değer Girmelisiniz.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                return;
            }
            if (cityList.Count < 5)
            {
                MessageBox.Show("En Az 5 Şehirli Liste Yükleyin. ", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                return;
            }

            this.Start.Text = "Durdur";
            ThreadPool.QueueUserWorkItem(new WaitCallback(BeginTsp));
        }
        private void BeginTsp(Object stateInfo)
        {
            int populationSize = Convert.ToInt32(populationSizeTextBox.Text, CultureInfo.CurrentCulture);
            int maxGenerations = Convert.ToInt32(maxGenerationTextBox.Text, CultureInfo.CurrentCulture); ;
            int mutation = Convert.ToInt32(mutationTextBox.Text, CultureInfo.CurrentCulture);
            int groupSize = Convert.ToInt32(groupSizeTextBox.Text, CultureInfo.CurrentCulture);
            int seed = Convert.ToInt32(randomSeedTextBox.Text, CultureInfo.CurrentCulture);
            int numberOfCloseCities = Convert.ToInt32(CloseCityOddsTextBox.Text, CultureInfo.CurrentCulture);
            int chanceUseCloseCity = Convert.ToInt32(randomSeedTextBox.Text, CultureInfo.CurrentCulture);
            cityList.CalculateCityDistances(numberOfCloseCities);
            tsp = new Tsp();
            tsp.foundNewBestTour += new Tsp.NewBestTourEventHandler(tsp_foundNewBestTour);
            tsp.Begin(populationSize, maxGenerations, groupSize, mutation, seed, chanceUseCloseCity, cityList);
            tsp.foundNewBestTour -= new Tsp.NewBestTourEventHandler(tsp_foundNewBestTour);
            tsp = null;
        }


        private void picture_MouseDown(object sender, MouseEventArgs e)
        {
            if (tsp != null)
            {
                lblDurum.Text = "Uygulama çalışırken şehir listesi değiştirilemez!";
                lblDurum.ForeColor = Color.Red;
                return;
            }

            cityList.Add(new City(e.X, e.Y));
            DrawCityList(cityList);

        }
        private void updateCityCount()
        {
            this.lblSehir.Text = cityList.Count.ToString();
        }

        private void ClearCity_Click(object sender, EventArgs e) // şehir listesini temizler
        {

            if (tsp != null)
            {
                lblDurum.Text = "Uygulama çalışırken şehir listesi değiştirilemez!";
                lblDurum.ForeColor = Color.Red;
                return;
            }

            cityList.Clear();
            this.DrawCityList(cityList);
            cityImage = new Bitmap(picture.Width, picture.Height);
        }

        private void selectFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileOpenDialog = new OpenFileDialog();
            fileOpenDialog.Filter = "Resim Dosyaları(*.PNG; *.BMP; *.JPG; *.GIF)| *PNG; *.BMP; *.JPG; *.GIF";
            fileOpenDialog.InitialDirectory = ".";
            fileOpenDialog.ShowDialog();

            string resim = "";

            try
            {
                if (tsp != null)
                {
                    lblDurum.Text = "Uygulama çalışırken şehir listesi değiştirilemez!";
                    lblDurum.ForeColor = Color.Red;
                    return;
                }

                resim = fileOpenDialog.FileName;

                YcityImage = new Bitmap(resim);
                cityGraphics = Graphics.FromImage(YcityImage);
                this.picture.Image = YcityImage;
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Dosya bulunamadı: " + resim, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Resim dosyası geçerli değil!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void openCityListButton_Click(object sender, EventArgs e)// şehir listesi yüklememizi sağlar XML dosya formatında
        {
            OpenFileDialog fileOpenDialog = new OpenFileDialog();
            fileOpenDialog.Filter = "XML(*.xml)|*.xml";
            fileOpenDialog.InitialDirectory = ".";
            fileOpenDialog.ShowDialog();

            string fileName = "";

            try
            {
                if (tsp != null)
                {
                    lblDurum.Text = "Uygulama çalışırken şehir listesi değiştirilemez!";
                    lblDurum.ForeColor = Color.Red;
                    return;
                }

                fileName = fileOpenDialog.FileName;

                cityList.OpenCityList(fileName);
                DrawCityList(cityList);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Dosya bulunamadı: " + fileName, "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("Şehirler XML dosyası geçerli değil!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        public class Information
        {
            private string sehir;
            

            public string Sehir
            {
                get { return sehir; }
                set { sehir = value; }

            }
        }
        public class KaydetXml
        {
            public static void KaydetData(object obj, string filename)
            {
                XmlSerializer sr = new XmlSerializer(obj.GetType());
                TextWriter writer = new StreamWriter(filename);

                sr.Serialize(writer, obj);
                writer.Close();

              
            }
        }


        private void Gezgin_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
