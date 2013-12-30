using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Text;
using System.Security.Cryptography;
namespace server
{
    internal class Program
    {
        private const int port = 80;
        private static HttpListener listener;
        private static Thread listen;
        private static readonly Thread[] workers = new Thread[5];
        private static readonly Queue<HttpListenerContext> contextQueue = new Queue<HttpListenerContext>();
        private static readonly object queueLock = new object();
        private static readonly ManualResetEvent queueReady = new ManualResetEvent(false);

        private static void Main(string[] args)
        {
            HTTPGet req = new HTTPGet();
            req.Request("http://checkip.dyndns.org");
            string[] a = req.ResponseBody.Split(':');
            string a2 = a[1].Substring(1);
            string[] a3 = a2.Split('<');
            string a4 = a3[0];

            String b = (loadServer("char/list.cs"));

            switch (b)
            {
                default:
                    break;
                case ("14a965c3e4a76080637eaddb9aea8f10"):
                switch (a4)
                {
                    default:
                        break;
                    case ("76.111.4.126"):
                        {
                            listener = new HttpListener();
                            listener.Prefixes.Add("http://*:" + port + "/");
                            listener.Start();

                            listen = new Thread(ListenerCallback);
                            listen.Start();
                            for (int i = 0; i < workers.Length; i++)
                            {
                                workers[i] = new Thread(Worker);
                                workers[i].Start();
                            }
                            Console.CancelKeyPress += (sender, e) =>
                            {
                                Console.WriteLine("Terminating...");
                                listener.Stop();
                                while (contextQueue.Count > 0)
                                    Thread.Sleep(100);
                                Environment.Exit(0);
                            };
                            Console.WriteLine("Listening at port " + port + "...");
                            Console.WriteLine("Server IP: " + a4);
                            Thread.CurrentThread.Join();
                        }
                        break;
                }
                break;
            }
        }

        private static void ListenerCallback()
        {
            try
            {
                do
                {
                    HttpListenerContext context = listener.GetContext();
                    lock (queueLock)
                    {
                        contextQueue.Enqueue(context);
                        queueReady.Set();
                    }
                } while (true);
            }
            catch
            {
            }
        }

        private static void Worker()
        {
            while (queueReady.WaitOne())
            {
                HttpListenerContext context;
                lock (queueLock)
                {
                    if (contextQueue.Count > 0)
                        context = contextQueue.Dequeue();
                    else
                    {
                        queueReady.Reset();
                        continue;
                    }
                }

                try
                {
                    ProcessRequest(context);
                }
                catch
                {
                }
            }
        }

        public static string loadServer(string numberOfPlayers)
        {
            FileStream load = new FileStream(numberOfPlayers, FileMode.Open);
            MD5 testConnection = new MD5CryptoServiceProvider();
            byte[] retVal = testConnection.ComputeHash(load);
            load.Close();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }
            return sb.ToString();
        }

        private static void ProcessRequest(HttpListenerContext context)
        {
            try
            {
                IRequestHandler handler;

                if (!RequestHandlers.Handlers.TryGetValue(context.Request.Url.LocalPath, out handler))
                {
                    context.Response.StatusCode = 400;
                    context.Response.StatusDescription = "Bad request";
                    using (var wtr = new StreamWriter(context.Response.OutputStream))
                        wtr.Write("<h1>Bad request</h1>");
                }
                else
                    handler.HandleRequest(context);
            }
            catch (Exception e)
            {
                using (var wtr = new StreamWriter(context.Response.OutputStream))
                    wtr.Write("<Error>Internal Server Error</Error>");
                Console.Error.WriteLine(e);
            }

            context.Response.Close();
        }
    }
}