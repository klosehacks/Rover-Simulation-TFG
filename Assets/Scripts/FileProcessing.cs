using System;

public class FileProcessing {
	
	public static string ReadFile(string pathFile)
	{
		string line;
		string fileText = "";

		System.IO.StreamReader file = new System.IO.StreamReader (pathFile);

		while((line = file.ReadLine()) != null)
		{
				fileText += line + "\n";
		}
		file.Close ();

		return fileText;
	}

	public static void WriteFile(string pathFile,string text)
	{
		System.IO.File.WriteAllText(pathFile,text);	
	}
}
