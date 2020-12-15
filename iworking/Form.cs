using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Hook;

namespace iworking
{
    public partial class FormMain : Form
    {
        private Point mousePosition;

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

            mousePosition = Cursor.Position;
        }

        private void DoInput()
        {
            dtLastInput.Value = DateTime.Now;
        }

        private bool InputMouse(MouseEventType type, int x, int y)
        {
            mousePosition.X = x;
            mousePosition.Y = y;
            DoInput();
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
                    SimulMouse();
                }
            }
        }

        private void SimulMouse()
        {
            MouseSimulation.MouseUp(MouseEventType.NONE, mousePosition.X - 10, mousePosition.Y - 10);
            MouseSimulation.MouseUp(MouseEventType.NONE, mousePosition.X, mousePosition.Y);
        }
    }
}
