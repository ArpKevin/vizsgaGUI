using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace vizsgaGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<vizsgazo> vizsgazok = new();
        string filePath = @"..\..\..\src\adatok.txt";
        public MainWindow()
        {
            InitializeComponent();

            foreach (var item in File.ReadAllLines(filePath))
            {
                vizsgazok.Add(new(item));
            }

            osszesenHanyDiakLabel.Content = $"{vizsgazok.Count()} vizsgázó adatait beolvastuk.";

            tanulokListbox.ItemsSource = vizsgazok.Select(v => v.Nev);
        }

        private void sikeresVizsgatTettGomb_Click(object sender, RoutedEventArgs e)
        {
            sikeresVizsgaLabel.Content = $"{vizsgazok.Count(v => v.erdemjegy(v.Modulok) != "elégtelen")} fő";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using StreamWriter sw = new StreamWriter(@"..\..\..\src\vizsgaeredmenyek.txt");

            var sikeresVizsgak = vizsgazok.Where(v => v.erdemjegy(v.Modulok) != "elégtelen").Select(v => $"{v.Nev}\t{v.vegeredmeny*100}%\t{v.erdemjegy(v.Modulok)}");

            foreach (var item in sikeresVizsgak)
            {
                sw.WriteLine(item);
            }
        }

        private void tanuloTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            tanuloEredmenye.Content = string.Empty;
            if (vizsgazok.Exists(v => v.Nev.Contains(tanuloTextbox.Text)))
            {
                var keresettTanulo = vizsgazok.First(v => v.Nev.Contains(tanuloTextbox.Text));

                tanuloEredmenye.Content = $"Legjobb eredménye: {keresettTanulo.Modulok.Max()*100}%\nLeggyengébb eredménye: {keresettTanulo.Modulok.Min()*100}%\n{(keresettTanulo.erdemjegy(keresettTanulo.Modulok) == "elégtelen" ? "Sikertelen vizsgát tett" : "Sikeres vizsgát tett" )}";
            }
            else
            {
                MessageBox.Show("Nem található ilyen vizsgázó");
            }
        }
    }
}