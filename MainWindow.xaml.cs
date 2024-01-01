using Calendar.Job;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace Calendar
{
    public partial class MainWindow : Window
    {

        private string filePath = "data.xml";
        private PlanData job;
        public PlanData Job { get => job; set => job = value; }

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                DeserializeToXML(filePath);
            }
            catch
            {
                SetDefaultJob();
            }
        }
        void SetDefaultJob()
        {
            Job = new PlanData();
            Job.Job = new System.Collections.Generic.List<PlanItem>();
            Job.Job.Add(new PlanItem()
            {
                Date = DateTime.Now,
                FromTime = new System.Drawing.Point(4, 0),
                ToTime = new System.Drawing.Point(5, 0),
                Job = "JUST TRYYYY !!",
                Status = PlanItem.EPlanItem.COMING.ToString(),
            });
            Job.Job.Add(new PlanItem()
            {
                Date = DateTime.Now,
                FromTime = new System.Drawing.Point(4, 0),
                ToTime = new System.Drawing.Point(5, 0),
                Job = "JUST TRYYYY !!",
                Status = PlanItem.EPlanItem.COMING.ToString(),
            });
            Job.Job.Add(new PlanItem()
            {
                Date = DateTime.Now,
                FromTime = new System.Drawing.Point(4, 0),
                ToTime = new System.Drawing.Point(5, 0),
                Job = "JUST TRYYYY !!",
                Status = PlanItem.EPlanItem.COMING.ToString(),
            });
        }
        private void SerializeToXML(object data, string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            XmlSerializer sr = new XmlSerializer(typeof(PlanData));
            sr.Serialize(fs, data);
            fs.Close();
        }
        private object DeserializeToXML(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                XmlSerializer sr = new XmlSerializer(typeof(PlanData));
                object result = sr.Deserialize(fs);
                fs.Close();
                return result;
            }
            catch (Exception e)
            {
                fs.Close();
            }
            return null;
        }
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            SerializeToXML(Job, filePath);

        }
    }
}
