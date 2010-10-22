using System;
using System.IO;
using log4net.Config;
using OpenRasta.Hosting.HttpListener;
using OpenTop.Service.Configuration;
using OpenTop.Service.Hosting;
using Topshelf;
using Topshelf.Configuration;
using Topshelf.Configuration.Dsl;

namespace OpenTop.Service
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XmlConfigurator.ConfigureAndWatch(new FileInfo(".\\log4net.config"));

            RunConfiguration cfg = RunnerConfigurator.New(x =>
            {
                x.AfterStoppingServices(h => Console.WriteLine("AfterStoppingServices action invoked, services are stopping"));

                x.ConfigureService<HttpListenerHost>(s =>
                {
                    s.Named("tc");
                    s.HowToBuildService(name => ConfigureListener());
                    s.WhenStarted(tc => tc.StartListening());
                    s.WhenStopped(tc => tc.StopListening());
                });

                x.RunAsLocalSystem();

                x.SetDescription("OpenRasta in TopShelf Demo");
                x.SetDisplayName("OpenTop Demo Project");
                x.SetServiceName("OpenTop");
            });

            Runner.Host(cfg, args);
        }

        private static HttpListenerHost ConfigureListener()
        {
            var h = new HttpListenerHostWithConfiguration { Configuration = new OpenTopConfig() };
            h.Initialize(new[] { "http://+:12345/" }, "/", null);
            return h;
        }
    }
}
