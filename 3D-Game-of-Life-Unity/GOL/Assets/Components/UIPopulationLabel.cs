using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIPopulationLabel : MonoBehaviour {

	public Grid grid;
	private Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Population: " + grid.GetPopulationCount();
	}
}
