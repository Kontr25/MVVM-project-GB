using System;
using System.Collections;
using DG.Tweening;
using Script.Virus.Model;
using Script.Virus.ViewVirus;
using TMPro;
using UnityEngine;

namespace Script.Virus.View
{
    public class ViewVirus : MonoBehaviour
    {
        private IViewModel _viewModel;
        private TMP_Text _healthText;
        private MeshRenderer _virusMeshRenderer;
        private Color _defaultColor;
        private Color _onDamagedColor;

        public void Initialize(IViewModel viewModel, TMP_Text healthText, MeshRenderer virusMeshRenderer, Color defaultColor, Color onDamagedColor)
        {
            _viewModel = viewModel;
            _healthText = healthText;
            _virusMeshRenderer = virusMeshRenderer;
            _defaultColor = defaultColor;
            _onDamagedColor = onDamagedColor;
            _viewModel.OnDamaged += OnDamaged;
        }
        
        private void OnDestroy()
        {
            _viewModel.OnDamaged -= OnDamaged;
        }
        
        private void OnDamaged(int hp)
        {
            BlinkingColor();
            _healthText.text = _viewModel.remainingHealth.ToString();
        }

        private void BlinkingColor()
        {
            _virusMeshRenderer.material.DOColor(_onDamagedColor, 0.1f).onComplete = () =>
            {
                _virusMeshRenderer.material.color = _onDamagedColor;
                _virusMeshRenderer.material.DOColor(_defaultColor, 0.1f).onComplete = () =>
                {
                    _virusMeshRenderer.material.color = _defaultColor;
                };
            };
        }
        
        
    }
}