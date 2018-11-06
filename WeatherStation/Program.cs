using System;
using System.Timers;
using ObserverPatternDemo.Implemantation;
using ObserverPatternDemo.Implemantation.Observable;
using ObserverPatternDemo.Implemantation.Observers;

namespace WeatherStation
{
    class Program
    {
        static void Main(string[] args)
        {
            var weatherData = new WeatherData();
            
            var currentReport = new CurrentConditionsReport();
            var statisticReport = new StatisticReport();

            currentReport.StartObserving(weatherData);
            statisticReport.StartObserving(weatherData);

            var simulator = new SendingDataForWeatherDataSimulator();
            var timer = new Timer();
            weatherData.StartCheckingData(900);
            simulator.StartGeneration(weatherData, timer, 1000);

            Console.WriteLine("Press key to stop simulation");
            Console.ReadLine();

            simulator.StopGenerating(timer);
            weatherData.StopCheckingData();

            currentReport.StopObserving(weatherData);
            statisticReport.StopObserving(weatherData);

            Console.WriteLine(currentReport);
            Console.WriteLine(statisticReport);
        }
    }
}
