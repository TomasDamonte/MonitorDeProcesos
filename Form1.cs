using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitorDeProcesos
{    
    public partial class Form1 : Form
    {
        Timer Timer = new Timer();
        BindingList<Proceso> Procesos = new BindingList<Proceso>();

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {            
            gridControl1.DataSource = Procesos;
            Timer.Interval = 1000;
            Timer.Tick += Timer_Tick;
            Timer.Start();
            List<Process> prs = new List<Process>(Process.GetProcesses());
            prs.ForEach(p => Procesos.Add(new Proceso(p)));
            base.OnLoad(e);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {            
            List<Process> prs = new List<Process>(Process.GetProcesses());

            List<int> idsBorrar = new List<int>();
            foreach (Proceso pro in Procesos)
            {
                if (!prs.Any(p => p.Id == pro.Id)) idsBorrar.Add(pro.Id);
            }
            for(int i = 0; i < idsBorrar.Count; i++)
            {
                Procesos.Remove(Procesos.First(p => p.Id == idsBorrar.ElementAt(i)));
            }

            foreach(Process pr in prs)
            {
                Proceso actual = Procesos.FirstOrDefault(p => p.Id == pr.Id);
                if(actual != null) actual.Actualizar(pr);                
                else Procesos.Add(new Proceso(pr));                              
            }
            gridView1.RefreshData();
        }        
    }

    public class Proceso
    {
        public int Id { get; set; }
        public string ProcessName { get; set; }
        public TimeSpan TotalProcessorTime { get; set; }
        public int Hilos { get; set; }
        public DateTime StartTime { get; set; }
        public string WorkingSet64 { get; set; }

        public Proceso() { }

        public Proceso(Process p) 
        {
            Id = p.Id;            
            ProcessName = p.ProcessName;
            try { TotalProcessorTime = p.TotalProcessorTime; } catch (Exception) { }
            Hilos = p.Threads.Count;
            try { StartTime = p.StartTime; } catch (Exception) { }
            WorkingSet64 = ToSize(p.WorkingSet64, SizeUnits.MB);            
        }

        public void Actualizar(Process p)
        {
            Id = p.Id;
            ProcessName = p.ProcessName;
            try { TotalProcessorTime = p.TotalProcessorTime; } catch (Exception) { }
            Hilos = p.Threads.Count;
            try { StartTime = p.StartTime; } catch (Exception) { }
            WorkingSet64 = ToSize(p.WorkingSet64, SizeUnits.MB);
        }

        public enum SizeUnits
        {
            Byte, KB, MB, GB, TB, PB, EB, ZB, YB
        }

        public string ToSize(long value, SizeUnits unit)
        {
            return (value / (double)Math.Pow(1000, (long)unit)).ToString("0.00");
        }
    }


}
