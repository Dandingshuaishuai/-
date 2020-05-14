/**************************************************************************\
版权所有: Beijing Tiandi-Marco Electro-Hydraulic Control System Co., Ltd. 

文件名：MainViewModel.cs

功能描述：XXXX

创建日期：2020/4/28 16:01:39

作者：ws

版本：4.0.30319.42000

最后修改时间：2020/4/28 16:01:39

修改记录：
1)时间,作者: 修改说明
2)时间,作者: 修改说明

\***************************************************************************/
using GalaSoft.MvvmLight;
using System;
using System.Threading;
using System.Threading.Tasks;

using OxyPlot;
using OxyPlot.Axes;

using LineSeries = OxyPlot.Series.LineSeries;
using System.Collections.ObjectModel;

namespace 综保照明监控.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private TimeSpan _timeLength = new TimeSpan(0, 0, 60);

        public MainViewModel()
        {
            TempDataPoints = new ObservableCollection<DataPoint>();
            HumiDataPoints = new ObservableCollection<DataPoint>();

            //Model = new PlotModel() { Title = "Simple Example", Subtitle = "using OxyPlot" };
            Model = new PlotModel() { Title = "磁力启动器电流曲线", Subtitle = "" };
            var series1 = new LineSeries { Title = "磁启1", MarkerType = MarkerType.Circle, Smooth = true };
            var series2 = new LineSeries { Title = "磁启2", MarkerType = MarkerType.Star, Smooth = true, MarkerStroke = OxyColors.Red };
            var series3 = new LineSeries { Title = "磁启3", MarkerType = MarkerType.Circle, Smooth = true, MarkerStroke = OxyColors.Blue };
            var series4= new LineSeries { Title = "磁启4", MarkerType = MarkerType.Star, Smooth = true, MarkerStroke = OxyColors.LimeGreen };
            var series5 = new LineSeries { Title = "磁启5", MarkerType = MarkerType.Circle, Smooth = true, MarkerStroke = OxyColors.Yellow };
            var series6 = new LineSeries { Title = "磁启6", MarkerType = MarkerType.Star, Smooth = true, MarkerStroke = OxyColors.LightGoldenrodYellow };
            

            var dateTimeAxis1 = new DateTimeAxis();
            dateTimeAxis1.Title = "Time";

            var beginTime = DateTime.Now - _timeLength;
            var endTime = beginTime + _timeLength;
            var dMinX = beginTime;
            var dMaxX = endTime;

            Model.Axes.Add(dateTimeAxis1);
            Model.Series.Add(series1);
            Model.Series.Add(series2);
            Model.Series.Add(series3);
            Model.Series.Add(series4);
            Model.Series.Add(series5);
            Model.Series.Add(series6);
            Random rd = new Random();
            Task.Run(
                () =>
                {
                    while (true)
                    {
                        series1.Points.Add(DateTimeAxis.CreateDataPoint(DateTime.Now, rd.Next(10, 30)));
                        series2.Points.Add(DateTimeAxis.CreateDataPoint(DateTime.Now, rd.Next(10, 30)));
                        series3.Points.Add(DateTimeAxis.CreateDataPoint(DateTime.Now, rd.Next(10, 30)));
                        series4.Points.Add(DateTimeAxis.CreateDataPoint(DateTime.Now, rd.Next(10, 30)));
                        series5.Points.Add(DateTimeAxis.CreateDataPoint(DateTime.Now, rd.Next(10, 30)));
                        series6.Points.Add(DateTimeAxis.CreateDataPoint(DateTime.Now, rd.Next(10, 30)));
                        if (series1.Points.Count > 100)
                        {
                            series1.Points.RemoveAt(0);
                            series2.Points.RemoveAt(0);
                            series3.Points.RemoveAt(0);
                            series4.Points.RemoveAt(0);
                            series5.Points.RemoveAt(0);
                            series6.Points.RemoveAt(0);

                            dateTimeAxis1.Minimum = DateTimeAxis.ToDouble(dMinX);
                            dateTimeAxis1.Maximum = DateTimeAxis.ToDouble(dMaxX);
                        }
                        Model.InvalidatePlot(true);
                        Thread.Sleep(1000);
                    }
                });
            Task.Run(
                () =>
                {
                    while (true)
                    {
                        var date = DateTime.Now;
                        App.Current.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            TempDataPoints.Add(DateTimeAxis.CreateDataPoint(date, (double)(rd.Next(100, 500) / 10.0)));
                            HumiDataPoints.Add(DateTimeAxis.CreateDataPoint(date, (double)(rd.Next(500, 800) / 10.0)));
                            if (TempDataPoints.Count > 300)
                            {
                                TempDataPoints.RemoveAt(0);
                                HumiDataPoints.RemoveAt(0);
                            }
                        }));
                        Thread.Sleep(1000);
                    }
                });

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Model2 = new PlotModel() { Title = "综保照明电流曲线", Subtitle = "" };
            var series7 = new LineSeries { Title = "综保1", MarkerType = MarkerType.Circle, Smooth = true };
            var series8 = new LineSeries { Title = "综保2", MarkerType = MarkerType.Star, Smooth = true, MarkerStroke = OxyColors.Red };
            var series9 = new LineSeries { Title = "综保3", MarkerType = MarkerType.Circle, Smooth = true, MarkerStroke = OxyColors.Blue };
            var series10 = new LineSeries { Title = "综保4", MarkerType = MarkerType.Star, Smooth = true, MarkerStroke = OxyColors.LimeGreen };
            var series11 = new LineSeries { Title = "综保5", MarkerType = MarkerType.Circle, Smooth = true, MarkerStroke = OxyColors.Yellow };
            var dateTimeAxis2 = new DateTimeAxis();
            dateTimeAxis2.Title = "Time";
            var beginTime2 = DateTime.Now - _timeLength;
            var endTime2 = beginTime + _timeLength;
            var dMinX2 = beginTime;
            var dMaxX2 = endTime;

            Model2.Axes.Add(dateTimeAxis2);
            Model2.Series.Add(series7);
            Model2.Series.Add(series8);
            Model2.Series.Add(series9);
            Model2.Series.Add(series10);
            Model2.Series.Add(series11);
            Random rd2 = new Random();
            Task.Run(
                () =>
                {
                    while (true)
                    {
                        series7.Points.Add(DateTimeAxis.CreateDataPoint(DateTime.Now, rd2.Next(10, 30)));
                        series8.Points.Add(DateTimeAxis.CreateDataPoint(DateTime.Now, rd2.Next(10, 30)));
                        series9.Points.Add(DateTimeAxis.CreateDataPoint(DateTime.Now, rd2.Next(10, 30)));
                        series10.Points.Add(DateTimeAxis.CreateDataPoint(DateTime.Now, rd2.Next(10, 30)));
                        series11.Points.Add(DateTimeAxis.CreateDataPoint(DateTime.Now, rd2.Next(10, 30)));
                        if (series7.Points.Count > 100)
                        {
                            series7.Points.RemoveAt(0);
                            series8.Points.RemoveAt(0);
                            series9.Points.RemoveAt(0);
                            series10.Points.RemoveAt(0);
                            series11.Points.RemoveAt(0);
                            dateTimeAxis2.Minimum = DateTimeAxis.ToDouble(dMinX2);
                            dateTimeAxis2.Maximum = DateTimeAxis.ToDouble(dMaxX2);
                        }
                        Model2.InvalidatePlot(true);
                        Thread.Sleep(1000);
                    }
                });
            Task.Run(
                () =>
                {
                    while (true)
                    {
                        var date = DateTime.Now;
                        App.Current.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            TempDataPoints.Add(DateTimeAxis.CreateDataPoint(date, (double)(rd.Next(100, 500) / 10.0)));
                            HumiDataPoints.Add(DateTimeAxis.CreateDataPoint(date, (double)(rd.Next(500, 800) / 10.0)));
                            if (TempDataPoints.Count > 300)
                            {
                                TempDataPoints.RemoveAt(0);
                                HumiDataPoints.RemoveAt(0);
                            }
                        }));
                        Thread.Sleep(1000);
                    }
                });
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Model3 = new PlotModel() { Title = "馈电开关电流曲线", Subtitle = "" };
            var series12 = new LineSeries { Title = "馈电1", MarkerType = MarkerType.Circle, Smooth = true };
            var dateTimeAxis3 = new DateTimeAxis();
            dateTimeAxis3.Title = "Time";
            var beginTime3 = DateTime.Now - _timeLength;
            var endTime3 = beginTime + _timeLength;
            var dMinX3 = beginTime;
            var dMaxX3 = endTime;

            Model3.Axes.Add(dateTimeAxis3);
            Model3.Series.Add(series12);
            Random rd3 = new Random();
            Task.Run(
                () =>
                {
                    while (true)
                    {
                        series12.Points.Add(DateTimeAxis.CreateDataPoint(DateTime.Now, rd3.Next(10, 30)));
                        if (series12.Points.Count > 100)
                        {
                            series12.Points.RemoveAt(0);
                            dateTimeAxis3.Minimum = DateTimeAxis.ToDouble(dMinX3);
                            dateTimeAxis3.Maximum = DateTimeAxis.ToDouble(dMaxX3);
                        }
                        Model3.InvalidatePlot(true);
                        Thread.Sleep(1000);
                    }
                });
            Task.Run(
                () =>
                {
                    while (true)
                    {
                        var date = DateTime.Now;
                        App.Current.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            TempDataPoints.Add(DateTimeAxis.CreateDataPoint(date, (double)(rd.Next(100, 500) / 10.0)));
                            HumiDataPoints.Add(DateTimeAxis.CreateDataPoint(date, (double)(rd.Next(500, 800) / 10.0)));
                            if (TempDataPoints.Count > 300)
                            {
                                TempDataPoints.RemoveAt(0);
                                HumiDataPoints.RemoveAt(0);
                            }
                        }));
                        Thread.Sleep(1000);
                    }
                });
        }

        /// <summary>
        /// PlotModel
        /// </summary>
        /// 
        public PlotModel Model
        {
            get { return _model; }
            set { Set(ref _model, value); }
        }
        private PlotModel _model;
        /// <summary>
        /// PlotModel
        /// </summary>
        public PlotModel Model2
        {
            get { return _model2; }
            set { Set(ref _model2, value); }
        }

        private PlotModel _model2;
        /// <summary>
        /// PlotModel
        /// </summary>
        public PlotModel Model3
        {
            get { return _model3; }
            set { Set(ref _model3, value); }
        }

        private PlotModel _model3;


        private ObservableCollection<DataPoint> _tempDataPoints;
        /// <summary>
        /// 温度
        /// </summary>
        public ObservableCollection<DataPoint> TempDataPoints
        {
            get { return _tempDataPoints; }
            set { Set(ref _tempDataPoints, value); }
        }

        private ObservableCollection<DataPoint> _humiDataPoints;
        /// <summary>
        /// 湿度
        /// </summary>
        public ObservableCollection<DataPoint> HumiDataPoints
        {
            get { return _humiDataPoints; }
            set { Set(ref _humiDataPoints, value); }
        }
    }
}
