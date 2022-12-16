One option where you don't have to drill all the way down to the WinAPI is to implement `IMessageFilter` on the MainForm. The argument for doing so is that ordinarily the main form isn't going to see a `Click` event that occurs on a child control. This is an easy way to gain access to every click. In fact, this works so well that we have to take pains to _exclude_ a click that occurs on the button that enables the Click to Move!

In the code I used to test this answer, it seemed intuitive to center the button where the click takes place. This offset is easy to change if it doesn't suit you.

A screenshot doesn't really capture the behavior very well, so I've put the example up on GitHub feel free to [Clone]() it.
