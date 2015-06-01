using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace final
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        HttpClient httpClient;
        HouseInfo param;
        Registration reg;
        public MainPage()
        {
            this.InitializeComponent();
            param = new HouseInfo();
            reg = new Registration();
        }
        private void RadioButton_Click_1(object sender, RoutedEventArgs e)
        {
            var radBtn = sender as RadioButton;
            if (radBtn != null)
            {
                int index = Convert.ToInt32(radBtn.Tag);
                _flipVw.SelectedIndex = index;

            }
        }

              
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _flipVw.SelectedIndex = 0; 
            btnContact.Visibility = Visibility.Collapsed;
            btnsave.Visibility = Visibility.Collapsed;
            btnorder.Visibility = Visibility.Collapsed;
            txtname.Visibility = Visibility.Collapsed;
            txtfamily.Visibility = Visibility.Collapsed;
            //txtvalid.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            _flipVw.SelectedIndex = 1;           

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            _flipVw.SelectedIndex = 2; 
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            _flipVw.SelectedIndex = 3; 
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            _flipVw.SelectedIndex = 4; 
        }

        private async void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            //txtresult.Text = "1200 $";
            
            btnContact.Visibility = Visibility.Visible;
            btnorder.Visibility = Visibility.Visible;
            btnsave.Visibility = Visibility.Visible;
          //  calculateButton.Visibility = Visibility.Collapsed;

            param.postalCode = postalCodeBox.Text;
            param.address =  addressBox.Text;
            param.area = areaBox.Text;
            param.buildYear =  yearBox.Text;
            //String dateS = startDate.Date.ToString;
            param.insuranceStartDate = "01.06.2015"; //startDate.Text;
            param.houseType = "APARTMENT"; // homeType.Text;
            param.currency = "EUR"; //currencyBox.Text;
            param.billingPeriod = "YEAR"; //billingBox.Text;

            /*MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Price));
            ser.WriteObject(stream1, jsonObj);
            stream.Position = 0;
            StreamReader sr = new StreamReader(stream);
            string sr_string = sr.ReadToEnd();*/
            string sr_string = JsonConvert.SerializeObject(param);
            Debug.WriteLine("GET OFFER: " + sr_string);
            try
            {
                //For example let's get prices
                string RequestUrl = "http://185.20.136.51/sellertool/prices/";
                httpClient = new HttpClient();
                string plain = "LUT" + ":" + "0gmsl48hgi_jhfiud76";
                string authString = System.Convert.ToBase64String(Encoding.UTF8.GetBytes(plain));
                httpClient.DefaultRequestHeaders.Authorization = new
                System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authString);
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await httpClient.PostAsync(RequestUrl, new StringContent(sr_string,
                Encoding.UTF8, "application/json"));
                await DisplayPrice(response, this.addressBox);
            }
            catch (HttpRequestException err)
            {
                NotifyUser("Error, type: " + err.Message);
            }
            catch (TaskCanceledException)
            {
                NotifyUser("Task Cancelled Unexpectedly");
            }
            catch (Exception ex)
            {
                NotifyUser(ex.Message);
            }
            finally
            {
                //Debug.WriteLine("Task Completed! Good Luck :D");
            }
        }

        private  void OrderClick(object sender, RoutedEventArgs e)
        {
            txtname.Visibility = Visibility.Visible;
            txtfamily.Visibility = Visibility.Visible;
           // txtvalid.Visibility = Visibility.Visible;
            btnsave.Visibility = Visibility.Visible;

        }

        private async void BonusClick(object sender, RoutedEventArgs e)
        {
            var dialog = new MessageDialog("Welcome to our Bonus program");
            await dialog.ShowAsync();
        }
        private async void RegisterClick(object sender, RoutedEventArgs e)
        {
            
            reg.name = txtname.Text;
            reg.surName = txtfamily.Text;
            reg.validTo = "30.05.2016";
            reg.pricingParameters = param;
            string sr_string = JsonConvert.SerializeObject(reg);
            Debug.WriteLine("GET OFFER: " + sr_string);
            var dialog = new MessageDialog("Thanks for ordering our insurance");
            await dialog.ShowAsync();
            try
            {
                //For example let's get prices
                string RequestUrl = "http://185.20.136.51/sellertool/applications/";
                httpClient = new HttpClient();
                string plain = "LUT" + ":" + "0gmsl48hgi_jhfiud76";
                string authString = System.Convert.ToBase64String(Encoding.UTF8.GetBytes(plain));
                httpClient.DefaultRequestHeaders.Authorization = new
                System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authString);
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await httpClient.PostAsync(RequestUrl, new StringContent(sr_string,
                Encoding.UTF8, "application/json"));
                await DisplayId(response);
            }
            catch (HttpRequestException err)
            {
                NotifyUser("Error, type: " + err.Message);
            }
            catch (TaskCanceledException)
            {
                NotifyUser("Task Cancelled Unexpectedly");
            }
            catch (Exception ex)
            {
                NotifyUser(ex.Message);
            }
            finally
            {
                Debug.WriteLine("Task Completed! Good Luck :D");
            }
        }
        private async void SendClick(object sender, RoutedEventArgs e)
        {

            nameBox.Text = "";
            mailBox.Text = "";
            phoneBox.Text = "";
            var dialog = new MessageDialog("Thanks  " +  nameBox.Text + ", you would be contacted shortly");
            await dialog.ShowAsync();
        }
        private async Task DisplayPrice(HttpResponseMessage response, TextBox output)
        {
            using (HttpContent content = response.Content)
            {
                string result = await content.ReadAsStringAsync();
                //MessageBox.Show(result);
                param = JsonConvert.DeserializeObject<HouseInfo>(result);
                Debug.WriteLine(result);
                //MessageBox.Show("JSON REsult" + info.toString());
                txtresult.Text = param.toString();
                // txtresult.Content = result;
            }
        }
        private async Task DisplayId(HttpResponseMessage response)
        {
            using (HttpContent content = response.Content)
            {
                string result = await content.ReadAsStringAsync();
                //string info = JsonConvert.DeserializeObject<string>(result);
                Debug.WriteLine(result);
               
                //addressBox.Text = info.toString();
                // txtresult.Content = result;
            }

        }

        private async void NotifyUser(string message)
        {
            var dialog = new MessageDialog(message);
            await dialog.ShowAsync(); 
        }

        private void btncontact_Click(object sender, RoutedEventArgs e)
        {
            _flipVw.SelectedIndex = 2; 
        }
    }
}
