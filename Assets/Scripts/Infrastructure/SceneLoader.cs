using System;
using System.Collections;
using Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure
{
    public class SceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;
        public SceneLoader(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void Load(string sceneName, Action onLoaded = null)
        {
            _coroutineRunner.StartCoroutine(LoadScene(sceneName, onLoaded));
        }

        private IEnumerator LoadScene(string sceneName, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == sceneName)
            {
                onLoaded?.Invoke();
                yield break;
            }
            
            yield return new WaitForSeconds(0.3f);

            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(sceneName);
            
            while (!waitNextScene.isDone)
            {
                yield return null;
            }
            
            onLoaded?.Invoke();
        }
    }
}