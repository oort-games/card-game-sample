using System.Collections;

public interface IArcanaPresentationHandler
{
    IEnumerator Play(ArcanaEffectData effect, BattleContext context);
}
