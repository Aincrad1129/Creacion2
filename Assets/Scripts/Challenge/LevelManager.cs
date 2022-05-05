using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> levels = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        RandomLevels();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void RandomLevels() {
        for (int i = 0; i< levels.Count;  i++) { 
            int randomIndex = Random.Range(0, levels.Count - 1);
            GameObject objectToChange = levels[randomIndex];
            levels[randomIndex] = levels[i];
            levels[i] = objectToChange;
        }
        for (int i = 0; i< levels.Count;i++) {
            levels[i].transform.localPosition = new Vector3(3 + i * 6, 0,0);
        }
    }
}
