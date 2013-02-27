using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace EDMDownload
{
    class HtmlHelper
    {
        public static HttpWebRequest GenerateHttpRequest(string url, CookieContainer cookies)
        {
            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = WebRequestMethods.Http.Get;
            httpRequest.CookieContainer = cookies;
            return httpRequest;
        }

        public static HttpWebRequest GenerateHttpRequest(string url, CookieContainer cookies, string postData)
        {
            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = WebRequestMethods.Http.Post;
            httpRequest.CookieContainer = cookies;
            httpRequest.ContentLength = postData.Length;
            httpRequest.ContentType = "application/x-www-form-urlencoded";
            // Write the post data to the HTTP request
            StreamWriter requestWriter = new StreamWriter(httpRequest.GetRequestStream(), System.Text.Encoding.ASCII);
            requestWriter.Write(postData);
            requestWriter.Close();
            return httpRequest;
        }



        public static IEnumerable<HtmlElement> ElementsByClass(HtmlDocument doc, string className)
        {
            foreach (HtmlElement e in doc.All)
                if (e.GetAttribute("className") == className)
                    yield return e;
        }

        public static void PostDataToWebBrowser(WebBrowser browser, string url, string data)
        {
            System.Text.Encoding textEncoder = System.Text.Encoding.UTF8;

            byte[] dataBytes = textEncoder.GetBytes(data);

            string AdditionalHeaders = "Content-Type: application/x-www-form-urlencoded" + Environment.NewLine;
            browser.Navigate(url, "", dataBytes, AdditionalHeaders);
        }

        public static int SearchForStringInBrowser(WebBrowser browser, string search)
        {
            if (browser.Document == null)
            {
                //System.Diagnostics.Debug.WriteLine("HTML Document NULL");
                return 0;
            }

            int stringCount = 0;
            foreach (HtmlElement htmlElement in browser.Document.All)
            {
                if (htmlElement.InnerHtml != null && htmlElement.InnerHtml.Contains(search))
                    stringCount++;
            }
            return stringCount;
        }

        public static void DumpHTMLToOutput(WebBrowser browser)
        {
            if (browser.Document == null)
            {
                System.Diagnostics.Debug.WriteLine("HTML Document NULL");
                return;
            }

            foreach (HtmlElement htmlElement in browser.Document.All)
            {
                System.Diagnostics.Debug.WriteLine("Element:" + htmlElement.InnerHtml);
            }
        }

        public static void DumpContentHTMLToOutput(WebBrowser browser)
        {
            if (browser.Document == null)
            {
                System.Diagnostics.Debug.WriteLine("HTML Document NULL");
                return;
            }


            HtmlElement contentElement = browser.Document.GetElementById("content");
            if (contentElement != null)
            {
                System.Diagnostics.Debug.WriteLine("Content panel: " + contentElement.InnerHtml);
            }
        }

        public static HtmlElement GetHTMLElementByClassName(WebBrowser webView, string className)
        {
            try
            {
                HtmlElementCollection spans = webView.Document.GetElementsByTagName("span");
                foreach (HtmlElement element in spans)
                {
                    string cls = element.GetAttribute("className");
                    if (String.IsNullOrEmpty(cls) || !cls.Equals(className))
                        continue;

                    return element;
                }
            }
            catch
            {
            }
            return null;
        }

        public static HtmlElement[] GetHTMLElementsByClassName(WebBrowser webView, string className)
        {
            List<HtmlElement> elements = new List<HtmlElement>();
            try
            {
                HtmlElementCollection spans = webView.Document.GetElementsByTagName("span");
                foreach (HtmlElement element in spans)
                {
                    string cls = element.GetAttribute("className");
                    if (String.IsNullOrEmpty(cls) || !cls.Equals(className))
                        continue;

                    elements.Add(element);
                }
            }
            catch
            {
            }
            return elements.ToArray();
        }

        public static HtmlElement[] GetHTMLElements(WebBrowser webView, string tag, string className)
        {
            List<HtmlElement> elements = new List<HtmlElement>();
            try
            {
                HtmlElementCollection spans = webView.Document.GetElementsByTagName(tag);
                foreach (HtmlElement element in spans)
                {
                    string cls = element.GetAttribute("className");
                    if (String.IsNullOrEmpty(cls) || !cls.Equals(className))
                        continue;

                    elements.Add(element);
                }
            }
            catch
            {
            }
            return elements.ToArray();
        }
    }
}
