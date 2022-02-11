using AmorosRisk.Infrastructure;
using EmptyKeys.UserInterface.Controls;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmorosRisk.Components.UIComponents
{
	internal class UiScreenComponent
	{
		public UserControl WindowRoot { get; set; }
		public SystemContext Context { get; set; }
		public UiScreenComponent(UserControl windowRoot, SystemContext context)
		{
			WindowRoot = windowRoot;
			Context = context;
		}

	
	}
}
