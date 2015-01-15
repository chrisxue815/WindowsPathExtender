using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WindowsPathExtender
{
    public partial class Form1
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        internal static extern IntPtr GetFocus();

        private Control GetFocusedControl()
        {
            Control focusedControl = null;
            // To get hold of the focused control:
            IntPtr focusedHandle = GetFocus();
            if (focusedHandle != IntPtr.Zero)
            {
                // Note that if the focused Control is not a .Net control, then this will return null.
                focusedControl = FromHandle(focusedHandle);
            }
            return focusedControl;
        }

        /// <summary>
        /// Add Ctrl-A select all function to text boxes
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            const int WM_KEYDOWN = 0x100;
            if (msg.Msg == WM_KEYDOWN)
            {
                var keyCode = (Keys)(msg.WParam.ToInt32() & Convert.ToInt32(Keys.KeyCode));
                if (keyCode == Keys.A && ModifierKeys == Keys.Control)
                {
                    var focused = GetFocusedControl() as TextBox;
                    if (focused != null)
                    {
                        textBoxEnv.SelectAll();
                        return true;
                    }
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
