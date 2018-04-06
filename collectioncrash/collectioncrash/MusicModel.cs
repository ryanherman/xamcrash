using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace collectioncrash
{
    public class MusicModel
    {
        public ObservableCollection<List> list = new ObservableCollection<List>();
        public DateTime refreshDate { get; set; }

        public class List
        {
            public ObservableCollection<Detail> details = new ObservableCollection<Detail>();

            public ObservableCollection<int> projectLocations = new ObservableCollection<int>();
            public ObservableCollection<string> thumbnails = new ObservableCollection<string>();

            public Color BackgroundColor => Color.FromHex("#2E2E2E");

            private string _headerBackgroundColor { get; set; }

            public Color SoldOutColor
            {
                get
                {
                    if (isSoldOut)
                        return Color.FromHex("#bc372a");

                    return Color.FromHex("#27ae60");
                }
            }

            public string headerBackgroundColor
            {
                get
                {
                    if (string.IsNullOrEmpty(_headerBackgroundColor))
                        return "#CC000000";
                    return _headerBackgroundColor;
                }
                set => _headerBackgroundColor = value;
            }

            public bool isEnabled => !isSoldOut;

            public string DayLabel => startDateUTC.AddHours(-timezone).ToString("ddd").ToUpper();

            public string MonthLabel => startDateUTC.AddHours(-timezone).ToString("MMM").ToUpper();

            public string DateLabel => startDateUTC.AddHours(-timezone).ToString("dd");

            public string YearLabel => startDateUTC.Year.ToString();

            public string TimeLabel
            {
                get
                {
                    if (TimeZoneInfo.Utc.IsDaylightSavingTime(DateTime.Now))
                        return startDateUTC.AddHours(-timezone).AddHours(-1).ToString("h:mmt");

                    return startDateUTC.AddHours(-timezone).ToString("h:mmt");
                }
            }


            public int id { get; set; }
            public int projectId { get; set; }
            public int type { get; set; }
            public int eventState { get; set; }
            public DateTime startDateUTC { get; set; }
            public int timezone { get; set; }
            public string url { get; set; }
            public string title { get; set; }
            private string _logoUrl { get; set; }

            public string logoUrl
            {
                get
                {
                    if (!_logoUrl.Contains("http://") && !_logoUrl.Contains("https://"))
                        return "http:" + _logoUrl;
                    return _logoUrl;
                }
                set => _logoUrl = value;
            }

            public string description { get; set; }
            public string comingSoonDescription { get; set; }
            public string guestLabel { get; set; }
            public string guestList { get; set; }
            public object projectWatchlistButtonLabel { get; set; }
            public bool isVisible { get; set; }
            public bool isSoldOut { get; set; }
            public bool isComingSoon { get; set; }

            public bool hasGuests { get; set; }
            public bool isProjectWatchlistEnabled { get; set; }
            public object promo { get; set; }
            private string _projectLogoUrl { get; set; }

            public string eventLocation => details[2]?.value;

            public string projectLogoUrl
            {
                get
                {
                    if (!_projectLogoUrl.Contains("http://") && !_projectLogoUrl.Contains("https://"))
                        return "http:" + _projectLogoUrl;
                    return _projectLogoUrl;
                }
                set => _projectLogoUrl = value;
            }

            public string localStartDate { get; set; }
        }

        public class Detail
        {
            public object containerClass { get; set; }
            public string label { get; set; }
            public string value { get; set; }
        }
    }
}