using UnityEngine;
using Vuforia;
using System.Collections;

public class MyPrefabInstantiator : DefaultTrackableEventHandler {

    private TrackableBehaviour mTrackableBehaviour;

    public Transform myModelPrefab;

    // Use this for initialization
    void Start ()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();

        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterOnTrackableStatusChanged(OnTrackableStatusChanged);
        }
    }               

    // Update is called once per frame
    void Update ()
    {
    }

    public void OnTrackableStateChanged(
    TrackableBehaviour.Status previousStatus,
    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED)
        {
            OnTrackingFound();
        }
    }

    void OnTrackableStatusChanged(TrackableBehaviour.StatusChangeResult statusChangeResult)
    {
        m_PreviousStatus = statusChangeResult.PreviousStatus;
        m_NewStatus = statusChangeResult.NewStatus;

        Debug.LogFormat("Trackable {0} {1} -- {2}",
        mTrackableBehaviour.TrackableName,
        mTrackableBehaviour.CurrentStatus,
        mTrackableBehaviour.CurrentStatusInfo);

        HandleTrackableStatusChanged();
    }
    private void OnTrackingFound()
    {
        if (myModelPrefab != null)
        {
            Transform myModelTrf = GameObject.Instantiate(myModelPrefab) as Transform;

             myModelTrf.parent = mTrackableBehaviour.transform;             
             myModelTrf.localPosition = new Vector3(0f, 0f, 0f);
             myModelTrf.localRotation = Quaternion.identity;
             myModelTrf.localScale = new Vector3(0.0005f, 0.0005f, 0.0005f);

             myModelTrf.gameObject.active = true;
         }
     }
}