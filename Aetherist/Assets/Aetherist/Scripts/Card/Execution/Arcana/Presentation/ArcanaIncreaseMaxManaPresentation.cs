using NUnit.Framework.Internal;
using System.Collections;
using UnityEngine;

public class ArcanaIncreaseMaxManaPresentation : IArcanaPresentationHandler
{
    public IEnumerator Play(ArcanaEffectData effect, BattleContext context)
    {
        // TODO: 연출 넣기
        yield return new WaitForSeconds(0.25f);
        ArcanaEffectProcessor.Apply(effect, context);
    }
}
