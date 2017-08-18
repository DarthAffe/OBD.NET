using System.Threading;
using System.Threading.Tasks;

namespace OBD.NET.Common.Util
{
    /// <summary>
    /// Notifies one or more waiting awaiters that an event has occurred
    /// </summary>
    public class AsyncManualResetEvent
    {
        #region Properties & Fields

        private volatile TaskCompletionSource<bool> _tcs = new TaskCompletionSource<bool>();

        #endregion

        #region Methods

        /// <summary>
        /// Waits the async.
        /// </summary>
        /// <returns></returns>
        public Task WaitAsync() => _tcs.Task;

        //public void Set() { m_tcs.TrySetResult(true); }
        /// <summary>
        /// Sets the state of the event to signaled, allowing one or more waiting awaiters to proceed.
        /// </summary>
        public void Set()
        {
            TaskCompletionSource<bool> tcs = _tcs;
            Task.Factory.StartNew(s => ((TaskCompletionSource<bool>)s).TrySetResult(true),
                                  tcs, CancellationToken.None, TaskCreationOptions.PreferFairness, TaskScheduler.Default);

            tcs.Task.Wait();
        }

        /// <summary>
        /// Sets the state of the event to nonsignaled, causing awaiters to block.
        /// </summary>
        public void Reset()
        {
            while (true)
            {
                TaskCompletionSource<bool> tcs = _tcs;
                if (!tcs.Task.IsCompleted ||
                    (Interlocked.CompareExchange(ref _tcs, new TaskCompletionSource<bool>(), tcs) == tcs))
                    return;
            }
        }

        #endregion
    }
}