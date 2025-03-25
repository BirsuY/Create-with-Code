using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour{
    public static UIManager Instance;

    public InputField iField;
    public string name;

    private void Awake(){
        if(Instance != null){
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void TakeInput(){
        name = iField.text;
        
    }

    public void ChangeScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);

    }


}
    
