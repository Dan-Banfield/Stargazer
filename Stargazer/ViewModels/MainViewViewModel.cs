using Stargazer.API;

namespace Stargazer.ViewModels
{
    public class MainViewViewModel : BindableObject
    {
        private bool isLoading = false;
        public bool IsLoading
        {
            get => isLoading;

            set
            {
                isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        private bool refreshing = false;
        public bool Refreshing
        {
            get => refreshing;

            set
            {
                refreshing = value;
                OnPropertyChanged(nameof(Refreshing));
            }
        }

        private string title = "";
        public string Title
        {
            get => title;

            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private string imageSource = "";
        public string ImageSource
        {
            get => imageSource;

            set
            {
                imageSource = value;
                OnPropertyChanged(nameof(ImageSource));
            }
        }

        private string description = "";
        public string Description
        {
            get => description;

            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public Command RefreshCommand { get; }
        public Command ImageTapCommand { get; }

        public MainViewViewModel()
        {
            RefreshCommand = new Command(OnRefresh);
            ImageTapCommand = new Command(OnImageTap);
        }

        public async void OnLoad()
        {
            IsLoading = true;
            await GetDataAsync();
            IsLoading = false;
        }

        private async void OnRefresh()
        {
            Refreshing = true;
            IsLoading = true;
            await GetDataAsync();
            IsLoading = false;
            Refreshing = false;
        }

        private async void OnImageTap()
        {
            if (!string.IsNullOrEmpty(ImageSource))
                await Launcher.OpenAsync(ImageSource);
        }

        private async Task GetDataAsync()
        {
            try
            {
                APIResposne apiResponse = await APIManager.GetAPIResponseAsync();

                Title = apiResponse.title;
                Description = apiResponse.explanation;
                ImageSource = apiResponse.hdurl;
            }
            catch (APIException apiException)
            {
                await Application.Current.MainPage.DisplayAlert("Error!", apiException.Message, "OK");
                Application.Current.Quit();
            }
        }
    }
}