using Plugin.Maui.ScreenSecurity;

namespace MauiScreenSecuritySample;

// Plugin repo: https://github.com/FabriBertani/Plugin.Maui.ScreenSecurity
public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();

#if ANDROID
		ScreenSecurity.Default.EnableScreenSecurityProtection();
#elif IOS
		ScreenSecurity.Default.EnableBlurScreenProtection(Plugin.Maui.ScreenSecurity.Platforms.iOS.ThemeStyle.Light);
#endif
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);

#if ANDROID
        ScreenSecurity.Default.DisableScreenSecurityProtection();
#elif IOS
		ScreenSecurity.Default.DisableBlurScreenProtection();
#endif
	}
}

