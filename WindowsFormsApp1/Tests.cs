using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Tests
    {
        /// <summary>
        /// Test1_field - checks that an item with an "gh-ac" id exists on eBay
        /// </summary>
        public static void Test1_field()
        {
            WebBrowser webBrowser = new WebBrowser();
            webBrowser.Navigate("https://www.ebay.com");
            System.Threading.Thread.Sleep(5000); // Wait for page to load
            
            try
            {
                HtmlElement searchField = webBrowser.Document.GetElementById("gh-ac");
                if (searchField == null)
                {
                    throw new Exception("FAIL: Search field with id 'gh-ac' does not exist on eBay");
                }
                Console.WriteLine("PASS: Test1_field - Search field 'gh-ac' exists on eBay");
            }
            catch (Exception ex)
            {
                Console.WriteLine("FAIL: Test1_field - " + ex.Message);
            }
            finally
            {
                webBrowser.Dispose();
            }
        }

        /// <summary>
        /// Test2_search - checks that an item with an "gh-btn" id exists on eBay
        /// </summary>
        public static void Test2_search()
        {
            WebBrowser webBrowser = new WebBrowser();
            webBrowser.Navigate("https://www.ebay.com");
            System.Threading.Thread.Sleep(5000); // Wait for page to load
            
            try
            {
                HtmlElement searchButton = webBrowser.Document.GetElementById("gh-btn");
                if (searchButton == null)
                {
                    throw new Exception("FAIL: Search button with id 'gh-btn' does not exist on eBay");
                }
                Console.WriteLine("PASS: Test2_search - Search button 'gh-btn' exists on eBay");
            }
            catch (Exception ex)
            {
                Console.WriteLine("FAIL: Test2_search - " + ex.Message);
            }
            finally
            {
                webBrowser.Dispose();
            }
        }
    }
}

