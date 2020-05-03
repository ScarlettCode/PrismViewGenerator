using Prism.Navigation;

namespace PrismExample.ViewModels
{
  public class SecondPageViewModel : ViewModelBase
  {
    public SecondPageViewModel(INavigationService navigationService)
        : base(navigationService)
    {
      Title = "Second Page";
    }
  }
}
