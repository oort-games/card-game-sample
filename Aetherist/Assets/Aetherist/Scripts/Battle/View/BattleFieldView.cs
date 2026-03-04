using UnityEngine;

public class BattleFieldView : MonoBehaviour
{
    [SerializeField] BattleUnitView _playerPrefab;
    [SerializeField] BattleUnitView _enemyPrefab;

    [SerializeField] Transform _playerRoot;
    [SerializeField] Transform _enemyRoot;
    [SerializeField] float _enemySpacing = 2f;

    public void Spawn(BattleContext context)
    {
        var player = Instantiate(_playerPrefab, _playerRoot);
        player.Bind(context.Player);

        SpawnEnemies(context);
    }

    void SpawnEnemies(BattleContext context)
    {
        int count = context.Enemies.Count;

        float totalWidth = (count - 1) * _enemySpacing;
        float startX = -totalWidth * 0.5f;

        for (int i = 0; i < count; i++)
        {
            var enemy = Instantiate(_enemyPrefab, _enemyRoot);

            Vector3 pos = new Vector3(startX + i * _enemySpacing, 0, 0);
            enemy.transform.localPosition = pos;

            enemy.Bind(context.Enemies[i]);
        }
    }
}
