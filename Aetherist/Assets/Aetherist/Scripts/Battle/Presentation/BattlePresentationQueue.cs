using System.Collections;
using System.Collections.Generic;

public class BattlePresentationQueue
{
    readonly Queue<IBattlePresentation> _queue = new();
    bool _isPlaying;

    public void Enqueue(IBattlePresentation presentation)
    {
        _queue.Enqueue(presentation);
    }

    public IEnumerator Play()
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
