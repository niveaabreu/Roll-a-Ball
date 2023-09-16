using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TelaInicial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void IrProJogo(){
        SceneManager.LoadScene("Scenes/Minigame");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
