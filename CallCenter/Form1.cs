using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace CallCenter
{
    public partial class Form1 : Form
    {

        Funcionario atendente1 = new Funcionario("Paula", "Atendente");
        Funcionario especialista = new Funcionario("Alice", "Especialista");
        Funcionario revisor = new Funcionario("Bruno", "Revisor");


        public Form1()
        {
            InitializeComponent();
 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        
            lblNome.Text = atendente1.Nome.ToString();
            lblNome2.Text = especialista.Nome.ToString();
            lblNome3.Text = revisor.Nome.ToString();

            lblCargo.Text = atendente1.Cargo.ToString();
            lblCargo2.Text = especialista.Cargo.ToString();
            lblCargo3.Text = revisor.Cargo.ToString();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var horaAgora = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

            flukeMethod(horaAgora);
        }

        public void flukeMethod( TimeSpan horaAgora)
        {
            //variavel que soma um tempo ao horario de atendimento para saber quando estara disponivel
            //Supondo que uma ligação dure 2 minutos
            var time = new TimeSpan(0, 2, 0);

            //verificando se o horario que estara disponivel é menor que o horario  atual
            int atendenteDisp, especialistaDisp, revisorDisp;
            atendenteDisp = TimeSpan.Compare( atendente1.horaLivre, horaAgora);
            especialistaDisp = TimeSpan.Compare(especialista.horaLivre, horaAgora);
            revisorDisp = TimeSpan.Compare(revisor.horaLivre, horaAgora);


            //Se retornar 1 = horario de agora é maior que o horario que estara disponivel
            if (atendenteDisp <= 0)
            {
                //Pega o horario do sistema
                atendente1.horaLivre = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

                lblAtendeu.Text = "Atendeu";

                lblHorario.Text = atendente1.horaLivre.ToString();

                //Somando o horario do atendimento para criar o horario que estara disponivel
                var total = time.Add(atendente1.horaLivre);
                atendente1.horaLivre = total;

                lblMod.Text = total.ToString();

                //Torna visiveis as labels 
                lblAtendeu.Visible = true;
                lblHorario.Visible = true;
                lblMod.Visible = true;



                return;
                
            }
            else
            {
                lblAtendeu.Text = "Ocupado";
            }
            if (especialistaDisp <= 0)
            {
                //Pega o horario do sistema
                especialista.horaLivre = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);


                lblAtendeu2.Text = "Atendeu";

                lblHorario2.Text = especialista.horaLivre.ToString();

                //Somando o horario do atendimento para criar o horario que estara disponivel
                var total = time.Add(especialista.horaLivre);
                especialista.horaLivre = total;

                lblMod2.Text = total.ToString();

               

                //Torna visiveis as labels 
                lblAtendeu2.Visible = true;
                lblHorario2.Visible = true;
                lblMod2.Visible = true;

                return;

            }
            else
            {
                lblAtendeu2.Text = "Ocupado";
            }
            if (revisorDisp <= 0)
            {
                //Pega o horario do sistema
                revisor.horaLivre = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);


                lblAtendeu3.Text = "Atendeu";

                lblHorario3.Text = revisor.horaLivre.ToString();

                //Somando o horario do atendimento para criar o horario que estara disponivel
                var total = time.Add(revisor.horaLivre);
                revisor.horaLivre = total;

                lblMod3.Text = total.ToString();



                //Torna visiveis as labels 
                lblAtendeu3.Visible = true;
                lblHorario3.Visible = true;
                lblMod3.Visible = true;

                return;

            }
            else
            {
                lblAtendeu3.Text = "Ocupado";
            }

        }


        //Timer para mostrar o horário
        private void Timer1_Tick(object sender, EventArgs e)
        {
            lblRelogio.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
