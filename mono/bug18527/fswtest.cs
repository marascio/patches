using System;
using System.IO;

namespace fswtest
{
	class Class1
	{
		[STAThread]
		static void Main(string[] args)
		{
            FileSystemWatcher fsw = new FileSystemWatcher(args[0]);
            
            fsw.Created += new FileSystemEventHandler(fswEvent);
            fsw.Deleted += new FileSystemEventHandler(fswEvent);
            fsw.Changed += new FileSystemEventHandler(fswEvent);
            fsw.Renamed += new RenamedEventHandler(fswRenamedEvent);

            fsw.EnableRaisingEvents = true;

            Console.WriteLine("Press enter to quit");
            Console.ReadLine();

            fsw.EnableRaisingEvents = false;
            fsw.Dispose();
        }

        private static void fswEvent(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("{0} - {1}", e.ChangeType, e.Name);
        }

        private static void fswRenamedEvent(object sender, RenamedEventArgs e)
        {
            Console.WriteLine("{0} - {1} -> {2}", e.ChangeType, e.OldName, e.Name);
        }
    }
}
