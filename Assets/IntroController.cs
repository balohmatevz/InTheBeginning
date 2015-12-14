using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IntroController : MonoBehaviour {

    float progression = 0;
    public CanvasGroup LiamLimeLogo;
    public AudioSource LiamLimeAudio;
    public CanvasGroup LudumDareLogo;
    public AudioSource LudumDareAudio;

    
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        progression += Time.deltaTime;

        LiamLimeLogo.alpha = 0;
        LudumDareLogo.alpha = 0;

        if (progression > 1f && progression < 2f)
        {
            LiamLimeLogo.alpha = progression - 1;
            if (!LiamLimeAudio.isPlaying)
            {
                LiamLimeAudio.Play();
            }
        }
        if (progression > 2f && progression < 3.5f)
        {
            LiamLimeLogo.alpha = 1;
        }
        if (progression > 3.5f && progression < 4.5f)
        {
            LiamLimeLogo.alpha = Mathf.Abs(progression - 4.5f);
        }



        if (progression > 5f && progression < 6f)
        {
            LudumDareLogo.alpha = progression - 5;
            if (!LudumDareAudio.isPlaying)
            {
                LudumDareAudio.Play();
            }
        }
        if (progression > 6f && progression < 7.5f)
        {
            LudumDareLogo.alpha = 1;
        }
        if (progression > 7.5f && progression < 8.5f)
        {
            LudumDareLogo.alpha = Mathf.Abs(progression - 8.5f);
        }


        if (progression > 9f)
        {
            Application.LoadLevel("Menu");
        }

    }
}
