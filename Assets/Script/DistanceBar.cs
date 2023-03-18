using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceBar : MonoBehaviour
{
    [SerializeField] private GameObject goal;
    [SerializeField] private GameObject startPoint;
    [SerializeField] private DistanceCount _distanceCount;
    [SerializeField] private Slider _slider;
    private float fullDistance;
    private float barProgress;

    private bool isRunning = false;
    
    // Start is called before the first frame update
    void Start()
    {

        
        
    }

    void Update()
    {


        if (isRunning == true)
        {
            barProgress = _distanceCount.GetDistance() / fullDistance;
            _slider.value = barProgress;
        }
        else
        {
          
            goal = GameObject.FindGameObjectsWithTag("Goal")[0];
          

            isRunning = true;

            Vector3 _startPoint = new Vector3(startPoint.transform.position.x, startPoint.transform.position.y,
                startPoint.transform.position.z);
            Vector3 _goal = new Vector3(goal.transform.position.x, goal.transform.position.y,
                goal.transform.position.z);

            fullDistance = Mathf.Sqrt(Mathf.Pow(_goal.z - _startPoint.z, 2) + Mathf.Pow(_goal.y - _startPoint.y, 2));
        }
    }

}
