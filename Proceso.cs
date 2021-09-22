using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace MonitorDeProcesos
{
    public class Proceso
    {
        public int Id { get; set; }
        public string ProcessName { get; set; }
        public TimeSpan TotalProcessorTime { get; set; }
        public int Hilos { get; set; }
        public DateTime StartTime { get; set; }
        public double WorkingSet64 { get; set; }
        public string Prioridad { get; set; }
        public string Usuario { get; set; }

        public Proceso(Process p)
        {
            Id = p.Id;
            ProcessName = p.ProcessName;
            try { TotalProcessorTime = p.TotalProcessorTime; } catch (Exception) { }
            Hilos = p.Threads.Count;
            try { StartTime = p.StartTime; } catch (Exception) { }
            WorkingSet64 = ToSize(p.WorkingSet64, SizeUnits.MB);
            try { Prioridad = p.PriorityClass.ToString(); } catch (Exception) { }
            SetUser();
        }

        public void Actualizar(Process p)
        {            
            try { TotalProcessorTime = p.TotalProcessorTime; } catch (Exception) { }
            Hilos = p.Threads.Count;            
            WorkingSet64 = ToSize(p.WorkingSet64, SizeUnits.MB);
            try { Prioridad = p.PriorityClass.ToString(); } catch (Exception) { }
        }

        public double ToSize(long value, SizeUnits unit)
        {
            return Math.Round(value/(double)Math.Pow(1000, (long)unit),2);
        }

        void SetUser()
        {
            string query = "Select * From Win32_Process Where ProcessID = " + Id;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            ManagementObjectCollection processList = searcher.Get();

            foreach (ManagementObject obj in processList)
            {
                string[] argList = new string[] { string.Empty, string.Empty };
                int returnVal = Convert.ToInt32(obj.InvokeMethod("GetOwner", argList));
                if (returnVal == 0)
                {
                    // return DOMAIN\user
                    Usuario = argList[1] + "\\" + argList[0];
                    return;
                }
            }
            Usuario = "NO OWNER";
        }

    }

    public enum SizeUnits
    {
        Byte, KB, MB, GB, TB, PB, EB, ZB, YB
    }

}
