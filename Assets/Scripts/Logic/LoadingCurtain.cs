using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class LoadingCurtain : MonoBehaviour
{
    private const float FadeInTime = 0.03f;
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        _canvasGroup = GetComponent<CanvasGroup>();

        if (_canvasGroup == null)
        {
            Debug.LogError("CanvasGroup not found on LoadingCurtain!");
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
        _canvasGroup.alpha = 1.0f;
    }

    public void Hide() => StartCoroutine(FadeIn());

    private IEnumerator FadeIn()
    {
        while (_canvasGroup.alpha > 0)
        {
            _canvasGroup.alpha -= FadeInTime;
            yield return new WaitForSeconds(FadeInTime);
        }

        gameObject.SetActive(false);
    }
}
