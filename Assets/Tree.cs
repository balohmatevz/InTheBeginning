using UnityEngine;
using System.Collections;

public class Tree : MonoBehaviour {

    public Water water;
    public float life = 0;
    public SpriteRenderer sr;

    // Use this for initialization
    void Start ()
    {
        sr = this.GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {

        life = Mathf.Max(life, 0);

        if (life < 1)
        {
            sr.color = new Color((111 * (1-life)) / 255, (111 - ((1-life) * 46)) / 255, 19f / 255, 1);
        }

        if (life >= 1)
        {
            sr.color = new Color(0 / 255, 111f / 255, 19f / 255, 1);
        }
        
        if (water.amount > 0.3f)
        {
            //water
            water.transferOut += 0.05f * Time.deltaTime;
            life += 0.05f * Time.deltaTime;
        }
        else
        {
            //no water
            life -= Time.deltaTime / 30;
        }

        if (C.planet.Temperature < 260f)
        {
            //too cold
            float rate = 60 - (260 - C.planet.Temperature);
            if (rate < 1)
            {
                rate = 1;
            }

            life -= Time.deltaTime / rate;
        }

        if (C.planet.Temperature > 330f)
        {
            //too hot
            float rate = 60 - (C.planet.Temperature - 330);
            if (rate < 1)
            {
                rate = 1;
            }

            life -= Time.deltaTime / rate;
        }

        if (C.planet.Atmosphere < 0.7f)
        {
            //not enough air
            life -= Time.deltaTime / 60;
        }

        if (life >= 0.01f)
        {
            if (C.planet.Atmosphere > 0f)
            {
                //co2 to o2
                C.planet.o2level += 0.02f * Time.deltaTime;
            }
        }



        if (life <= 0.01f)
        {
            sr.color = new Color(1, 1, 1, 0);
            //return;
        }
    }
}
