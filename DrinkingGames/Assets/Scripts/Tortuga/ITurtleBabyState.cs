using UnityEngine;
using System.Collections;

public interface ITurtleBabyState {

	void UpdateState();

	void OnTriggerEnter2D(Collider2D coll);

	void ToWanderState();

	void ToFollowState(Transform follow);

	void ToSkidState();

}
