As I understand it, the desired behavior is to enable the "Click to Move" (one way or another) and then move the form to a new location based on where you click _next_. 

One option where you don't have to drill all the way down to the WinAPI is to implement `IMessageFilter` on the MainForm. The argument for doing so is that ordinarily the main form isn't going to see a `Click` event that occurs on a child control. This is an easy way to gain access to every click. (In fact, this works so well that we have to take pains to _exclude_ a click that occurs on the button that enables the Click to Move!)

***
**MessageFilter implementation and disposal**

    public partial class MainForm : Form, IMessageFilter
    {
        public MainForm()
        {
            InitializeComponent();
            Application.AddMessageFilter(this);

            // A little bit of setting up for the move offsets etc.
            var offset = RectangleToScreen(ClientRectangle);
            CLIENT_RECT_OFFSET = offset.Y - Location.Y;
            initRichText();
        }
        readonly int CLIENT_RECT_OFFSET;

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
    }

***
**Perform the Move**

Using `BeginInvoke` to avoid blocking the mouse click itself, set the new main form location to the screen position of the WM_LBUTTONDOWN message;

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

            var offsetToNow = new Point(
                mousePosition.X - centerButton.X,
                mousePosition.Y - centerButton.Y - CLIENT_RECT_OFFSET);

            BeginInvoke(() =>
            {
                Location = offsetToNow;                    
                richTextBox.Select(0, 0); // Cosmetic fix selection artifact
            });
        }
    }

In the code I used to test this answer, it seemed intuitive to center the button where the click takes place. This offset is easy to change if it doesn't suit you. A screenshot doesn't really capture the behavior very well, so I've put the example up on GitHub feel free to [Clone](https://github.com/IVSoftware/move-with-mouse-click.git) it.


[![screenshot][1]][1]


  [1]: https://i.stack.imgur.com/r4b3S.png