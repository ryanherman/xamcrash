using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace collectioncrash
{
    public partial class App : Application
    {
        public static MusicModel FilteredMusic = new MusicModel();

        public App()
        {
            InitializeComponent();
            Samples = new ObservableCollection<SamplePack>
            {
                new SamplePack {Info = "1"},
                new SamplePack {Info = "2"},
                new SamplePack {Info = "3"}
            };

            var sorted = from sampelData in Samples
                orderby sampelData.Info
                group sampelData by sampelData.Info
                into sampleGroup
                select new Grouping<string, SamplePack>(sampleGroup.Key, sampleGroup);

            Testing = new ObservableCollection<Grouping<string, SamplePack>>(sorted);


            MainPage = new MainPage();
        }

        public static ObservableCollection<Grouping<string, SamplePack>> Testing { get; set; }
        public static ObservableCollection<SamplePack> Samples { get; set; }

        public static void ResetList()
        {
            Testing.Clear();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public class CelebGroup
        {
            public string name { get; set; }
            public string logoUrl { get; set; }
        }

        public class SamplePack
        {
            public string Info { get; set; }
        }
    }
}