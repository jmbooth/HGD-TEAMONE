using UnityEngine;
using System.Collections;

public class BubbleShield : MonoBehaviour {

    private Color bubble;
    // Use this for initialization
    void Start() {
        transform.position = Movement.dolphPos;
        bubble = GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update() {
        if (Movement.inBubble) {
            GetComponent<SpriteRenderer>().color = bubble;
        }
        else {
            GetComponent<SpriteRenderer>().color = new Color(bubble.r, bubble.g, bubble.b, 0f);
        }
        transform.position = Movement.dolphPos;
    }

    /*void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Net")) {
            if (Movement.inBubble)
            {
                Movement.powerUp = " ";
                Movement.inBubble = false;
                Destroy(other.gameObject);
            }
        }
        else if (other.gameObject.CompareTag("Harpoon")) {
            if (Movement.inBubble)
            {
                Movement.powerUp = " ";
                Movement.inBubble = false;
                Destroy(other.gameObject);
            }
        }

    }*/

}
