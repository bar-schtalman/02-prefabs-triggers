using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class round_world : MonoBehaviour
{
    Vector3 move;
    // Start is called before the first frame update
    float x_offset = 0.5f;
    float y_offset = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "right_lim" && enabled){
           move = new Vector3(-transform.position.x+x_offset, transform.position.y,0);
           transform.position = move;
        }
        if(other.tag == "left_lim" && enabled){
           move = new Vector3(-transform.position.x-x_offset, transform.position.y,0);
           transform.position = move;
        }
        if(other.tag == "top_lim" && enabled){
           move = new Vector3(transform.position.x, -transform.position.y+y_offset,0);
           transform.position = move;
        }
        if(other.tag == "bottom_lim" && enabled){
           move = new Vector3(transform.position.x, -transform.position.y-y_offset,0);
           transform.position = move;
        }
    }
}
