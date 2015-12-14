using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TemperatureDisplay : MonoBehaviour {

    Text t;

	// Use this for initialization
	void Start () {
        t = this.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        t.text = "Temperature: " + Mathf.Floor(C.planet.Temperature) + " K\n";
        t.text += "Atmosphere: " + (Mathf.Round(C.planet.Atmosphere * 100) / 100) + " Atmospheres\n";
        t.text += "O2 percentage: " + (Mathf.Round(C.planet.o2level * 100) / 100) + "%\n";
    }
}
