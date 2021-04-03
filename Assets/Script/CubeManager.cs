using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class CubeManager : MonoBehaviour
{
    public GameObject[] Cube, Cubelight, Check, CubePrefab;
    public Toggle[] Toggle;
    private GameObject[] PCube = new GameObject[4];
    int[] CubeState;
    
    Vector3 pos1, pos2, pos3;
    public AudioClip SFX_Cube;
    float x, y, z;
    int result = 0;
    
    [System.Serializable]
    public class SmallCubeClass
    {
        public GameObject[] SmallCube;
    }
    public SmallCubeClass[] SmallCubeParents;
    
    void Start()
    {
        CubeState = new int[Check.Length];
        for (int i = 0; i < Check.Length; i++)
        {
            Check[i].SetActive(false);
            CubeState[i] = 0;
        }
    }

    void Update()
    {
        if (Input.touchCount == 1 && IsPointerOverUIObject() == false)
            CubeMove();
    }

    void CubeMove()
    {
        if (SceneManager.GetActiveScene().name.Substring(0, 1) == "0")
        {
            for (int i = 0; i < 4; i++)
            {
                if (Toggle[i].isOn == true)
                {
                    PCube[i] = Instantiate(CubePrefab[i]) as GameObject;
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                    {
                        x = Mathf.RoundToInt(hit.point.x);
                        y = Mathf.RoundToInt(hit.point.y);
                        z = Mathf.RoundToInt(hit.point.z);

                        PCube[i].transform.position = new Vector3(x, y + 0.5f, z);
                        if (PlayerPrefs.GetInt("SFX_Volume", 1) == 1) AudioSource.PlayClipAtPoint(SFX_Cube, PCube[i].transform.position);
                    }
                }
            }
            if (Toggle[0].isOn == false && Toggle[1].isOn == false && Toggle[2].isOn == false && Toggle[3].isOn == false)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    x = Mathf.RoundToInt(hit.point.x);
                    y = Mathf.RoundToInt(hit.point.y);
                    z = Mathf.RoundToInt(hit.point.z);

                    if (hit.collider.tag != "Floor")
                        Destroy(hit.transform.gameObject);
                }
            }
        }
        else
        {
            for (int i = 0; i < Check.Length; i++)
            {
                if (Toggle[i].isOn == true && CubeState[i] == 0)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                    {
                        x = Mathf.RoundToInt(hit.point.x);
                        z = Mathf.RoundToInt(hit.point.z);

                        int layerMask = (-1) - (1 << LayerMask.NameToLayer("Answer"));
                        for (int j = 0; j < SmallCubeParents[i].SmallCube.Length; j++)
                        {
                            Cubelight[i].transform.position = new Vector3(x, 8, z);
                            if (Physics.Raycast(SmallCubeParents[i].SmallCube[j].transform.position, Vector3.down, out hit, Mathf.Infinity, layerMask))
                                if (j == 0 || hit.point.y > y) y = hit.point.y + 0.5f;
                        }
                        Cube[i].transform.position = new Vector3(x, y, z);
                        Cubelight[i].transform.position = new Vector3(x, y, z);
                        Check[i].SetActive(true);
                        CubeState[i] = 1;
                        if (PlayerPrefs.GetInt("SFX_Volume", 1) == 1) AudioSource.PlayClipAtPoint(SFX_Cube, Cube[i].transform.position);
                        Cube[i].GetComponent<ParticleSystem>().Play();
                    }
                }
            }
        }
    }

    public void CubeSelect()
    {
        for (int i = 0; i < Check.Length; i++)
        {
            if (Toggle[i].isOn == true && result == 0)
            {
                for (int j = 0; j < Check.Length; j++)
                    Cubelight[j].transform.position = new Vector3(-100, -100, -100);
                Cubelight[i].transform.position = new Vector3(0, 8, 0);
                result = i;
                return;
            }
            else
            {
                Cubelight[i].transform.position = new Vector3(-100, -100, -100);
                result = 0;
            }
        }
    }
    
    public void Rotate_1()
    {
        for(int i = 0; i < Check.Length; i++)
        { 
            if (result == i && CubeState[i] == 0)
            {
                Cube[i].transform.RotateAround(Cube[i].transform.position, Vector3.up, 90f);
                Cubelight[i].transform.RotateAround(Cubelight[i].transform.position, Vector3.up, 90f);
                Cubelight[i].transform.position = new Vector3(0, 8, 0);
                break;
            }
        }
    }
    public void Rotate_2()
    {
        for (int i = 0; i < Check.Length; i++)
        {
            if (result == i && CubeState[i] == 0)
            {
                Cube[i].transform.RotateAround(Cube[i].transform.position, Vector3.up, -90f);
                Cubelight[i].transform.RotateAround(Cubelight[i].transform.position, Vector3.up, -90f);
                Cubelight[i].transform.position = new Vector3(0, 8, 0);
                break;
            }
        }
    }

    bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition
            = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position
            = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}