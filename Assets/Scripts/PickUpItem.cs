using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField]
    private KeyCode _pickUpKey;

    [SerializeField]
    private GameObject _holdSpot;

    [SerializeField]
    private Vector3 _distance = new Vector3(100, 100, 0);

    [SerializeField]
    private LayerMask _PickUpLayer;

    private GameObject _itemPickup;

    //public Vector3 direction { get; set; }

    private bool _hasItem = false;


    private void Start()
    {
       _itemPickup = GameObject.FindGameObjectWithTag("PickUp");
    }

    void Update()
    {
        if (Input.GetKeyDown(_pickUpKey))
        {
            if (_hasItem)
            {
                DropItem();
            }
            else
            {
                PickUp();
            }
        }
    }

    void PickUp()
    {
        int pickupLayer = LayerMask.NameToLayer("PickUp");
        Vector3 itemPos = _itemPickup.transform.position;
        Vector3 playerPos = transform.position;
        Rigidbody2D itemRb = _itemPickup.GetComponent<Rigidbody2D>();

        Debug.Log((itemPos - playerPos).sqrMagnitude);

        if ((itemPos - playerPos).sqrMagnitude <= _distance.sqrMagnitude && _itemPickup.layer == pickupLayer)
        {
            _itemPickup.transform.SetParent(transform);  // Parent to _holdSpot
            _itemPickup.transform.position = _holdSpot.transform.position;
            itemRb.simulated = false; // Disable physics
            _hasItem = true;
        }
    }


    void DropItem()
    {
        _itemPickup.transform.SetParent(null);

        _itemPickup.GetComponent<Rigidbody2D>().simulated = true;

        _hasItem = false;
    }
}
