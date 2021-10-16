using System;
using System.IO;
using System.Text;
using Modding;

namespace AllSkills
{
    public class AllSkills : Mod 
    {
        private const string version = "1.2.0";
        
        private int _dashLevel;
        private int _dreamNailLevel;
        private bool _dreamNailUpgraded;
        private int _fireballLevel;
        private bool _hasAcidArmour;
        private bool _hasCyclone;
        private bool _hasDash;
        private bool _hasDashSlash;
        private bool _hasDoubleJump;
        private bool _hasDreamNail;
        private bool _hasShadowDash;
        private bool _hasSuperDash;
        private bool _hasUpwardSlash;
        private bool _hasWalljump;
        private int _quakeLevel;
        private int _screamLevel;

        public override void Initialize()
        {
            ModHooks.Instance.SetPlayerBoolHook += PlayerBoolSet;
        }
        
        public void PlayerBoolSet(string target, bool value)
        {
            PlayerData.instance.SetBoolInternal(target, value);
            UpdateSkillValues();
        }

        public override string GetVersion()
        {
            return version;
        }

        private bool HasSkillNewValue()
        {
            PlayerData pd = PlayerData.instance;

            return 
                   _dreamNailUpgraded != pd.dreamNailUpgraded ||
                   _fireballLevel != pd.fireballLevel ||
                   _hasAcidArmour != pd.hasAcidArmour ||
                   _hasCyclone != pd.hasCyclone ||
                   _hasDashSlash != pd.hasDashSlash ||
                   _hasDoubleJump != pd.hasDoubleJump ||
                   _hasDreamNail != pd.hasDreamNail ||
                   _hasShadowDash != pd.hasShadowDash ||
                   _hasSuperDash != pd.hasSuperDash ||
                   _hasUpwardSlash != pd.hasUpwardSlash ||
                   _hasWalljump != pd.hasWalljump ||
                   _quakeLevel != pd.quakeLevel ||
                   _screamLevel != pd.screamLevel ||
                   _hasDash != pd.hasDash;
        }

        private void UpdateSkillValues()
        {
            if (HasSkillNewValue())
            {
                PlayerData pd = PlayerData.instance;

                _dashLevel = pd.hasShadowDash ? 2 : pd.hasDash ? 1 : 0;
                _dreamNailLevel = pd.dreamNailUpgraded ? 2 : pd.hasDreamNail ? 1 : 0;
                _dreamNailUpgraded = pd.dreamNailUpgraded;
                _fireballLevel = pd.fireballLevel;
                _hasAcidArmour = pd.hasAcidArmour;
                _hasCyclone = pd.hasCyclone;
                _hasDash = pd.hasDash;
                _hasDashSlash = pd.hasDashSlash;
                _hasDreamNail = pd.hasDreamNail;
                _hasDoubleJump = pd.hasDoubleJump;
                _hasShadowDash = pd.hasShadowDash;
                _hasSuperDash = pd.hasSuperDash;
                _hasUpwardSlash = pd.hasUpwardSlash;
                _hasWalljump = pd.hasWalljump;
                _quakeLevel = pd.quakeLevel;
                _screamLevel = pd.screamLevel;
                
                WriteHtmlDataFile();
            }
        }
        
        public void WriteHtmlDataFile()
        {
            string path = Directory.GetCurrentDirectory() + @"\hollow_knight_Data\Managed\Mods\AllSkills";
            string fileName = "data.html";
            string fullPath = path + "\\" + fileName;
            string timeString = DateTime.Now.ToString("hh:mm:ss");

            // Create folder if doesn't exist 
            System.IO.Directory.CreateDirectory(path);

            try    
            {    
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(fullPath))    
                {    
                    File.Delete(fullPath);    
                }    
    
                // Create a new file     
                using (FileStream fs = File.Create(fullPath))
                {
                    string html = $"<html><body><script>" +
                                  $"const data = {{" +
                                  $"skills: {{" +
                                      $"acidArmour: {_hasAcidArmour.ToString().ToLower()}," +
                                      $"cyclone: {_hasCyclone.ToString().ToLower()}," +
                                      $"dashLevel: {_dashLevel}," +
                                      $"dreamNailLevel: {_dreamNailLevel}," +
                                      $"dashSlash: {_hasDashSlash.ToString().ToLower()}," +
                                      $"doubleJump: {_hasDoubleJump.ToString().ToLower()}," +
                                      $"fireballLevel: {_fireballLevel.ToString().ToLower()}," +
                                      $"focus: true," +
                                      $"greatSlash: {_hasUpwardSlash.ToString().ToLower()}," +
                                      $"quakeLevel: {_quakeLevel.ToString().ToLower()}," +
                                      $"screamLevel: {_screamLevel.ToString().ToLower()}," +
                                      $"superDash: {_hasSuperDash.ToString().ToLower()}," +
                                      $"wallJump: {_hasWalljump.ToString().ToLower()}," +
                                  $"}}," +
                                  $"lastUpdateTime: '{timeString}'" +
                                  $"}};" +
                                  $"parent.postMessage(data, \"*\");" +
                                  $"</script></body></html>";
                    
                    fs.Write(new UTF8Encoding(true).GetBytes(html), 0, html.Length);
                }
            }    
            catch (Exception Ex)    
            {    
                Log(Ex.ToString());    
            }
        }
    }
}