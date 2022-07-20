using System;
using System.IO;
using System.Text;
using Modding;

namespace AllSkills
{
    public class AllSkills : Mod 
    {
        private const string version = "1.5";
        
        private int? _dashLevel = null;
        private int? _dreamNailLevel = null;
        private bool? _dreamNailUpgraded = null;
        private int? _fireballLevel = null;
        private bool? _hasAcidArmour = null;
        private bool? _hasCyclone = null;
        private bool? _hasDash = null;
        private bool? _hasDashSlash = null;
        private bool? _hasDoubleJump = null;
        private bool? _hasDreamNail = null;
        private bool? _hasShadowDash = null;
        private bool? _hasSuperDash = null;
        private bool? _hasUpwardSlash = null;
        private bool? _hasWalljump = null;
        private int? _quakeLevel = null;
        private int? _screamLevel = null;

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
                _hasDashSlash = pd.hasUpwardSlash;
                _hasDreamNail = pd.hasDreamNail;
                _hasDoubleJump = pd.hasDoubleJump;
                _hasShadowDash = pd.hasShadowDash;
                _hasSuperDash = pd.hasSuperDash;
                _hasUpwardSlash = pd.hasDashSlash;
                _hasWalljump = pd.hasWalljump;
                _quakeLevel = pd.quakeLevel;
                _screamLevel = pd.screamLevel;
                
                WriteHtmlDataFile();
            }
        }
        
        public void WriteHtmlDataFile()
        {
            string path = Directory.GetCurrentDirectory() + @"\hollow_knight_Data\Managed\Mods\AllSkills_1.3";
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