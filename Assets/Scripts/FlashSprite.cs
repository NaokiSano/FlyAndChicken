using UnityEngine;
using System.Collections;

public class FlashSprite : MonoBehaviour {
    private SpriteRenderer spriteRenderer;
    private Color color;
    private float minAlpha;
    private float maxAlpha;
    public float velosity;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = spriteRenderer.color;
        velosity /= 255.0f;
        minAlpha = 50 / 255.0f;
        maxAlpha = 1;
    }
	
	// Update is called once per frame
	void Update () {
        color.a += velosity * Time.deltaTime;
        if (color.a <= minAlpha || color.a >= maxAlpha)
        {
            velosity *= -1;
            color.a = color.a <= minAlpha ? minAlpha : maxAlpha;
        }
        spriteRenderer.color = color;
	}
}
