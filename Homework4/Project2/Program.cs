using System;
using System.Threading;

namespace Alarm
{
    public class Clock
    {
        private int clockTime;
        public delegate void ClockEventHandler(Object sender, ClockEventArgs e);
        public event ClockEventHandler UsualEvent; 
        public event ClockEventHandler AlarmEvent;

        public class ClockEventArgs : EventArgs
        {
            public readonly int clockTime;
            public ClockEventArgs(int clockTime)
            {
                this.clockTime = clockTime;
            }
        }

        public void AlarmMode(ClockEventArgs e)
        {
            if (AlarmEvent != null)
            { 
                AlarmEvent(this, e);  // 响铃事件
            }
        }

        public void UsualMode(ClockEventArgs e)
        {
            if (UsualEvent != null)
            { 
                UsualEvent(this, e);  // 显示时间事件
            }
        }

        public void SomeClock(int setTime)
        {
            for (int i = 0; i <= 1000; i++)
            {
                Thread.Sleep(500);
                clockTime = i%24;
                ClockEventArgs e = new ClockEventArgs(clockTime);
                UsualMode(e);
                if (clockTime ==setTime)
                {
                    AlarmMode(e);  
                }
            }
        }
    }

    // 响铃装置
    public class Alarm
    {
        public void MakeAlert(Object sender, Clock.ClockEventArgs e)
        {
            Clock clock = (Clock)sender;     
            Console.WriteLine($"嘀嘀嘀，已经到{e.clockTime} 点了！");
            Console.WriteLine();
        }
    }

    // 显示当前时间
    public class Display
    {
        public static void ShowTime(Object sender, Clock.ClockEventArgs e)
        {   
            Clock clock = (Clock)sender;
            Console.WriteLine($"现在是{e.clockTime}点钟。" );
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Clock clock = new Clock();
            Alarm alarm = new Alarm();
            clock.AlarmEvent += alarm.MakeAlert;   
            clock.UsualEvent += Display.ShowTime;      
            clock.SomeClock(10);
            Console.ReadLine();
        }
    }
}

