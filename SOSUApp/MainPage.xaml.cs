using SOSUApp.ViewModels;

namespace SOSUApp
{
    public partial class MainPage : ContentPage
    {
        private readonly MainPageViewModel viewModel;

        public MainPage(MainPageViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;

            BindingContext = this.viewModel;
        }

        private async void ContentPage_Loaded(object sender, EventArgs e)
        {
            await viewModel.Initialize();
        }
    }
}