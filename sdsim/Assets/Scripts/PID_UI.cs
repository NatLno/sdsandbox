using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PID_UI : MonoBehaviour {

	public PIDController pid;
    public Logger logger;

	public Text maxSpeedText;
	public Text P_Term;
	public Text D_Term;
	public Text steerMax;
    public Slider SpeedSlider;
    public Slider PropSlider;
    public Slider DiffSlider;
    public Slider steerMaxSlider;

	public ConeChallenge coneChallenge;

	void Start()
	{
		
	}

    public void OnEnable()
    {
		if (logger != null)
			steerMaxSlider.interactable = !logger.isActiveAndEnabled;

        if (pid != null && pid.car != null)
        {
            steerMaxSlider.value = pid.car.GetMaxSteering();
            OnSteerMaxChanged(steerMaxSlider.value);
        }
		if (pid != null)
			SpeedSlider.value = pid.maxSpeed;
    }

	public void OnMaxSpeedChanged(float val)
	{
		maxSpeedText.text = "Max Speed: " + val;
		pid.maxSpeed = val;
	}

	public void OnPTermChanged(float val)
	{
		P_Term.text = "Prop: " + val;
		coneChallenge.numRandCone = Mathf.FloorToInt(val);
		coneChallenge.ResetChallenge();
	}

	public void OnDTermChanged(float val)
	{
		D_Term.text = "Diff: " + val;
	}	
	
    public void OnSteerMaxChanged(float val)
	{
        val = steerMaxSlider.value;
		steerMax.text = "Steer Max: " + val;
		pid.car.SetMaxSteering(val);
	}

    private void Update()
    {
		pid = GameObject.FindObjectOfType<PIDController>();
		logger = GameObject.FindObjectOfType<Logger>();
	}
}
