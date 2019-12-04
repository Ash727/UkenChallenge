
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (NumberFileReader))]
public class NumberFileReaderEditor : Editor 
{


    public override void OnInspectorGUI()
    {
        // calls the original GUI code
        base.OnInspectorGUI();
        // Target is the one always being inspected the one its being used on 
        NumberFileReader reader = (NumberFileReader) target;
        if (GUILayout.Button("Select Text File"))
        {
            reader.readFile();

        }

        GUILayout.Label("Results");
        
        GUILayout.Label("Number reapated fewest times:");
        GUILayout.TextField(reader.getlowestNumber.ToString());
        
        GUILayout.Label("Frequency");
        GUILayout.TextField(reader.getlowestFreq.ToString());
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
