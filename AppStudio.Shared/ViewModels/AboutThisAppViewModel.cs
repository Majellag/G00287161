using System;

using Windows.ApplicationModel;

namespace AppStudio.ViewModels
{
    public class AboutThisAppViewModel
    {
        public string Publisher
        {
            get
            {
                return "MajellaGreene";
            }
        }

        public string AppVersion
        {
            get
            {
                return string.Format("{0}.{1}.{2}.{3}", Package.Current.Id.Version.Major, Package.Current.Id.Version.Minor, Package.Current.Id.Version.Build, Package.Current.Id.Version.Revision);
            }
        }

        public string AboutText
        {
            get
            {
                return "Being a first time parent can be tough, as you do not know what to expect. This a" +
    "pp helps to monitor your child\'s growth throughout the first year of their life " +
    "and gives you an understanding of Cerebral Palsy to spread awareness about this " +
    "condition.";
            }
        }
    }
}

