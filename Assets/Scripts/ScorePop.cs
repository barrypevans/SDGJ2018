using UnityEngine;
using UnityEngine.UI;

public class ScorePop : MonoBehaviour
{
    SpriteRenderer _image;
    float velocity = .1f;
    float color =1;
    private void Start()
    {
        _image = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        velocity -= .001f;
        transform.position += Vector3.up*velocity;
        color -= .01f;
        if (color <= 0) Destroy(gameObject);
        _image.color = new Color(1, 1, 1, color);
    }

}
