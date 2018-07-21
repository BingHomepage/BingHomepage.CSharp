/*
   MIT License
   
   Copyright (c) 2018 BingHomepage
   
   Permission is hereby granted, free of charge, to any person obtaining a copy
   of this software and associated documentation files (the "Software"), to deal
   in the Software without restriction, including without limitation the rights
   to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
   copies of the Software, and to permit persons to whom the Software is
   furnished to do so, subject to the following conditions:
   
   The above copyright notice and this permission notice shall be included in all
   copies or substantial portions of the Software.
   
   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
   IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
   FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
   AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
   LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
   OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
   SOFTWARE.
 */

using System;
using System.Drawing;
using System.Net;
using System.Xml;

/// <summary>
///     BingHomepage.CSharp library is powered by BingHomepageAPI which provides Bing's current homepage image details which include URL for image, Copyright information, and a Copyright link.
/// </summary>
public class BingHomepage {
    /// <summary>
    ///     Initializes a new instance of the BingHomepageAPI.
    /// </summary>
    /// <param name="countryCode">Country Code for which you want the image. Default: US.</param>
    public BingHomepage(string countryCode) {
        try {
            ServicePointManager.SecurityProtocol =
                SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
            var xml = new XmlDocument();
            xml.Load("http://cdn.muzzammil.xyz/bing/bing.php?format=xml&lang=CSharp&type=dll&cc=" + countryCode);
            GetImageUrl = xml.GetElementsByTagName("url")[0].InnerText;
            GetCopyright = xml.GetElementsByTagName("copyright")[0].InnerText;
            GetCopyrightLink = xml.GetElementsByTagName("copyrightlink")[0].InnerText;
        } catch (Exception e) {
            throw new Exception(e.ToString());
        }
    }
    /// <summary>
    ///     Initializes a new instance of the BingHomepageAPI.
    /// </summary>
    public BingHomepage() {
        try {
            ServicePointManager.SecurityProtocol =
                SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
            var xml = new XmlDocument();
            xml.Load("https://cdn.muzzammil.xyz/bing/bing.php?format=xml&lang=CSharp&type=dll&cc=US");
            GetImageUrl = xml.GetElementsByTagName("url")[0].InnerText;
            GetCopyright = xml.GetElementsByTagName("copyright")[0].InnerText;
            GetCopyrightLink = xml.GetElementsByTagName("copyrightlink")[0].InnerText;
        } catch (Exception e) {
            throw new Exception(e.ToString());
        }
    }

    /// <summary>
    ///     Gets the image's URL on bing's server.
    /// </summary>
    public string GetImageUrl { get; }

    /// <summary>
    ///     Gets the Copyright information of the image.
    /// </summary>
    public string GetCopyright { get; }

    /// <summary>
    ///     Gets the Copyright Link of the image.
    /// </summary>
    public string GetCopyrightLink { get; }

    /// <summary>
    ///     Downloads, stores, and returns the current Homepage Image.
    /// </summary>
    /// <param name="path">Path to where the Image should be downloaded.</param>
    /// <returns>Returns the downloaded image data.</returns>
    public Image GetImage(string path) {
        try {
            new WebClient().DownloadFile(GetImageUrl, path);
            return new Bitmap(path);
        } catch (Exception e) {
            throw new Exception(e.ToString());
        }
    }
}