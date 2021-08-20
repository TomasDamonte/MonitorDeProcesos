using DevExpress.XtraEditors;
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
    public partial class Main : Form
    {
        Timer Timer = new Timer();
        BindingList<Proceso> Procesos = new BindingList<Proceso>();

        public Main()
        {
            InitializeComponent();
            Timer.Interval = 2000;
            Timer.Tick += Timer_Tick;
        }

        protected override void OnLoad(EventArgs e)
        {            
            gridControl1.DataSource = Procesos;            
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

        private void BtnFinalizar_Click(object sender, EventArgs e)
        {
            Proceso p = (Proceso)gridView1.GetRow(gridView1.FocusedRowHandle);
            if (p == null) return;
            if (XtraMessageBox.Show($"Desea finalizar el proceso [{p.ProcessName}]?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;           
            try
            {                
                Process.GetProcessById(p.Id)?.Kill();
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show($"No se pudo finalizar el proceso.{Environment.NewLine}{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                       
        }
    }

}
