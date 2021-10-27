using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float health;//当前血量
	private float res;//变化到的目标血量
	public Slider healthSlider; //对应UGUI的血条
	private float healthEps;//血条变化精度
	void Start(){
		health = 100.0f;//当前血量
		res = 1.0f;//变化到的目标血量
		healthEps = 0.1f;//血条变化精度
	}
	void OnGUI(){
		health = Mathf.Lerp(health, res, 0.05f);//进行插值
		if (health > 0.7f)//根据当前血量的多少决定绘制血条的颜色
			GUI.color = Color.green;
		else if (health > 0.4f)
			GUI.color = Color.yellow;
		else
			GUI.color = Color.red;
		GUI.HorizontalScrollbar(new Rect(20, 20, 200, 20), 0.0f, health, 0.0f, 1.0f);//使用水平滚动条绘制血条 将其宽度作为血条的显示值
	}
}
