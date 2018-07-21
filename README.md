# BingHomepage.CSharp [![Build status](https://ci.appveyor.com/api/projects/status/0dagkhknj0mxtpny/branch/master?retina=true)](https://ci.appveyor.com/project/muhammadmuzzammil1998/binghomepage-csharp/branch/master)


BingHomepage.CSharp library is powered by BingHomepageAPI which provides Bing's current homepage image details which include URL for image, Copyright information, and a Copyright link.

## Usage

### Getting the library

Download the Library from [releases](https://github.com/BingHomepage/BingHomepage.CSharp/releases) page and add a reference to it.

### Getting data

To get data, define a new instance of `BingHomepage` Class using `new` keyword. You can use optional parameter in constructor to define two letter country code for Bing Region.

```csharp
var data = new BingHomepage("US");
```

### Using data

Data returned from class is:

| Return Type | Calling name | Type | Description |
|--|--|--|--|
| string | GetImageUrl | Property |Returns image URL on bing's server. |
| string | GetCopyright | Property | Returns copyright information.|
| string | GetCopyrightLink | Property | Returns Copyright link. |
| Image | GetImage(string) | Function | Returns Image type of image. Parameter required is path to save image.|

## Example

```csharp
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Test {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            var data = new BingHomepage("US");
            pictureBox1.Image = data.GetImage(Path.GetTempFileName());
            label1.Text = data.GetCopyright;
            linkLabel1.Text = data.GetCopyrightLink;
            linkLabel1.Click += (s, e) => new Process {StartInfo = new ProcessStartInfo(linkLabel1.Text)}.Start();
        }
    }
}
```
