using System;
using Polly;
using Polly.Retry;

namespace BDD_Test_Framework.Extensions
{
    /// <summary>
    /// Polly extension methods.
    /// </summary>
    public static class PollyExtensions
    {
        public static RetryPolicy WaitAndRetry(
            this PolicyBuilder builder,
            int retryCount,
            TimeSpan sleepDuration)
        {
            TimeSpan sleepDurationFunc(int time) => sleepDuration;
            return builder
                .WaitAndRetry(retryCount, sleepDurationFunc);
        }

        public static AsyncRetryPolicy WaitAndRetryAsync(
            this PolicyBuilder builder,
            int retryCount,
            TimeSpan sleepDuration)
        {
            TimeSpan sleepDurationFunc(int time) => sleepDuration;
            return builder
                .WaitAndRetryAsync(retryCount, sleepDurationFunc);
        }

        public static RetryPolicy<TResult> WaitAndRetry<TResult>(
            this PolicyBuilder<TResult> builder,
            int retryCount,
            TimeSpan sleepDuration)
        {
            TimeSpan sleepDurationFunc(int time) => sleepDuration;
            return builder
                .WaitAndRetry(retryCount, sleepDurationFunc);
        }

        public static AsyncRetryPolicy<TResult> WaitAndRetryAsync<TResult>(
            this PolicyBuilder<TResult> builder,
            int retryCount,
            TimeSpan sleepDuration)
        {
            TimeSpan sleepDurationFunc(int time) => sleepDuration;
            return builder
                .WaitAndRetryAsync(retryCount, sleepDurationFunc);
        }
    }
}
