using System;

namespace Solucion_TP7
{
    class Program
    {
        static void Main(string[] args)
        {
            string nombre = "Jorge";
            string apellido = "Casas";
            Fecha fecha_nac = new Fecha(12, 11, 1990);
            string estado_civ = "Soltero";
            char  genero = 'H';
            Fecha fecha_ingr = new Fecha(12, 11, 2010);
            float sueldo_basico = 10000;
            Cargo cargo = Cargo.Auxiliar;



            Empleado emp = new Empleado(nombre, apellido, fecha_nac, estado_civ, genero, fecha_ingr, sueldo_basico, cargo);


            emp.MostrarDatos();




            Console.Read();
        }

        public struct Empleado
        {
            public string nombre;
            public string apellido;
            public Fecha fecha_nac;
            public string estado_civ;
            public char genero;
            public Fecha fecha_ingre;
            public float sueldo_basico;
            public Cargo cargo;

            public Empleado(string _nombre,
                            string _apellido,
                            Fecha _fecha_nac,
                            string _estado_civ,
                            char _genero,
                            Fecha _fecha_ingre,
                            float _sueldo_basico,
                            Cargo _cargo)
            {
                nombre = _nombre;
                apellido = _apellido;
                fecha_nac = _fecha_nac;
                estado_civ = _estado_civ;
                genero = _genero;
                fecha_ingre = _fecha_ingre;
                sueldo_basico = _sueldo_basico;
                cargo = _cargo;
            }

            public void MostrarDatos()
            {
                Console.WriteLine("---------------------");
                Console.WriteLine("Nombre: {0}", nombre);
                Console.WriteLine("Apellido: {0}", apellido);
                Console.WriteLine("Fecha de nacimiento: {0}/{1}/{2}", fecha_nac.dia, fecha_nac.mes, fecha_nac.anio);
                Console.WriteLine("Estado civil: {0}", estado_civ);
                Console.WriteLine("Género: {0}", genero);
                Console.WriteLine("Fecha de ingreso: {0}/{1}/{2}", fecha_ingre.dia, fecha_ingre.mes, fecha_ingre.anio);
                Console.WriteLine("Sueldo básico: ${0}", sueldo_basico);
                Console.WriteLine("Cargo: {0}", cargo);
                Console.WriteLine("---------------------");
            }

        }

        public struct Fecha
        {
            public int dia;
            public int mes;
            public int anio;

            public Fecha(int _dia, int _mes, int _anio)
            {
                dia = _dia;
                mes = _mes;
                anio = _anio;
            }
        }


        public enum Cargo
        {
            Auxiliar,
            Administrativo,
            Ingeniero,
            Especialista,
            Investigado,
        }
    }
}
