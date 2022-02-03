using System;

namespace AmorosRisk
{
	//look at me i am a change!
	public static class Program
	{
		[STAThread]
		static void Main()
		{
			using (var game = new AmorosRiskGame())
				game.Run();
		}
	}
}
