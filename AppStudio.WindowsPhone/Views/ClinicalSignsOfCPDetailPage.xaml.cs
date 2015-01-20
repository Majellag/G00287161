using System;
using System.Net.NetworkInformation;

using AppStudio.Services;
using AppStudio.ViewModels;

using Windows.ApplicationModel.DataTransfer;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace AppStudio.Views
{
    public sealed partial class ClinicalSignsOfCPDetail : Page
    {
        private NavigationHelper _navigationHelper;

        private DataTransferManager _dataTransferManager;

        public ClinicalSignsOfCPDetail()
        {
            this.InitializeComponent();
            _navigationHelper = new NavigationHelper(this);

            ClinicalSignsOfCPModel = new ClinicalSignsOfCPViewModel();

            ApplicationView.GetForCurrentView().
                SetDesiredBoundsMode(ApplicationViewBoundsMode.UseVisible);
        }

        public ClinicalSignsOfCPViewModel ClinicalSignsOfCPModel { get; private set; }

        public NavigationHelper NavigationHelper
        {
            get { return _navigationHelper; }
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            _dataTransferManager = DataTransferManager.GetForCurrentView();
            _dataTransferManager.DataRequested += OnDataRequested;

            _navigationHelper.OnNavigatedTo(e);

            if (ClinicalSignsOfCPModel != null)
            {
                await ClinicalSignsOfCPModel.LoadItemsAsync();
                if (e.NavigationMode != NavigationMode.Back)
                {
                    ClinicalSignsOfCPModel.SelectItem(e.Parameter);
                }

                ClinicalSignsOfCPModel.ViewType = ViewTypes.Detail;
            }
            DataContext = this;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _navigationHelper.OnNavigatedFrom(e);
            _dataTransferManager.DataRequested -= OnDataRequested;
        }

        private void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            if (ClinicalSignsOfCPModel != null)
            {
                ClinicalSignsOfCPModel.GetShareContent(args.Request);
            }
        }
    }
}
