using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409
// Author: Homayoon Fayez
namespace ContactApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void BtnHamburger_Click(object sender, RoutedEventArgs e)
        {
            SplitView.IsPaneOpen = SplitView.IsPaneOpen == false;
        }
        /// <summary>
        /// Navigates to a page. Depends on the Name attribute of the Button control
        /// Expects : Button Tag attribute to be the page name to navigate to, if page is in a folder then
        /// folderName.pageName e.g View.AddUser where View is the folder and AddUser is the xaml page
        /// Expects : Frame Name attribute to be ContentFrame
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void ClickHandler(object sender, RoutedEventArgs e)
        {
            //Exception is not handled deliberately.so the developer will be reminded to set control's Name attribute
            ContentFrame.Navigate(Type.GetType($"{Application.Current.GetType().Namespace}.{(sender as Button).Tag}"));
        }
    }
}
