using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CampaignController : MonoBehaviour {

    int stage = 0;
    float progression = 0;

    public Text t;
    public CanvasGroup cg;
    public Button btn;
    public CanvasGroup btnCG;

    public Tool t1;
    public Tool t2;
    public Tool t3;
    public GameObject circle;
    public Background background;

    int freeplay = 1;
    int campaigning = 0;

    // Use this for initialization
    void Start() {
        C.campaign = this;

    }

    // Update is called once per frame
    void Update() {
        

        progression += Time.deltaTime;

        if (campaigning == 0) {
            freeplay = PlayerPrefs.GetInt("freeplay");
        }
        if(freeplay != 0)
        {
            circle.active = false;
            cg.alpha = 0;
            return;
        }

        switch (stage)
        {
            case 0:

                t1.gameObject.active = false;
                t2.gameObject.active = false;
                t3.gameObject.active = false;
                circle.active = false;

                t.text = "Welcome to 'In the beginning'. Campaign information will appear here.";
                btnCG.alpha = 1;
                break;
            case 1:
                t.text = "This is your planet. It's not much right now, but with your help, it will soon support life.";
                btnCG.alpha = 1;
                break;
            case 2:
                t.text = "You have some tools available to you. Click on one to select it.";
                btnCG.alpha = 0;
                t3.gameObject.active = true;
                circle.active = true;
                circle.transform.position = t3.gameObject.transform.position;
                t3.progressOnClick = true;
                break;
            case 3:
                t.text = "Now you have the heating tool selected. You can move it anywhere around the planet by clicking there. Do so now.";
                circle.active = false;
                background.progressOnClick = true;
                btnCG.alpha = 0;
                break;
            case 4:
                t.text = "Good. Click on the tool again to turn it on.";
                btnCG.alpha = 0;
                t3.gameObject.active = true;
                circle.active = true;
                circle.transform.position = t3.gameObject.transform.position;
                t3.progressOnClick = true;
                break;
            case 5:
                t.text = "Great! Notice the temperature display in the top left. It is going up! Once it reaches about 290 Kelvin, stop the tool by clicking on it.";
                circle.active = false;
                if(C.planet.Temperature > 290)
                {
                    Progress2();
                }
                break;
            case 6:
                t.text = "Stop the tool now.";
                circle.active = true;
                t3.progressOnClick = true;
                circle.transform.position = t3.gameObject.transform.position;
                break;
            case 7:
                t.text = "Here is a new tool! this one makes ice! Try it now.";
                t1.gameObject.active = true;
                circle.active = true;
                t1.progressOnClick = true;
                circle.transform.position = t1.gameObject.transform.position;
                break;
            case 8:
                t.text = "Turn it on now.";
                t1.gameObject.active = true;
                circle.active = true;
                t1.progressOnClick = true;
                circle.transform.position = t1.gameObject.transform.position;
                break;
            case 9:
                t.text = "It makes ice! Try melting the ice with the heating tool. It of course needs to be over the ice to melt it.";
                circle.active = false;
                C.atmosphere.progressOnAtmos = true;
                break;
            case 10:
                t.text = "Look in the top left! It's creating an atmosphere!";
                btnCG.alpha = 1;
                break;
            case 11:
                t.text = "The atmosphere is however made of CO2. We'll need some plant life to convert it to oxygen.";
                btnCG.alpha = 1;
                break;
            case 12:
                t.text = "But before that. We need water.";
                btnCG.alpha = 1;
                break;
            case 13:
                t.text = "Time for a new tool!";
                t2.gameObject.active = true;
                circle.active = true;
                t2.progressOnClick = true;
                circle.transform.position = t2.gameObject.transform.position;
                btnCG.alpha = 0;
                break;
            case 14:
                t.text = "Turn it on and let it rain.";
                t2.gameObject.active = true;
                circle.active = true;
                t2.progressOnClick = true;
                circle.transform.position = t2.gameObject.transform.position;
                break;
            case 15:
                t.text = "Once the conditions are right for plant life to form, forests will grow.";
                btnCG.alpha = 1;
                circle.active = false;

                break;
            case 16:
                t.text = "For forests to grow, the temperature needs to be right, there needs to be an atmosphere and enough water.";
                btnCG.alpha = 1;
                circle.active = false;
                break;
            case 17:
                t.text = "Your planet is now suitable for animal life. Unfortunately, however, the seed of animal life did not ship with this game.";
                btnCG.alpha = 1;
                circle.active = false;
                break;
            case 18:
                t.text = "Thank you for playing. I hope you found this experience at least a bit interesting and innovative. ";
                btnCG.alpha = 1;
                circle.active = false;
                break;
            case 19:
                cg.alpha = 0;
                break;



        }

    }

    public void Progress()
    {
        if (btnCG.alpha > 0)
        {
            stage++;
        }
    }
    public void Progress2()
    {
        stage++;
    }
}
