using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    [SerializeField]
    private View[] views;
    private Stack<View> history;

    [SerializeField]
    private View startingView;
    private View currentView;

    public T GetView<T>() where T : View => views.FirstOrDefault(x => x is T) as T;


    public void Start()
    {
        history = new Stack<View>();
        foreach (var view in views) 
        {
            view.Init();
            view.Hide();
        }
        if(startingView != null)
            ShowView(startingView);
    }

    public void ShowView(View view, bool remember = true)
    {
        //if you write is not null visual studio will not show error
        //but for some reason unity will write that there are compiler errors
        if (currentView != null)
            currentView.Hide();
        if(remember)
            history.Push(currentView);
        view.Show();
        currentView = view;
    }

    public void ShowView<T>(bool remember = true) where T : View
    {
        var view = GetView<T>();
        if (view is null) 
        {
            Debug.LogError($"View of type {typeof(T)} does not exist");
            return;
        }
        ShowView(view, remember);
    }

    public void ShowPreviousView() 
    {
        var prev = history.Pop();
        if (prev is null) 
            currentView.Hide();
        
        else
            ShowView(prev, false);
    }
}
