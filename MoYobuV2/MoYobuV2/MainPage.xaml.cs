using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FFImageLoading;
using MoYobuV2.Helpers;
using Xamarin.Forms;

namespace MoYobuV2
{
    public partial class MainPage : ContentPage
    {
        // private HttpClient _http = null;

        public MainPage()
        {
            InitializeComponent();
            // if (_http == null)
            // {
            //     HttpClientHandler handler = new HttpClientHandler()
            //     {
            //         AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            //     };
            //     _http = new HttpClient(handler);
            // }
            //
            var config = new FFImageLoading.Config.Configuration()
            {
                VerboseLogging = true,
                ExecuteCallbacksOnUIThread = true,
                // HttpClient = _http,
                Logger = new CustomFFLoger()
            };
            
            // ImageService.Instance.Initialize( new CustomFFLoger());
            ImageService.Instance.Initialize(config);
        }
    }
}