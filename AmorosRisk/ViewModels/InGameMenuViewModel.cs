using EmptyKeys.UserInterface.Input;
using EmptyKeys.UserInterface.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmorosRisk.ViewModels
{

	public class InGameMenuViewModel : ViewModelBase
	{
		private AmorosRiskGame game;

		public ICommand BackCommand
		{
			get;
			set;
		}

		public InGameMenuViewModel(AmorosRiskGame game)
		{
			this.game = game;
			BackCommand = new RelayCommand(new Action<object>(
				(object o) =>
				{
					this.game.ScheduleContextChange(Infrastructure.SystemContext.MainMenu);
				}));
		}
	}
}
