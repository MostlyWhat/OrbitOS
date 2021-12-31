using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ModernWpf.Controls;
using System.Text.RegularExpressions;
using Microsoft.Web.WebView2.Core;
using System.Web;

namespace OrbitOS
{
    /// <summary>
    /// Interaction logic for ArithCalculator.xaml
    /// </summary>
    public partial class Browser : Window
    {
        public Browser()
        {
            InitializeComponent();
            webView.NavigationStarting += EnsureHttps;
            InitializeAsync();
        }
        void EnsureHttps(object sender, CoreWebView2NavigationStartingEventArgs args)
        {
            String uri = args.Uri;
            if (!uri.StartsWith("https://"))
            {
                webView.CoreWebView2.ExecuteScriptAsync($"alert('{uri} is not safe, try an https link')");
                args.Cancel = true;
            }
        }

        void UpdateAddressBar(object sender, CoreWebView2WebMessageReceivedEventArgs args)
        {
            String uri = args.TryGetWebMessageAsString();
            WebAddress.Text = uri;
            //webView.CoreWebView2.PostWebMessageAsString(uri);
        }
        async void InitializeAsync()
        {
            await webView.EnsureCoreWebView2Async(null);
            webView.CoreWebView2.WebMessageReceived += UpdateAddressBar;

            await webView.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync("window.chrome.webview.postMessage(window.document.URL);");
            await webView.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync("window.chrome.webview.addEventListener(\'message\', event => alert(event.data));");
        }
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                WebSearch_Click();
            }
        }
        private void WebSearch_Click()
        {
            if (webView != null && webView.CoreWebView2 != null)
            {
                //need to implement search engine settings
                string websiteAddress = WebAddress.Text;

                Regex domain = new Regex("^((?!-)[A-Za-z0-9-]{1, 63}(?<!-)\\.)+[A-Za-z]{2, 6}$");
                Regex Ipv4 = new Regex("(([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])\\.){3}([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])");

                bool validDomainCheck = domain.IsMatch(websiteAddress);
                bool validIpv4Check = Ipv4.IsMatch(websiteAddress);

                if (validDomainCheck == true || validIpv4Check == true || websiteAddress == "localhost")
                {
                    try
                    {
                        string finalWebsiteAddress = "https://" + websiteAddress;
                        webView.CoreWebView2.Navigate(finalWebsiteAddress);
                    }
                    catch
                    {
                        string finalWebsiteAddress = "http://" + websiteAddress;
                        webView.CoreWebView2.Navigate(finalWebsiteAddress);
                    }
                }

                else
                {
                    string finalWebsiteAddress = "https://www.google.com/search?client=orbitos-browser&q=" + HttpUtility.UrlEncode(websiteAddress);
                    webView.CoreWebView2.Navigate(finalWebsiteAddress);
                }
                
            }

            else
            {
                //add async back
                //var dialog = new NormalDialog("OrbitOS Web Browser", "Please enter a value!", "OK");
                //await dialog.ShowAsync();
                webView.CoreWebView2.PostWebMessageAsString("OrbitOS Web Browser: Please enter a value!");
            }
        }

        private void WebBack_Click(object sender, RoutedEventArgs e)
        {
            if (webView.CanGoBack)
                webView.GoBack();

            else
            {
                //add async back
                //var dialog = new NormalDialog("OrbitOS Web Browser", "Cannot go back any further!", "OK");
                //await dialog.ShowAsync();
                webView.CoreWebView2.PostWebMessageAsString("OrbitOS Web Browser: Cannot go back any further");
            }
        }

        private void WebForward_Click(object sender, RoutedEventArgs e)
        {
            if (webView.CanGoForward)
                webView.GoForward();

            else
            {
                //add async back
                //var dialog = new NormalDialog("OrbitOS Web Browser", "Cannot go forward any further!", "OK");
                //await dialog.ShowAsync();
                webView.CoreWebView2.PostWebMessageAsString("OrbitOS Web Browser: Cannot go forward any further!");
            }
        }

        private void WebReload_Click(object sender, RoutedEventArgs e)
        {
            webView.Reload();
        }
    }
}
