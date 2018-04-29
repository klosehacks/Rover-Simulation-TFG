using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


	public class PathPlanningExecutor 
	{
		//public delegate void _OnThreadExit ();
		//public static event _OnThreadExit onThreadExit;
		
		static string ruta_directorio  = ".\\PathPlanning\\Paths";
		static string ruta_archivo_jar = "..\\PathPlanning.jar";
		static string ruta_archivo_dtm = "..\\DTM\\DTEEC_023928_1205_024060_1205_U01.IMG";
		static string ruta_archivo_out = "pathPoints.txt";

		static int posicion_inicial_x = 1000;
		static int posicion_inicial_y = 1000;
		static int posicion_final_x = 1200;
		static int posicion_final_y = 1200;

		static float valor_heuristico = 0.5f;

		/**
         * Escala
         * A = 0.25 m ==> Escala = 4
         * B = 0.5 m  ==> Escala = 2
         * C = 1.0 m  ==> Escala = 1
         * D = 2.0 m  ==> Escala = 0.5
         */
		static double escala_mapa = 1;
		static int pendiente = -1; // -1 desactiva el límite de la pendiente

		string[] argumentos_cadena = new string[]
		{
			"-Djava.util.Arrays.useLegacyMergeSort=true",
			"-Xmx1G",
			"-jar",
			ruta_archivo_jar,
			ruta_archivo_dtm,
			"null",
			posicion_inicial_x + "",
			posicion_inicial_y + "",
			posicion_final_x + "",
			posicion_final_y + "",
			"-n",
			valor_heuristico.ToString().Replace(',','.'),
			"-z",
			escala_mapa + "",
			pendiente + "",
			ruta_archivo_out
		};
	/*
	public PathPlanningExecutor()
	{
	}
	*/
		
	public int execute()
	{
		UnityEngine.Debug.Log ("Inicia la ejecucion");

		string argumentos = "";
		foreach(String str in argumentos_cadena)
		{
			argumentos += str + " ";
		}
			try
			{
				Process processJar = new Process();

				processJar.StartInfo.FileName = "java";
				processJar.StartInfo.Arguments = argumentos;
				processJar.StartInfo.WorkingDirectory = ruta_directorio;

				processJar.StartInfo.RedirectStandardOutput = true;
				processJar.StartInfo.RedirectStandardError = true;
				processJar.StartInfo.UseShellExecute = false;
				processJar.StartInfo.CreateNoWindow = true;
				processJar.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

				processJar.Start();

				if (!processJar.HasExited)
				{
					processJar.WaitForExit();
					UnityEngine.Debug.Log ("El proceso "+ processJar.ProcessName + " ha terminado.");
				}

				// En caso de error...
				if(processJar.ExitCode != 0)
				{
					UnityEngine.Debug.Log("Final_Err: " + processJar.StandardError.ReadToEnd());
					return 1;
				}
			}
			catch (Exception ex)
			{
				UnityEngine.Debug.Log( "Exception_Err: " + ex.Message);
				return 2;
			}
			return 0;
		}
	}




