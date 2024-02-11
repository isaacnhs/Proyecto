// See https://aka.ms/new-console-template for more information

/* Proyecto de programación II */

using System;

class Estudiante
{
    public string Cedula { get; set; }
    public string Nombre { get; set; }
    public double Promedio { get; set; }
    public string Condicion { get; set; }
}

class Programa
{
    static Estudiante[] estudiantes = new Estudiante[10];

    static void Main(string[] args)
    {
        int opcion;

        do
        {
            Console.WriteLine("Menú principal del sistema de estudiantes");
            Console.WriteLine("");
            Console.WriteLine("1. Inicializar vectores");
            Console.WriteLine("2. Incluir estudiantes");
            Console.WriteLine("3. Consultar estudiantes");
            Console.WriteLine("4. Modificar estudiantes");
            Console.WriteLine("5. Eliminar estudiantes");
            Console.WriteLine("6. Submenú de reportes");
            Console.WriteLine("7. Salir");

            try
            {
                Console.WriteLine("");
                Console.Write("Seleccione una opción del 1-6 para continuar o 7 para salir del programa: ");
                Console.WriteLine("");
                Console.WriteLine("");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        InicializarVectores();
                        break;
                    case 2:
                        IncluirEstudiantes();
                        break;
                    case 3:
                        ConsultarEstudiantes();
                        break;
                    case 4:
                        ModificarEstudiantes();
                        break;
                    case 5:
                        EliminarEstudiantes();
                        break;
                    case 6:
                        SubmenuReportes();
                        break;
                    case 7:
                        Console.WriteLine("");
                        Console.WriteLine("Saliendo del programa...");
                        Console.WriteLine("");
                        break;
                    default:
                        Console.WriteLine("");
                        Console.WriteLine("Error: Por favor, ingrese un número válido entre 1 y 7.");
                        Console.WriteLine("");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("");
                Console.WriteLine("Opción inválida. Inténtelo de nuevo, digitando un valor númerico.");
                Console.WriteLine("");
                opcion = 0; 
            }

        } while (opcion != 7);
    }

    static void InicializarVectores()
    {
        estudiantes = new Estudiante[10];
        Console.WriteLine("Los vectores han sido inicializados correctamente.");
    }

    static void IncluirEstudiantes()
    {
        for (int i = 0; i < estudiantes.Length; i++)
        {
            if (estudiantes[i] == null)
            {
                Console.WriteLine("");
                Console.WriteLine("Ingrese los datos del estudiante:");
                Console.WriteLine("");
                Console.Write("Cédula: ");
                string cedula = Console.ReadLine();
                Console.Write("Nombre: ");
                string nombre = Console.ReadLine();
                Console.Write("Promedio: ");
                double promedio = double.Parse(Console.ReadLine());

                string condicion;
                if (promedio >= 70)
                    condicion = "Aprobado";
                else if (promedio >= 60)
                    condicion = "Reprobado";
                else
                    condicion = "Aplazado";

                estudiantes[i] = new Estudiante { Cedula = cedula, Nombre = nombre, Promedio = promedio, Condicion = condicion };
                Console.WriteLine("");
                Console.WriteLine($"El estudiante {estudiantes[i].Nombre} fue incluido correctamente.");
                Console.WriteLine("");
                return;
            }
        }
        Console.WriteLine("");
        Console.WriteLine("No hay espacio disponible para incluir más estudiantes.");
        Console.WriteLine("");
    }

    static void ConsultarEstudiantes()
    {
        Console.WriteLine("");
        Console.Write("Ingrese el número de cédula del estudiante a consultar: ");
        Console.WriteLine("");
        string cedula = Console.ReadLine();

        foreach (var estudiante in estudiantes)
        {
            if (estudiante != null && estudiante.Cedula == cedula)
            {
                Console.WriteLine($"Cédula: {{estudiante.Cedula}}, Nombre: {{estudiante.Nombre}}, Promedio: {{estudiante.Promedio}}, Condición: {{estudiante.Condicion}}");
                return;
            }
        }
        Console.WriteLine("");
        Console.WriteLine($"El estudiante con el número de cédula {cedula} no fue encontrado.");
        Console.WriteLine("");
    }

    static void ModificarEstudiantes()
    {
        Console.WriteLine("");
        Console.Write("Ingrese el número de cédula del estudiante a modificar: ");
        Console.WriteLine("");
        string cedula = Console.ReadLine();

        for (int i = 0; i < estudiantes.Length; i++)
        {
            if (estudiantes[i] != null && estudiantes[i].Cedula == cedula)
            {
                Console.WriteLine("Ingrese los nuevos datos del estudiante:");
                Console.Write("Nombre: ");
                estudiantes[i].Nombre = Console.ReadLine();
                Console.Write("Promedio: ");
                estudiantes[i].Promedio = double.Parse(Console.ReadLine());

                if (estudiantes[i].Promedio >= 70)
                    estudiantes[i].Condicion = "Aprobado";
                else if (estudiantes[i].Promedio >= 60)
                    estudiantes[i].Condicion = "Reprobado";
                else
                    estudiantes[i].Condicion = "Aplazado";

                Console.WriteLine($"El estudiante con el número de cédula {cedula} fue modificado correctamente.");
                return;
            }
        }

        Console.WriteLine($"El estudiante con el número de cédula {cedula} no fue encontrado.");
    }

    static void EliminarEstudiantes()
    {
        Console.WriteLine("");
        Console.Write("Ingrese el número de cédula del estudiante a eliminar: ");
        Console.WriteLine("");
        string cedula = Console.ReadLine();

        for (int i = 0; i < estudiantes.Length; i++)
        {
            if (estudiantes[i] != null && estudiantes[i].Cedula == cedula)
            {
                estudiantes[i] = null;
                Console.WriteLine($"El estudiante {estudiantes[i].Nombre} fue eliminado correctamente.");
                return;
            }
        }

        Console.WriteLine($"El estudiante con el número de cédula {cedula} no fue encontrado.");

    }

    static void SubmenuReportes()
    {
        int opcion;
        do
        {
            Console.WriteLine("Submenú de reportes");
            Console.WriteLine("");
            Console.WriteLine("1. Reporte Estudiantes por Condición");
            Console.WriteLine("2. Reporte Todos los datos");
            Console.WriteLine("3. Regresar al menú principal");
            Console.WriteLine("");
            Console.Write("Seleccione una opción del 1-2 para continuar o 3 para regresar al menú principal: ");
            Console.WriteLine("");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    ReporteEstudiantesPorCondicion();
                    break;
                case 2:
                    ReporteTodosLosDatos();
                    break;
                case 3:
                    Console.WriteLine("");
                    Console.WriteLine("Usted está regresando al menú principal...");
                    Console.WriteLine("");
                    break;
                default:
                    Console.WriteLine("");
                    Console.WriteLine("Opción inválida. Inténtelo de nuevo digitando un número de 1-3 para continuar.");
                    Console.WriteLine("");
                    break;
            }
        } while (opcion != 3);
    }

    static void ReporteEstudiantesPorCondicion()
    {
        Console.WriteLine("Seleccione la condición para el reporte del estudiante: ");
        Console.WriteLine("");
        Console.WriteLine("1. Aprobado");
        Console.WriteLine("2. Reprobado");
        Console.WriteLine("3. Aplazado");
        Console.WriteLine("");
        Console.Write("Seleccione una opción: ");
        Console.WriteLine("");
        int opcion = int.Parse(Console.ReadLine());

        string condicion;

        switch (opcion)
        {
            case 1:
                condicion = "Aprobado";
                break;
            case 2:
                condicion = "Reprobado";
                break;
            case 3:
                condicion = "Aplazado";
                break;
            default:
                Console.WriteLine("");
                Console.WriteLine("Opción inválida. Inténtelo de nuevo digitando un número de 1-3 para continuar.");
                Console.WriteLine("");
                return;
        }

        Console.WriteLine($"Reporte de estudiantes con la condición: '{condicion}':");
        foreach (var estudiante in estudiantes)
        {
            if (estudiante != null && estudiante.Condicion == condicion)
            {
                Console.WriteLine($"Cedula: {estudiante.Cedula}, Nombre: {estudiante.Nombre}, Promedio: {estudiante.Promedio}");
            }
        }
    }

    static void ReporteTodosLosDatos()
    {
        int cantidadEstudiantes = 0;
        double promedioMayor = double.MinValue;
        double promedioMenor = double.MaxValue;
        Estudiante estudianteMayor = null;
        Estudiante estudianteMenor = null;

        foreach (var estudiante in estudiantes)
        {
            if (estudiante != null)
            {
                cantidadEstudiantes++;
                if (estudiante.Promedio > promedioMayor)
                {
                    promedioMayor = estudiante.Promedio;
                    estudianteMayor = estudiante;
                }
                if (estudiante.Promedio < promedioMenor)
                {
                    promedioMenor = estudiante.Promedio;
                    estudianteMenor = estudiante;
                }
            }
        }

        Console.WriteLine("Reporte de todos los estudiantes:");
        Console.WriteLine($"Cantidad de estudiantes: {cantidadEstudiantes}");

        if (estudianteMayor != null)
            Console.WriteLine($"Estudiante(s) con el promedio mayor: Cédula: {{estudianteMayor.Cedula}}, Nombre: {{estudianteMayor.Nombre}}, Promedio: {{estudianteMayor.Promedio}}");

        if (estudianteMenor != null)
            Console.WriteLine($"Estudiante(s) con el promedio menor: Cédula: {{estudianteMenor.Cedula}}, Nombre: {{estudianteMenor.Nombre}}, Promedio: {{estudianteMenor.Promedio}}");
    }
}