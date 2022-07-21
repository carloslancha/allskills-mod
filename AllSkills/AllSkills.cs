using System;
using System.IO;
using System.Reflection;
using System.Text;
using Modding;
using static Skills;

namespace AllSkills {
    public class AllSkills : Mod {
        private const string version = "Beta-1.5.0";
        private Skills Skills_ = new Skills();
        public override void Initialize() {
            ModHooks.SetPlayerBoolHook += PlayerBoolSet;
        }
        private bool PlayerBoolSet(string target, bool value) {
            PlayerData.instance.SetBoolInternal(target, value);
            Skills_.UpdateSkillValues(PlayerData.instance);
            WriteHtmlDataFile();

            return true;
        }        
        private void WriteHtmlDataFile() {
            string path = Directory.GetCurrentDirectory() + @"\hollow_knight_Data\Managed\Mods\AllSkills_1.3";
            string fileName = "data.html";
            string fullPath = path + "\\" + fileName;

            // Create folder if doesn't exist 
            System.IO.Directory.CreateDirectory(path);

            try {    
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(fullPath)) {    
                    File.Delete(fullPath);    
                }    
    
                // Create a new file     
                using (FileStream fs = File.Create(fullPath)) {
                    
                    string HTML_ = Skills_.toString();
                    
                    fs.Write(new UTF8Encoding(true).GetBytes(HTML_), 0, HTML_.Length);
                }
            }    
            catch (Exception Ex) {    
                Log(Ex.ToString());    
            }
        }
        public override string GetVersion() => version;
    }
}