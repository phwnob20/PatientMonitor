﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms.Integration;
using System.Windows.Threading;

namespace PatientMonitor
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        DateTime timeStarted;
        double yValue = 2;
        double dVariance = 0;
        Random rand;
        DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            InitSetting();


            waveformUC.CheckAndAddSeriesToGraph("trial", "rpm");
            dVariance = yValue;
            rand = new Random();

            timeStarted = DateTime.Now;
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        //public WaveformChart Chart1 { get; set; }
        private void InitSetting()
        {
            // WaveformChart.cs will be removed because of changing implementation how.
            //Chart1 = new WaveformChart();

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            double dValueX = (double)(DateTime.Now.Subtract(timeStarted).TotalSeconds);
            waveformUC.AddPointToLine("trial", yValue + (rand.NextDouble() - dVariance), dValueX);
        }
    }
}
