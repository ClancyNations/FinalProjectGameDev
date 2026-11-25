using UnityEngine;

public class Pack : MonoBehaviour
{
    
    public GameManager gameManager;
    public PackType packType;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        //REFACTOR INTO SWITCH STATEMENT LATER
        if (packType == PackType.basic)
        {
            gameManager.OpenBasicPack();
            Destroy(gameObject);
        }
        
    }
    
}
