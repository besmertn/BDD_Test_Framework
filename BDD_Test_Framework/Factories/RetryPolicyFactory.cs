using System;
using BDD_Test_Framework.Config.Readers;
using BDD_Test_Framework.Extensions;
using Polly;

namespace BDD_Test_Framework.Factories
{
    /// <summary>
    /// In retry policy factory are implemented simple policy scenario using Polly package.
    /// there are useful predefined scenarios to make retry and wait policy
    /// with result value handling or/and exception handling.
    /// </summary>
    public class RetryPolicyFactory
    {
        private readonly UtilityConfigReader utilityConfigReader;
        private readonly TimeSpan waitInMillis;

        public RetryPolicyFactory(UtilityConfigReader utilityConfigReader)
        {
            this.utilityConfigReader = utilityConfigReader;
            this.waitInMillis = this.utilityConfigReader.WaitInMilliseconds.Short;
        }

        /// <summary>
        /// Create the retry policy that handle exception 'TException' type
        /// , wait and retry parameters are configured.
        /// </summary>
        /// <returns>Retry policy.</returns>
        public Policy CreateConfiguredRetryPolicy<TException>()
            where TException : Exception
        {
            return Policy
                .Handle<TException>()
                .WaitAndRetry(this.utilityConfigReader.RetryCount, this.waitInMillis);
        }

        public Policy CreateConfiguredRetryPolicy<TException>(Func<TException, bool> exceptionHandler)
            where TException : Exception
        {
            return Policy
                .Handle(exceptionHandler)
                .WaitAndRetry(this.utilityConfigReader.RetryCount, this.waitInMillis);
        }

        public Policy<TResult> CreateConfiguredRetryPolicy<TException, TResult>(
            Func<TException, bool> exceptionHandler,
            Func<TResult, bool> resultHandler)
            where TException : Exception
        {
            return Policy.Handle(exceptionHandler)
                .OrResult(resultHandler)
                .WaitAndRetry(this.utilityConfigReader.RetryCount, this.waitInMillis);
        }

        public Policy<TResult> CreateConfiguredRetryPolicy<TException, TResult>(
            Func<TResult, bool> resultHandler)
            where TException : Exception
        {
            return Policy.Handle<TException>()
                .OrResult(resultHandler)
                .WaitAndRetry(this.utilityConfigReader.RetryCount, this.waitInMillis);
        }

        public Policy CreateRetryPolicy<TException>(int retryCount, TimeSpan waitPerRetry)
            where TException : Exception
        {
            return Policy
                .Handle<TException>()
                .WaitAndRetry(retryCount, waitPerRetry);
        }

        public Policy CreateRetryPolicy<TException>(
            Func<TException, bool> exceptionHandler,
            int retryCount,
            TimeSpan waitPerRetry)
            where TException : Exception
        {
            return Policy
                .Handle(exceptionHandler)
                .WaitAndRetry(retryCount, waitPerRetry);
        }

        public Policy<TResult> CreateRetryPolicy<TException, TResult>(
            Func<TException, bool> exceptionHandler,
            Func<TResult, bool> resultHandler,
            int retryCount,
            TimeSpan waitPerRetry)
            where TException : Exception
        {
            return Policy.Handle(exceptionHandler)
                .OrResult(resultHandler)
                .WaitAndRetry(retryCount, waitPerRetry);
        }
    }
}
