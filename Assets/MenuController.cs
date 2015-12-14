using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

    public CanvasGroup menuCG;

    float progression = 0;
    bool fadeout = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (fadeout)
        {
            progression -= Time.deltaTime;
            menuCG.alpha = Mathf.Max(0, progression);
            if(progression <= 0)
            {
                Application.LoadLevel("Planet");

            }
        }
        else {
            progression += Time.deltaTime;
            menuCG.alpha = Mathf.Min(1, progression - 0.5f);
        }

    }

    public void StartFreePlay()
    {
        PlayerPrefs.SetInt("freeplay", 1);
        PlayerPrefs.Save();
        fadeout = true;
        progression = 1;
    }

    public void StartCampaign()
    {
        PlayerPrefs.SetInt("freeplay", 0);
        PlayerPrefs.Save();
        fadeout = true;
        progression = 1;
    }
}
