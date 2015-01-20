using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class ClinicalSignsOfCPViewModel : ViewModelBase<ClinicalSignsOfCPSchema>
    {
        private RelayCommandEx<ClinicalSignsOfCPSchema> itemClickCommand;
        public RelayCommandEx<ClinicalSignsOfCPSchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<ClinicalSignsOfCPSchema>(
                        (item) =>
                        {
                            NavigationServices.NavigateToPage("ClinicalSignsOfCPDetail", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected DataSourceBase<ClinicalSignsOfCPSchema> CreateDataSource()
        {
            return new ClinicalSignsOfCPDataSource(); // CollectionDataSource
        }


        override public Visibility PinToStartVisibility
        {
            get { return ViewType == ViewTypes.Detail ? Visibility.Visible : Visibility.Collapsed; }
        }

        override protected void PinToStart()
        {
            base.PinToStart("ClinicalSignsOfCPDetail", "{DefaultTitle}", "{DefaultSummary}", "{DefaultImageUrl}");
        }

        override public Visibility ShareItemVisibility
        {
            get { return ViewType == ViewTypes.Detail ? Visibility.Visible : Visibility.Collapsed; }
        }

        override public Visibility TextToSpeechVisibility
        {
            get { return ViewType == ViewTypes.Detail ? Visibility.Visible : Visibility.Collapsed; }
        }

        override protected async void TextToSpeech()
        {
            await base.SpeakText("Description");
        }

        public RelayCommandEx<Slider> IncreaseSlider
        {
            get
            {
                return new RelayCommandEx<Slider>(s => s.Value++);
            }
        }

        public RelayCommandEx<Slider> DecreaseSlider
        {
            get
            {
                return new RelayCommandEx<Slider>(s => s.Value--);
            }
        }

        override public void NavigateToSectionList()
        {
            NavigationServices.NavigateToPage("ClinicalSignsOfCPList");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("ClinicalSignsOfCPDetail");
        }
    }
}
