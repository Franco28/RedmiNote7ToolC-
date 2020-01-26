
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Franco28Tool.Engine
{
    public class Lang
    {

        const string fileName = @"C:\Program Files\RedmiNote7Tool\es.xml";

        public static string LangEngine()
        {
            if (File.Exists(fileName))
            {
                StringBuilder result = new StringBuilder();
                foreach (XElement level1Element in XElement.Load(fileName).Elements("User"))
                {
                    result.AppendLine(level1Element.Attribute("name").Value);
                    foreach (XElement level2Element in level1Element.Elements(""))
                    {
                        result.AppendLine("  " + level2Element.Attribute("name").Value);
                    }
                }

            }
            else
            {
                MessageBox.Show("Error on loading Language!", "Language Engine", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }
    }
}
