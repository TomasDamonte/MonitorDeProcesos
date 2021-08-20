using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        public double ToSize(long value, SizeUnits unit)
        {
            return Math.Round(value/(double)Math.Pow(1000, (long)unit),2);
        }

    }

    public enum SizeUnits
    {
        Byte, KB, MB, GB, TB, PB, EB, ZB, YB
    }

}
