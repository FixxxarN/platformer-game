using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    private bool _isPlayerNearWindow = false;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PeekThroughWindow();
    }

    private void PeekThroughWindow()
    {
        if(_isPlayerNearWindow)
        {
            if(Input.GetKey(KeyCode.E))
            {
                transform.parent.gameObject.GetComponent<RoomHandler>().IsVisible = true;
            }
            else
            {
                transform.parent.gameObject.GetComponent<RoomHandler>().IsVisible = false;
            }
        }
        else
        {
            transform.parent.gameObject.GetComponent<RoomHandler>().IsVisible = false;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            _isPlayerNearWindow = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _isPlayerNearWindow = false;
        }
    }
}
