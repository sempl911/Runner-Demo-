using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCubeCollect : MonoBehaviour
{
    [SerializeField] GameObject cubeObj;
    [SerializeField] GameObject _player;
    [SerializeField] GameObject pickUpOnTrack;
    [SerializeField] Animator stickManAnimator;
    [SerializeField] GameObject collectTxt;
    [SerializeField] GameObject stackPref;
    [SerializeField] GameObject collectAudio;

    float cubeLength = .95f;
    bool addCubes;
    PickUpCollision _addCube;
    Animator _jumpAnim;
    private void Start()
    {
        _addCube = pickUpOnTrack.GetComponent<PickUpCollision>();
        addCubes = _addCube.addNewCube;
        _jumpAnim = stickManAnimator.GetComponent<Animator>();
    }
    private void Update()
    {
        AddCube(addCubes);
    }
   public void AddCube( bool addCube)
    {
        if (addCube)
        {
            var NewCube = Instantiate(cubeObj).transform;
            NewCube.SetParent(gameObject.transform);
            PlayerUp(cubeLength);
            NewCube.localPosition = new Vector3(cubeObj.transform.position.x, cubeObj.transform.position.y + .02f, cubeObj.transform.position.z);
            StackEffect(NewCube.transform.position);
            addCube = false;
        }
    }
    void PlayerUp(float posY)
    {
        _player.transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y + posY, _player.transform.position.z);
        _jumpAnim.SetTrigger("Jump");
        CollectTxt();
        StackAudio();
    }
    void CollectTxt()
    {
        Vector3 colTxtPos = new Vector3(_player.transform.position.x + 10, _player.transform.position.y + .5f, _player.transform.position.z);
       GameObject collectTxtTmp = Instantiate(collectTxt, colTxtPos, Quaternion.Euler(0,90,0));
        Destroy(collectTxtTmp, .4f);
    }
    void StackEffect(Vector3 effectPos)
    {
       var stackTmp = Instantiate(stackPref, effectPos, Quaternion.identity);
        Destroy(stackTmp, .2f);
    }
    void StackAudio()
    {
        var stackAudio = Instantiate(collectAudio, _player.transform.position, Quaternion.identity);
        Destroy(stackAudio, .1f);
    }
}
