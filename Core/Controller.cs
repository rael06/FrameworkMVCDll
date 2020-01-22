using System;
using System.Collections.Generic;

namespace FrameworkMVC.Core
{
	public abstract class Controller
	{
		protected Dictionary<string, object> data;
		protected string name;
		protected Controller()
		{
		}
		public void Init(Dictionary<string, object> data, string name)
		{
			this.data = data;
			this.name = name;
		}
		protected abstract Dictionary<string, object> GenerateViewData();
		public abstract void Start();
		public void ShowView()
		{
			var data = GenerateViewData();
			var view = GetViewInstance(data);
			view.Show();
		}
		private View GetViewInstance(Dictionary<string, object> data)
		{
			var viewName = $"{Constants.ROOT_NAMESPACE}.Views.{name}View";
			Type t = Constants.ASSEMBLY.GetType(viewName);
			return (View)Activator.CreateInstance(t, data);
		}
	}
}
