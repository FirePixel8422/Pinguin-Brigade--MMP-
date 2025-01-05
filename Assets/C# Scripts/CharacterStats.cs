using UnityEngine;



[System.Serializable]
public struct CharacterStats
{
    [SerializeField] private float baseMoveSpeed;
    [SerializeField] private float moveSpeedMultiplier;

    public float MoveSpeed => baseMoveSpeed * moveSpeedMultiplier;
}
