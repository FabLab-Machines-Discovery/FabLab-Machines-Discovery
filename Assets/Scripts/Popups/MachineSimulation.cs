using System;
using UnityEngine;

namespace Popups
{
    [RequireComponent(typeof(Animator))]
    public class MachineSimulation : MonoBehaviour
    {
        // Animator component needed to play the simulation
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        /// <summary>
        /// Plays the simulation if it's not already playing
        /// </summary>
        public void Play()
        {
            if (gameObject.activeSelf) return;
            
            gameObject.SetActive(true);
            _animator.Play("Playing State", -1, 0f);
        }

        /// <summary>
        /// Should be called when playing the simulation is finished
        /// </summary>
        public void Exit()
        {
            gameObject.SetActive(false);
        }
    }
}