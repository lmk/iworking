using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

using Hook;

namespace iworking
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            dtStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 9, 0, 0);
            dtEnd.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 18, 0, 0);

            KeyboardHook.KeyDown += InputKeyboard;
            KeyboardHook.KeyUp += InputKeyboard;
            MouseHook.MouseDown += InputMouse;
            MouseHook.MouseUp += InputMouse;
            MouseHook.MouseMove += InputMouse;
            MouseHook.MouseScroll += InputMouseScroll;

            KeyboardHook.HookStart();
            if (!MouseHook.HookStart())
            {
                MessageBox.Show("Mouse hook failed");
            }

            timerNoInput.Start();
        }

        private void DoInput()
        {
            dtLastInput.Value = DateTime.Now;
        }

        private bool InputMouse(MouseEventType type, int x, int y)
        {
            DoInput();

            if (type == MouseEventType.RIGHT)
            {
                Debug.WriteLine("Mouse Event {0}, {1}", Cursor.Position.X, Cursor.Position.Y);
            }

            return true;
        }

        private bool InputKeyboard(int vkCode)
        {
            DoInput();
            return true;
        }

        private bool InputMouseScroll(MouseScrollType type)
        {
            DoInput();
            return true;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            dtLastInput.Value = DateTime.Now;
        }

        private void TimerNoInput_Tick(object sender, EventArgs e)
        {

            TimeSpan ts = DateTime.Now.Subtract(dtLastInput.Value);

            // 60초 동안 입력이 없으면 동작
            if (ts.TotalSeconds >= 60)
            {
                int start = Int32.Parse(dtStart.Value.ToString("HHmmss"));
                int end = Int32.Parse(dtEnd.Value.ToString("HHmmss"));
                int now = Int32.Parse(DateTime.Now.ToString("HHmmss"));

                if ((start <= now) && (now <= end))
                {
                    SimulInput();
                }
            }
        }

        private void SimulInput()
        {
            int x = Cursor.Position.X;
            int y = Cursor.Position.Y;

            //MouseSimulation.MouseUp(MouseEventType.NONE, 10, 10);
            //Thread.Sleep(100);
            //MouseSimulation.MouseUp(MouseEventType.NONE, x, y);

            Debug.WriteLine("{0} SimulInput {1}, {2}", DateTime.Now.ToString("HHmmss"), x, y);

            bool isRemote = WinAPI.GetSystemMetrics(SystemMetric.SM_REMOTESESSION) != 0;
            //Debug.WriteLine("{0} isRemote: {1}", DateTime.Now.ToString("HHmmss"), isRemote);

            if (WindowControl.GetTopWindowProcess() == null)
            {
                // TimeKeeper 근무시작 버튼 위치
                MouseSimulation.MouseClick(MouseEventType.LEFT, 80, 45);
            }
            else if (isRemote)
            {
                // control key 
                KeyboardSimulation.MakeKeyEvent(0x11, KeyboardEventType.KEYDOWN);
                KeyboardSimulation.MakeKeyEvent(0x11, KeyboardEventType.KEYUP);
            }
            else
            {
                // draw star
                int[,] pts = new int[5, 2] { { 843, 215 }, { 1197, 468 }, { 1121, 713 }, { 761, 725 }, { 669, 448 } };

                MoveMouse(new Point(pts[0, 0], pts[0, 1]), new Point(pts[2, 0], pts[2, 1]));
                MoveMouse(new Point(pts[2, 0], pts[2, 1]), new Point(pts[4, 0], pts[4, 1]));
                MoveMouse(new Point(pts[4, 0], pts[4, 1]), new Point(pts[1, 0], pts[1, 1]));
                MoveMouse(new Point(pts[1, 0], pts[1, 1]), new Point(pts[3, 0], pts[3, 1]));
                MoveMouse(new Point(pts[3, 0], pts[3, 1]), new Point(pts[0, 0], pts[0, 1]));
            }


        }

        private void MoveMouse(Point from, Point to)
        {
            int mc = 30; // 움직일 회수
            int ms = 100; // 움직일 시간

            //MouseSimulation.MouseUp(MouseEventType.NONE, from.X, from.Y);
            Cursor.Position = from;

            Thread.Sleep(ms / mc);

            for (int i=0; i<mc; i++)
            {
                int x, y;

                if (from.X > to.X) x = from.X - ((from.X - to.X) / mc * i);
                else x = from.X + ((to.X - from.X) / mc * i);

                if (from.Y > to.Y) y = from.Y - ((from.Y - to.Y) / mc * i);
                else y = from.Y + ((to.Y - from.Y) / mc * i);

                //MouseSimulation.MouseUp(MouseEventType.NONE, x, y);
                Cursor.Position = new Point(x, y);
                Debug.WriteLine("{0} SimulInput {1}, {2}", DateTime.Now.ToString("HHmmss"), x, y);

                Thread.Sleep(ms / mc);

            }

            //MouseSimulation.MouseUp(MouseEventType.NONE, to.X, to.Y);
            Cursor.Position = to;
        }
    }
}
