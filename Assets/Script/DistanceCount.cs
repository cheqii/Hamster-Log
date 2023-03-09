using TMPro;
using UnityEngine;

public class DistanceCount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private Hamster hamster;

    [Header("About Distance")]
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
    private void Awake()
    {
        if (hamster)
        {
            Debug.Log("Start Point Assign");
            startPoint = hamster.GetComponent<Hamster>().transform.localPosition;
            Debug.Log("Start at : " + startPoint);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetFloat("highscore", 0);
        highScoreText.text = "HighScore : " + highScore.ToString("F0");
    }

    // Update is called once per frame
    void Update()
    {
        if (hamster)
        {
            Debug.Log("Hamster distance");
            var position = hamster.transform.position;
            currentPoint = new Vector2(position.z, position.y);
            HamsterDistance();
        }
        else if (!hamster)
        {
            Debug.Log("Hamster null");
            HamsterDistance();
        }
    }

    public void HamsterDistance()
    {
        //find distance
        distance = Mathf.Sqrt(Mathf.Pow(currentPoint.x - startPoint.x, 2) + Mathf.Pow(currentPoint.y - startPoint.y, 2));
        maxDistance = distance;
        if (distance >= maxDistance) text.text = distance.ToString("F0") + " M";
        

        if (highScore < maxDistance)
        {
            highScore = maxDistance;
            PlayerPrefs.SetFloat("highscore", highScore);
        }
    }
}
