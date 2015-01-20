using AppStudio.ViewModels;

using Windows.ApplicationModel.DataTransfer;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace AppStudio.Views
{
    public sealed partial class VideosDetail : Page
    {
        private DataTransferManager _dataTransferManager;

        private NavigationHelper _navigationHelper;

        private DisplayOrientations _currentOrientations;

        public VideosDetail()
        {
            this.InitializeComponent();
            _navigationHelper = new NavigationHelper(this);

            ytViewer.NavigationHelper = _navigationHelper;

            VideosModel = new VideosViewModel();

            DataContext = this;

            ApplicationView.GetForCurrentView().
                SetDesiredBoundsMode(ApplicationViewBoundsMode.UseVisible);
        }

        public VideosViewModel VideosModel { get; private set; }

        public NavigationHelper NavigationHelper
        {
            get { return _navigationHelper; }
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            _dataTransferManager = DataTransferManager.GetForCurrentView();
            _dataTransferManager.DataRequested += OnDataRequested;

            _navigationHelper.OnNavigatedTo(e);

            if (VideosModel != null)
            {
                await VideosModel.LoadItemsAsync();
                VideosModel.SelectItem(e.Parameter);

                VideosModel.ViewType = ViewTypes.Detail;
            }

            ytViewer.OnNavigatedTo();

            // Allow this page to rotate
            _currentOrientations = DisplayInformation.AutoRotationPreferences;
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.Portrait
                                                        | DisplayOrientations.Landscape
                                                        | DisplayOrientations.LandscapeFlipped
                                                        | DisplayOrientations.PortraitFlipped;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _navigationHelper.OnNavigatedFrom(e);

            _navigationHelper.OnNavigatedFrom(e);
            
            ytViewer.EmbedUrl = null;

            ytViewer.OnNavigatedFrom();

            // Restore previous rotation preferences
            DisplayInformation.AutoRotationPreferences = _currentOrientations;
        }

        private void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            if (VideosModel != null)
            {
                VideosModel.GetShareContent(args.Request);
            }
        }
    }
}
