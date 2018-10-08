using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4
{

    public class AlarmClock
    {
        public class AlarmEventArgs : EventArgs
        {

        }
        
        //定义一个委托
        public delegate void Eventhandler(object sender,EventArgs e);
        //定义一个事件
        public event Eventhandler Alarm;
        //引发事件的方法
        public void DoAlarm()
        {
            Console.WriteLine("Please input hour and minute:");
            string getTime;
            getTime = Console.ReadLine();
            int hour, minute;
            hour = Int32.Parse(getTime);
            getTime = Console.ReadLine();
            minute = Int32.Parse(getTime);
            DateTime time = DateTime.Now;
            if ((minute == time.Minute) && (hour == time.Hour))
            {
                AlarmEventArgs args = new AlarmEventArgs();
                Alarm(this, args);
            }
           
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            AlarmClock alarmClock = new AlarmClock();
            //注册事件
            alarmClock.Alarm += RingAlarm;
            alarmClock.DoAlarm();
        }
        //事件处理方法
        static void RingAlarm(object sender,EventArgs e)
        {
            Console.WriteLine("Time's Up!!");
        }
    }
}
