using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Elevator : MonoBehaviour
    {
        private bool _isPlayerStandingByElevator = false;
        private GameObject _player;

        void Start()
        {

        }

        void Update()
        {
            if(_isPlayerStandingByElevator)
            {
                if(Input.GetKeyDown(KeyCode.UpArrow))
                {
                    _player.transform.position = transform.parent.gameObject.transform.parent.gameObject.GetComponent<BuildingHandler>().Elevators[1].transform.position;
                }
                else if(Input.GetKeyDown(KeyCode.DownArrow))
                {
                    _player.transform.position = transform.parent.gameObject.transform.parent.gameObject.GetComponent<BuildingHandler>().Elevators[0].transform.position;
                }
            }
        }

        void OnTriggerStay2D(Collider2D other)
        {
            if(other.tag == "Player")
            {
                _player = other.gameObject;
                _isPlayerStandingByElevator = true;
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                _player = null;
                _isPlayerStandingByElevator = false;
            }
        }
    }
}
