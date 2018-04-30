using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileProcessing {
	
	public static string readFile(string pathFile)
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

	public static void writeFile(string pathFile,string text)
	{
		System.IO.File.WriteAllText(pathFile,text);	
	}

	public static Path readPath(string path)
	{
		Path newPath = new Path ();

		string file = readFile (path);
		string [] values = file.Split('#');
		string []strLenght = values [1].Split (' ');
		// Distancia recorrida
		newPath._length = float.Parse(strLenght [1]);

		string []strSteps1 = values [7].Split (' ');
		string[] strSteps2 = strSteps1 [1].Split ('\n');
		// Numeros de pasos
		newPath._steps  = int.Parse(strSteps2[0]);

		string[] strAllSteps = file.Split (':');
		string[] strPoints = strAllSteps[8].Split ('\n');

		//string rtn = "";

		for (int i = 1; i < strPoints.Length-1; i++)
		{
			string[] strCoordiantes = strPoints [i].Split (' ');
			//rtn += strCoordiantes [0] + "-" + strCoordiantes[1] + "-" + strCoordiantes[2] + "\n";
			float x = float.Parse (strCoordiantes[0]);
			float y = float.Parse (strCoordiantes[1]);
			float z = float.Parse (strCoordiantes[2]);
			Vector3 point = new Vector3 (x, y, z);
			newPath._points.Add (point);
		}
		return newPath;
	}
}
