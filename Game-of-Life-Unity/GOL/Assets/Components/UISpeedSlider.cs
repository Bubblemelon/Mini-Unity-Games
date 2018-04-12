using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class UISpeedSlider : MonoBehaviour {

	public Grid grid;
	private Slider slider;

	void Start () {
		slider = GetComponent<Slider>();
	}

	public void OnSliderValueChanged() {
		grid.SetEvolutionPeriod(slider.value);
	}
}
