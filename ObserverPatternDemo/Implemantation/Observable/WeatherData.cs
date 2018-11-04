using System;
using System.Threading;

namespace ObserverPatternDemo.Implemantation.Observable
{
    /// <summary>
    /// Represent patented object that tracking current weather conditions.
    /// </summary>
    public class WeatherData : IObservable<WeatherInfo>
    {
        /// <summary>
        /// Represents method that is called when weather update occurs.
        /// </summary>
        /// <param name="observer">The object that is to raised notifications.</param>
        /// <param name="info">The weather condition information.</param>
        private delegate void WeatherDataUpdate(IObservable<WeatherInfo> observer, WeatherInfo info);

        private static readonly Lazy<WeatherData> instance =
            new Lazy<WeatherData>(() => new WeatherData(), LazyThreadSafetyMode.PublicationOnly);

        private WeatherData() { }

        public static WeatherData Instance { get => instance.Value; }

        /// <summary>
        /// Occurs when the <see cref="WeatherInfo"/> instance is passed to the <see cref="IObservable{T}"/> implementation.
        /// </summary>
        private event WeatherDataUpdate WeatherUpdateEvent;

        /// <summary>
        /// Allows <see cref="WeatherData"/> object to send notifications to their recievers.
        /// </summary>
        /// <param name="sender">Notification sender.</param>
        /// <param name="info">The weather information.</param>
        /// <exception cref="ArgumentNullException">Sender/info is null</exception>
        public void Notify(IObservable<WeatherInfo> sender, WeatherInfo info)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender) + " is null");
            }

            if (info == null)
            {
                throw new ArgumentNullException(nameof(info) + " is null");
            }

            WeatherUpdateEvent(sender, info);
        }

        /// <summary>
        /// Registers the notifications recipients.
        /// </summary>
        /// <param name="observer">The object that is to receive notifications.</param>
        /// <exception cref="ArgumentNullException">observer is null.</exception>
        public void Register(IObserver<WeatherInfo> observer)
        {
            if (observer == null)
            {
                throw new ArgumentNullException(nameof(observer) + " is null");
            }

            WeatherUpdateEvent += observer.Update;
        }

        /// <summary>
        /// Unregisters the notifications recipients.
        /// </summary>
        /// <param name="observer">The object that is to receive notifications.</param>
        /// <exception cref="ArgumentNullException">observer is null.</exception>
        public void Unregister(IObserver<WeatherInfo> observer)
        {
            if (observer == null)
            {
                throw new ArgumentNullException(nameof(observer) + " is null");
            }

            WeatherUpdateEvent -= observer.Update;
        }
    }
}