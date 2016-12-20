using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {
    // ส่วน player
    private Rigidbody rb;
    public float speed;
    public Text countText;
    public Text winText;
    private int count;
     void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }
    void FixedUpdate()
    {
        float movieHorizontal = Input.GetAxis ("Horizontal");
        float movieVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (movieHorizontal, 0.0f, movieVertical);

        rb.AddForce (movement* speed);
        
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count " + count.ToString();
        if(count > 7)
        {
            winText.text = "You Win";
        }
    }
}
 /*Destroy(other.gameObject);
if(other.gameObject.CompareTag("Player"))
    gameObject.SetActive(false);*/