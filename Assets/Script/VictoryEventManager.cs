using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script
{
    public class VictoryEventManager: MonoBehaviour
    {
        [SerializeField] private Transform _victoryWindow;
        [SerializeField] private Transform _endPoint;
        public static Action Victory;

        private void Start()
        {
            Victory += VictoryWindow;
        }

        private void OnDestroy()
        {
            Victory = null;
        }

        private void VictoryWindow()
        {
            _victoryWindow.DOMove(_endPoint.position, .5f);
        }

        public void Restart()
        {
            SceneManager.LoadScene(0);
        }
        
        
    }
}