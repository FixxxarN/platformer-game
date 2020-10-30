using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private Sprite[] _sprites;
    private bool _isOpened = false;
    private bool _isPlayerStandingByTheDoor = false;
    private GameObject Player;

    public bool IsOpened
    {
        get { return _isOpened; }
    }

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = _sprites[0];
    }

    void Update()
    {
        InteractWithDoor();
    }

    private void InteractWithDoor()
    {
        if(_isPlayerStandingByTheDoor)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (_isOpened)
                {
                    GetComponent<SpriteRenderer>().sprite = _sprites[0];
                    transform.Find("collider").gameObject.SetActive(true);
                    _isOpened = false;
                }
                else
                {
                    if (Player.transform.position.x > transform.position.x)
                        GetComponent<SpriteRenderer>().sprite = _sprites[1];
                    else
                        GetComponent<SpriteRenderer>().sprite = _sprites[2];
                    transform.Find("collider").gameObject.SetActive(false);
                    _isOpened = true;
                }
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player = other.gameObject;
            _isPlayerStandingByTheDoor = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player = null;
            _isPlayerStandingByTheDoor = false;
        }
    }
}
