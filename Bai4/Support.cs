using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai4
{
    public partial class Support : Form
    {
        public Support()
        {
            InitializeComponent();
        }

        public void LoadMovie(string url)
        {
            if (string.IsNullOrEmpty(url)) return;

            // Kiểm tra xem WebView đã khởi tạo chưa
            if (WV_URL != null && WV_URL.CoreWebView2 != null)
            {
                WV_URL.CoreWebView2.Navigate(url);
            }
            else
            {
                WV_URL.Source = new Uri(url);
            }
        }
    }
}
