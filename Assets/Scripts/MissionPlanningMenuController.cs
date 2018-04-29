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
	public Image _mapDisplay;
	public Dropdown _dropdownMap;
	public Dropdown _dropdownMission;

	public Map[] _maps;

	// AUX //
	private int cont = 0;


	void Start () 
	{
		_isThreadRunning = false;
		//_console.text = "";

		List<string> mapNames = new List<string>();
		foreach (Map map in _maps) 
		{
			mapNames.Add (map._name);
		}
		_dropdownMap.AddOptions (mapNames);
	}

	void Update()
	{
		/*
		if (_isThreadRunning) 
		{
			_console.text = "Calulando ruta..." + cont++;
		} else {
			_console.text = "Esperando..." + cont++;
		}
		*/

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

	/// <summary>
	/// Se ejecuta cuando cambia un valor en el dropdown de mapas.
	/// </summary>
	public void onDropDownMapVC (int index)
	{
		_console.text = _maps [index]._id;
		_mapDisplay.sprite = _maps [index]._image;

	}
}
