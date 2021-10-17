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
        private HttpClient _httpClient = null;

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
            
            var handler = new HttpClientHandler();
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback = 
                (httpRequestMessage, cert, cetChain, policyErrors) => true;

            _httpClient = new HttpClient(handler);
            
            
            // ImageService.Instance.Initialize(new Configuration
            // {
            //     HttpClient = client
            // }); 
            
            
            var config = new FFImageLoading.Config.Configuration()
            {
                VerboseLogging = true,
                ExecuteCallbacksOnUIThread = true,
                HttpClient = _httpClient,
                Logger = new CustomFFLoger()
            };
            
            // ImageService.Instance.Initialize( new CustomFFLoger());
            ImageService.Instance.Initialize(config);
        }
    }
}