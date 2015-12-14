using UnityEngine;
using System.Collections;

public class Atmosphere : MonoBehaviour {

    public SpriteRenderer sr;
    public bool progressOnAtmos = false;

    // Use this for initialization
    void Start () {
        sr = this.GetComponent<SpriteRenderer>();
        C.atmosphere = this;
	}
	
	// Update is called once per frame
	void Update () {
		UpdateAtmosphere ();
        if(progressOnAtmos && C.planet.Atmosphere > 0)
        {
            progressOnAtmos = false;
            C.campaign.Progress2();
        }
	}

	public void UpdateAtmosphere(){
		this.transform.position = new Vector3 (0, 0, 1);
		this.transform.localScale = Vector3.one * (0.30f + Mathf.Min(1, C.planet.Atmosphere) * 0.33f);
        if(C.planet.Atmosphere > 0)
        {
            float amt = C.planet.o2level;
            sr.color = new Color((169 + 20 * amt) / 255, (57 + (239-57) * amt) / 255, (57 + (255-57) * amt) / 255, 1);
        }
    }
}
