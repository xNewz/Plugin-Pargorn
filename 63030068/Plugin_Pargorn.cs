using System;
using PluginInterface;

namespace Plugin_Pargorn
{
	/// <summary>
	/// Plugin2
	/// </summary>
	public class Plugin : IPlugin  // <-- See how we inherited the IPlugin interface?
	{
		public Plugin()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		
		//Declarations of all our internal plugin variables
		string myName = "Plugin_Pargorn";
		string myDescription = "Check you age !";
		string myAuthor = "Pargorn Ruasijan";
		string myVersion = "1.0.1";
		IPluginHost myHost = null;
		System.Windows.Forms.UserControl myMainInterface = new ctlMain();
		
		/// <summary>
		/// Description of the Plugin's purpose
		/// </summary>
		public string Description
		{
			get {return myDescription;}
		}

		/// <summary>
		/// Author of the plugin
		/// </summary>
		public string Author
		{
			get	{return myAuthor;}
		
		}

		public IPluginHost Host
		{
			get {return myHost;}
			set	{myHost = value;}
		}

		public string Name
		{
			get {return myName;}
		}

		public System.Windows.Forms.UserControl MainInterface
		{
			get {return myMainInterface;}
		}

		public string Version
		{
			get	{return myVersion;}
		}
		
		public void Initialize()
		{
			//This is the first Function called by the host...
			//Put anything needed to start with here first
		}
		
		public void Dispose()
		{
			//Put any cleanup code in here for when the program is stopped
		}

	}
}
