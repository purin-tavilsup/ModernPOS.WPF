using System.Windows.Media;
using MaterialDesignThemes.Wpf;

namespace ModernPosApp.Services;

public enum AppTheme
{
	Light, 
	Dark
}

public class ThemeService : IThemeService
{
	public void ApplyTheme(AppTheme appTheme)
	{
		switch (appTheme)
		{
			case AppTheme.Light:
				ApplyLightTheme();
				break;
			case AppTheme.Dark:
				ApplyDarkTheme();
				break;
			default:
				throw new ArgumentOutOfRangeException(nameof(appTheme), appTheme, null);
		}
	}

	private static void ApplyDarkTheme()
	{
		var paletteHelper = new PaletteHelper();
		//Retrieve the app's existing theme
		var theme = paletteHelper.GetTheme();

		//Change the base theme to Dark
		theme.SetBaseTheme(BaseTheme.Dark);
		//or theme.SetBaseTheme(Theme.Light);

		//Change all the primary colors to Red
		theme.SetPrimaryColor(Colors.Teal);

		//Change all the secondary colors to Blue
		theme.SetSecondaryColor(Colors.LightBlue);

		//You can also change a single color on the theme, and optionally set the corresponding foreground color
		//theme.PrimaryMid = new ColorPair(Colors.Brown, Colors.White);

		//Change the app's current theme
		paletteHelper.SetTheme(theme);
	}

	private static void ApplyLightTheme()
	{
		var paletteHelper = new PaletteHelper();
		//Retrieve the app's existing theme
		var theme = paletteHelper.GetTheme();

		//Change the base theme to Dark
		theme.SetBaseTheme(BaseTheme.Light);
		//or theme.SetBaseTheme(Theme.Light);

		//Change all the primary colors to Red
		theme.SetPrimaryColor(Colors.Teal);

		//Change all the secondary colors to Blue
		theme.SetSecondaryColor(Colors.LightBlue);

		//You can also change a single color on the theme, and optionally set the corresponding foreground color
		//theme.PrimaryMid = new ColorPair(Colors.Brown, Colors.White);

		//Change the app's current theme
		paletteHelper.SetTheme(theme);
	}
}