namespace ModernPosApp.Services;

public interface INavigationService
{
	void NavigateTo<T>() where T : class;
}