using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Planet : MonoBehaviour {

	public const float PLANET_SIZE = 0.5f;
	public float Atmosphere = 0.0f;
    public List<Tool> ToolList;
    public List<Snow> SnowList;
    public List<Water> WaterList;
    public float Temperature = 150f;
    public float Water = 150f;
    public float o2level = 0;

    SpriteRenderer sr;

    // Use this for initialization
    void Awake () {
		C.planet = this;
		this.transform.localScale = Vector3.one * PLANET_SIZE;
        ToolList = new List<Tool>();
        SnowList = new List<Snow>();
        WaterList = new List<Water>();
        sr = this.GetComponent<SpriteRenderer>();
        Atmosphere = 0;

    }
	
	// Update is called once per frame
	void Update () {
        //this.Atmosphere += Time.deltaTime * 0.25f; //DEBUG increases atmosphere over time

        Temperature = Mathf.Max(2.7f, Temperature);

        Atmosphere -= (Atmosphere / 100) * Time.deltaTime;
        Atmosphere = Mathf.Max(0f, Atmosphere);

        if (Temperature >= 0 && Temperature < 150)
        {
            sr.color = new Color(220f / 255, 220f / 255, 220f / 255);
        }
        if (Temperature >= 150 && Temperature < 220)
        {
            float diff = (Temperature - 150) / 70;
            sr.color = new Color((200 + ((1 - diff) * 20)) / 255, (200 + ((1 - diff) * 20)) / 255, (220 + (diff * 35)) / 255);
        }
        if (Temperature >= 220 && Temperature < 280)
        {
            float diff = (Temperature - 220) / 60;
            sr.color = new Color((200 - 69 * diff) / 255, (200 - 95 * diff) / 255, (255 - 199 * diff) / 255);
        }
        if (Temperature >= 280 && Temperature < 320)
        {
            sr.color = new Color(131f / 255, 105f / 255, 56f / 255);
        }
        if (Temperature >= 320 && Temperature < 520)
        {
            float diff = (Temperature - 320) / 200;
            sr.color = new Color((131 + 36 * diff) / 255, (105 - 18 * diff) / 255, (56 - 16 * diff) / 255);
        }
        if (Temperature >= 520 && Temperature < 520)
        {
            sr.color = new Color(167f / 255, 87f / 255, 40f / 255);
        }


        o2level = Mathf.Clamp(o2level, 0, 1);
    }
}
