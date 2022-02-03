using System;

namespace AmorosRisk
{
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
