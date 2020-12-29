using System.Collections.Generic;
using WeifenLuo.WinFormsUI.Docking;

namespace Common.Process
{
    public class UIProcess
    {
        public static ThemeBase DockPanelTheme { get; } = new VS2015BlueTheme();

        public static Dictionary<string, DockState> ContentState { get; set; } = new Dictionary<string, DockState>();
    }
}
