using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Obstacle", order = 1)]
public class Obstacle : ScriptableObject
{
    public GameObject[] Objects;
}