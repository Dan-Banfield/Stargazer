namespace Stargazer.ViewModels
{
    public class MainViewViewModel : BindableObject
    {
        private bool isLoading = true;
        public bool IsLoading
        {
            get => isLoading;

            set
            {
                isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        private string title = "A Triply Glowing Night Sky over Iceland";
        public string Title
        {
            get => title;

            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private string imageSource = "https://apod.nasa.gov/apod/image/2308/TripleIceland_Zarzycka_1080.jpg";
        public string ImageSource
        {
            get => imageSource;

            set
            {
                imageSource = value;
                OnPropertyChanged(nameof(ImageSource));
            }
        }

        private string description = "Some long description.";
        public string Description
        {
            get => description;

            set
            {
                description = value;
                OnPropertyChanged(nameof(description));
            }
        }

        public MainViewViewModel()
        {
        }
    }
}