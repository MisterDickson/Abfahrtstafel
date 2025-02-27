using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Abfahrtstafel
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Vollbildtafel : Page
    {
        public Vollbildtafel()
        {
            this.InitializeComponent();
        }

        private void Anzeige_Loaded(object sender, RoutedEventArgs e)
        {
            Anzeige.Source = Bridge.StationsUri;
            
            if (Bridge.appWindow != null)
                Bridge.appWindow.SetPresenter(AppWindowPresenterKind.FullScreen);
            
            VollbildPage.Focus(FocusState.Programmatic);
        }
        private void Page_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Back)
            {
                Frame.GoBack(new DrillInNavigationTransitionInfo());
                if (Bridge.appWindow != null)
                    Bridge.appWindow.SetPresenter(AppWindowPresenterKind.Default);
            }
        }
    }
}
