using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

// Mikkel Refsgaard 
// https://github.com/MikkelJR/

// TODO: Change Namespace
namespace Namespace
{
    public class StopWatchHandler
    {
        public DataResult Data;
        public Stopwatch Sw;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            Data = new DataResult
            {
                IntervalItemList = new List<IntervalsItem>(),
                TotalElapsed = new TimeSpan()
            };
            Sw = new Stopwatch();
        }

        /// <summary>
        /// Starts the Stopwatch.
        /// </summary>
        public void StartWatch()
        {
            Sw.Start();
        }

        /// <summary>
        /// Stops the Stopwatch.
        /// </summary>
        /// <param name="text">The text.</param>
        public void StopWatch(string text)
        {
            Sw.Stop();

            Data.IntervalItemList.Add(new IntervalsItem { Text = text, Elapsed = Sw.Elapsed });
        }

        /// <summary>
        /// Resets the Stopwatch.
        /// </summary>
        public void ResetWatch()
        {
            Sw.Reset();
        }

        /// <summary>
        /// Collect data produced.
        /// </summary>
        /// <returns></returns>
        public DataResult GetData()
        {
            return new DataResult
            {
                IntervalItemList = Data.IntervalItemList,
                TotalElapsed = Data.IntervalItemList.Aggregate(TimeSpan.Zero, (subtotal, t) => subtotal.Add(t.Elapsed))
            };
        }
    }

    public class DataResult
    {
        public List<IntervalsItem> IntervalItemList { get; set; }
        public TimeSpan TotalElapsed { get; set; }
    }

    public class IntervalsItem
    {
        public TimeSpan Elapsed { get; set; }
        public string Text { get; set; }
    }
}