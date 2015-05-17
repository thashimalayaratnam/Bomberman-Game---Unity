using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	public static bool isInvincible = false;
	public static float timeSpentInvincible;
	public Texture2D lifeIconTexture;
	public static bool dead = false;
	public static int life = 100;

    public float speed = 0.1f;
	// NEED TO ADD
	public static Vector2 bombermanPosition, bombermanPositionRounded; 

    Animator anim;

    void Start() {
        anim = GetComponent<Animator>();
		dead = false;
		life = 100;
    }

	void FixedUpdate () {
        Vector2 dir = Vector2.zero;
        if (Input.GetKey(KeyCode.UpArrow)) {
            anim.SetInteger("Direction", 0);
            dir.y = speed;
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            anim.SetInteger("Direction", 1);
            dir.x = speed;
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            anim.SetInteger("Direction", 2);
            dir.y = -speed;
        } else if (Input.GetKey(KeyCode.LeftArrow)) {
            anim.SetInteger("Direction", 3);
            dir.x = -speed;
        } else {
            // idle
            anim.SetInteger("Direction", 4);
        }
        transform.Translate(dir);

 		bombermanPosition = transform.position;
		float tempX = Mathf.Round(bombermanPosition.x);
		float tempY = Mathf.Round(bombermanPosition.y);
		//Debug.Log (bombermanPosition);
		bombermanPositionRounded = new Vector2 (tempX, tempY);

		if (dead) {
			Application.LoadLevel("scene_win");
		}

		if (isInvincible) {
			timeSpentInvincible += Time.deltaTime;

			if(timeSpentInvincible < 3f)	{
				float remainder = timeSpentInvincible % .3f;
				renderer.enabled = remainder> .15f;
			}

			else{
				renderer.enabled = true;
				isInvincible = false;
			}
		}
    }

	void OnTriggerEnter2D(Collider2D collider)	{
		life -= 10;
		if (life <= 0) {
			dead = true;
		}
		isInvincible = true;
		timeSpentInvincible = 0;
	}

	public static void BombExplosion()	{
		life -= 20;
		if (life <= 0) {
			dead = true;
		}
		isInvincible = true;
		timeSpentInvincible = 0;
	}

	void DisplayLifeCount()	{
		Rect lifeIconRect = new Rect(10, 10, 32, 32);
		GUI.DrawTexture (lifeIconRect, lifeIconTexture);

		GUIStyle style = new GUIStyle ();
		style.fontSize = 30;
		style.fontStyle = FontStyle.Bold;
		style.normal.textColor = Color.yellow;

		Rect labelRect = new Rect (lifeIconRect.xMax + 10, lifeIconRect.y, 60, 32);
		GUI.Label (labelRect, life.ToString (), style);
	}

	void OnGUI()	{
		DisplayLifeCount ();
	}
}