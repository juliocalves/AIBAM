using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIBAM.Forms
{
    public partial class FrmWebView : Form
    {
        public string url = "";
        public FrmWebView(string url)
        {
            InitializeComponent();

            // Inicializa o WebView2 com o URL fornecido
            webView21.Source = new Uri(url);
        }
    }
}
