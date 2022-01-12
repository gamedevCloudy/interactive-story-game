using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternManger : MonoBehaviour
{
    //public PasswordController passCtrl; 
    //private int passInt = 0; 
    public PasswordManager pass; 
    public GameObject linePrefab; 
    public Canvas canvas; 

    private Dictionary<int,CircleIdentifier> circles;
    private List<CircleIdentifier> lines; 

    private GameObject lineOnEdit;
    private RectTransform lineOnEditRcTs; 
    private CircleIdentifier circleOnEdit; 

    private bool unlocking; 
    private bool enabled = true; 

    void Start()
    {
        circles = new Dictionary<int, CircleIdentifier>(); 
        lines = new List<CircleIdentifier>(); 
        
        for(int i = 0; i < transform.childCount; i++)
        {
            var circle = transform.GetChild(i); 
            var identifier = circle.GetComponent<CircleIdentifier>(); 

            identifier.id = i; 
            circles.Add(i, identifier); 
        }
    }

    void Update()
    {
        if(enabled == false)
        {
            return; 
        }
        if(unlocking)
        {
            Vector3 mousePos = canvas.transform.InverseTransformPoint(Input.mousePosition);
            lineOnEditRcTs.sizeDelta = new Vector2(lineOnEditRcTs.sizeDelta.x, 
                Vector3.Distance(mousePos, circleOnEdit.transform.localPosition));   
            lineOnEditRcTs.rotation = Quaternion.FromToRotation(
                Vector3.up, 
                (mousePos - circleOnEdit.transform.localPosition).normalized); 
        }    
    }

    GameObject CreateLine(Vector3 pos, int id)
    {
        var line = GameObject.Instantiate(linePrefab, canvas.transform); 
        
        line.transform.localPosition = pos; 

        var lineIdf = line.AddComponent<CircleIdentifier>(); 

        lineIdf.id = id; 

        lines.Add(lineIdf); 
        return line;  

    }

    void TrySetLineEdit(CircleIdentifier circle)
    {
        foreach (var line in lines)
        {
            if(line.id == circle.id)
            {
                return; 
            } 
        }
        lineOnEdit = CreateLine(circle.transform.localPosition, circle.id);
        lineOnEditRcTs = lineOnEdit.GetComponent<RectTransform>(); 
        circleOnEdit = circle;
    }

    void EnableColorFade(Animator anim)
    {
        anim.enabled = true; 
        anim.Rebind(); 
    }
    IEnumerator Release()
    {
        enabled = false; 
        yield return new WaitForSeconds(3); 

        foreach( var circle in circles)
        {
            circle.Value.GetComponent<UnityEngine.UI.Image>().color = Color.white; 
            circle.Value.GetComponent<Animator>().enabled = false; 
        }
        foreach(var line in lines)
        {
            Destroy(line.gameObject); 
        }
        lines.Clear(); 

        lineOnEdit = null; 
        lineOnEditRcTs = null; 
        circleOnEdit = null;
        pass.VerifyPattern(); 
        pass.inputPattern.Clear(); 
        enabled = true; 
    }

    public void OnMouseEnterCircle(CircleIdentifier idf)
    {
        if(unlocking)
        {
            lineOnEditRcTs.sizeDelta = new Vector2(lineOnEditRcTs.sizeDelta.x, 
                Vector3.Distance(circleOnEdit.transform.localPosition, idf.transform.localPosition)); 
            
            lineOnEditRcTs.rotation = Quaternion.FromToRotation(Vector2.up,
                (idf.transform.localPosition - circleOnEdit.transform.localPosition).normalized); 
            
            TrySetLineEdit(idf); 
        }
    }
    public void OnMouseExitCircle(CircleIdentifier idf)
    {
        //Debug.Log(idf.id); 
    }

    public void OnMouseDownCircle(CircleIdentifier idf)
    {
        unlocking = true; 
        TrySetLineEdit(idf); 
    }

    public void OnMouseUpCircle(CircleIdentifier idf)
    {
         if(enabled == false)
        {
            return; 
        }
        if(unlocking)
        {
            foreach( var line in lines)
            {
                EnableColorFade( circles[line.id].gameObject.GetComponent<Animator>()); 
                //check password
                pass.inputPattern.Add(line.id); 
            }
            
           
            //Debug.Log(Verified); 
        
            Destroy(lines[lines.Count -1].gameObject); 
            lines.RemoveAt(lines.Count -1);

            foreach( var line in lines)
            {
                EnableColorFade(line.GetComponent<Animator>()); 
            }
            StartCoroutine(Release()); 
        }
        unlocking = false; 
    }
}
