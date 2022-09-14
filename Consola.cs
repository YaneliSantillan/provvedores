using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionElectronicaCompleta
{
    internal class Consola
    {
        public ConsoleColor colorTextoDeaulft;

        public Consola(ConsoleColor _colorTextoDeaulft)
        {
            this.colorTextoDeaulft = _colorTextoDeaulft;
        }

        public void Marco(int x, int y, int x2, int y2)
        {
            Escribir(x, y, ConsoleColor.DarkRed, "╔");
            Escribir(x2, y2, ConsoleColor.DarkRed, "╝");
            Escribir(x, y2, ConsoleColor.DarkRed, "╚");
            Escribir(x2, y, ConsoleColor.DarkRed, "╗");

            for (int i = x + 1; i < x2; i++)
            {
                Escribir(i, y, ConsoleColor.DarkYellow, "═");
                Escribir(i, y2, ConsoleColor.DarkYellow, "═");
            }

            for (int i = y + 1; i < y2; i++)
            {
                Escribir(x, i, ConsoleColor.DarkMagenta, "║");
                Escribir(x2, i, ConsoleColor.DarkMagenta, "║");
            }

        }
        public void Escribir(int left, int top, ConsoleColor color, String Texto)
        {
            Console.SetCursorPosition(left, top);
            Console.ForegroundColor = color;
            Console.Write(Texto);
            Console.ForegroundColor = colorTextoDeaulft;
        }

        public String leerCadena(int left, int top, int longitud = 0)
        {
            String valor = "";
            do
            {
                Console.SetCursorPosition(left, top); Console.Write("                    ");
                Console.SetCursorPosition(left, top);
                valor = Console.ReadLine();

                if (longitud > 0)
                {
                    if (valor.Length != longitud) valor = "";
                }

            } while (valor == "");

            return valor;
        }

        public int leerNumeroEntero(int left, int top)
        {
            int valor;
            do
            {
                Console.SetCursorPosition(left, top); Console.Write("                    ");
                Console.SetCursorPosition(left, top);
            } while (!int.TryParse(Console.ReadLine(), out valor));

            return valor;
        }

        public double leerNumeroDecimal(int left, int top)
        {
            double valor;
            do
            {
                Console.SetCursorPosition(left, top); Console.Write("                    ");
                Console.SetCursorPosition(left, top);
            } while (!double.TryParse(Console.ReadLine(), out valor));

            return valor;
        }

        public void MenuPrincipal()
        {

            Escribir(35, 1, ConsoleColor.Yellow, "MENÚ DE OPCIONES");
            Escribir(36, 2, ConsoleColor.DarkGreen, "!!BIENVENIDO!!");
            Escribir(32, 4, ConsoleColor.DarkMagenta, "1.- ");
            Escribir(35, 4, ConsoleColor.White, "PRODUCTOS");
            Escribir(32, 5, ConsoleColor.DarkMagenta, "2.- ");
            Escribir(35, 5, ConsoleColor.White, "CLIENTES");
            Escribir(32, 6, ConsoleColor.DarkMagenta, "3.- ");
            Escribir(35, 6, ConsoleColor.White, "PROVEEDORES");
            Escribir(32, 7, ConsoleColor.DarkMagenta, "4.- ");
            Escribir(35, 7, ConsoleColor.White, "EMPLEADOS");
            Escribir(32, 8, ConsoleColor.DarkMagenta, "5.- ");
            Escribir(35, 8, ConsoleColor.White, "FACTURAR");
            Escribir(32, 9, ConsoleColor.DarkMagenta, "6.- ");
            Escribir(35, 9, ConsoleColor.White, "SALIR..");
            Marco(25, 3, 65, 11);

        }

        public void MenuItems(String ItemDescripcion)
        {

            Escribir(35, 1, ConsoleColor.Yellow, "MENÚ DE OPCIONES DE " + ItemDescripcion);
            Escribir(32, 4, ConsoleColor.Yellow, "1.- ");
            Escribir(35, 4, ConsoleColor.White, "AGREGAR " + ItemDescripcion);
            Escribir(32, 5, ConsoleColor.Yellow, "2.- ");
            Escribir(35, 5, ConsoleColor.White, "VER " + ItemDescripcion);
            Escribir(32, 6, ConsoleColor.Yellow, "3.- ");
            Escribir(35, 6, ConsoleColor.White, "ACTUALIZAR " + ItemDescripcion);
            Escribir(32, 7, ConsoleColor.Yellow, "4.- ");
            Escribir(35, 7, ConsoleColor.White, "MOSTRAR ITEMS.." + ItemDescripcion);
            Escribir(32, 8, ConsoleColor.Yellow, "5.- ");
            Escribir(35, 8, ConsoleColor.White, "ELIMINAR " + ItemDescripcion);
            Escribir(32, 9, ConsoleColor.Yellow, "6.- ");
            Escribir(35, 9, ConsoleColor.White, "REGRESAR AL MENÚ PRINCIPAL..");
            Marco(25, 3, 65, 11);

        }


        public void MenuFacturación()
        {

            Escribir(35, 1, ConsoleColor.Yellow, "MENÚ DE OPCIONES DE FACTURACIÓN ");
            Escribir(32, 4, ConsoleColor.Yellow, "1.- ");
            Escribir(35, 4, ConsoleColor.White, "CREAR FACTURA ");
            Escribir(32, 5, ConsoleColor.Yellow, "2.- ");
            Escribir(35, 5, ConsoleColor.White, "BUSCAR FACTURA ");
            Escribir(32, 6, ConsoleColor.Yellow, "3.- ");
            Escribir(35, 6, ConsoleColor.White, "MOSTRAR FACTURAS..");
            Escribir(32, 7, ConsoleColor.Yellow, "4.- ");
            Escribir(35, 7, ConsoleColor.White, "ELIMINAR FACTURA ");
            Escribir(32, 8, ConsoleColor.Yellow, "5.- ");
            Escribir(35, 8, ConsoleColor.White, "REGRESAR AL MENÚ PRINCIPAL..");
            Marco(25, 3, 65, 11);

        }
        public void PintarFondo(ConsoleColor color)
        {
            Console.BackgroundColor = color;
            for (int i = 0; i <= 50; i++)
                for (int j = 0; j <= 15; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");
                }


        }


        public int leerOpcion()

        {
            int opcion = 0;
            do
            {
                Escribir(25, 12, ConsoleColor.DarkCyan, "Ingrese una opción: ");
                opcion = leerNumeroEntero(45, 12);
            } while (opcion <= 0 || opcion > 6);

            return opcion;
        }
    }
}
