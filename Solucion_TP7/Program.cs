using System;
using System.Collections.Generic;
using System.Linq;

namespace Solucion_TP7
{
    class Program
    {
        static void Main(string[] args)
        {
            int anioActual = 2019;
            List<Empleado> ListaEmpleados = new List<Empleado>();
            Empleado emp;
            
            for (int i = 0; i < 20; i++)
            {
                ListaEmpleados.Add(CrearEmpleado());
            }

            Console.WriteLine("Cantidad de empleados de la empresa: {0}", ListaEmpleados.Count);
            Console.WriteLine("Monto total en concepto de salarios: ${0}", ListaEmpleados.Sum(x => x.Salario(anioActual)));



            Console.WriteLine("Datos del empleado numero 5:");
            emp = ListaEmpleados.ElementAt(5-1);
           
            emp.MostrarDatos();
            Console.WriteLine("Edad del empleado: {0}", emp.Edad(anioActual));
            Console.WriteLine("Antigüedad del empleado: {0}", emp.Antiguedad(anioActual));
            Console.WriteLine("Años restantes para la jubilación del empleado: {0}", emp.AniosRestantesJubilacion(anioActual));
            Console.WriteLine("Salario del empleado: ${0}", emp.Salario(anioActual));
            
            Console.Read();
        }

        public enum Cargo
        {
            Auxiliar,
            Administrativo,
            Ingeniero,
            Especialista,
            Investigador,
        }

        public struct Empleado
        {
            public string nombre;
            public string apellido;
            public string estadoCiv;
            public string genero;
            public float sueldoBasico;
            public int cantHijos;
            public Fecha fechaNac;
            public Fecha fechaIngre;
            public Cargo cargo;

            public Empleado(string _nombre,
                            string _apellido,
                            Fecha _fechaNac,
                            string _estadoCiv,
                            string _genero,
                            Fecha _fechaIngre,
                            float _sueldoBasico,
                            Cargo _cargo,
                            int _cantHijos)
            {
                nombre = _nombre;
                apellido = _apellido;
                fechaNac = _fechaNac;
                estadoCiv = _estadoCiv;
                genero = _genero;
                fechaIngre = _fechaIngre;
                sueldoBasico = _sueldoBasico;
                cargo = _cargo;
                cantHijos = _cantHijos;
            }

            public void MostrarDatos()
            {
                Console.WriteLine("---------------------");
                Console.WriteLine("Nombre: {0}", nombre);
                Console.WriteLine("Apellido: {0}", apellido);
                Console.WriteLine("Fecha de nacimiento: {0}/{1}/{2}", fechaNac.dia, fechaNac.mes, fechaNac.anio);
                Console.WriteLine("Estado civil: {0}", estadoCiv);
                Console.WriteLine("Género: {0}", genero);
                Console.WriteLine("Fecha de ingreso: {0}/{1}/{2}", fechaIngre.dia, fechaIngre.mes, fechaIngre.anio);
                Console.WriteLine("Sueldo básico: ${0}", sueldoBasico);
                Console.WriteLine("Cargo: {0}", cargo);
                Console.WriteLine("Cantidad de hijos: {0}", cantHijos);
                Console.WriteLine("---------------------");
            }

            public int Antiguedad(int anioActual)
            {
                //Devuelve la antigüedad en años del empleado
                return anioActual - fechaIngre.anio;
            }

            public int Edad(int anioActual)
            {
                //Devuelve la edad en años del empleado
                return anioActual - fechaNac.anio;
            }

            public int AniosRestantesJubilacion(int anioActual)
            {
                //Devuelve la cantidad de años restantes para la jubilación del empleado
                if (genero == "Hombre")
                {
                    return 65 - this.Edad(anioActual);
                }
                else
                {
                    return 60 - this.Edad(anioActual);
                }
            }

            public float Salario(int anioActual)
            {
                float adicional = 0;

                if (this.Antiguedad(anioActual) >= 20)
                {
                    //Si la antiguedad es mayor a 20 años 
                    adicional += sueldoBasico * (float)0.25;
                }
                else
                {
                    adicional += sueldoBasico *  this.Antiguedad(anioActual) * (float)0.02;
                }

                if (cargo == Cargo.Ingeniero || cargo == Cargo.Especialista)
                {
                    adicional *= (float)1.5;
                }

                if ( (estadoCiv.ToLower() == "casado") && (cantHijos > 2) )
                {
                    adicional += (float)5000.0;
                }

                return sueldoBasico + adicional;


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

        public static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        public static Empleado CrearEmpleado()
        {
            string nombre;
            string apellido;
            string genero;
            Fecha fechaNac;
            Fecha fecha_ingr;
            string estado_civ;
            float sueldo_basico;
            Cargo cargo;
            int cantHijos;

            string[] nombresMasc = new string[5] { "Jorge", "Emanuel", "Pepe", "Santiago", "Hugo" };
            string[] nombresFeme = new string[5] { "Sofia", "Maria", "Amelia", "Liliana", "Marta" };
            string[] apellidos = new string[5] { "Armando", "Casas", "Fuertes"," Guerra", "Frías" };

            apellido = apellidos[RandomNumber(1, 5)];

            if (RandomNumber(0, 2) == 1)
            {
                genero = "Mujer";
                nombre = nombresFeme[RandomNumber(1, 5)];
            }
            else
            {
                genero = "Hombre";
                nombre = nombresMasc[RandomNumber(1, 5)]; 
            }

            if (RandomNumber(0, 2) == 1)
            {
                estado_civ = "Casado";
            }
            else
            {
                estado_civ = "Soltero";
            }

            sueldo_basico = RandomNumber(2000, 20001);

            cantHijos = RandomNumber(0, 4);

            fechaNac = new Fecha(RandomNumber(1, 29), RandomNumber(1, 13), RandomNumber(1960, 2001));

            fecha_ingr = new Fecha(RandomNumber(1, 29), RandomNumber(1, 13), RandomNumber(fechaNac.anio + 18, 2019));

            switch (RandomNumber(1, 6))
            {
                case 1:
                    cargo = Cargo.Auxiliar;
                    break;
                case 2:
                    cargo = Cargo.Administrativo;
                    break;
                case 3:
                    cargo = Cargo.Especialista;
                    break;
                case 4:
                    cargo = Cargo.Ingeniero;
                    break;
                case 5:
                    cargo = Cargo.Investigador;
                    break;
                default:
                    cargo = Cargo.Auxiliar;
                    break;
            }


            Empleado emp = new Empleado(nombre, apellido, fechaNac, estado_civ, genero, fecha_ingr, sueldo_basico, cargo, cantHijos);

            return emp;
        }
    }
}
