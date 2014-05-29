﻿using System;
using System.Timers;
using TopShelf;

namespace TopShelf
{
	public class TownCrier
	{
		readonly Timer _timer;
		public TownCrier()
		{
			_timer = new Timer(1000) {AutoReset = true};
			_timer.Elapsed += (sender, eventArgs) => Console.WriteLine("It is {0} an all is well", DateTime.Now);
		}
		public void Start() { _timer.Start(); }
		public void Stop() { _timer.Stop(); }
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			HostFactory.Run(x =>                                 //1
				{
					x.Service<TownCrier>(s =>                        //2
						{
							s.ConstructUsing(name=> new TownCrier());     //3
							s.WhenStarted(tc => tc.Start());              //4
							s.WhenStopped(tc => tc.Stop());               //5
						});
					x.RunAsPrompt();                           //6

					x.SetDescription("Sample Topshelf Host");        //7
					x.SetDisplayName("Stuff");                       //8
					x.SetServiceName("stuff");                       //9
				});    
		}
	}
}
