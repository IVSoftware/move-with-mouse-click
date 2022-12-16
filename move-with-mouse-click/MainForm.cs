using System.Diagnostics;

namespace move_with_mouse_click
{
    public partial class MainForm : Form, IMessageFilter
    {
        public MainForm()
        {
            InitializeComponent();
            Application.AddMessageFilter(this);
            var clientOffset = Location.Y - PointToScreen(ClientRectangle.Location).Y;
            var offset = RectangleToScreen(ClientRectangle);
            CLIENT_RECT_OFFSET = offset.Y - Location.Y;
        }
        readonly int CLIENT_RECT_OFFSET;
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
                Application.RemoveMessageFilter(this);
            }
            base.Dispose(disposing);
        }

        const int WM_LBUTTONDOWN = 0x0201;
        public bool PreFilterMessage(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_LBUTTONDOWN:
                    if(checkBoxEnableCTM.Checked)
                    {
                        onClickToMove(MousePosition);
                    }
                    break;
            }
            return false;
        }
        private void onClickToMove(Point mousePosition)
        {
            if (checkBoxEnableCTM.ClientRectangle.Contains(checkBoxEnableCTM.PointToClient(mousePosition)))
            {
                // We really have to exclude this control, don't we?
            }
            else
            {
                // Try this. Offset the new `mousePosition` so that the cursor lands
                // in the middle of the button when the move is over. This feels
                // like a semi-intuitive motion perhaps. This means we have to
                // subtract the relative position of the button from the new loc.
                var clientNew = PointToClient(mousePosition);

                var centerButton =
                    new Point(
                        checkBoxEnableCTM.Location.X + checkBoxEnableCTM.Width / 2,
                        checkBoxEnableCTM.Location.Y + checkBoxEnableCTM.Height / 2);
                { }
                var offsetToNow = new Point(
                    mousePosition.X - centerButton.X,
                    mousePosition.Y - centerButton.Y - CLIENT_RECT_OFFSET);
                { }

                BeginInvoke(() => Location = offsetToNow);
            }
        }
    }
}