using UnityEngine;

public class DDHazard : MonoBehaviour
{
    public int damage;
    public Player player;

    public Color damageColour;
    private Color playerColour;

    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ApplyDamage()
    {
        player.takeDamage(damage);
    }

    public void ChangePlayerColor()
    {
        SpriteRenderer playerRenderer = player.GetComponent<SpriteRenderer>();
        playerColour = playerRenderer.color;
        playerRenderer.color = damageColour;
    }

    public void ResetPlayerColor()
    {
        SpriteRenderer playerRenderer = player.GetComponent<SpriteRenderer>();
        playerRenderer.color = playerColour;
    }
}
