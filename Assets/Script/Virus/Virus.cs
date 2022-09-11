using System;
using Script.Gun;
using Script.Virus.Model;
using Script.Virus.ViewVirus;
using TMPro;
using UnityEngine;

namespace Script.Virus
{
    public class Virus : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _virusMeshRenderer;
        [SerializeField] private TMP_Text _healthText;
        [SerializeField] private Rigidbody _virusRigidbody;
        [SerializeField] private float _speed;
        [SerializeField] private int _health;
        [SerializeField] private VictoryEventManager victoryEventManager;
        
        private View.ViewVirus _viewVirus;
        private Color _defaultColor;
        private Color _onDamagedColor;
        private VirusModel _modelVirus;
        private ViewModelVirus _modelView;
        
        private void Start()
        {
            _viewVirus = new View.ViewVirus();
            _defaultColor = _virusMeshRenderer.material.color;
            _onDamagedColor = Color.white;
            _modelVirus = new VirusModel(_virusRigidbody, _speed, _health, gameObject);
            _modelView = new ViewModelVirus(_modelVirus, victoryEventManager);
            _viewVirus.Initialize(_modelView, _healthText, _virusMeshRenderer, _defaultColor, _onDamagedColor);
            Move();
        }

        public void Move()
        {
            _modelView.Move(_virusRigidbody, _speed);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Bullet bullet))
            {
                Move();
                _modelView.Damage(1);
            }
        }
    }
}