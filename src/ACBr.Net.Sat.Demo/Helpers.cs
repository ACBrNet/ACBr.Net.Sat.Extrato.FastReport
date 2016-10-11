using System.Configuration;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ACBr.Net.Sat.Demo
{
	public static class Helpers
	{
		public static string OpenFile(string filters)
		{
			using (var ofd = new OpenFileDialog())
			{
				ofd.CheckPathExists = true;
				ofd.CheckFileExists = true;
				ofd.Multiselect = false;
				ofd.Filter = filters;

				return ofd.ShowDialog().Equals(DialogResult.Cancel) ? null : ofd.FileName;
			}
		}

		public static string SaveFile(string filename, string filter)
		{
			using (var sfd = new SaveFileDialog())
			{
				sfd.CheckPathExists = true;
				sfd.CheckFileExists = true;
				sfd.Filter = filter;
				sfd.FileName = filename;

				return sfd.ShowDialog().Equals(DialogResult.Cancel) ? null : sfd.FileName;
			}
		}

		public static Configuration GetConfiguration()
		{
			var configFile = Path.Combine(Application.StartupPath, "sat.config");
			if (!File.Exists(configFile))
			{
				var sb = new StringBuilder();
				sb.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
				sb.AppendLine("<configuration>");
				sb.AppendLine("	<appSettings>");
				sb.AppendLine("	</appSettings>");
				sb.AppendLine("</configuration>");
				File.WriteAllText(configFile, sb.ToString());
			}

			var configFileMap = new ExeConfigurationFileMap
			{
				ExeConfigFilename = Path.Combine(Application.StartupPath, "sat.config")
			};

			return ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
		}
	}
}