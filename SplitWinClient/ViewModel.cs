namespace SplitWinClient
{
    using System.Windows.Ink;
    using System.Windows.Input;

    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;

    public class ViewModel : ObservableObject
    {
        private readonly ApiClient _apiClient = new ApiClient();
        private string _newUserName;

        public string NewUserName { get => _newUserName; set => SetProperty(ref _newUserName, value); }



        public ICommand PostUserCommand => new RelayCommand(NewUser);
        private async void NewUser()
        {
            string newUserName = System.Text.Json.JsonSerializer.Serialize(_newUserName);
            await _apiClient.PostAsync("/NewUser", newUserName);
        }
    }
}
