using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


    public class ColorManager : MonoBehaviour
    {
        [SerializeField] private List<ColorPalette> listPalette;

        [SerializeField] private Camera mainCamera;
        //[SerializeField] private SpriteRenderer snake;

        private int _lastColorPaletteIndex = -1;

        public void RandomChange()
        {
            int random;
            do
            {
                random = Random.Range(0, listPalette.Count);
            } while (random == _lastColorPaletteIndex);

            _lastColorPaletteIndex = random;
            ChangeColor(random);
        }

        //[Button]
        private void ChangeColor(int index)
        {
            var current = listPalette[index];

            // Smoothly transition the camera background color to the target color
            StartCoroutine(SmoothColorTransition(mainCamera.backgroundColor, current.background, 0.5f));
        }

        private IEnumerator SmoothColorTransition(Color startColor, Color targetColor, float transitionTime)
        {
            float elapsedTime = 0;
            while (elapsedTime < transitionTime)
            {
                elapsedTime += Time.deltaTime;
                float t = Mathf.Clamp01(elapsedTime / transitionTime);
                mainCamera.backgroundColor = Color.Lerp(startColor, targetColor, t);
                yield return null;
            }
            mainCamera.backgroundColor = targetColor;
        }
    }
