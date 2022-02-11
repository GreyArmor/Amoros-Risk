using AmorosRisk.Systems;
using EmptyKeys.UserInterface.Input;
using EmptyKeys.UserInterface.Mvvm;
using System;

namespace AmorosRisk
{
	public class MainMenuScreenViewModel : ViewModelBase
	{

		private AmorosRiskGame game;
		public ICommand PlayCommand
		{
			get;
			set;
		}
		public ICommand CreditsCommand
		{
			get;
			set;
		}

		public MainMenuScreenViewModel(AmorosRiskGame game)
		{
			this.game = game;
			PlayCommand = new RelayCommand(new Action<object>(
				(object o)=>
				{
					this.game.ScheduleContextChange(Infrastructure.SystemContext.InGame);
				}));

			CreditsCommand = new RelayCommand(new Action<object>(
			(object o) =>
			{
				//nothing for now
				//this.game.ScheduleContextChange(Infrastructure.SystemContext.Credits);
			}));

		}
	}
}