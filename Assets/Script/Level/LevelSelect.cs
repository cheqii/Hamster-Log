using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] private BlockGenerate startBlock;

    public void ChangeLevel(int _level)
    {
        startBlock.SetLevel(_level-1,GameData.Instance.GetLaneSwitch(_level-1),GameData.Instance.GetLevelDistance(_level-1));
        startBlock.GenerateLevel();
        Instantiate(GameData.Instance.GetEnemy(_level - 1),startBlock.transform.position + (Vector3.forward*100),GameData.Instance.GetEnemy(_level - 1).transform.rotation);
        FindObjectOfType<DistanceCount>().GetComponent<DistanceCount>().SetLevel("HSLV" + _level.ToString());
        RenderSettings.skybox = GameData.Instance.GetSkybox(_level-1);
        
        SoundManager.Instance.StopSound();
        SoundManager.Instance.PlayGameMusic();
    }

}
