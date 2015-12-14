using UnityEngine;
using System.Collections;

public class Tool : MonoBehaviour {
	public float rotation;	//Rotation around the planet
	public float targetRotation;	//Rotation around the planet
	public ParticleSystem pSystem;
	public int type = 0;

    public float FreezeSpeed = 10f;
    public float HeatSpeed = 10f;
    public float WetSpeed = 10f;
    public float startingRotation = 0;

    public bool progressOnClick = false;

    public bool on = false;
    public SpriteRenderer sr;
    Color clr;

    // Use this for initialization
    void Start ()
    {
        rotation = startingRotation;
        targetRotation = startingRotation;
		C.planet.ToolList.Add (this);
        sr = this.GetComponent<SpriteRenderer>();
        clr = sr.color;

    }

    // Update is called once per frame
    void Update()
    {

        if(C.inputController.usingTool != this)
        {
            sr.color = clr;
        }
        else
        {
            sr.color = new Color(62f / 255, 165f / 255, 63f /255);
        }

        //Movement
        if (targetRotation != rotation)
        {

            while (rotation < 0)
            {
                rotation += 360;
            }
            while (rotation >= 360)
            {
                rotation -= 360;
            }
            while (targetRotation < 0)
            {
                targetRotation += 360;
            }
            while (targetRotation >= 360)
            {
                targetRotation -= 360;
            }

            float diff = targetRotation - rotation;



            int dir = 0; //-1 = left; 1 = right;

            if (diff > 0 && diff < 180)
            {
                dir = 1;
            }
            if (diff > 180)
            {
                dir = -1;
            }
            if (diff < 0 && diff > -180)
            {
                dir = -1;
            }
            if (diff < -180)
            {
                dir = 1;
            }

            float rotAmt = 90 * Time.deltaTime;

            if (dir == 1)
            {
                if (rotation + rotAmt > 360)
                {
                    rotation = rotation - 360 + rotAmt;
                }
                else {
                    rotation += rotAmt;
                }
            }

            if (dir == -1)
            {
                if (rotation - rotAmt < 0)
                {
                    rotation = rotation + 360 - rotAmt;
                }
                else {
                    rotation -= rotAmt;
                }
            }

            if (Mathf.Abs(rotation - targetRotation) < rotAmt)
            {
                rotation = targetRotation;
            }

            //Debug.Log (diff+"; "+dir);
        }
        else {

        }

        if (Input.GetKey("d"))
        {
            rotation += 90 * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            rotation -= 90 * Time.deltaTime;
        }

        this.transform.position = new Vector3(0, 9 * Planet.PLANET_SIZE, -1);
        this.transform.rotation = Quaternion.identity;
        this.transform.RotateAround(Vector3.zero, Vector3.back, rotation);

        //Do tool thing
        if (on)
        {
            if (!pSystem.isPlaying)
            {
                pSystem.Play();
            }
            switch (type)
            {
                case 0:

                    break;
                case 1:
                    //Freeze
                    C.planet.Temperature -= Time.deltaTime * FreezeSpeed;

                    foreach (Snow s in C.planet.SnowList)
                    {
                        if (rotation > (s.angle - 22.5f) && rotation < (s.angle + 22.5f) ||
                            (rotation - 360) > (s.angle - 22.5f) && (rotation - 360) < (s.angle + 22.5f))
                        {
                            s.amount += 10 * Time.deltaTime;
                        }
                    }

                    break;
                case 2:
                    //Rain
                    C.planet.Water -= Time.deltaTime * WetSpeed;

                    foreach (Water w in C.planet.WaterList)
                    {
                        if (rotation > (w.angle - 22.5f) && rotation < (w.angle + 22.5f) ||
                            (rotation - 360) > (w.angle - 22.5f) && (rotation - 360) < (w.angle + 22.5f))
                        {
                            w.amount += 0.2f * Time.deltaTime;
                        }
                    }
                    break;
                case 3:
                    //Heat
                    C.planet.Temperature += Time.deltaTime * HeatSpeed;

                    foreach (Snow s in C.planet.SnowList)
                    {
                        if (rotation > (s.angle - 22.5f) && rotation < (s.angle + 22.5f) ||
                            (rotation - 360) > (s.angle - 22.5f) && (rotation - 360) < (s.angle + 22.5f))
                        {
                            if(s.amount > 0)
                            {
                                float removedAmount = 10 * Time.deltaTime;
                                if(removedAmount > s.amount)
                                {
                                    removedAmount = s.amount;
                                }
                                s.amount -= removedAmount;
                                C.planet.Atmosphere += removedAmount / 100;
                                C.planet.o2level -= removedAmount / 50;
                            }
                            
                        }
                    }
                    break;
            }
        }
        else
        {

            if (pSystem.isPlaying)
            {
                pSystem.Stop();
            }
        }
    }

    void OnMouseUp()
    {
        if (C.inputController.usingTool != this)
        {
            C.inputController.usingTool = this;
        }
        else {
            on = !on;
        }

        if (progressOnClick)
        {
            progressOnClick = false;
            C.campaign.Progress2();
        }
    }
}
