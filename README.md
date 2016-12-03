Introduction

This program simulates your mouse and keyboard; user simulates step by step mouse or keyboard actions; when user presses the “start” button, the actions run automatically.
Background

The reason that I built this code is to save me a lot of time. When I test my code (Windows application most of the time), I need to run the application and do the same step over and over again. All of the steps are by mouse and keyboard; some of them take a few seconds, others take more. So I built a program that simulates my mouse and keyboard.
How To Use

First load actions.

To simulate mouse:

    Move mouse to specific location and:
    Press ‘c’ to left click (mouse)
    Press ‘d’ to double click (mouse)
    Press ‘r’ to right click (mouse)

To simulate keyboard:

    Fill SendKeys command in text-box
    Simulate click to specific location
    Press ‘t’ (keyboard)

To delete or edit action use context-menu. You can move mouse out of the main window and simulate action. The biggest problem is to stay focused on the main window without moving the mouse -> the solution is very simple ‘Alt + Tab’ (until you refocus the main window). After you load your action, press “Start” button and wait (don't move your mouse, until the loop finished. You can save or load (open) configuration.
Using the Code

I tried to make the code as simple as possible.
The Next API Moves the Mouse to the Relevant Position
Hide   Copy Code

[DllImport("user32")]
public static extern int SetCursorPos(int x, int y);

The next API simulates mouse events (left/right click down/up, wheel EXE):
Hide   Copy Code

private const int MOUSEEVENTF_MOVE = 0x0001; /* mouse move */
private const int MOUSEEVENTF_LEFTDOWN = 0x0002; /* left button down */
private const int MOUSEEVENTF_LEFTUP = 0x0004; /* left button up */
private const int MOUSEEVENTF_RIGHTDOWN = 0x0008; /* right button down */

DllImport("user32.dll",
    CharSet = CharSet.Auto,CallingConvention=CallingConvention.StdCall)]
public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons,
    int dwExtraInfo);

To simulate one click, you need to use this method twice: the first time for down click and the second time for up click. On the save side, wait 100 milliseconds between moving new location and the click, like in the following code:
Hide   Copy Code

SetCursorPos(action.X, action.Y)
Thread.Sleep(100);
mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);

Points of Interest

I ran actions loop in thread. Because it’s wrong to turn to the main thread from another thread, I use SynchronizationContext class. I will not expand on this issue in this article although it’s a great solution to fixed cross thread problem.
License

This article, along with any associated source code and files, is licensed under The Code Project Open License (CPOL)
