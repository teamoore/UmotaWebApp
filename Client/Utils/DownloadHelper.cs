using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UmotaWebApp.Client.Utils
{
    public class DownloadHelper
    {
        private IJSRuntime jsRuntime { get; set; }
        public DownloadHelper(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }

        public async Task DownloadCsv(string content, string fileName = "dosya.csv")
        {
            byte[] file = System.Text.Encoding.GetEncoding("iso-8859-9").GetBytes(content);
            string contentType = "text/csv";

            // Check if the IJSRuntime is the WebAssembly implementation of the JSRuntime
            if (jsRuntime is IJSUnmarshalledRuntime webAssemblyJSRuntime)
            {
                webAssemblyJSRuntime.InvokeUnmarshalled<string, string, byte[], bool>("BlazorDownloadFileFast", fileName, contentType, file);
            }
            else
            {
                // Fall back to the slow method if not in WebAssembly
                await jsRuntime.InvokeVoidAsync("BlazorDownloadFile", fileName, contentType, file);
            }
        }

    }
}
