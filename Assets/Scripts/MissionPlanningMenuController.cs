using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class MissionPlanningMenuController : MonoBehaviour {

	// PRIVATE //
	private bool _isThreadRunning;

	// PUBLIC //
	public Text _console;

	// AUX //
	private int cont = 0;


	void Start () 
	{
		_isThreadRunning = false;
		_console.text = "";
	}

	void Update()
	{
		if (_isThreadRunning) 
		{
			_console.text = "Calulando ruta..." + cont++;
		} else {
			_console.text = "Esperando..." + cont++;
		}

		/*
		if(_updateData)
		{
			_console.text = FileProcessing.ReadFile (".\\PathPlanning\\Paths\\pathPoints.txt");
			_updateData = false;
		}
		*/
	}

	/// <summary>
	/// Inicia la ejecucion del hilo que se encarga de ejecutar el proceso del algoritmo de pathplanning.
	/// </summary>
	public void startPathPlanningExecutor()
	{
		ThreadStart pathPlanningExecutorThread;
		_isThreadRunning = true;
		pathPlanningExecutorThread = new ThreadStart (Run);
		Thread hilo = new Thread (pathPlanningExecutorThread);
		hilo.Start ();
		//hilo.Join ();

	}

	/// <summary>
	/// Metodo que va a ejecutar el hilo.
	/// </summary>
	private void Run()
	{
		PathPlanningExecutor pathPlanningExecutor = new PathPlanningExecutor ();


		Debug.Log ("Resultado: " + pathPlanningExecutor.execute ());

		_isThreadRunning = false;

	}

	/*
	// Se ejecuta cuando se activa el objeto //
	void OnEnable(){
		PathPlanningExecutor.onThreadExit += HandleOnThreadExit;
	}

	// Se jecuta cuando se desactiva el objeto //
	void OnDisable(){
		PathPlanningExecutor.onThreadExit -= HandleOnThreadExit;
	}

	// Metodo que se ejecuta cuando termina la ejecucion del hilo //
	void HandleOnThreadExit(){
		Debug.Log ("Termino la ejecucion correctamente.");
		_isThreadRunning = false;
	}
	*/
}
