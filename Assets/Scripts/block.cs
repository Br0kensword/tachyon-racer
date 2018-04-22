using UnityEngine;


public class block : MonoBehaviour {

    public Color[] _colors;
    public float lerpTime;

    private Color lerpColorStart, lerpColorEnd;
    private Renderer blockRender;
    // Use this for initialization
    void Start () {
        blockRender = GetComponent<Renderer>();
        lerpColorStart = Color.white;
        lerpColorEnd = _colors[Random.Range(0, _colors.Length - 1)];
	}
	
	// Update is called once per frame
	void Update () {
        float lerp = Mathf.PingPong(Time.time, lerpTime) / lerpTime;

        blockRender.material.color = Color.Lerp(lerpColorStart, lerpColorEnd, lerp);

        if (lerp >= .9f)
        {
            lerpColorStart = _colors[Random.Range(0, _colors.Length - 1)];
        }
    }
	
}
