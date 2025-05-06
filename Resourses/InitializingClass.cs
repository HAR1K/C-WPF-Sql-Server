using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectCursovay.Sourse
{
    internal class InitializingClass
    {
        public ProgressBarSettings pgSettings;
        public InterfaseSettings interfaseSettings;
        public StartAddData startAddData;
        public GetData getData;
        public PlayerController playerController;
        public InitializingClass() 
        {
            interfaseSettings = new InterfaseSettings();
            pgSettings = new ProgressBarSettings();
            startAddData = new StartAddData();
            getData = new GetData();
            playerController = new PlayerController();
        }
    }
}
