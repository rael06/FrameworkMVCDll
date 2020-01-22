using System;
using System.Collections.Generic;

namespace FrameworkMVC.Core
{
	public class App
	{
		private Controller controller;
		private Dictionary<string, object> data = new Dictionary<string, object>();
		public App(string[] paramsNames, string[] args)
		{
			for (int i = 0; i < args.Length; i++)
			{
				data.Add(paramsNames[i], args[i]);
			}
		}

		public void Route()
		{
			var controllerName = UppercaseFirst(LastUrlSegment(data["controller"] as string));
			controller = GetInstance(controllerName);
			controller.Init(data, controllerName);
			controller.Start();
			controller.ShowView();
		}

		private Controller GetInstance(string name)
		{
			string controllerName = $"{Constants.ROOT_NAMESPACE}.Controllers.{name}";
			var t = Constants.ASSEMBLY.GetType(controllerName);

			return (Controller)Activator.CreateInstance(t);
		}

		private string LastUrlSegment(string s)
		{
			var url = s.Split('/');
			return url[url.Length - 1];
		}

		private string UppercaseFirst(string s)
		{
			if (string.IsNullOrEmpty(s))
			{
				return string.Empty;
			}
			return char.ToUpper(s[0]) + s.Substring(1);
		}
	}
}
