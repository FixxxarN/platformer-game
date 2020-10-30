using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomHandler : MonoBehaviour
{
    public bool IsVisible;
    [SerializeField]
    private List<GameObject> _doors;
    private bool _isPlayerInside;
    
    void Update()
    {
        if(_doors.Count > 0)
        {
            if(_doors.Exists(d => d.GetComponent<Door>().IsOpened) || _isPlayerInside || IsVisible)
                transform.Find("Overlay").gameObject.SetActive(false);
            else
                transform.Find("Overlay").gameObject.SetActive(true);
        }
        else
        {
            if (_isPlayerInside)
                transform.Find("Overlay").gameObject.SetActive(false);
            else
                transform.Find("Overlay").gameObject.SetActive(true);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
            _isPlayerInside = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
            _isPlayerInside = false;
    }
}
