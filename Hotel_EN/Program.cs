using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_EN

    {
        class Program
        {
            static void Main(string[] args)
            {
                //Programa for a hotel (10 available rooms)
                // Menu: 1) register guests 2) free rooms 3) check availability 4) income (w/password) 5)settings  6) exit
                //1) register guest: a. Name b. ID c. nights d. price
                //2) Free rooms. Show the guest's information.
                //3) Show availability
                //4) Password. Show total income and income per room
                //5) Change password and modify prices
                //6) Exit

                int[] disponibilidad = new int[10];
                int[] recaudacion = new int[10];
                int[] estadia = new int[10];
                int[] dni = new int[10];
                string[] huesped = new string[10];
                string nombre = "";
                int con = 0, acu = 0;
                string msj = "";
                int dias = 0, precio = 0, valorhab = 1000, num = 0;
                int completo = 0;
                int opcion = 0;
                Password contr = new Password();
                int contraseña = 1234, validacion = 0, intentos = 0;
                Boolean acceso = false;

                Console.WriteLine("HOTEL ALTOS DE SÍQUIMAN. WELCOME");
                while (opcion != 6)
                {
                    Console.WriteLine("~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~*~");
                    Console.WriteLine("");
                    Console.WriteLine("Elija la acción que desea realizar");
                    Console.WriteLine("1--> Registrar huésped");
                    Console.WriteLine("2--> Liberar habitación");
                    Console.WriteLine("3--> Ver disponibilidad");
                    Console.WriteLine("4--> Ver recaudación");
                    Console.WriteLine("5--> Configuración");
                    Console.WriteLine("6--> Salir");
                    Console.WriteLine("\n");
                    opcion = Convert.ToInt32(Console.ReadLine());
                    switch (opcion)
                    {
                        case 1:

                            Console.WriteLine("Elija la habitación que desea ocupar");
                            con = Convert.ToInt32(Console.ReadLine());

                            if (disponibilidad[con] == 0)
                            {
                                Console.Clear();
                                Console.WriteLine("Ingrese el nombre del huésped");
                                nombre = Console.ReadLine();
                                huesped[con] = nombre;

                                Console.WriteLine("Ingrese el DNI del huésped");
                                num = Convert.ToInt32(Console.ReadLine());
                                dni[con] = num;

                                Console.WriteLine("Ingrese la cantidad de noches de su estadía");
                                dias = Convert.ToInt32(Console.ReadLine());
                                estadia[con] = dias;

                                precio = dias * valorhab;
                                Console.WriteLine("Monto a cobrar: $" + precio.ToString());
                                recaudacion[con] = recaudacion[con] + precio;
                                acu = acu + precio;

                                disponibilidad[con] = 1;
                                completo += 1;

                                Console.WriteLine("Presione Enter para volver al menú principal");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("La habitación " + con + " ya está ocupada");
                                Console.WriteLine("\n");
                            }

                            break;

                        case 2:
                            Console.WriteLine("Elija la habitación que desea liberar");
                            con = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("\n");
                            if (disponibilidad[con] == 1)
                            {
                                Console.WriteLine("Nombre del huésped: " + huesped[con]);
                                Console.WriteLine("DNI del huésped: " + dni[con].ToString());
                                Console.WriteLine("Estadía: " + estadia[con].ToString() + " noches");
                                Console.WriteLine("¿Confirma que desea liberar esta habitación?");
                                Console.WriteLine("1--> SÍ");
                                Console.WriteLine("2--> NO");
                                opcion = Convert.ToInt32(Console.ReadLine());

                                if (opcion == 1)
                                {
                                    disponibilidad[con] = 0;
                                    completo = completo - 1;
                                }
                                if (opcion == 2)
                                {
                                    Console.WriteLine("Presione Enter para volver al menú principal");
                                    Console.ReadLine();
                                }
                            }
                            break;

                        case 3:
                            Console.WriteLine("Disponibilidad");
                            for (con = 0; con < 10; con++)
                            {
                                if (disponibilidad[con] == 0)
                                {
                                    msj = "Habitación " + con.ToString() + " DISPONIBLE";
                                    Console.WriteLine(msj);
                                }
                            }
                            if (completo == 10)
                            {
                                Console.WriteLine("HOTEL LLENO");
                                Console.WriteLine("\n");
                                Console.WriteLine("Presione Enter para volver al menú principal");
                                Console.ReadLine();
                            }

                            break;

                        case 4:
                            acceso = contr.Ingreso(acceso, contraseña, num, intentos);
                            if (acceso == true)
                            {
                                for (con = 0; con < 10; con++)
                                {
                                    Console.WriteLine("Recaudación habitación " + con.ToString() + ": $" + recaudacion[con].ToString());
                                }
                                Console.WriteLine("Recaudación total: $" + acu.ToString());
                            }
                            break;

                        case 5:
                            Console.WriteLine("CONFIGURACIÓN");
                            Console.WriteLine("1--> Cambiar contraseña de administrador");
                            Console.WriteLine("2--> Modificar precio");
                            opcion = Convert.ToInt32(Console.ReadLine());

                            if (opcion == 1)
                            {
                                contraseña = contr.CambioContraseña(intentos, contraseña, num, validacion);
                            }

                            if (opcion == 2)
                            {
                                acceso = contr.Ingreso(acceso, contraseña, num, intentos);
                                if (acceso == true)
                                {
                                    Console.WriteLine("El precio actual por noche es de $" + valorhab.ToString());
                                    Console.WriteLine("Ingrese el nuevo precio");
                                    valorhab = Convert.ToInt32(Console.ReadLine());
                                }
                            }
                            break;

                        case 6:
                            Console.WriteLine("¡Hasta luego!");
                            Console.ReadLine();
                            break;
                    }
                }
            }

        }
    }

    