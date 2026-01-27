using System.Collections;

public interface IRelicPresentationHandler
{
    IEnumerator Play(RelicEffectData effect, RelicTriggerContext contex);
}
