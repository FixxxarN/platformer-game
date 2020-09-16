﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class CameraController : MonoBehaviour
    {
        private GameObject player;

        void Start()
        {
            player = FindObjectOfType<PlayerController>().gameObject;
        }

        void Update()
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        }
    }
}
