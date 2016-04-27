using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AlfaPlayer2
{
    public static class Util
    {
        private const string UpgradeFlag = "UpgradeRequired";

        public static void DoUpgrade(ApplicationSettingsBase settings)
        {
            try
            {
                // attempt to read the upgrade flag
                if ((bool)settings[UpgradeFlag] == true)
                {
                    // upgrade the settings to the latest version
                    settings.Upgrade();

                    // clear the upgrade flag
                    settings[UpgradeFlag] = false;
                    settings.Save();
                }
                else
                {
                    // the settings are up to date
                }
            }
            catch (SettingsPropertyNotFoundException ex)
            {
                // notify the developer that the upgrade
                // flag should be added to the settings file
                throw ex;
            }
        }

       
    }

}
