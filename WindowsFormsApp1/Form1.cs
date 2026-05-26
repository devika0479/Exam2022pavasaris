using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.ebay.com");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchTerm = textBox1.Text;
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                MessageBox.Show("Please enter a search term", "Search Error");
                return;
            }

            string script = $"document.getElementById('gh-ac').value = '{searchTerm}'; document.getElementById('gh-btn').click();";
            webBrowser1.Document.InvokeScript("eval", new object[] { script });

            Task.Delay(2000).ContinueWith(_ =>
            {
                this.Invoke((MethodInvoker)delegate
                {
                    string resultUrl = webBrowser1.Url.ToString();
                    textBox2.Text = resultUrl;
                    richTextBox1.AppendText(resultUrl + Environment.NewLine);
                });
            });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Back button - go back in browser, clear search field and result
            if (webBrowser1.CanGoBack)
            {
                webBrowser1.GoBack();
                textBox1.Clear();
                textBox2.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Close browser button
            webBrowser1.Dispose();
            MessageBox.Show("Browser closed", "Close");
        }
    }
}
