using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GoogleKeyCheck
{
    public partial class MainWindow : Form
    {
        readonly List<Tests.BaseTest> TestsList = new List<Tests.BaseTest>
        {
            new Tests.Maps.Geocoding(),
            new Tests.Maps.StaticMaps(),
            new Tests.Maps.Directions(),
            new Tests.Maps.DistanceMatrix(),
            new Tests.Maps.StreetView(),
            new Tests.Maps.NearestRoads(),
            new Tests.Maps.SnapToRoad(),
            new Tests.Places.NearBySearch(),
            new Tests.Places.PlacesDetails(),
            new Tests.Translate.Translate()
        };
        public MainWindow()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.google_cloud_32px;
        }

        private void btnCheckKey_Click(object sender, EventArgs e)
        {
            string key = txtApiKey.Text.Trim();
            if (string.IsNullOrWhiteSpace(key))
            {
                MessageBox.Show("Key is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtResponse.Text = string.Empty;
            LogAddLine($"Test Key: {key}");
            foreach (var test in TestsList)
            {
                test.ApiKey = key;
                LogAppend($"{test.Api} - {test.ApiClass}");
                try
                {
                    string res = test.RunTest().ToString();
                    LogAddLine("\t:" + res);
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("The provided API key is invalid"))
                    {
                        LogAppend(Environment.NewLine);
                        LogAppend("The provided API key is invalid");
                        return;
                    }
                    LogAddLine("\t: False");
                }
            }
        }
        private void LogAddLine(string s)
        {
            txtResponse.Text += s + Environment.NewLine;
        }
        private void LogAppend(string s)
        {
            txtResponse.Text += s;
        }
    }
}
