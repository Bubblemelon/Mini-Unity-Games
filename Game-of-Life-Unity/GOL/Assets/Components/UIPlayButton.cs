using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class UIPlayButton : MonoBehaviour {

	public Grid grid;
	public Text text;
	private Toggle toggle;

	void Start() {
		toggle = GetComponent<Toggle>();
	}

	public void Toggle() {

		text.text = !toggle.isOn ? "Play" : "Pause";

		grid.PlayOrPause();
	}
}
