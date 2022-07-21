using AllSkills;
using System.IO;
using System.Text;
using Modding;

namespace Mod_Skills {
    public class Mod_Skills : Mod {
        private AllSkills mySkills = new AllSkills();
        public override void Initialize() {
            ModHooks.Instance.SetPlayerBoolHook += PlayerBoolSet;
        }
        public void PlayerBoolSet(string target, bool value) {
            PlayerData.instance.SetBoolInternal(target, value);
            mySkills.UpdateSkillValues(Playerdata.instance);
            WriteHtmlDataFile();
        }        
        public void WriteHtmlDataFile() {
            string path = Directory.GetCurrentDirectory() + @"\hollow_knight_Data\Managed\Mods\AllSkills_1.3";
            string fileName = "data.html";
            string fullPath = path + "\\" + fileName;
            string timeString = DateTime.Now.ToString("hh:mm:ss");

            // Create folder if doesn't exist 
            System.IO.Directory.CreateDirectory(path);

            try {    
                // Check if file already exists. If yes, delete it.     
                if (File.Exists(fullPath)) {    
                    File.Delete(fullPath);    
                }    
    
                // Create a new file     
                using (FileStream fs = File.Create(fullPath)) {
                    
                    string myHTML = mySkills.toString();
                    
                    fs.Write(new UTF8Encoding(true).GetBytes(myHTML), 0, myHTML.Length);
                }
            }    
            catch (Exception Ex) {    
                Log(Ex.ToString());    
            }
        }
        public override string GetVersion() => Assembly.GetExecutingAssembly().GetName().Version.ToString();
    }
}