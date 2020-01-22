using System.Collections.Generic;

namespace FrameworkMVC.Core
{
	public abstract class View
	{
		protected Dictionary<string, object> data;
		public View(Dictionary<string, object> data)
		{
			this.data = data;
		}

		public abstract void Show();
	}
}
