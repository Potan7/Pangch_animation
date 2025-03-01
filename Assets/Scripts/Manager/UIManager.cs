using Riten.Native.Cursors;
using UnityEngine;

public class UIManger : RootManager
{
    FileManager fileManager;
    BDObjectManager BDObjectManager;

    public GameObject LoadingPanel;
    int cursorID;

    private void Start()
    {
        fileManager = GameManager.GetManager<FileManager>();
        BDObjectManager = GameManager.GetManager<BDObjectManager>();
    }

    public void SetLoadingPanel(bool isOn)
    {
        LoadingPanel.SetActive(isOn);
        if (isOn)
        {
            cursorID = CursorStack.Push(NTCursors.Busy);
        }
        else
        {
            CursorStack.Pop(cursorID);
        }
    }

    public void OnPressImportButton()
    {
        fileManager.ImportFile();
    }

    public void OnPressClearButton()
    {
        BDObjectManager.ClearAllObject();
    }
    private void OnDestroy()
    {
        GameManager.Instance?.DestroyedManager(this);
    }
}
