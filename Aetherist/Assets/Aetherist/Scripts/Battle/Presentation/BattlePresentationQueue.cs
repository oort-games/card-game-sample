using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePresentationQueue
{
    readonly Queue<IBattlePresentation> _queue = new();
    
    MonoBehaviour _coroutineHost;

    bool _isPlaying;
    public bool IsPlaying => _isPlaying;

    public void SetCoroutineHost(MonoBehaviour runner)
    {
        _coroutineHost = runner;
    }

    public void Enqueue(IBattlePresentation presentation)
    {
        _queue.Enqueue(presentation);
    }

    public void Play()
    {
        if (_coroutineHost == null)
        {
            Debug.LogError("PresentationQueue runner not set");
            return;
        }

        _coroutineHost.StartCoroutine(PlayCoroutine());
    }

    public IEnumerator PlayCoroutine()
    {
        if (_isPlaying)
        {
            yield break;
        }

        _isPlaying = true;

        while (_queue.Count > 0)
        {
            yield return _queue.Dequeue().Play();
        }

        _isPlaying = false;
    }
}
