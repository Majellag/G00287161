using System;
using System.Windows;
using System.Windows.Input;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using AppStudio.Services;
using AppStudio.Data;

namespace AppStudio.ViewModels
{
    public class SignsOfCerebralPalsyViewModel : ViewModelBase<SignsOfCerebralPalsySchema>
    {
        private RelayCommandEx<SignsOfCerebralPalsySchema> itemClickCommand;
        public RelayCommandEx<SignsOfCerebralPalsySchema> ItemClickCommand
        {
            get
            {
                if (itemClickCommand == null)
                {
                    itemClickCommand = new RelayCommandEx<SignsOfCerebralPalsySchema>(
                        (item) =>
                        {
                            NavigationServices.NavigateToPage("SignsOfCerebralPalsyDetail", item);
                        });
                }

                return itemClickCommand;
            }
        }

        override protected DataSourceBase<SignsOfCerebralPalsySchema> CreateDataSource()
        {
            return new SignsOfCerebralPalsyDataSource(); // CollectionDataSource
        }


        override public Visibility PinToStartVisibility
        {
            get { return ViewType == ViewTypes.Detail ? Visibility.Visible : Visibility.Collapsed; }
        }

        override protected void PinToStart()
        {
            base.PinToStart("SignsOfCerebralPalsyDetail", "{DefaultTitle}", "{DefaultSummary}", "{DefaultImageUrl}");
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
            await base.SpeakText("Subtitle");
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
            NavigationServices.NavigateToPage("SignsOfCerebralPalsyList");
        }

        override protected void NavigateToSelectedItem()
        {
            NavigationServices.NavigateToPage("SignsOfCerebralPalsyDetail");
        }
    }
}
