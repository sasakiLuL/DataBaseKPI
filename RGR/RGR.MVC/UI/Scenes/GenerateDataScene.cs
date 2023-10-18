using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGR.MVC.UI.Scenes
{
    public class GenerateDataScene : Scene
    {
        public GenerateDataScene(UISettings settings) : base(settings) 
        {
            
        }

        public override SceneType Type => SceneType.GenerateMenu;

        public override SceneType Render()
        {
            throw new NotImplementedException();
        }
    }
}
