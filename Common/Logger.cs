using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Media;
using ff14bot.Helpers;

namespace CarbuncleTech.Common
{
	public class Logger
	{   
		internal static void Log(string component, string text, Color color)
		{            
			Logging.Write(color, $@"[{component}] {text}");
        }
        
		internal static void Log(string component, string text)
		{
			Log(component, text, Color.FromRgb(255, 191, 0));
		}
	}
}