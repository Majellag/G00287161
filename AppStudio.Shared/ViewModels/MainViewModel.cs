using System;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Net.NetworkInformation;

using Windows.UI.Xaml;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class MainViewModel : BindableBase
    {
       private DevelopmentAgeViewModel _developmentAgeModel;
       private SignsOfCerebralPalsyViewModel _signsOfCerebralPalsyModel;
       private ClinicalSignsOfCPViewModel _clinicalSignsOfCPModel;
       private VideosViewModel _videosModel;
       private FacebookViewModel _facebookModel;
        private PrivacyViewModel _privacyModel;

        private ViewModelBase _selectedItem = null;

        public MainViewModel()
        {
            _selectedItem = DevelopmentAgeModel;
            _privacyModel = new PrivacyViewModel();

        }
 
        public DevelopmentAgeViewModel DevelopmentAgeModel
        {
            get { return _developmentAgeModel ?? (_developmentAgeModel = new DevelopmentAgeViewModel()); }
        }
 
        public SignsOfCerebralPalsyViewModel SignsOfCerebralPalsyModel
        {
            get { return _signsOfCerebralPalsyModel ?? (_signsOfCerebralPalsyModel = new SignsOfCerebralPalsyViewModel()); }
        }
 
        public ClinicalSignsOfCPViewModel ClinicalSignsOfCPModel
        {
            get { return _clinicalSignsOfCPModel ?? (_clinicalSignsOfCPModel = new ClinicalSignsOfCPViewModel()); }
        }
 
        public VideosViewModel VideosModel
        {
            get { return _videosModel ?? (_videosModel = new VideosViewModel()); }
        }
 
        public FacebookViewModel FacebookModel
        {
            get { return _facebookModel ?? (_facebookModel = new FacebookViewModel()); }
        }

        public void SetViewType(ViewTypes viewType)
        {
            DevelopmentAgeModel.ViewType = viewType;
            SignsOfCerebralPalsyModel.ViewType = viewType;
            ClinicalSignsOfCPModel.ViewType = viewType;
            VideosModel.ViewType = viewType;
            FacebookModel.ViewType = viewType;
        }

        public ViewModelBase SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                SetProperty(ref _selectedItem, value);
                UpdateAppBar();
            }
        }

        public Visibility AppBarVisibility
        {
            get
            {
                return SelectedItem == null ? AboutVisibility : SelectedItem.AppBarVisibility;
            }
        }

        public Visibility AboutVisibility
        {

         get { return Visibility.Visible; }
        }

        public void UpdateAppBar()
        {
            OnPropertyChanged("AppBarVisibility");
            OnPropertyChanged("AboutVisibility");
        }

        /// <summary>
        /// Load ViewModel items asynchronous
        /// </summary>
        public async Task LoadDataAsync(bool forceRefresh = false)
        {
            var loadTasks = new Task[]
            { 
                DevelopmentAgeModel.LoadItemsAsync(forceRefresh),
                SignsOfCerebralPalsyModel.LoadItemsAsync(forceRefresh),
                ClinicalSignsOfCPModel.LoadItemsAsync(forceRefresh),
                VideosModel.LoadItemsAsync(forceRefresh),
                FacebookModel.LoadItemsAsync(forceRefresh),
            };
            await Task.WhenAll(loadTasks);
        }

        //
        //  ViewModel command implementation
        //
        public ICommand RefreshCommand
        {
            get
            {
                return new DelegateCommand(async () =>
                {
                    await LoadDataAsync(true);
                });
            }
        }

        public ICommand AboutCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    NavigationServices.NavigateToPage("AboutThisAppPage");
                });
            }
        }

        public ICommand PrivacyCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    NavigationServices.NavigateTo(_privacyModel.Url);
                });
            }
        }
    }
}
