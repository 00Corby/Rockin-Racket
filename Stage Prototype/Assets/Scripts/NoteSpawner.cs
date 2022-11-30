using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class NoteSpawner : MonoBehaviour
{

    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject _note;
    [SerializeField] private float _maxSpawnRate = 1;

    [SerializeField] [NotNull] private float[] _startEndValues;

    private bool[] _spawnAvailablity = new[] {false, false, false, false};
    
    private int _numSpawnPoints;
    private void Awake()
    {
        _numSpawnPoints = _spawnPoints.Length;
        if (_numSpawnPoints == 0)
            Debug.LogError("There are no spawn points in the spawn point list");

        
        // set availability true if there is a spawn point active
        for (int i = 0; i < _numSpawnPoints; i++)
        {
            _spawnAvailablity[i] = true;
        }
    }

    void Update()
    {
        float[] spectrum = new float[256];

        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

        float average = 0f;
        for (int i = 1; i < spectrum.Length - 1; i++)
        {
            average += Mathf.Log(spectrum[i]) + 10;
            // Debug.DrawLine(new Vector3(i - 1, Mathf.Log(spectrum[i - 1]) + 10, 2), new Vector3(i, Mathf.Log(spectrum[i]) + 10, 2), Color.cyan);
        }

        average /= spectrum.Length;
        
        Debug.Log(average);
        
        // takes values you put in and compares them to the current average magnitude of the track
        // if the value fits the case then starts a coroutine spawning the correct note
        if (average > _startEndValues[0] && average < _startEndValues[1] && _spawnAvailablity[0])
        {
            StartCoroutine(SpawnNote(0));
        }
        else if (average > _startEndValues[2] && average < _startEndValues[3] && _spawnAvailablity[1])
        {
            StartCoroutine(SpawnNote(1));
        }
        else if (average > _startEndValues[4] && average < _startEndValues[5] && _spawnAvailablity[2])
        {
            StartCoroutine(SpawnNote(2));
        }
        else if (average > _startEndValues[6] && average < _startEndValues[7] && _spawnAvailablity[3])
        {
            StartCoroutine(SpawnNote(3));   
        }
        
        /*
         *  you can add more cases if you want to have more notes!
         *
         *  You will have to add another else if statement i.e.

            else if (average > _startEndValues[8] && average < _startEndValues[9] && _spawnAvailablity[4])
            {
                StartCoroutine(SpawnNote(4));   
            }
            
            You will also have to make a new case in the spawn note coroutine,
            increment the value that is being compared at the head of the case,
            then you can copy everything over from any one of the cases already created
            just make sure to change the colors and any other variables you may be using.
         */
    }

    // here is where you spawn the note, you will be able to change any type of variable you want for the note after instantiation
    private IEnumerator SpawnNote(int noteType)
    {
        switch (noteType)
        {
            case 0:
                _spawnAvailablity[noteType] = false;
                GameObject noteTypeOne = Instantiate(_note, _spawnPoints[noteType].position, Quaternion.identity, transform);
                noteTypeOne.GetComponent<MeshRenderer>().materials[0].color = Color.red;
                // change variables of note object here 

                yield return new WaitForSeconds(_maxSpawnRate);
                _spawnAvailablity[noteType] = true;
                break;
            case 1:
                _spawnAvailablity[noteType] = false;
                GameObject noteTypeTwo = Instantiate(_note, _spawnPoints[noteType].position, Quaternion.identity, transform);
                noteTypeTwo.GetComponent<MeshRenderer>().materials[0].color = Color.cyan;
                // change variables of note object here 

                yield return new WaitForSeconds(_maxSpawnRate);
                _spawnAvailablity[noteType] = true;
                break;
            case 2:
                _spawnAvailablity[noteType] = false;
                GameObject noteTypeThree = Instantiate(_note, _spawnPoints[noteType].position, Quaternion.identity, transform);
                noteTypeThree.GetComponent<MeshRenderer>().materials[0].color = Color.green;
                // change variables of note object here 

                yield return new WaitForSeconds(_maxSpawnRate);
                _spawnAvailablity[noteType] = true;
                break;
            case 3:
                _spawnAvailablity[noteType] = false;
                GameObject noteTypeFour = Instantiate(_note, _spawnPoints[noteType].position, Quaternion.identity, transform);
                noteTypeFour.GetComponent<MeshRenderer>().materials[0].color = Color.blue;
                // change variables of note object here 
                
                yield return new WaitForSeconds(_maxSpawnRate);
                _spawnAvailablity[noteType] = true;
                break;
        }
    }
}