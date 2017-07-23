using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace AirTicket.Helper
{
    public class XmlHelper : IDisposable
    {
        private Thread xmlProcessingThread = null;
        private Queue<String> xmlQueue = new Queue<String>();
        private readonly object _xmlQueueLocker = new object();
        private EventWaitHandle _whxmlEvent = new AutoResetEvent(false);

        public XmlHelper()
        {
            xmlProcessingThread = new Thread(xmlProcessingThread_DoWork);
            xmlProcessingThread.Start();
        }
        public void Dispose()
        {
            // Signal the end by sending 'null'
            EnqueuexmlEvent(null);
            xmlProcessingThread.Join();
            _whxmlEvent.Close();
        }
        // The fast xml data comes in, locks queue, and then
        // enqueues the data, and releases the EventWaitHandle
        private void EnqueuexmlEvent(string wd)
        {
            lock (_xmlQueueLocker)
            {
                xmlQueue.Enqueue(wd);
                _whxmlEvent.Set();
            }
        }
        private void xmlProcessingThread_DoWork(object obj)
        {
            while (true)
            {
                string wd = null;
                lock (_xmlQueueLocker)
                {
                    if (xmlQueue.Count > 0)
                    {
                        wd = xmlQueue.Dequeue();
                        if (wd == null)
                        {
                            // Quit the loop, thread finishes
                            return;
                        }
                    }
                }
                if (wd != null)
                {
                    try
                    {
                        // Call specific handlers for the type of xmlData that was received
                    }
                    catch (Exception exc)
                    {
                        //log
                    }
                }
                else
                    _whxmlEvent.WaitOne(); // No more tasks, wait for a signal
            }
        }
    }
}