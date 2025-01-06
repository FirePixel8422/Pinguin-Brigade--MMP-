using UnityEngine;



[System.Serializable]
public class CharacterStats
{
    [SerializeField] private float baseMoveSpeed;
    [SerializeField] private float moveSpeedMultiplier;

    public float MoveSpeed => baseMoveSpeed * moveSpeedMultiplier;
}
