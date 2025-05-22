using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private List<ScreenView> _screenViews;
        
        [SerializeField] private Transform _canvasOverlay;
        [SerializeField] private Transform _canvasWorld;

        private Transform _xrCamera;
        private ScreenView _currentScreen;

        public void ShowScreen(Enums.ScreenType screenType)
        {
            if (_currentScreen != null)
            {
                _currentScreen.Hide();
                Destroy(_currentScreen.gameObject);
            }

            foreach (ScreenView screenView in _screenViews)
            {
                if (screenView.ScreenType == screenType)
                {
                    ScreenView newScreen = Instantiate(screenView);

                    if (screenView.CanvasType == Enums.CanvasType.Overlay)
                    {
                        newScreen.transform.SetParent(_canvasOverlay, false);  
                    } 
                    else if (screenView.CanvasType == Enums.CanvasType.WorldSpace)
                    {
                        FindCamera();
                        WorldSpaceCanvasSet(newScreen);
                    }

                    _currentScreen = newScreen;
                    _currentScreen.Show(); 
                }
            }
        }

        private void FindCamera()
        {
            GameObject xrCameraObj = GameObject.FindGameObjectWithTag("MainCamera");
            if (xrCameraObj != null) 
                _xrCamera = xrCameraObj.transform;
        }

        private void WorldSpaceCanvasSet(ScreenView newScreen)
        {
            newScreen.transform.SetParent(_canvasWorld, false);
                        
            Vector3 forward = _xrCamera.forward;
            Vector3 position = _xrCamera.position + forward * 2f;
                        
            newScreen.transform.position = position;
                        
            Quaternion lookRotation = Quaternion.LookRotation(forward, Vector3.up);
            newScreen.transform.rotation = lookRotation;
                        
            //скрипт для слежки
        }

        public void HideScreen(Enums.ScreenType screenType)
        {
            if (_currentScreen != null)
            {
                _currentScreen.Hide();
                Destroy(_currentScreen.gameObject);
            }
        }
    }
}