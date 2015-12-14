using UnityEngine;
using System.Collections;

public class Snow : MonoBehaviour {

    public float amount = 0;
    public SpriteRenderer sr;
    public float angle;

	// Use this for initialization
	void Start () {
        sr = this.GetComponent<SpriteRenderer>();
        C.planet.SnowList.Add(this);
	}
	
	// Update is called once per frame
	void Update () {

        amount = Mathf.Min(amount, 40f);
        amount -= Time.deltaTime;

        amount = Mathf.Max(0, amount);

	    if(amount < 20)
        {
            sr.color = new Color(1, 1, 1, Mathf.Max(0, amount / 20));
        }
        else
        {
            sr.color = new Color(1, 1, 1, 1);
        }
    }
}
