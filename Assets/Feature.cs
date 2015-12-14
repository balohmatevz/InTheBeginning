using UnityEngine;
using System.Collections;

public class Feature : MonoBehaviour {

	public float ScaleFactor; //Scale difference factor for this particular feature type.
	public SpriteRenderer sr;
	public Sprite Sprite;
	public float rotation;	//Rotation around the planet

	// Use this for initialization
	void Start () {
		ScaleFactor = 0.2f;
		sr = this.GetComponent<SpriteRenderer> ();
		sr.sprite = Sprite;
		this.transform.position = new Vector3 (0, 6 * Planet.PLANET_SIZE, -1);
		this.transform.localScale = Vector3.one * Planet.PLANET_SIZE * ScaleFactor;
		this.transform.RotateAround (Vector3.zero, Vector3.back, rotation);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
