using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PeppaSquad.Utils;

namespace PeppaSquad.Enemies {
    public class ColorRandomizer : MonoBehaviour {

        void Start() {
            var renderer = GetComponent<Renderer>();
            renderer.material.color = new RandomColor();

        }

    }
}