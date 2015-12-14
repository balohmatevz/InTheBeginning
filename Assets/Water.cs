using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour {

    public int angle;
    public SpriteRenderer sr;
    public float amount;

    public float transferIn = 0;
    public float transferOut = 0;

    // Use this for initialization
    void Start ()
    {
        sr = this.GetComponent<SpriteRenderer>();
        C.planet.WaterList.Add(this);
    }
	
	// Update is called once per frame
	void Update ()
    {

        amount += transferIn;
        amount -= transferOut;

        transferIn = 0;
        transferOut = 0;

        amount = Mathf.Min(amount, 1f);
        amount -= Time.deltaTime / 100;

        amount = Mathf.Max(0, amount);

        if (amount < 1)
        {
            sr.color = new Color(1, 1, 1, Mathf.Max(0, amount / 1));
        }
        else
        {
            sr.color = new Color(1, 1, 1, 1);
        }

        if(amount > 0)
        {

            foreach (Water w in C.planet.WaterList)
            {
                if(w.angle == angle + 45 || w.angle == angle - 45 ||
                    w.angle == angle + 360 + 45 || w.angle == angle + 360 - 45)
                {
                    if (w.amount < this.amount)
                    {
                        //Debug.Log(w.angle + ", " + angle);
                        float diff = this.amount - w.amount;
                        diff = Mathf.Min(diff, amount / 300);

                        if (diff < 0.30f * Time.deltaTime)
                        {
                            this.transferOut += diff;
                            w.transferIn += diff;
                        }
                        else
                        {
                            diff = 0.30f * Time.deltaTime;
                            this.transferOut += diff;
                            w.transferIn += diff;
                        }
                    }
                }
            }
        }
    }
}
