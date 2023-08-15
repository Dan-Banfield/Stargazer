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

        public MainViewViewModel()
        {
            RefreshCommand = new Command(OnLoad);
        }

        public async void OnLoad()
        {
            IsLoading = true;
            await GetDataAsync();
            IsLoading = false;
        }

        private async Task GetDataAsync()
        {
            APIResposne apiResponse = await APIManager.GetAPIResponseAsync();

            Title = apiResponse.title;
            Description = apiResponse.explanation;
            ImageSource = apiResponse.hdurl;
        }
    }
}