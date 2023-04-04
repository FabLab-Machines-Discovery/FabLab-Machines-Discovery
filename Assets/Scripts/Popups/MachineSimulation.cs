using System;
using UnityEngine;

namespace Popups
{
    [RequireComponent(typeof(Animator))]
    public class MachineSimulation : MonoBehaviour
    {
        // Popup that would play this simulation when clicked
        private Popup _caller;
        
        // Animator component needed to play the simulation
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        
        /// <summary>
        /// Plays the simulation if it's not already playing
        /// </summary>
        /// <param name="caller">Reference to the simulation popup that calls this when clicked</param>
        public void Play(Popup caller)
        {
            if (gameObject.activeSelf) return;
            
            caller.gameObject.SetActive(false);
            _caller = caller;
            
            gameObject.SetActive(true);
            _animator.Play("Playing State", -1, 0f);
        }

        /// <summary>
        /// Should be called when playing the simulation is finished
        /// </summary>
        public void Exit()
        {
            gameObject.SetActive(false);

                _caller.gameObject.SetActive(true);

        }
    }
}