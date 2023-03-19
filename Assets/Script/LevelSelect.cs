using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] private BlockGenerate1 startBlock;

    public void ChangeLevel(int _level)
    {
        startBlock.SetLevel(_level-1,GameData.Instance.GetLaneSwitch(_level-1),GameData.Instance.GetLevelDistance(_level-1));
        startBlock.GenerateLevel();
        FindObjectOfType<DistanceCount>().GetComponent<DistanceCount>().SetLevel("HSLV" + _level.ToString());
    }

}
