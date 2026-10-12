using System;

namespace Calculadora
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("===== CALCULADORA Y VERIFICADOR DE NOTAS =====");
                Console.WriteLine("1. Sumar");
                Console.WriteLine("2. Restar");
                Console.WriteLine("3. Multiplicar");
                Console.WriteLine("4. Dividir");
                Console.WriteLine("5. Verificar si un estudiante aprobó");
                Console.WriteLine("6. Salir");
                Console.Write("\nSeleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                        RealizarOperacion(opcion);
                        break;

                    case "5":
                        VerificarAprobado();
                        break;

                    case "6":
                        continuar = false;
                        Console.WriteLine("\nPrograma finalizado. ¡Hasta luego!");
                        break;

                    default:
                        Console.WriteLine("\nOpción no válida. Elija un número del 1 al 6.");
                        break;
                }

                if (continuar)
                {
                    Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
                    Console.ReadKey();
                }
            }
        }

        static double LeerNumero(string mensaje)
        {
            double numero;
            Console.Write(mensaje);

            while (!double.TryParse(Console.ReadLine(), out numero))
            {
                Console.Write("Entrada inválida. Ingrese un número válido: ");
            }

            return numero;
        }

        static void RealizarOperacion(string opcion)
        {
            double num1 = LeerNumero("\nIngrese el primer número: ");
            double num2 = LeerNumero("Ingrese el segundo número: ");

            try
            {
                double resultado = 0;

                switch (opcion)
                {
                    case "1":
                        resultado = num1 + num2;
                        break;
                    case "2":
                        resultado = num1 - num2;
                        break;
                    case "3":
                        resultado = num1 * num2;
                        break;
                    case "4":
                        if (num2 == 0)
                        {
                            throw new DivideByZeroException();
                        }
                        resultado = num1 / num2;
                        break;
                }

                Console.WriteLine($"\nEl resultado es: {resultado}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("\nError: no se puede dividir entre cero.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nOcurrió un error inesperado: {ex.Message}");
            }
        }

        static void VerificarAprobado()
        {
            const double NotaMinima = 70; 

            double nota = LeerNumero("\nIngrese la nota del estudiante (0-100): ");

            if (nota < 0 || nota > 100)
            {
                Console.WriteLine("\nError: la nota debe estar entre 0 y 100.");
            }
            else if (nota >= NotaMinima)
            {
                Console.WriteLine($"\nCon {nota} el estudiante APROBÓ.");
            }
            else
            {
                Console.WriteLine($"\nCon {nota} el estudiante REPROBÓ.");
            }
        }
    }
}