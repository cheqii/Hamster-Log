using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DistanceCount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TextMeshProUGUI highScoreText;
    private Hamster hamster;

    [Header("Distance Score")]
    private Vector2 startPoint;
    private Vector2 currentPoint;
    private float distance;
    private float maxDistance;
    public float MaxDistance
    {
        get => maxDistance;
        set => maxDistance = value;
    }

    private float highScore;
    public float HighScore
    {
        get => highScore;
        set => highScore = value;
    }

    private string currentLevel;

    private void Awake()
    {
        hamster = FindObjectOfType<Hamster>().GetComponent<Hamster>();
        if (hamster)
        {
            Debug.Log("Start Point Assign");
            startPoint = hamster.GetComponent<Hamster>().transform.localPosition;
        }
    }
    
    void Update()
    {
        if (hamster)
        {
            var position = hamster.transform.position;
            currentPoint = new Vector2(position.z, position.y);
            HamsterDistance();
        }
        else if (!hamster)
        {
            HamsterDistance();
        }
    }

    public void HamsterDistance()
    {
        //Find Distance
        distance = Mathf.Sqrt(Mathf.Pow(currentPoint.x - startPoint.x, 2) + Mathf.Pow(currentPoint.y - startPoint.y, 2));
        if (distance >= maxDistance)
        {
            maxDistance = distance;
            text.text = distance.ToString("F0") + " M";
        }
        else if (distance < maxDistance) text.text = maxDistance.ToString("F0") + " M";

        // HighScore Check
        if (highScore < maxDistance)
        {
            highScore = maxDistance;
            PlayerPrefs.SetFloat(currentLevel, highScore);
        }
    }

    public int GetDistance()
    {
        return distance.ConvertTo<int>();
    }

    public void SetLevel(string level)
    {
        currentLevel = level;
        highScore = PlayerPrefs.GetFloat(currentLevel, 0);
        highScoreText.text = "HighScore : " + highScore.ToString("F0") + " M";
    }
}
