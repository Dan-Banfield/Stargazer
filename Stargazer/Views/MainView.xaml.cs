using Stargazer.ViewModels;

namespace Stargazer.Views
{
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is MainViewViewModel mainViewViewModel)
                mainViewViewModel.OnLoad();
        }
    }
}