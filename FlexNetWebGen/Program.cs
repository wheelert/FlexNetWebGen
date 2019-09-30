using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexNetParse;
using System.Configuration;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            FNParse _parse = new FNParse();

            var appSettings = ConfigurationManager.AppSettings;

            string _server = appSettings["server"];
            string _lmpath = appSettings["lmpath"];

            _parse.setServer(_server);
            _parse.setlmutilpath(_lmpath);

            string _data = _parse.FNData();

            string _html = System.IO.File.ReadAllText(@"template.html");
            DateTime _time = DateTime.Now;
            _html = _html.Replace("###TIME###", _time.ToString());
            _html = _html.Replace("###REPLACE###", _data);
            
            System.IO.File.WriteAllText(@"index.html", _html);


        }
    }
}
