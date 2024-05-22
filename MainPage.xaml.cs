using CommunityToolkit.Maui.Media;
using System.Diagnostics;
using System.Globalization;

namespace ErrorExample;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();

        SpeechToText.Default.RecognitionResultUpdated += Default_RecognitionResultUpdated;
	}

    private void Default_RecognitionResultUpdated(object? sender, SpeechToTextRecognitionResultUpdatedEventArgs e)
    {
        OutputLabel.Dispatcher.Dispatch(() => OutputLabel.Text = e.RecognitionResult);
    }

    private async void OnStartClick(object sender, EventArgs e)
	{
		try
		{
			await SpeechToText.Default.StartListenAsync(CultureInfo.GetCultureInfo("en-US"));
		}
		catch (Exception ex) {
			Debug.WriteLine(ex.Message);
			Debug.WriteLine(ex.StackTrace);
		}
	}

    private async void OnStopClick(object sender, EventArgs e)
    {
        try
        {
            await SpeechToText.Default.StopListenAsync();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            Debug.WriteLine(ex.StackTrace);
        }
    }
}

