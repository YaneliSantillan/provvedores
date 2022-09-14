using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace FacturacionElectronicaCompleta
{
    internal class Proveedores : Item
    {
        
        public String Ruc;
        public String RazonSocial;
        public String Direccion;
        public String Ciudad;
        public String Telefono;

        public Proveedores(Consola _consola, BaseDatos _objBD) : base(_consola, _objBD, "000", "Proveedores", "cedula")
        {
        }

        public Proveedores(Consola _consola, BaseDatos _objBD, String _Codigo,
            String Ruc, String RazonSocial, String Direccion, String Ciudad, String Telefono)
            : base(_consola, _objBD, _Codigo, "Proveedor", "cedula")
        {
            this.Ruc = Ruc;
            this.RazonSocial = RazonSocial;
            this.Direccion = Direccion;
            this.Ciudad = Ciudad;
            this.Telefono = Telefono;
        }
        public override Item creatItem(Consola _consola, BaseDatos _objBD)
        {
            return new Proveedores(_consola, _objBD);
        }
        public override Item creatItem(Consola _consola, BaseDatos _objBD, DataRow _registro)
        {
            return new Proveedores(_consola, _objBD, _registro["Cedula"].ToString(),
                (_registro["RUC"].ToString()), _registro["RazonSocial"].ToString(), _registro["Direccion"].ToString(),
                _registro["Ciudad"].ToString(), (_registro["Telefono"].ToString()));
        }
        public override void mostrarMembreteTabla()
        {
            consola.Escribir(40, 2, ConsoleColor.Yellow, "LISTA DE PROVEEDORES");
            consola.Escribir(5, 5, ConsoleColor.Blue, "N°"); consola.Escribir(10, 5, ConsoleColor.Blue, "Cédula");
            consola.Escribir(30, 5, ConsoleColor.Blue, "RUC");consola.Escribir(60, 5, ConsoleColor.Blue, "Razon Social");
            consola.Escribir(70, 5, ConsoleColor.Blue, "Direccion"); consola.Escribir(80, 5, ConsoleColor.Blue, "Ciudad");
            consola.Escribir(120, 5, ConsoleColor.Blue, "Telefono");
            consola.Marco(3, 4, 95, 15);
        }
        public override void mostrarInfoComoFila(int Num, int fila)
        {
            consola.Escribir(5, fila, ConsoleColor.White, Num.ToString());
            consola.Escribir(10, fila, ConsoleColor.White, Ruc);
            consola.Escribir(25, fila, ConsoleColor.White, RazonSocial);
            consola.Escribir(55, fila, ConsoleColor.White, Direccion);
            consola.Escribir(70, fila, ConsoleColor.White, Ciudad);
            consola.Escribir(80, fila, ConsoleColor.White, Telefono.ToString());
        }
        public override void mostrarInfo()
        {

            consola.Escribir(30, 2, ConsoleColor.Red, "INFORMACIÓN DEL EMPLEADO");
            consola.Marco(10, 3, 65, 11);
            consola.Escribir(20, 5, ConsoleColor.Yellow, "Cédula: "); consola.Escribir(35, 5, ConsoleColor.White, Codigo);
            consola.Escribir(20, 6, ConsoleColor.Yellow, "RUC: "); consola.Escribir(35, 6, ConsoleColor.White, Ruc.ToString());
            consola.Escribir(20, 7, ConsoleColor.Yellow, "Razon Social: "); consola.Escribir(35, 7, ConsoleColor.White, RazonSocial);
            consola.Escribir(20, 8, ConsoleColor.Yellow, "Direccion: "); consola.Escribir(35, 8, ConsoleColor.White, Direccion);
            consola.Escribir(20, 9, ConsoleColor.Yellow, "Ciudad: "); consola.Escribir(35, 8, ConsoleColor.White, Ciudad);
            consola.Escribir(20, 10, ConsoleColor.Yellow, "Telefono: "); consola.Escribir(35, 8, ConsoleColor.White, Telefono.ToString());
        }

        public override void leerInfo()
        {

            consola.Escribir(30, 2, ConsoleColor.Red, "NUEVO PROVEEDOR");
            consola.Marco(10, 3, 65, 11);
            consola.Escribir(20, 5, ConsoleColor.Yellow, "Cédula: ");
            consola.Escribir(20, 6, ConsoleColor.Yellow, "RUC: ");
            consola.Escribir(20, 7, ConsoleColor.Yellow, "Razon Social: ");
            consola.Escribir(20, 8, ConsoleColor.Yellow, "Direccion: ");
            consola.Escribir(20, 9, ConsoleColor.Yellow, "Ciudad: ");
            consola.Escribir(20, 10, ConsoleColor.Yellow, "Telefono: ");
            Codigo = consola.leerCadena(35, 5);
            Ruc =consola.leerCadena(35, 6);
            RazonSocial = consola.leerCadena(35, 7);
            Direccion = consola.leerCadena(35, 8);
            Ciudad = consola.leerCadena(35, 9);
            Telefono = consola.leerCadena(35, 10);

        }



        public override String getSQL(String TipoSQL, String CodigoABuscar = "")
        {
            String SQL = "";
            switch (TipoSQL)
            {
                case "Insert":
                    SQL = "Insert into TbProveedores (Ruc, RazonSocial,Direccion,Ciudad,Telefono) values('"
                       + Ruc + "','" + RazonSocial + "','" + Direccion + "','" + Ciudad + "','" + Telefono + "');";
                    break;
                case "Delete":
                    SQL = "Delete from TbProveedores where Ruc='" + CodigoABuscar + "'";
                    break;
                case "Select":
                    if (CodigoABuscar != "")
                    {
                        SQL = "Select * from TbProveedores where Ruc='" + CodigoABuscar + "'";
                    }
                    else
                    {
                        SQL = "Select * from TbProveedores order by Ruc";
                    }
                    break;
            }

            return SQL;
        }
    }
}
