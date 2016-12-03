using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clicker
{    
    //[Flags]
    public enum ClickType
    {
        Click = 0,
        RightClick = 1,
        DoubleClick = 2,
        SendKeys = 3
    }

    public class ActionEntry
    {
        public ActionEntry() { }
        public ActionEntry(int x, int y, string text, int interval, ClickType type)
        {
            this.X = x;
            this.Y = y;
            this.Text = text;
            this.Interval = interval;
            this.Type = type;
        }

        public int X { get; set; }

        public int Y { get; set; }
        public string Text { get; set; }

        public int Interval { get; set; }
        public ClickType Type { get; set; }
    }

    public class ActionsEntry
    {
        
        public ActionEntry[] Action { get; set; }
        public int Repeat { get; set; }
        public bool StayOnTop { get; set; }
    }

}
