using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWCFService
{
    public class TeaService : ITeaStore
    {
        // get tea details by name
        public string GetTeaInfo(string teaName)
        {

            try
            {
                TeastoreDataModel db = new TeastoreDataModel();

                Tea tea = db.Teas.Where(d => d.Name == teaName).FirstOrDefault();

                return tea.ToString();

            }
            catch (ArgumentNullException e)
            {
                return "No such tea name exists in the database.";
            }

            catch (Exception e)
            {
                return "Error: " + e.Message;
            }

        }
        // return all tea names from db
        public string GetTeaNames()
        {
            try
            {
                TeastoreDataModel db = new TeastoreDataModel();

                string allnames = "";

                var allteasnames = db.Teas.Select(d => d.Name);

                foreach (string name in allteasnames)
                {
                    allnames = allnames + name + ", ";
                }
                // to remove space and comma at the end of the string
                
                allnames = allnames.TrimEnd(' ',',');

                return allnames;

            }
            catch (ArgumentNullException e)
            {
                return "No teas in the database now.";
            }

            catch (Exception e)
            {
                return "Error: " + e.Message;
            }
        }

        // return all entries
        public List<Tea> GetAllTeas()
        {
            TeastoreDataModel db = new TeastoreDataModel();

            return db.Teas.ToList();
        }
    }
}
