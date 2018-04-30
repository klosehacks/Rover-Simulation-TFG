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
	public Text _infoMapText;
	public Text _infoMissionText;
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

		// Rellena la información del dropdown de mapas //
		List<string> mapNames = new List<string>();
		foreach (Map map in _maps) 
		{
			mapNames.Add (map._name);
		}
		_dropdownMap.AddOptions (mapNames);

		// Carga la información del primer elemento del dropdown //
		loadMapInfo(0);

		// Esto es temporal //
		loadMissionInfo();
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
	/// <param name="index">Index.</param>
	public void onDropDownMapVC (int index)
	{
		loadMapInfo (index);
	}

	/// <summary>
	/// Actualiza el menu con la información del mapa seleccionado.
	/// </summary>
	/// <param name="index">Index.</param>
	private void loadMapInfo (int index)
	{
		Map map = _maps [index];
		_mapDisplay.sprite = map._image;

		string infoText = "INFORMACION DEL MAPA\n";
		infoText += "Nombre: " + map._name + "\n";
		infoText += "ID: " + map._id + "\n";
		infoText += "Tamaño: " + map._lines + "\n";
		infoText += "Factor de escala: " + map._scalingFactor + "\n"; 

		_infoMapText.text = infoText;
	}

	private void loadMissionInfo ()
	{
		Path path = FileProcessing.readPath (".\\PathPlanning\\Paths\\m01_02.txt");

		string infoText = "INFORMACION DE LA MISION\n";
		infoText += "Distnacia: " + path._length + "\n";
		infoText += "Numero de pasos: " + path._steps + "\n";
		infoText += "Ruta:\n";

		foreach(Vector3 vec in path._points)
		{
			infoText += vec.x + " " + vec.y + " " + vec.z + "\n"; 
		}

		_infoMissionText.text = infoText;
	}
}
