using UnityEngine;
using System.Collections;

public class BoatMovement : BoatScript {
	
	//Components
	public AudioSource thrustAudioSource;
	public AudioSource rotateAudioSource;
	public ParticleSystem thrustParticles;
	public ParticleSystem rotateParticles;
	private Rigidbody2D _rb2D;
	private SoundPlayer _soundPlayer;
	public IconAlpha thrustIcon;
	public IconAlpha rotateIcon;

	//Variables
	private float thrustSpeed = .5f;

	void Awake() {
		_rb2D = GetComponent<Rigidbody2D>();
		_soundPlayer = GetComponent<SoundPlayer>();

	}

	// Use this for initialization
	void Start () {

		thrustParticles.enableEmission = false;
		rotateParticles.enableEmission = false;
	}

	public void thrust() {
		_rb2D.AddRelativeForce(new Vector2(0,thrustSpeed),ForceMode2D.Impulse);
		thrustParticles.enableEmission = true;
		_soundPlayer.playLoopingSound(thrustAudioSource);
		thrustIcon.turnOn ();
	}

	public void stopThrust() {
		thrustParticles.enableEmission = false;
		thrustAudioSource.Stop ();
		thrustIcon.turnOff ();
	}


	public void rotate() {
		transform.Rotate (Vector3.forward*-2);
		rotateParticles.enableEmission = true;
		_soundPlayer.playLoopingSound(rotateAudioSource);
		rotateIcon.turnOn ();
	}

	public void stopRotate() {
		rotateParticles.enableEmission = false;
		rotateAudioSource.Stop();
		rotateIcon.turnOff ();
	}

}
