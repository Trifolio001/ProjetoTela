using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using generic.core.Singleton;

namespace Screens
{

    public class ScreenManager : Singleton<ScreenManager>
    {
        
        public List<ScreenBase> screenBases;

        public ScreenType startScreen = ScreenType.Panel;

        private ScreenBase _CurrentScreen;

        
        private void Start()
        {
            HideAll();
            ShowByType(startScreen);
        }

        public void ShowByType(ScreenType type)
        {
            if (_CurrentScreen != null) _CurrentScreen.Ocult();

            var nextScreen = screenBases.Find(i => i.screenType == type);

            nextScreen.Show();
            _CurrentScreen = nextScreen;
        }

        public void HideAll()
        {
            screenBases.ForEach(i => i.Hide());
        }



    }
}
